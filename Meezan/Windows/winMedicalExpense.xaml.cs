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

namespace Meezan.Windows
{
    /// <summary>
    /// Interaction logic for winMedicalExpense.xaml
    /// </summary>
    public partial class winMedicalExpense : Window
    {

        private bool isloaded;
        public winMedicalExpense()
        {
            InitializeComponent();
            messReportViewer.Load += messExpenseReport_Load;
        }

        private void messExpenseReport_Load(object sender, EventArgs e)
        {
            if (!isloaded) {

                Microsoft.Reporting.WinForms.ReportDataSource datasource = new Microsoft.Reporting.WinForms.ReportDataSource();
                MeezanDBDataSet dataset = new MeezanDBDataSet();

                dataset.BeginInit();
                datasource.Name = "ExpenseMessDataSet";
                datasource.Value = dataset.EXPENSE_MESS_S0;
                this.messReportViewer.LocalReport.DataSources.Add(datasource);
                this.messReportViewer.LocalReport.ReportEmbeddedResource = "Meezan.Reports.expenseMessReport.rdlc";

                dataset.EndInit();

                MeezanDBDataSetTableAdapters.EXPENSE_MESS_S0TableAdapter da = new MeezanDBDataSetTableAdapters.EXPENSE_MESS_S0TableAdapter();
                
                DateTime fromdate = Convert.ToDateTime("2000-01-01");
                DateTime todate = Convert.ToDateTime("2016-01-01");
                string expensetype = "lumpsum";

                da.Fill(dataset.EXPENSE_MESS_S0,fromdate,todate,expensetype);
                da.ClearBeforeFill = true;
                messReportViewer.RefreshReport();
                isloaded = true;
            
            }
            
        }


    }
}
