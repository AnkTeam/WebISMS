using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayerISMS
{
    interface LoginEntity
    {
        int Userid { get; set; }
        string Password { get; set; }
        string EmpName { get; set; }
        string  EmpID  { get;  set ;}
        string  RoleName  { get;  set ; }
        int RoleID { get; set; }


    }
    interface LoginDetails
    {

        string LastLogin { get; set; }
        string LastLogout { get; set; }

    }
    public class LoginUser : LoginEntity , LoginDetails
    {
        public string Password { get; set; }

        public int Userid { get;  set; }

        public string EmpName  { get;  set ;}
        public string EmpID  { get;  set ;}
        public string RoleName { get;  set ; }
        public int RoleID  { get;  set ; }
        public string LastLogin { get; set; }

      public  string LastLogout { get; set; }


    }
}
