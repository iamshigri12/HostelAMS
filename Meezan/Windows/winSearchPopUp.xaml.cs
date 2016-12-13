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
using System.Collections.Generic;
using System.Data.SqlClient;
using Meezan.HelperClasses;
namespace Meezan.Windows
{
    /// <summary>
    /// Interaction logic for winSearchPopUp.xaml
    /// </summary>
    public partial class winSearchPopUp : Window
    {
        SqlConnection DB;
        SqlCommand Query;
        SqlDataAdapter DA;
        DataTable DT;
        List<searchedStudentInfo> searchedinfo;
        public winSearchPopUp()
        {
            InitializeComponent();
            DB = new SqlConnection(Properties.Settings.Default.ConnectionString);
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource searchedStudentInfoViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("searchedStudentInfoViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // searchedStudentInfoViewSource.Source = [generic data source]
        }

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            searchStudent(txtSearchbox.Text);
        }

        private void searchStudent(string name)
        {
            try
            {
                DB.Open();
                Query = new SqlCommand("SELECT first_nme +' ' + second_nme + ' ' + last_nme as fullName,father_nme ,admission_no , domicile  FROM STUDENT WHERE first_nme + second_nme + last_nme LIKE '%" + name + "%'", DB);
                DA = new SqlDataAdapter(Query);
                DT = new DataTable();
                DA.Fill(DT);
                if (DT != null) {
                    searchedinfo = new List<searchedStudentInfo>();
                    for (int i = 0; i < DT.Rows.Count; i++) {
                        int j = 0;
                        searchedinfo.Add(new searchedStudentInfo() { name = DT.Rows[i].ItemArray[j++].ToString(), fatherName = DT.Rows[i].ItemArray[j++].ToString(), admissionNo = DT.Rows[i].ItemArray[j++].ToString(), domicle = DT.Rows[i].ItemArray[j++].ToString() });
                        
                    
                    }
                        
                    searchedStudentInfoDataGrid.ItemsSource = searchedinfo;
                
                }


            }
            catch (SqlException ex) {
                MessageBox.Show("Data base Connection Fail : {0}",ex.Message);
            }
            finally {
                DB.Close();
            }
        }

        private void searchedStudentInfoDataGrid_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            searchedStudentInfo SelectedRow = searchedStudentInfoDataGrid.SelectedItem as searchedStudentInfo;

            winNewStudent SearchedStudent = new winNewStudent(SelectedRow.name, SelectedRow.admissionNo);
            SearchedStudent.Show();
        }




    }
}
