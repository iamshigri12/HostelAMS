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
using Meezan.HelperClasses;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
namespace Meezan.Windows
{
    /// <summary>
    /// Interaction logic for winReciept.xaml
    /// </summary>
    public partial class winReciept : Window 
    {
        List elementrow = new List();
        string userName;
        double totalAmount;
        DBHelper DatabaseHelper = new DBHelper();
        
        public winReciept()
        {
            InitializeComponent();
            
            dpReceiptDate.SelectedDate = DateTime.Now;

            bindReceiptCode_Combo();
        }
        public winReciept(string UserName)
        {
            InitializeComponent();
            bindReceiptCode_Combo();
            dpReceiptDate.SelectedDate = DateTime.Now;
            this.userName = UserName;
        }


        private void bindReceiptCode_Combo() 
        {
            cmbReceiptCode.Items.Add("Mess");
            cmbReceiptCode.Items.Add("Medical");
            cmbReceiptCode.Items.Add("Event");
            cmbReceiptCode.Items.Add("Maintenance");
            cmbReceiptCode.SelectedItem = "Mess";
        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {

            if (validateData())
            {
                receiptDataGridDataSourceHelper DGelement = new receiptDataGridDataSourceHelper();

               
                DGelement.Item = txtitem.Text;
                DGelement.Detail = txtdetails.Text;
                DGelement.Price= Convert.ToDouble(txtPrice.Text);
                DGelement.Quantity = Convert.ToDouble(txtQuantity.Text);
                DGelement.Unit = Convert.ToString(cmbUnit.SelectedItem);
                DGelement.receiptDate = Convert.ToDateTime(dpReceiptDate.SelectedDate).Date;
                DGelement.ReceptType = Convert.ToString(cmbReceiptType.SelectedItem);
                DGelement.PrintedBy = this.userName;
                DGelement.ReceiptCatagory = cmbReceiptCode.SelectedItem.ToString();
                this.totalAmount = (this.totalAmount + (Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtQuantity.Text)));
                receiptDataGridDataSourceHelperDataGrid.Items.Add(DGelement);
                
            }
        }


        private bool validateData() {
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("price/amount field can't be empty", "Error ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                txtQuantity.Text = "1";
               
            }
            if(txtitem.Text==string.Empty  && cmbReceiptCode.SelectedItem.ToString().Equals("Mess")){
                MessageBox.Show("Item Feild is Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (txtitem.Text == string.Empty && cmbReceiptCode.SelectedItem.ToString().Equals("Event")) {
                MessageBox.Show("Event Name is Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (txtitem.Text == string.Empty && cmbReceiptCode.SelectedItem.ToString().Equals("Medical")) {
                MessageBox.Show("Med/Dr Name is Empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (txtPrice.Text!=null && System.Text.RegularExpressions.Regex.IsMatch(txtPrice.Text, "[^0-9]") && !System.Text.RegularExpressions.Regex.IsMatch(txtPrice.Text, "[.]"))
            {
                MessageBox.Show("Please Enter Only numbers in Price/amount Field", "Error ", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else if (txtQuantity.Text!=null && System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "[^0-9]") && !System.Text.RegularExpressions.Regex.IsMatch(txtQuantity.Text, "[.]"))
          {
              MessageBox.Show("Please Enter Only numbers in Quantity Field", "Error ", MessageBoxButton.OK, MessageBoxImage.Error);
              return false;


          }
      
            else
                return true;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource receiptDataGridDataSourceHelperViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("receiptDataGridDataSourceHelperViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // receiptDataGridDataSourceHelperViewSource.Source = [generic data source]
        }

        private void receiptDataGridDataSourceHelperDataGrid_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete) {
                MessageBoxResult result = MessageBox.Show("Do you want to Delete the Selected Item", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
              if(result== MessageBoxResult.Yes){
              receiptDataGridDataSourceHelperDataGrid.Items.Remove(receiptDataGridDataSourceHelperDataGrid.SelectedItem);            
              }
            
            }
        }

 
        private void cmbReceiptCode_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            switch(cmbReceiptCode.SelectedItem.ToString()){
                case "Mess" :
                                     
                    txtQuantity.Text = null;
                    txtPrice.Text = null;
                    txtitem.Text = null;
                    txtdetails.Text = null;
                    cmbUnit.Items.Clear();
                    cmbUnit.Visibility = Visibility.Visible;
                    cmbReceiptType.Items.Clear();
                    cmbReceiptType.Items.Add("Lumpsum");
                    cmbReceiptType.Items.Add("Daily");
                    cmbUnit.Items.Add("KG");
                    cmbUnit.Items.Add("M");
                    cmbUnit.Items.Add("L");
                    cmbUnit.Items.Add("Gaylen");
                    cmbUnit.Items.Add("Mun");
                    cmbUnit.Items.Add("Bag");
            break;
                case "Event":
                           cmbReceiptType.Items.Clear();
                           cmbReceiptType.Visibility = Visibility.Visible;
                         cmbReceiptType.Items.Add("Regular Dars");
                         cmbReceiptType.Items.Add("Special Event");
                           txtQuantity.Text = null;
                           txtPrice.Text = null;
                           txtitem.Text = null;
                           txtdetails.Text = null;
                           tbprice.Text = "Amount :";
                           tbitems.Text = "Event Name :";
                           tbdetails.Text = "Event Details :";

                         cmbUnit.Visibility = Visibility.Hidden;

            break;
                case "Medical":
                          cmbReceiptType.Items.Clear();
                          cmbReceiptType.Visibility = Visibility.Visible;
                        cmbReceiptType.Items.Add("Check Up");
                        cmbReceiptType.Items.Add("Medicine");
                         
                        txtQuantity.Text = null;
                        txtPrice.Text = null;
                        txtitem.Text = null;
                        txtdetails.Text = null;


                       cmbUnit.Visibility = Visibility.Hidden;
                       tbquantity.Visibility = Visibility.Hidden;
                       tbprice.Text = "Amount :";
                       txtPrice.HorizontalAlignment = HorizontalAlignment.Left;
                       txtQuantity.Text = "1";
                       txtQuantity.Visibility = Visibility.Hidden;
                       tbitems.Text = "Student / Med :";

                       tbdetails.Text="Details :";
            break;
                case "Maintenance" :
                     cmbReceiptType.Items.Clear();
                     cmbReceiptType.Visibility = Visibility.Hidden;
                           txtQuantity.Text = null;
                           txtPrice.Text = null;
                           txtitem.Text = null;
                           txtdetails.Text = null;
                           tbprice.Text = "Amount :";
                           txtPrice.HorizontalAlignment = HorizontalAlignment.Left;
                           tbitems.Text = "Item :";
                         cmbUnit.Visibility = Visibility.Hidden;
                         tbdetails.Text = "Maintenance Details :";

                    break;
            
            
            }
        }

      

        private void btnReset_Click_1(object sender, RoutedEventArgs e)
        {
            txtQuantity.Text = null;
            txtPrice.Text = null;
            txtitem.Text = null;
            txtdetails.Text = null;
            receiptDataGridDataSourceHelperDataGrid.Items.Clear();
        }

        private void btnSaveReceipt_Click_1(object sender, RoutedEventArgs e)
        { string query;

        try
        {




            foreach (receiptDataGridDataSourceHelper item in receiptDataGridDataSourceHelperDataGrid.Items)
            {
                query = "   INSERT INTO [MeezanDB].[dbo].[RECEIPT]"
                    + "([Receipt_item]"
                  + ",[Receipt_Details]"
                  + ",[Receipt_Dte]"
                  + ",[Receipt_Price]"
                  + ",[Receipt_Quantity]"
                  + ",[Receipt_Subtotal]"
                 + " ,[Receipt_Type]"
                 + " ,[Receipt_By]"
                  + ",[Receipt_catagory]"
                  + ",[unit])"
           + " VALUES"
                  + "('" + item.Item + "','"
                  + item.Detail
                  + "','" + item.receiptDate
                  + "','" + item.Price
                  + "','" + item.Quantity
                  + "','" + item.SubTotal
                  + "','" + item.ReceptType
                  + "','" + item.PrintedBy
                  + "','" + item.ReceiptCatagory
                  + "','" + item.Unit + "')";


                DatabaseHelper.ConnectDB();
                DatabaseHelper.Query = new SqlCommand(query, DatabaseHelper.DB);
                DatabaseHelper.Query.ExecuteNonQuery();
                DatabaseHelper.CloseDB();

            }
            receiptDataGridDataSourceHelperDataGrid.Items.Clear();
            MessageBox.Show("Saved Successfully ", "Saved ", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally {
           
        }
        
        }

        private void btncancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click_1(object sender, RoutedEventArgs e)
        {
            printTemplate pt = new printTemplate(receiptDataGridDataSourceHelperDataGrid.Items, dpReceiptDate.SelectedDate.ToString(),userName);
            pt.printReceipt();
        }





    }
}
