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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Meezan.Windows;
using Meezan.HelperClasses;
namespace Meezan
{
    /// <summary>
    /// Interaction logic for winMainWindow.xaml
    /// </summary>
    public partial class winMainWindow : Window
    {

        string user_name;
        DBHelper DatabaseHelper = new DBHelper();

        public winMainWindow()
        {
            InitializeComponent();
            
        }
        public winMainWindow(string name)
        {
            InitializeComponent();
            UserMenu.Header = name;
            this.user_name = name;
            setBackground();
        }

        private void Logout_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow LoginWindow = new MainWindow();
            LoginWindow.Show();
            this.Close();
        }

        private void AddNewUser_Click_1(object sender, RoutedEventArgs e)
        {
            winNewUser NewUser = new winNewUser();
            NewUser.Show();
        }

        private void ChangePassword_Click_1(object sender, RoutedEventArgs e)
        {

            winPasswordChange PasswordChangeWindow = new winPasswordChange(this.user_name);
            PasswordChangeWindow.Show();
            
        }

        private void Exit_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bgAquaBlue_Click_1(object sender, RoutedEventArgs e)
        {
            pnlMain.Background = new ImageBrush(new BitmapImage( new Uri(@"Images\Aqua Blue.png",UriKind.Relative)));
            setBackground("00001");
        }

        private void bgShigarthang_Click_1(object sender, RoutedEventArgs e)
        {
            pnlMain.Background = new ImageBrush(new BitmapImage(new Uri(@"Images\ShigarRoad.png", UriKind.Relative)));

            setBackground("00003");
        }

        private void bgkhupulufort_Click_1(object sender, RoutedEventArgs e)
        {
            pnlMain.Background = new ImageBrush(new BitmapImage(new Uri(@"Images\Khapulufort.png", UriKind.Relative)));
            setBackground("00005");
        }

        private void delta_Click_1(object sender, RoutedEventArgs e)
        {
            pnlMain.Background = new ImageBrush(new BitmapImage(new Uri(@"Images\delta.png", UriKind.Relative)));
            setBackground("00004");
             
        }

        private void bgblack_Click_1(object sender, RoutedEventArgs e)
        {
            pnlMain.Background = Brushes.DarkGreen;
            setBackground("00002");
        }

      
        

        private void setBackground() {
            try
            {
                DatabaseHelper.ConnectDB();
                DatabaseHelper.Query = new SqlCommand("SELECT background_cde FROM BACKGROUND_CODE WHERE active_ind=1", DatabaseHelper.DB);
                DatabaseHelper.DataAdapter = new SqlDataAdapter(DatabaseHelper.Query);
                DatabaseHelper.Datatable = new DataTable();
                DatabaseHelper.DataAdapter.Fill(DatabaseHelper.Datatable);
                if (DatabaseHelper.Datatable.Rows[0].ItemArray[0].ToString().Equals("00001"))
                {

                    pnlMain.Background = new ImageBrush(new BitmapImage(new Uri(@"Images\Aqua Blue.png", UriKind.Relative)));

                }
                else if (DatabaseHelper.Datatable.Rows[0].ItemArray[0].ToString().Equals("00002"))
                {
                    pnlMain.Background = Brushes.DarkGreen;
                }
                else if (DatabaseHelper.Datatable.Rows[0].ItemArray[0].ToString().Equals("00003"))
                {
                    pnlMain.Background = new ImageBrush(new BitmapImage(new Uri(@"Images\ShigarRoad.png", UriKind.Relative)));
                }
                else if (DatabaseHelper.Datatable.Rows[0].ItemArray[0].ToString().Equals("00004"))
                {
                    pnlMain.Background = new ImageBrush(new BitmapImage(new Uri(@"Images\delta.png", UriKind.Relative)));
                }
                else if (DatabaseHelper.Datatable.Rows[0].ItemArray[0].ToString().Equals("00005"))
                {
                    pnlMain.Background = new ImageBrush(new BitmapImage(new Uri(@"Images\Khapulufort.png", UriKind.Relative)));
                }



            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.Message);
            }
            finally {
                DatabaseHelper.CloseDB();
            }
        
        
        }


        private void setBackground(string bgcode) {

            try
            {
                DatabaseHelper.ConnectDB();
                DatabaseHelper.Query = new SqlCommand("UPDATE BACKGROUND_CODE SET active_ind=0 ", DatabaseHelper.DB);
                DatabaseHelper.Query.ExecuteNonQuery();
                DatabaseHelper.Query = new SqlCommand("UPDATE BACKGROUND_CODE SET active_ind=1 WHERE background_cde='" + bgcode + "'", DatabaseHelper.DB);
                DatabaseHelper.Query.ExecuteNonQuery();


            }
            catch (SqlException EX) { MessageBox.Show(EX.Message); }
            finally
            {
                DatabaseHelper.CloseDB();
            }
        
        }



        private void mnuReceipt_Click_1(object sender, RoutedEventArgs e)
        {
            winReciept NewReciept = new winReciept(this.user_name);
            NewReciept.Show();
        }

        private void mnuMedical_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void rprt_messExpense_Click_1(object sender, RoutedEventArgs e)
        {
            winMedicalExpense expenseReport = new winMedicalExpense();
            expenseReport.Show();
        }

        private void DeleteUser_Click_1(object sender, RoutedEventArgs e)
        {

            winNewUser UserToDelete = new winNewUser(this.user_name);
            UserToDelete.Show();

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            winNewStudent newStudent = new winNewStudent();
            newStudent.Show();
        }
    }
}
