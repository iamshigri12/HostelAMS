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
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
namespace Meezan.Windows
{
    /// <summary>
    /// Interaction logic for winPasswordChange.xaml
    /// </summary>
    public partial class winPasswordChange : Window
    {
      
        string username;
        SqlConnection DB = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand query;
        SqlDataAdapter Da;
        DataTable dt;
        public winPasswordChange()
        {
            InitializeComponent();
        }

        public winPasswordChange(String username)
        {
            InitializeComponent();
            this.username = username;
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            try {
                DB.Open();
                query = new SqlCommand("SELECT user_pwd FROM SYS_USER WHERE user_name='"+this.username+"'",DB);
               Da= new SqlDataAdapter(query);
                dt=new DataTable();
                Da.Fill(dt);
                if (txtOldpwd.Password == txtnewpwd.Password && txtOldpwd.Password!=string.Empty) {
                    MessageBox.Show("New password must be different ","Password Error",MessageBoxButton.OK,MessageBoxImage.Error);
                    txtOldpwd.Password = string.Empty;
                    txtnewpwd.Password = string.Empty;
                    txtcnfmpwd.Password = string.Empty;
                }
                else if (txtOldpwd.Password == string.Empty || txtnewpwd.Password == string.Empty) {
                    MessageBox.Show("Password Can't be empty","Empty Password",MessageBoxButton.OK,MessageBoxImage.Exclamation);
                
                }

                else if (txtOldpwd.Password != dt.Rows[0].ItemArray[0].ToString())
                {
                    MessageBox.Show("Wrong Password","Password Error",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                else if (txtOldpwd.Password == dt.Rows[0].ItemArray[0].ToString() && txtnewpwd.Password == txtcnfmpwd.Password)
                {
                    if (txtnewpwd.Password.Length < 6)
                    {

                        MessageBox.Show("Password length must be at least 6 characters","Password Error",MessageBoxButton.OK,MessageBoxImage.Information);
                        txtOldpwd.Password = string.Empty;
                        txtnewpwd.Password = string.Empty;
                        txtcnfmpwd.Password = string.Empty;

                    }
                    else
                    {
                        query.CommandText = "UPDATE SYS_USER SET user_pwd='" + txtnewpwd.Password + "' WHERE user_name='" + this.username + "'";
                        query.ExecuteNonQuery();
                        MessageBox.Show("Password Changed Successfully","Password Changed",MessageBoxButton.OK,MessageBoxImage.Information);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Password could not be confirmed","Password error",MessageBoxButton.OK,MessageBoxImage.Error);

                }
                

            }
            catch (SqlException ex) {
                MessageBox.Show(ex.Message);
            }

            finally {
                DB.Close();
            
            }



        }

        private void btnReset_Click_1(object sender, RoutedEventArgs e)
        {
            txtcnfmpwd.Password = null;
            txtnewpwd.Password = null;
            txtOldpwd.Password = null;
        }




    }
}
