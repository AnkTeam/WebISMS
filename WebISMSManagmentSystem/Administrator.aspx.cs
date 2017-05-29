using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;


namespace WebISMSManagmentSystem
{
    public partial class Administrator : System.Web.UI.Page
    {
       System.Windows.Forms.TabControl dynamicTabControl = new TabControl();
     
        protected void Page_Load(object sender, EventArgs e)
        {= 
            if (!IsPostBack)
            {
                if (Session["Emp_Name"] != null)
                {                   
                    Label1.Text = "Welcome " + Session["Emp_Name"].ToString()+ " "+ "[ " + Session["Roll"].ToString()+ " ]" ;
                    Label1.ForeColor = Color.Gray;
                }

            }
        }

        protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Int32.Parse(e.Item.Value);
            MultiView1.ActiveViewIndex = index;
        }
    }
}