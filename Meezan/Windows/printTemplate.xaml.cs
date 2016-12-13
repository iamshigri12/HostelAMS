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
    /// Interaction logic for printTemplate.xaml
    /// </summary>
    public partial class printTemplate : Window
    {
     
        

        public printTemplate()
        {
            InitializeComponent();
        }
        public printTemplate(ItemCollection itemCollection, string printDate, string PrintedBy)
        {
            InitializeComponent();
            tbReceiptDate.Text = printDate;
            tbfooter.Text += PrintedBy;
            //foreach ( item in itemCollection)
            //{
            //    pnlitem.Children.Add(item);            
            //}
        }

       
        public void printReceipt() {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog()==true) {
                this.Height = pd.PrintableAreaHeight;
                this.Width = pd.PrintableAreaWidth;
                pd.PrintVisual(this, "Print");
             
            }
        
        
        }


    }
}
