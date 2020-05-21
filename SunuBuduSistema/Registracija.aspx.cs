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
    public partial class Registracija : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegistrationButton_Click(object sender, EventArgs e)
        {
            Visibility();
            var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());

            string checkuser = "select count (*) from Klientai where Prisijungimo_vardas='" + TextBox1.Text + "'";
            string checkemail = "select count (*) from Klientai where E_pastas='" + TextBox6.Text + "'";
            SqlConnection connection1 = new SqlConnection(connString);
            connection1.Open();
            SqlCommand checkus = new SqlCommand(checkuser, connection1);
            SqlCommand checkem = new SqlCommand(checkemail, connection1);
            int emailCount = Convert.ToInt32(checkem.ExecuteScalar().ToString());
            int usernameCount = Convert.ToInt32(checkus.ExecuteScalar().ToString());
            if (usernameCount == 1)
            {
                ErrorUserEmailLabel.Text = "Toks prisijungimo vardas jau yra!";
                ErrorUserEmailLabel.Visible = true;
                connection1.Close();
            }
            else if 
                (emailCount == 1) {

                ErrorUserEmailLabel.Text = "Toks elektroninis paštas jau yra!";
                ErrorUserEmailLabel.Visible = true;
                connection1.Close();
            }
            else { 
            SqlCommand cmd = new SqlCommand( "insert into Klientai values(@Prisijungimo_vardas,@Vardas,@Pavarde,@Slaptazodis,@Telefonas,@E_pastas,@Adresas)");             
                    cmd.Connection = connection1;
                    cmd.Parameters.AddWithValue("@Prisijungimo_vardas", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Vardas", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@Pavarde", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@Slaptazodis", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@Telefonas", TextBox5.Text);
                    cmd.Parameters.AddWithValue("@E_pastas", TextBox6.Text);
                    cmd.Parameters.AddWithValue("@Adresas", TextBox7.Text);
                    cmd.ExecuteNonQuery();
                connection1.Close();
                Response.Redirect("~/Registracija_Sekminga.aspx");
            }
        }
        private void ClearControls()
        {
            foreach (var item in Page.Controls)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }

        private void Visibility()
        {
            ErrorUserEmailLabel.Visible = false;          
        }
    }
}