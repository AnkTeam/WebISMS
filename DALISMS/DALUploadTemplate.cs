using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayerISMS;
 

namespace DALISMS
{
   public  class DALUploadTemplate
    {

       DBConnectionISMS connection;
       public int UploadTemplate(SqlCommand command )
       {
           try
           {
               connection = new DBConnectionISMS();
               return connection.ExecuteQuery(command);
           }
           catch (Exception)
           {
               
               throw;
           }
          
       }

    }
}
