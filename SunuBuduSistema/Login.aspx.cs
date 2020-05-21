using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;

namespace SunuBuduSistema
{
    public partial class Login : System.Web.UI.Page
    {
        public static int authtype;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Visibility();
            var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());
            SqlConnection connection1 = new SqlConnection(connString);
            string admin = "select count(*) from Adminai where Prisijungimo_vardas='" + TextBox1.Text + "'";
            string user = "select count(*) from Klientai where Prisijungimo_vardas ='" + TextBox1.Text + "'";
            connection1.Open();
            SqlCommand com = new SqlCommand(user, connection1);
            SqlCommand com2 = new SqlCommand(admin, connection1);
            int temp2 = Convert.ToInt32(com2.ExecuteScalar().ToString());
            int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
            connection1.Close();
            if (temp2 == 1)
            {
                connection1.Open();
                string pass2 = "select Slaptazodis from Adminai where  Prisijungimo_vardas ='" + TextBox1.Text + "'";
                SqlCommand passadm = new SqlCommand(pass2, connection1);
                string password = passadm.ExecuteScalar().ToString().Replace(" ", ""); ;
                if (password == TextBox2.Text)
                {
                    connection1.Close();
                    Session["Name"] = TextBox1.Text;
                    Session["authtype"] = "Admin";
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    connection1.Close();
                    PassErrorLabel.Visible = true;
                }
            }
            else if (temp == 1)
            {
                connection1.Open();
                string pass = "select Slaptazodis from Klientai where  Prisijungimo_vardas ='" + TextBox1.Text + "'";
                SqlCommand passcomm = new SqlCommand(pass, connection1);
                string password = passcomm.ExecuteScalar().ToString().Replace(" ", ""); ;
                if (password == TextBox2.Text)
                {
                    connection1.Close();
                    Session["Name"] = TextBox1.Text;
                    Session["authtype"] = "User";
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    connection1.Close();
                    PassErrorLabel.Visible = true;
                }
            }
            else
            {
                connection1.Close();
                UserErrorLabel.Visible = true;
            }
        }
        
        //    if (temp == 1)

        //    {
        //        connection1.Open();
        //        string pass = "select Slaptazodis from Klientai where  Prisijungimo_vardas ='" + TextBox1.Text + "'";
        //        SqlCommand passcomm = new SqlCommand(pass, connection1);
        //        string password = passcomm.ExecuteScalar().ToString().Replace(" ", ""); ;
        //        if (password == TextBox2.Text)
        //        {
        //            Session["Name"] = TextBox1.Text;
        //            Response.Redirect("Default.aspx");
        //        }
        //        else
        //        {
        //            PassErrorLabel.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        UserErrorLabel.Visible = true;
        //    }
        //}
        void Visibility()
        {
            PassErrorLabel.Visible = false;
            UserErrorLabel.Visible = false;
        }

    }
}