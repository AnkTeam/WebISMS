using EntityLayerISMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DALISMS
{
    public class DALLogin
    {
        SqlDataReader dr;       
        public LoginUser LoginInformation(string username, string password)
        {
            LoginUser entity = new LoginUser();

            try
            {

                using (SqlConnection con = DBConnectionISMS.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("Usp_Isms_Login", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@status", 0);
                        dr = cmd.ExecuteReader();
                        //cmd.ExecuteNonQuery();
                        //int retval = (int)cmd.Parameters["@status"].Value;

                        if (dr.Read())
                        {
                            entity.EmpName = dr["Emp_Name"].ToString();
                            entity.EmpID = dr["Emp_ID"].ToString();
                            entity.RoleID = Convert.ToInt32(dr["RollID"]);
                            entity.RoleName = dr["Roll_Name"].ToString();

                        }
                        

                    }
                }
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public LoginUser InsertLoginDetails(LoginUser entity)
        {
            int insert;
            try
            {

                using (SqlConnection con = DBConnectionISMS.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("Usp_LoginDetails", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpID", entity.EmpID);
                    
                        cmd.Parameters.AddWithValue("@LastLoginTime", entity.LastLogin);
                    
                     insert =    cmd.ExecuteNonQuery();
                        if(insert == 1)
                        {

                        }
                        else
                        {


                        }
                        

                    }
                }
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
