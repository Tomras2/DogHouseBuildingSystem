using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunuBuduSistema
{
    public partial class KlientuUzsakymai : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Name"] == null )
            {
                Response.Redirect("Default.aspx");
            }
            GetUzsakymai();
        }
        //private void GetUzsakymai()
        //{
        //    var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());
        //    SqlConnection con = new SqlConnection(connString);
        //    con.Open();
        //    string name = Session["Name"].ToString();
        //    string query = "Select Id, CONVERT(VARCHAR(10),Data,101) as Data, Busena, Kaina, CONVERT(VARCHAR(10),Preliminari_data,101) as Preliminari_data from Uzsakymai where Klientas='" + name + "'";
        //    SqlDataAdapter ad = new SqlDataAdapter(query, con);
        //    DataTable data = new DataTable();
        //    ad.Fill(data);
        //    Uzsakymai.DataSource = data;
        //    Uzsakymai.DataBind();
        //    con.Close();
        //}
        private void GetUzsakymai()
        {
            var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());
            SqlConnection con = new SqlConnection(connString);
            con.Open();
            string name = Session["Name"].ToString();
            string query = "Select DISTINCT u1.Id, CONVERT(VARCHAR(10),u1.Data,101) as Data, u1.Busena, u1.Kaina, CONVERT(VARCHAR(10),u1.Preliminari_data,101) as Preliminari_data, u1.Kiekis, u1.Medis, u1.SpalvosPav, u1.AngosForma, CONCAT(u1.Ilgis, ' cm ', ' x ',u1.Plotis, ' cm ') as Dydis, u2.StogoMedis, u2.StogoSpalva FROM UzsakymaiPilni u1, UzsakymaiPilni2 u2 where u1.Klientas='" + name + "' AND u2.Klientas='" + name + "'";
           // query += "Select StogoMedis, StogoSpalva FROM UzsakymaiPilni2 where Klientas='" + name + "'";
            SqlDataAdapter ad = new SqlDataAdapter(query, con);
            DataTable data = new DataTable();
            ad.Fill(data);
            Uzsakymai.DataSource = data;
            Uzsakymai.DataBind();
            con.Close();
        }
    }
}