using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace Meezan.Windows
{
    /// <summary>
    /// Interaction logic for winNewUser.xaml
    /// </summary>
    public partial class winNewUser : Window
    {
      
        SqlConnection DB = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Quera;
        SqlDataAdapter da;
        DataTable Dt;
         public winNewUser()
        {
            InitializeComponent();
        }
         public winNewUser(string user_name)
        {
            InitializeComponent();
            SearchUser(user_name);
            btnSave.Visibility = Visibility.Collapsed;
            btnDelete.Visibility = Visibility.Visible;
            btnReset.Visibility = Visibility.Collapsed;
        }

        private void btnCancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            if (validateData()) {
                if (SaveData()) {

                    MessageBox.Show("Saved Successfully");
                    this.Close();

                }

            }
        }

        private bool validateData() {


            if (this.txtUserName.IsEnabled == true)
            {
                if (this.txtUserName.Text == string.Empty)
                {
                    MessageBox.Show("User Name Can not be Empty");
                    return false;
                }
                else if (this.txtPwd.Password == string.Empty)
                {
                    MessageBox.Show("Password Can not be Empty");
                    return false;
                }
                else if (this.txtPwd.Password.Length < 6)
                {
                    MessageBox.Show("Password Length Must be greater than 6");
                    return false;
                }
                else if (isDublicate())
                {
                    MessageBox.Show("User Name Already Exists");
                    return false;
                }
                else
                    return true;
            }
            else
                return true;
        
        }


        private bool isDublicate(){
            try { DB.Open(); }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
                finally{
               
            Quera = new SqlCommand( "SELECT * FROM SYS_USER WHERE user_name= '"+txtUserName.Text +"'" ,DB);
            da = new SqlDataAdapter(Quera);
            Dt = new DataTable();
             da.Fill(Dt);
             DB.Close();
            }
            if (Dt.Rows.Count > 0)
                return true;
            else
                return false;
        }


        private bool SaveData() {
            try { DB.Open(); }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
            finally
            {
                if (txtUserName.IsEnabled == true)
                {
                    int activeind = chactive.IsChecked == true ? 1 : 0;
                    Quera = new SqlCommand("INSERT INTO SYS_USER( user_name,user_pwd,active_ind) VALUES('" + txtUserName.Text + "','" + txtPwd.Password + "'," + activeind + ")", DB);
                    Quera.ExecuteNonQuery();
                    DB.Close();
                }
                else
                {
                    Quera = new SqlCommand("DELETE FROM SYS_USER WHERE user_name= '"+ txtUserName.Text+"'", DB);
                    Quera.ExecuteNonQuery();
                    DB.Close();
                
                
                }
            }


            return true;
        }


        private void SearchUser(string name) {
          //  Dt.Clear();
            try { DB.Open(); }
            catch (SqlException ex) { MessageBox.Show(ex.Message); }
            finally
            {

                Quera = new SqlCommand("SELECT * FROM SYS_USER WHERE user_name= '" + name + "'", DB);
                da = new SqlDataAdapter(Quera);
                Dt = new DataTable();
                da.Fill(Dt);
                if (Dt.Rows.Count > 0)
                {
                    txtUserName.Text = Dt.Rows[0].ItemArray[1].ToString();
                    txtUserName.IsEnabled = false;
                    txtPwd.Password = Dt.Rows[0].ItemArray[2].ToString();
                    txtPwd.IsEnabled = false;
                   

                }
                else
                    MessageBox.Show("User Not Exist");



                DB.Close();
            }

        
        
        }

        private void btnDelete_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Do You Want To delete Your Account ?", "Confirmation ", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                if (validateData())
                {
                    if (SaveData())
                    {

                        MessageBox.Show("Deleted Successfully");
                        this.Close();

                    }

                }
            }
        }

        private void btnReset_Click_1(object sender, RoutedEventArgs e)
        {
            txtPwd.Password = null;
            txtUserName.Text = null;
            chactive.IsChecked = false;
        }


    }
}
