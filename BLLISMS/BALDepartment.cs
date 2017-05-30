using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayerISMS;
using DALISMS;

namespace BLLISMS
{
    public class BALDepartment
    {

        public List<Department> GetDepartment(int RoleId)
        {
            try
            {
                DALDepartment dept = new DALDepartment();
                return dept.LoadDepartment(RoleId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
