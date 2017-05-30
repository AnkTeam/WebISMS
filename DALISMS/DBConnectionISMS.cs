using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALISMS
{
    public class DBConnectionISMS 
    {
        SqlConnection connection;
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);   
            con.Open();
            return con;
        }
        public DBConnectionISMS()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);   
        }

        private void OpenConnection()
        {
            if (ConnectionState.Open == connection.State)
            {
                connection.Close();
                connection.Open();
            }
            else
            {
                connection.Open();
            }
        }

        private void CloseConnection()
        {
            if(ConnectionState.Closed != connection.State)
            {
                connection.Close();
            }
        }
        /// <summary>
        /// For Insert , Update , Delete Opration
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int  ExecuteQuery(SqlCommand command)
        {
            try
            {
              
                command.Connection = connection;
                connection.Open();
                return  command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return 0;
        }
        /// <summary>
        /// For Retrive Data 
        /// </summary>
        /// <returns></returns>

        public DataTable GetRecord(SqlCommand command)
        {
            try
            {
                command.Connection = connection;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable tbl =new DataTable ();
                adapter.Fill(tbl);
                return tbl;
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }

        public DataSet GetRecords(SqlCommand command)
        {
            try
            {
                command.Connection = connection;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch (Exception)
            {

                throw;
            }

        }

     
       
    }
}
