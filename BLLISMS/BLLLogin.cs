using DALISMS;
using EntityLayerISMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLISMS
{
    public class BLLLogin
    {
        DALLogin dal = new DALLogin();
        public LoginUser LoginInformation(string username, string password)
        {
            LoginUser obj = new LoginUser();
            try
            {              
                obj = dal.LoginInformation(username, password);             
            }
            catch (Exception ex)
            {               
            }
            return obj;
        }


        public LoginUser InsertLoginDetails(LoginUser LoginDetails)
        {
            LoginUser obj = new LoginUser();
            try
            {
                obj = dal.InsertLoginDetails(LoginDetails);
            }
            catch (Exception ex)
            {
            }
            return obj;
        }

    }
}
