using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Meezan.HelperClasses
{
  public class DBHelper
    {
      SqlConnection _DB;
      SqlCommand _Query;
      SqlDataAdapter _DataAdapter;
      DataTable _Datatable;


      public SqlConnection DB
      {
          get { return _DB; }
         private set { _DB = value; }
      }

      public SqlCommand Query
      {
          get
          {
              return _Query;
          }
          set
          {
              _Query = value;
          }
      }


      public DataTable Datatable
      {
          get { return _Datatable; }
          set { _Datatable = value; }
      }
      


      public SqlDataAdapter DataAdapter
      {
          get { return _DataAdapter; }
          set { _DataAdapter = value; }
      }
      

      public DBHelper()
      {

          DB = new SqlConnection(Properties.Settings.Default.ConnectionString);
         

      }

        public void ConnectDB()
        {
            try
            {
                
                DB.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {


            }

        }

        public void CloseDB()
        {
            try
            {

                DB.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {


            }


        }


    }
}
