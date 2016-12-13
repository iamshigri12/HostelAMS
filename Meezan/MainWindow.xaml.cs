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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data;
using Meezan.HelperClasses;
namespace Meezan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
   
    public partial class MainWindow : Window
    {
        bool _isValidated = false;
        bool _isactive = true;
        DBHelper DatabaseHelper = new DBHelper();
        
        public MainWindow()
        {      
            InitializeComponent();
            DatabaseHelper.Datatable = new DataTable();           
            DatabaseHelper.ConnectDB();
        }

        private void btnCancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            validateData();
            if(_isValidated){
                winMainWindow mainwin = new winMainWindow(txtname.Text);
                mainwin.Show();
                this.Close();
            }
            else if (!_isactive) {
                MessageBox.Show("This is not active user", "Login Fail", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtname.Text = string.Empty;
                txtpwd.Password = string.Empty;
            }else if(txtname.Text!=string.Empty && txtpwd.Password!=string.Empty)
                MessageBox.Show("Incorrect Name or Password", "Login Fail", MessageBoxButton.OK, MessageBoxImage.Warning);
            
        }

        public bool validateData() {
            _isValidated = false;
            DatabaseHelper.Datatable.Clear();
            if (this.txtname.Text == string.Empty) {
                MessageBox.Show("User Name Can not be empty","Login Fail",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
           else if (this.txtpwd.Password == string.Empty)
            {
                MessageBox.Show("Password Can not be Empty", "Login Fail", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (this.txtpwd.Password != string.Empty)
            {
              DatabaseHelper.Query = new SqlCommand("SELECT * FROM SYS_USER " + "WHERE" + " user_name = " + "'" + txtname.Text + "'" + " AND " + "user_pwd = " + "'" + txtpwd.Password + "'", DatabaseHelper.DB);
                DatabaseHelper.DataAdapter = new SqlDataAdapter(DatabaseHelper.Query);
                DatabaseHelper.DataAdapter.Fill(DatabaseHelper.Datatable);
                if (DatabaseHelper.Datatable.Rows.Count > 0)
                {
                    if (DatabaseHelper.Datatable.Rows[0].ItemArray[3].ToString().Equals("1"))
                    {
                        _isValidated = true;
                    }
                    else
                    {
                        _isactive = false;
                        _isValidated = false;
                    }

                }
            }

        return _isValidated;
        }


    }
}
