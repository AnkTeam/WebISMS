using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;


namespace WebISMSManagmentSystem
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Emp_Name"] != null)
                {

                    Label1.Text = "Welcome " + Session["Emp_Name"].ToString() + " " + "[ " + Session["Roll"].ToString() + " ]";
                    Label1.ForeColor = Color.Gray;

                }
            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
        }

       

        protected void LogOutBtn_Click(object sender, ImageClickEventArgs e)
        {
            
        }
    }
}