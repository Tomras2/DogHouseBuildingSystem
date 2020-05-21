using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunuBuduSistema
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] != null)
            {
                UserLabel.Text = Session["Name"].ToString();
                UserLabel.Visible = true;
                LogOutButton.Visible = true;
            }
            else
            {
                UserLabel.Visible = false;
                LogOutButton.Visible = false;
            }

        }

        protected void LogOutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}