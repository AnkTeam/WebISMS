using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using BLLISMS;
using EntityLayerISMS;
using System.Xml.Linq;
using System.Text;

namespace WebISMSManagmentSystem
{
    /// <summary>
    /// Summary description for Upload
    /// </summary>
    public class Upload : IHttpHandler
    {

        private string baseTemplatePath = "~/UploadTemplate";
        private DirectoryInfo templateDirectory = new DirectoryInfo(HttpContext.Current.Server.MapPath("~/UploadTemplate"));
        Dictionary<int, List<DocTemplate>> document = new Dictionary<int, List<DocTemplate>>();
        List<DocTemplate> templates = new List<DocTemplate>();
        List<Department> depts = new List<Department>();
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                List<string> departments = new List<string>();

                departments = ((string)context.Request["Department"]).TrimEnd(',').Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                string templatePath = string.Empty;
                depts = GetDepartment();
                foreach (var department in departments)
                {

                    if (departments.Count() == depts.Count)
                    {
                        templatePath = baseTemplatePath + "/ALL";
                    }
                    else
                    {
                        templatePath = baseTemplatePath + "/" + depts.Where(p => p.Id == Convert.ToInt16(department)).FirstOrDefault().Name;
                    }
                    CreateDirectory(templatePath);
                    UploadISMSTemplate(templatePath, context, Convert.ToInt16(department));
                   
                }



                string xmldata = new XElement("Templates", from template in templates
                                                           select new XElement("Template",
                                                          new XAttribute("DepartmentId", template.DeptId),
                                                          new XAttribute("DocumentName", template.DocumentName),
                                                          new XAttribute("DocumentUrl", template.DocumentUrl)
                                                          )
                                                    ).ToString();
                BALUploadTemplate uploadTemplate = new BALUploadTemplate();
                uploadTemplate.UploadDocument(xmldata, 1);

            }
            catch (Exception ex)
            {

                RemoveFile(templates);
                ErrorLog(ex);
                throw ex;
            }
        }


        private void RemoveFile(List<DocTemplate> templates)
        {
            foreach (DocTemplate template in templates)
            {
                File.Delete(HttpContext.Current.Server.MapPath(template.DocumentUrl));
            }
        }



        private void CreateDirectory(string templatePath)
        {
            DirectoryInfo info = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath(templatePath));
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

        //private void CreateNewDepartmentTemplate(string departmentName)
        //{
        //    DirectoryInfo dir = new System.IO.DirectoryInfo(HttpContext.Current.Server.MapPath("~/UploadTemplate/" + departmentName));
        //    if (!dir.Exists)
        //    {
        //        dir.Create();
        //    }

        //}


        public List<Department> GetDepartment()
        {
            List<Department> departments = new List<Department>();
            BALDepartment balDepartment = new BALDepartment();
            departments = balDepartment.GetDepartment(1);
            return departments;
        }

        public void ErrorLog(Exception ex)
        {
            
            using (FileStream errorLogStream = File.Create((HttpContext.Current.Server.MapPath("~/ErrorLog/" + System.DateTime.UtcNow.ToString("dd-mm-yy-hh-mm-ss") + ".txt"))))
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


        //public int UploadDocument(string TemplateData, int uploadedBy)
        //{
        //    try
        //    {
        //        SqlCommand command = new SqlCommand();
        //        command.CommandText = "UspUploadTemplate";
        //        command.CommandType = System.Data.CommandType.StoredProcedure;
        //        command.Connection = new SqlConnection();
        //        command.Parameters.AddWithValue("@UploadTemplate", TemplateData);
        //        command.Parameters.AddWithValue("@EMPId", uploadedBy);
        //        return command.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


    }
}