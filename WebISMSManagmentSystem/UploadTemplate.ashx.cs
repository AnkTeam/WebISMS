using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace WebISMSManagmentSystem
{
    /// <summary>
    /// Summary description for UploadTemplate
    /// </summary>
    /// <summary>
    /// Summary description for UploadTemplate
    /// </summary>
    public class UploadTemplate : IHttpHandler
    {

        private string baseTemplatePath = "~/UploadTemplate";
        private DirectoryInfo templateDirectory = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/UploadTemplate"));
        Dictionary<int, List<DocTemplate>> document = new Dictionary<int, List<DocTemplate>>();
        List<DocTemplate> templates = new List<DocTemplate>();
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                List<string> departments = new List<string>();

                departments = ((string)context.Request["Department"]).TrimEnd(',').Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                string templatePath = string.Empty;

                bool status = true;
                foreach (var department in departments)
                {
                    CreateDirectory(Convert.ToInt32(department));

                    if (departments.Count() == GetDepartment().Count)
                    {
                        if (status)
                        {
                            status = false;
                            templatePath = baseTemplatePath + "/ALL";
                            UploadISMSTemplate(templatePath, context, Convert.ToInt16(department));
                        }
                    }
                    else
                    {
                        templatePath = baseTemplatePath + "/" + department;
                        UploadISMSTemplate(templatePath, context, Convert.ToInt16(department));

                    }


                }



                var data = new XElement("Templates", from template in templates
                                                     select new XElement("Template",
                                                    new XAttribute("DepartmentId", template.DeptId),
                                                    new XAttribute("DocumentName", template.DocumentName),
                                                    new XAttribute("DocumentUrl", template.DocumentUrl)
                                                    )
                                                    );

            }
            catch (Exception ex)
            {
                ErrorLog(ex);
                throw ex;
            }
        }
        private string GetDepartment(int DeparmentId)
        {
            string DeptName = string.Empty;
            switch (DeparmentId)
            {
                case 1:
                    DeptName = "IT";
                    break;
                case 2:
                    DeptName = "SD";
                    break;
                case 3:
                    DeptName = "HR";
                    break;
                default:
                    DeptName = "ALL";
                    break;
            }
            return DeptName;
        }

        private void CreateDirectory(int departmentId)
        {
            DirectoryInfo info = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(baseTemplatePath + "/" + departmentId));
            if (!info.Exists)
            {
                info.Create();
            }
        }
        private void UploadISMSTemplate(string templatePath, HttpContext context, int departmentId)
        {
            HttpFileCollection files = context.Request.Files;
            templateDirectory = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(templatePath));
            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    string fileName = GetUniqueName(Path.GetFileNameWithoutExtension(file.FileName));
                    string pathName = context.Server.MapPath(templatePath + "/" + fileName + Path.GetExtension(files[i].FileName));
                    string urlPath = templatePath + "/" + fileName + Path.GetExtension(files[i].FileName);
                    file.SaveAs(pathName);
                    templates.Add(new DocTemplate() { DeptId = departmentId, DocumentName = file.FileName, DocumentUrl = urlPath });
                }
            }
        }
        private bool IsTemapleExist(string fileName)
        {
            try
            {
                if (templateDirectory.GetFiles().Where(p => Path.GetFileNameWithoutExtension(p.FullName) == fileName).FirstOrDefault() != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string GetUniqueName(string fileName)
        {
            while (IsTemapleExist(fileName))
            {
                fileName = fileName + "_1";
            }
            return fileName;
        }

        private void CreateNewDepartmentTemplate(string departmentName)
        {
            DirectoryInfo dir = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath("~/UploadTemplate/" + departmentName));
            if (!dir.Exists)
            {
                dir.Create();
            }

        }


        public List<string> GetDepartment()
        {
            List<string> department = new List<string>();
            department.Add("IT");
            department.Add("SD");
            department.Add("HR");
            department.Add("Account");
            return department;
        }

        public void ErrorLog(Exception ex)
        {

            using (FileStream errorLogStream = new System.IO.FileStream(HttpContext.Current.Server.MapPath("~/ErrorLog/" + System.DateTime.UtcNow.ToString()), FileMode.Create, FileAccess.ReadWrite))
            {

                string message = "Error Message:\t" + ex.Message + "\n" + "Stack Trace Error: \t" + ex.StackTrace;
                byte[] info = new UTF8Encoding(true).GetBytes(message);
                errorLogStream.Write(info, 0, info.Length);
            };

        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }


        public int UploadDocument(string TemplateData, int uploadedBy)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "UspUploadTemplate";
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Connection = new SqlConnection();
                command.Parameters.AddWithValue("@UploadTemplate", TemplateData);
                command.Parameters.AddWithValue("@EMPId", uploadedBy);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }



    public class DocTemplate
    {
        public string DocumentName { get; set; }
        public string DocumentUrl { get; set; }
        public int DeptId { get; set; }
    }
}