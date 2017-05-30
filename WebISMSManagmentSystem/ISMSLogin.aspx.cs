using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLISMS;
using EntityLayerISMS;
namespace WebISMSManagmentSystem
{
    public partial class ISMSLogin : System.Web.UI.Page
    {
        BLLLogin bal = new BLLLogin();       
        protected void Page_Load(object sender, EventArgs e)
        {          
            //HttpCookie reqCookies = Request.Cookies["UserId"];
            //if (reqCookies != null)
            //{
            //    Txtusername.Text = Request.Cookies["UserId"].Value;
            //    //Response.Cookies["StudentCookies"].Expires = DateTime.Now.AddDays(-1);
            //    //Response.Redirect("Result.aspx");  //to refresh the page
            //}
        }


        protected void LoginISMSBntn_Click(object sender, EventArgs e)
        {
            try
            {                
                LoginUser loginUser = bal.LoginInformation(TxtUsername.Text, txtpassword.Text);
                Session["Emp_Name"] = loginUser.EmpName;
                Session["Roll"] = loginUser.RoleName;
                if (loginUser.RoleID == 2)
                {
                    loginUser.LastLogin = DateTime.Now.ToString();
                    loginUser.LastLogout = DateTime.Now.ToString();
                    bal.InsertLoginDetails(loginUser);
                    //Response.Write("simple");
                    Response.Redirect("User.aspx");
                }
                else if (loginUser.RoleID == 1)
                {
                    //Response.Write("Admin");
                    loginUser.LastLogin = DateTime.Now.ToString();                    
                    bal.InsertLoginDetails(loginUser);
                    Response.Redirect("Administrator.aspx");
                }

                else if(TxtUsername.Text == "" || txtpassword.Text == "")
                {


                }
           else if(TxtUsername.Text != loginUser.EmpID & txtpassword.Text != loginUser.Password)
                {
                    ldlMessage.Text = "Please use valid username and password !";
                }
              
            }
            catch
            {



            }


        }

        protected void remember_me_CheckedChanged(object sender, EventArgs e)
        {

            //HttpCookie StudentCookies = new HttpCookie("usernametCookies");
            //StudentCookies.Value = TextBox1.Text;
            //StudentCookies.Expires = DateTime.Now.AddHours(1);
            //Response.Cookies.Add(StudentCookies);
            //Response.Cookies["UserId"].Value = Txtusername.Text;
            //Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(1);

        }

       
    }
}