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
    /// Interaction logic for winNewStudent.xaml
    /// </summary>
    public partial class winNewStudent : Window
    {
        SqlConnection DB = new SqlConnection(Properties.Settings.Default.ConnectionString);
        SqlCommand Query;
        DataTable DT;
        SqlDataAdapter DA;



        public winNewStudent()
        {
            InitializeComponent();


            initializeData();
        
        }

        public winNewStudent(string name , string AdmissionNo)
        {
            InitializeComponent();
            initializeData();
            FillDataOfSearchedStudent(name, AdmissionNo);


        }

        private void initializeData()
        {
            cmbDomicile.Items.Add("Khaplu");
            cmbDomicile.Items.Add("Kharmang");
            cmbDomicile.Items.Add("Mashabrum");
            cmbDomicile.Items.Add("Roundu");
            cmbDomicile.Items.Add("Shigar");
            cmbDomicile.Items.Add("Skardu");

            cmbClass.Items.Add("1st Year");
            cmbClass.Items.Add("2nd Year");

            cmbFeild.Items.Add("Pre-Engineering");
            cmbFeild.Items.Add("Pre-Medical");

            dpJoiningDate.SelectedDate = System.DateTime.Now;
        }

        private void btnReset_Click_1(object sender, RoutedEventArgs e)
        {
            resetData();
        }

        private void resetData()
        {
            txtFirstName.Text = string.Empty;

            txtSecondName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtFatherName.Text = string.Empty;
            txtaddress.Text= string.Empty;
            txtAdmissionNo.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            txtSchool.Text = string.Empty;
            txtsscpercentage.Text = string.Empty;
            txttestMarks.Text = string.Empty;
            txtEmailAddress.Text = string.Empty;
            
        }

        private void btncancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            if (validateData()) {

                try
                {
                    DB.Open();
                    Query = new SqlCommand("INSERT INTO STUDENT ([first_nme],[second_nme],[last_nme],[father_nme],[domicile],[joining_dte],[admission_no],[class],[school],[sscpercent],[admissionTestMarks],[contact_no],[mailing_address],[email_address],[field]) VALUES ('"+txtFirstName.Text +"','"+txtSecondName.Text+"','"+txtLastName.Text+"','"+txtFatherName.Text+"','"+cmbDomicile.SelectedItem.ToString()+"','"+dpJoiningDate.SelectedDate.ToString()+"','"+txtAdmissionNo.Text+"','"+cmbClass.SelectedItem.ToString()+"','"+txtSchool.Text+"','"+txtsscpercentage.Text+"','"+txttestMarks.Text+"','"+txtContactNo.Text+"','"+txtaddress.Text+"','"+txtEmailAddress.Text+"','"+cmbFeild.SelectedItem.ToString()+"')", DB);
                    Query.ExecuteNonQuery();


                }
                catch (SqlException ex)
                {

                    MessageBox.Show("Error Has Occurred:" + ex.Message);
                }
                finally {

                    DB.Close();
                    resetData();
                    MessageBox.Show("Saved Successfully ", "Saved", MessageBoxButton.OK, MessageBoxImage.Information);
                }
               
            }
        }

        private bool validateData()
        {

            if (txtFirstName.Text == string.Empty) {
                txtFirstName.BorderBrush = Brushes.Red;
               
                MessageBox.Show("Please Enter Name", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
            else if (cmbDomicile.SelectedItem == null) {
                MessageBox.Show("Please select Domicile", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                cmbDomicile.BorderBrush = Brushes.Red;
                return false;
            }
            else if (txtAdmissionNo.Text == string.Empty) {
                txtAdmissionNo.BorderBrush = Brushes.Red;

                MessageBox.Show("Please Enter Admission Number", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (System.Text.RegularExpressions.Regex.IsMatch(txtsscpercentage.Text, "[^0-9]") && !System.Text.RegularExpressions.Regex.IsMatch(txtsscpercentage.Text, "[.]"))
            {    
                        txtsscpercentage.BorderBrush = Brushes.Red;
                
                    MessageBox.Show("Invalid SSC % ", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;

            }
            else if (txtsscpercentage.Text!=string.Empty && Convert.ToDouble(txtsscpercentage.Text) > 100) {

                txtsscpercentage.BorderBrush = Brushes.Red;

                MessageBox.Show(" SSC % value is Invalid ", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            
            }
            else if ((System.Text.RegularExpressions.Regex.IsMatch(txttestMarks.Text, "[^0-9]")))
            {
                txttestMarks.BorderBrush = Brushes.Red;
                MessageBox.Show("Invalid Test Marks ", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;

            }
            else if (txtContactNo.Text == string.Empty)
            {
                txtContactNo.BorderBrush = Brushes.Red;

                MessageBox.Show("Please Enter Contact Number", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            } if (txtaddress.Text == string.Empty)
            {
                 txtaddress.BorderBrush=Brushes.Red;
                MessageBox.Show("Please Enter Address ", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            
            }
            return true;
            
        }

        private void FillDataOfSearchedStudent(string name , string admissionNo){
            try
            {
                DB.Open();
                Query = new SqlCommand("SELECT * FROM STUDENT WHERE first_nme +' '+ second_nme +' '+ last_nme LIKE '%" + name + "%' AND admission_no = '" + admissionNo + "'", DB);
                DA = new SqlDataAdapter(Query);
                DT = new DataTable();
                DA.Fill(DT);
                if (DT != null) {
                    txtFirstName.Text = DT.Rows[0].ItemArray[0].ToString();
                    txtSecondName.Text = DT.Rows[0].ItemArray[1].ToString(); 
                    txtLastName.Text = DT.Rows[0].ItemArray[2].ToString();
                    txtFatherName.Text = DT.Rows[0].ItemArray[3].ToString();
                    cmbDomicile.SelectedItem = DT.Rows[0].ItemArray[4].ToString();
                    dpJoiningDate.SelectedDate = Convert.ToDateTime(DT.Rows[0].ItemArray[5].ToString()); 
                    txtAdmissionNo.Text = DT.Rows[0].ItemArray[6].ToString();
                    cmbClass.SelectedItem = DT.Rows[0].ItemArray[7].ToString();
                    txtSchool.Text = DT.Rows[0].ItemArray[8].ToString();
                    txtsscpercentage.Text = DT.Rows[0].ItemArray[9].ToString();
                    txttestMarks.Text = DT.Rows[0].ItemArray[10].ToString();
                    txtContactNo.Text = DT.Rows[0].ItemArray[11].ToString();
                    txtaddress.Text = DT.Rows[0].ItemArray[12].ToString();
                    txtEmailAddress.Text = DT.Rows[0].ItemArray[13].ToString();
                    cmbFeild.SelectedItem = DT.Rows[0].ItemArray[15].ToString();
                    
                }
              
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Data base Connection Fail : {0}", ex.Message);
            }
            finally
            {
                DB.Close();
            }
        
        }

        private void txtFirstName_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            txtFirstName.BorderBrush = Brushes.White;
        }

        private void cmbDomicile_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            cmbDomicile.BorderBrush = null;
        }

        private void txtContactNo_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            txtContactNo.BorderBrush= Brushes.White;
        }

        private void txtaddress_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            txtaddress.BorderBrush = Brushes.White;
        }

        private void txtAdmissionNo_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            txtAdmissionNo.BorderBrush = Brushes.White; 
        }

        private void txtsscpercentage_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            txtsscpercentage.BorderBrush = Brushes.White;
        }

        private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            winSearchPopUp searchpopup = new winSearchPopUp();
            searchpopup.Show();
        }
    }
}
