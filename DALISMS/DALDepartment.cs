using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityLayerISMS;
using System.Data.SqlClient;


namespace DALISMS
{
    public class DALDepartment
    {
        DBConnectionISMS connection;
        public List<Department> LoadDepartment(int RoleId)
        {
            try
            {


                connection = new DBConnectionISMS();
                SqlCommand command = new SqlCommand();
                command.CommandText = "USPGetDepartment";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RoleId", RoleId);
                DataTable tblDepartment = connection.GetRecord(command);
                List<Department> departments = new List<Department>();
                departments = (from department in tblDepartment.AsEnumerable()
                               select new Department
                               {
                                   Id = department.Field<int>("ID"),
                                   Name = department.Field<string>("Name")
                               }).ToList<Department>();
                return departments;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

