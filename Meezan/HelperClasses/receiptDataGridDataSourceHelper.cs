using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meezan.HelperClasses
{
    class receiptDataGridDataSourceHelper
    {
        public string Unit { get; set; }
      public  string Item { get; set; }
      public string Detail { get; set; }
      public double Price { get; set; }
      public double Quantity { get; set; }
      public DateTime receiptDate { get; set; }
      public string ReceptType { get; set; }
      public string ReceiptCatagory { get; set; }
      public double SubTotal
      {
          get { return this.Price * this.Quantity; } 
          set { 
        SubTotal= this.Price*this.Quantity;
      } }
      public string PrintedBy { get; set; }   
    }
}
