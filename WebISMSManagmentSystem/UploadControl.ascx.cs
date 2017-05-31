using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntityLayerISMS;
using BLLISMS;

namespace WebISMSManagmentSystem
{
    public partial class UploadControl : System.Web.UI.UserControl
    {
        public UserRole Role;
        public List<Department> depts = new List<Department>();

        protected void Page_Load(object sender, EventArgs e)
        {
            Role = UserRole.IsoUser;
            BALDepartment department = new BALDepartment();
            depts = department.GetDepartment(1);

        }
        public enum UserRole
        {
            IsoUser = 1, // Admin User 
            User = 2 // Normal User
        }

        //private void LoadDepartment(int RoleId)
        //{
        //    using (SqlConnection connection = new SqlConnection(@"Data Source=CORP-SRV-56;Initial Catalog=ISMSManagement;Persist Security Info=True;User ID=isms_db_user;Password=!$Ms@2017"))
        //    {
        //        SqlCommand command = new SqlCommand();
        //        command.CommandText = "USPGetDepartment";
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        command.Connection = connection;
        //        command.Parameters.AddWithValue("@RoleId", RoleId);
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                depts.Add(Convert.ToInt32(reader["Id"]), Convert.ToString(reader["Name"]));
        //            }
        //        }
        //        connection.Close();
        //    }
        //}
    }
}