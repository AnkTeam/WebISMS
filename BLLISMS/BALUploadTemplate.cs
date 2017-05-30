using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLISMS
{
    public class BALUploadTemplate
    {
        DALISMS.DALUploadTemplate uploadTemplate;
        public int UploadDocument(string TemplateData, int uploadedBy)
        {
            try
            {
                uploadTemplate = new DALISMS.DALUploadTemplate();
                SqlCommand command = new SqlCommand();
                command.CommandText = "UspUploadTemplate";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UploadTemplate", TemplateData);
                command.Parameters.AddWithValue("@EMPId", uploadedBy);
                return uploadTemplate.UploadTemplate(command);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
