using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.datagathering
{
    class sql
    {
        static string myconstring = ConfigurationManager.ConnectionStrings["LibraryManagementSystem.Properties.Settings.libraryMangementConnectionString"].ConnectionString;
        OleDbConnection conn = new OleDbConnection(myconstring);
        public bool Login(string sql)
        {
            bool isSuccess = false;
            try
            {
              
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    count++;
                  
                }
                if (count > 0)
                {
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
           



            return isSuccess;
        }

        public bool insert(string sql)
        {
            bool isSuccess=false;
            try
            {
                Console.WriteLine("come");
                OleDbCommand cmd = new OleDbCommand(sql,conn);
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                if (row>0)
                {
                    
                    isSuccess = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }


        //select from table
        public DataTable select(String sql)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }



            return dt;
        }
        public bool update(String sql)
        {
            bool isSuccess = false;
            try
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                if (row > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;

        }

        public bool lableColor()
        {
           
            bool isSuccess = false;
            string sql = "SELECT * FROM issuebook where closing_date<=Date()+2";
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql,conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    isSuccess = true;
                }

            }
            catch (Exception ex)
            {


            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }



    }
}
