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
    public partial class BuduGamyba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindDropDownList();

        }

        private void BindDropDownList()
        {
            // Sienos
            // TextBox1
            var kiekis = sienu_kiekis_box.Text;

            // DropDownList1
            var medziaiAdapter = new DataSetTableAdapters.MedziaiTableAdapter();
            var medziaiSet = medziaiAdapter.GetData();
            sienos_medis_list.DataSource = medziaiSet;
            sienos_medis_list.DataValueField = "Numeris";
            sienos_medis_list.DataTextField = "Tipas";
            sienos_medis_list.DataBind();
            sienos_medis_list.Items.Insert(0, "-------------");

            // DropDownList2
            var spalvosAdapter = new DataSetTableAdapters.SpalvosTableAdapter();
            var spalvosSet = spalvosAdapter.GetData();
            sienos_spalva_list.DataSource = spalvosSet;
            sienos_spalva_list.DataValueField = "Numeris";
            sienos_spalva_list.DataTextField = "Pavadinimas";
            sienos_spalva_list.DataBind();
            sienos_spalva_list.Items.Insert(0, "-------------");

            // DropDownList3
            var angosAdapter = new DataSetTableAdapters.AngosTableAdapter();
            var angosSet = angosAdapter.GetData();
            sienos_anga_list.DataSource = angosSet;
            sienos_anga_list.DataValueField = "Numeris";
            sienos_anga_list.DataTextField = "Forma";
            sienos_anga_list.DataBind();
            sienos_anga_list.Items.Insert(0, "-------------");

            // CheckBox1
            var uzdengimas = uzdengimas_status.Checked;

            // DropDownList4
            var dydziaiAdapter = new DataSetTableAdapters.DydziaiTableAdapter();
            var dydziaiSet = dydziaiAdapter.GetData();
            dydziaiSet.Columns.Add("Full", typeof(string), "Pavadinimas + ' ' + Lentos_ilgis_cm + 'cm' + ' X ' + Lentos_plotis_cm + 'cm'");
            sienos_dydziai_list.DataSource = dydziaiSet;
            sienos_dydziai_list.DataValueField = "Numeris";
            sienos_dydziai_list.DataTextField = "Full";
            sienos_dydziai_list.DataBind();
            sienos_dydziai_list.Items.Insert(0, "--------------------------");

            // Stogas

            // CheckBox1
            var kaminas = kaminas_status.Checked;

            //DropDownList1
            stogo_medis_list.DataSource = medziaiSet;
            stogo_medis_list.DataValueField = "Numeris";
            stogo_medis_list.DataTextField = "Tipas";
            stogo_medis_list.DataBind();
            stogo_medis_list.Items.Insert(0, "-------------");

            // DropDownList2
            stogo_spalva_list.DataSource = spalvosSet;
            stogo_spalva_list.DataValueField = "Numeris";
            stogo_spalva_list.DataTextField = "Pavadinimas";
            stogo_spalva_list.DataBind();
            stogo_spalva_list.Items.Insert(0, "-------------");

            // Iranga

            var irangosAdapter = new DataSetTableAdapters.IrangosTableAdapter();
            var irangosSet = irangosAdapter.GetData();
            irangosSet.Columns.Add("Full", typeof(string), " '&nbsp;&nbsp;&nbsp' + Tipas + ' ( ' + Kaina + ' Eur )'");
            irangos_list.DataSource = irangosSet;
            irangos_list.DataValueField = "Numeris";
            irangos_list.DataTextField = "Full";
            irangos_list.DataBind();

            // Papildomi komponentai

            var atributaiAdapter = new DataSetTableAdapters.AtributaiTableAdapter();
            var atributaiSet = atributaiAdapter.GetData();
            atributaiSet.Columns.Add("Full", typeof(string), "'&nbsp;&nbsp;&nbsp' + Tipas + '  (' + Kaina + ' Eur)'");
            atributai_list.DataSource = atributaiSet;
            atributai_list.DataValueField = "Numeris";
            atributai_list.DataTextField = "Full";
            atributai_list.DataBind();

        }

        //****************************************************************************

        protected void Button2_Click(object sender, EventArgs e)
        {
            Visibility();
            //lauku uzpildymo tikrinimas

            bool visiLaukai = Tikrinimas();
            if (visiLaukai == false)
            {
                Klaidalauku.Visible = true;
                kainoslable.Visible = false;
                kaina.Visible = false;
                datoslabel.Visible = false;
                data.Visible = false;
            }
            else
            {
                Klaidalauku.Visible = false;

                double pasirinktosIrangosKaina = IrangosKaina();
                double papildomuPasirinkimuKaina = PapildomuKaina();

                double sienuKaina = SienosKaina();
                double stogoKaina = StogoKaina();

                double bendraSuma = pasirinktosIrangosKaina + papildomuPasirinkimuKaina + sienuKaina + stogoKaina;

                DateTime pagaminimoData = SkaiciuotiData(out double zmogvalandes);
                string tikraData = pagaminimoData.ToString("yyyy/MM/dd");

                datoslabel.Visible = true;
                kainoslable.Visible = true;

                data.Visible = true;
                kaina.Visible = true;

                kaina.Text = bendraSuma.ToString() + " eurai";
                data.Text = tikraData;
            }

        }

        //****************************************************************************

        /// <summary>
        /// Skaiciuojama pasirinktu irangos elementu kainos suma
        /// </summary>
        /// <returns>Bendra pasirinktos irangos suma</returns>

        private double IrangosKaina()
        {
            double irangos_suma = 0;
            var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());
            SqlConnection connection1 = new SqlConnection(connString);

            foreach (ListItem item in irangos_list.Items)
            {
                if (item.Selected)
                {
                    string irangokaina = "SELECT Kaina FROM Irangos WHERE Numeris=" + item.Value;
                    SqlCommand SqlCommandkainos = new SqlCommand(irangokaina, connection1);
                    connection1.Open();
                    double kaina = Convert.ToDouble(SqlCommandkainos.ExecuteScalar().ToString());
                    connection1.Close();
                    irangos_suma = irangos_suma + kaina;
                }
            }
            return irangos_suma;
        }

        /// <summary>
        /// Pasirinktu papildomu atributu kainos skaiciavimas
        /// </summary>
        /// <returns>Bendra pasirinktu atributu kaina</returns>

        private double PapildomuKaina()
        {
            double papildomu_suma = 0;
            var connString = (ConfigurationManager.ConnectionStrings["Duomenu_bazeConnectionString"].ToString());
            SqlConnection connection1 = new SqlConnection(connString);
            foreach (ListItem item in atributai_list.Items)
            {
                if (item.Selected)
                {
                    string atributokaina = "SELECT Kaina FROM Atributai WHERE Numeris=" + item.Value;
                    SqlCommand SqlCommandkainos = new SqlCommand(atributokaina, connection1);
                    connection1.Open();
                    double kaina = Convert.ToDouble(SqlCommandkainos.ExecuteScalar().ToString());
                    connection1.Close();
                    papildomu_suma = papildomu_suma + kaina;
                }
            }
            return papildomu_suma;
        }

        //****************************************************************************

        /// <summary>
        /// Apskaiciuoja budos stogo kaina pagal pasirinkimus
        /// </summary>
        /// <returns>Budos stogo kaina</returns>
        private double StogoKaina()
        {
            double kaina = 0;
            double tarpine = 0;
            double vienosplotis = 0;

            // atrenkama pasirinkto dydzio kaina bei lentos matmenys
            var dydziaiAdapter = new DataSetTableAdapters.DydziaiTableAdapter();
            var dydziai = dydziaiAdapter.GetData();
            var dydzioPasirinkimas = sienos_dydziai_list.SelectedValue;
            foreach (var item in dydziai)
            {
                if (item.Numeris == dydzioPasirinkimas)
                {
                    vienosplotis = item.Lentos_plotis_cm * item.Lentos_ilgis_cm;
                    tarpine = item.Kaina;
                }
            }
            kaina += (tarpine * 2);
            // ivertinamas kamino pasirinkimas
            if (kaminas_status.Checked)
            {
                tarpine = (tarpine * 0.4);
                kaina += tarpine;
            }
            double plotas = vienosplotis * 2;         // apskaiciuojamas stoge naudojamu lentu plotas

            //pagal pasirinkta medi bei dydi apskaiciuojama medzio kaina stogui
            var medzioPasirinkimas = stogo_medis_list.SelectedValue;
            double medzioCm2kaina = Pasisirinktasmedis(medzioPasirinkimas);
            kaina += (medzioCm2kaina * plotas);
            var spalvosPasirinkimas = stogo_spalva_list.SelectedValue;
            double spalvoskaina = SpalvosKaina(spalvosPasirinkimas);
            kaina += spalvoskaina;

            return kaina;
        }

        /// <summary>
        /// Apskaiciuoja budos sienu kaina pagal pasirinkimus
        /// </summary>
        /// <returns>Budos sienu kaina</returns>
        private double SienosKaina()
        {
            double kaina = 0;
            double tarpine = 0;
            double vienosplotis = 0;

            int kiekis = Convert.ToInt32(sienu_kiekis_box.Text);            //ivestas sienu kiekis

            // atrenkama pasirinkto dydzio kaina bei lentos matmenys
            var dydziaiAdapter = new DataSetTableAdapters.DydziaiTableAdapter();
            var dydziai = dydziaiAdapter.GetData();
            var dydzioPasirinkimas = sienos_dydziai_list.SelectedValue;
            foreach (var item in dydziai)
            {
                if (item.Numeris == dydzioPasirinkimas)
                {
                    vienosplotis = item.Lentos_plotis_cm * item.Lentos_ilgis_cm;
                    tarpine = item.Kaina;
                }
            }
            kaina += (tarpine * kiekis);

            double plotas = vienosplotis * kiekis;         // apskaiciuojamas sienoms(pasirinktam kiekui) naudojamu lentu plotas
            var medzioPasirinkimas = sienos_medis_list.SelectedValue;
            double medzioCm2kaina = Pasisirinktasmedis(medzioPasirinkimas);
            kaina += (medzioCm2kaina * plotas);

            double angoskaina = AngosKaina();
            kaina += angoskaina;

            var spalvosPasirinkimas = sienos_spalva_list.SelectedValue;
            double spalvoskaina = SpalvosKaina(spalvosPasirinkimas);
            kaina += spalvoskaina;

            return kaina;
        }

        //****************************************************************************

        /// <summary>
        /// Pasirinktos spalvos kainos radimas
        /// </summary>
        /// <param name="spalvosNumeris">Pasirinktos spalvos numeris (raktas)</param>
        /// <returns>Pasirinktos saplvos kaina</returns>
        private double SpalvosKaina(string spalvosNumeris)
        {
            double kaina = 0;
            var spalvosAdapter = new DataSetTableAdapters.SpalvosTableAdapter();
            var spalvos = spalvosAdapter.GetData();
            foreach (var item in spalvos)
            {
                if (item.Numeris == spalvosNumeris)
                {
                    kaina = item.Kaina;
                }
            }
            return kaina;
        }

        /// <summary>
        /// Pasirinktos budos angos kainos apskaiciavimas, ivertinant angos uzdengimo pasirinkima
        /// </summary>
        /// <returns>Pasirinktos angos kaina</returns>
        private double AngosKaina()
        {
            double kaina = 0;
            double tarpine = 0;
            var angosAdapter = new DataSetTableAdapters.AngosTableAdapter();
            var angos = angosAdapter.GetData();
            var angosPasirinkimas = sienos_anga_list.SelectedValue;
            foreach (var item in angos)
            {
                if (item.Numeris == angosPasirinkimas)
                {
                    tarpine = item.Kaina;
                }
            }
            //ivertinamas angos uzdengimo pasirinkimas
            if (uzdengimas_status.Checked)
            {
                tarpine = tarpine + (tarpine * 0.4);
            }
            kaina = tarpine;
            return kaina;
        }


        /// <summary>
        /// Pasirinkto medzio (1 cm2) kainos atrinkimas
        /// </summary>
        /// <param name="medzioNumeris">Pasirinkto medzio numeris (raktas)</param>
        /// <returns>Pasirinkto medzio (1 cm2) kaina</returns>
        private double Pasisirinktasmedis(string medzioNumeris)
        {
            double kainaCm2 = 0;
            var medziaiAdapter = new DataSetTableAdapters.MedziaiTableAdapter();
            var medziai = medziaiAdapter.GetData();
            foreach (var item in medziai)
            {
                if (item.Numeris == medzioNumeris)
                {
                    kainaCm2 = item.Kaina_cm2;
                }
            }
            return kainaCm2;
        }

        //****************************************************************************

        /// <summary>
        /// Tikrina ar visi privalomi lauka yra pasirinkti, pazymeti ir uzpildyti
        /// </summary>
        /// <returns>Ar visi laukai privalomi uzpildyti ar ne</returns>

        private bool Tikrinimas()
        {
            bool tikrinimas = true;
            List<String> Iranga = new List<string>();
            foreach (ListItem item in irangos_list.Items)
            {
                if (item.Selected)
                {
                    Iranga.Add(item.Value);
                }
            }

            if (sienos_medis_list.SelectedItem.ToString() == "-------------" ||
                sienos_spalva_list.SelectedItem.ToString() == "-------------" ||
                sienos_anga_list.SelectedItem.ToString() == "-------------" ||
                sienos_dydziai_list.SelectedItem.ToString() == "--------------------------" ||
                stogo_medis_list.SelectedItem.ToString() == "-------------" ||
                stogo_spalva_list.SelectedItem.ToString() == "-------------" ||
                Iranga.Count == 0 ||
                sienu_kiekis_box.Text == "")
            {
                tikrinimas = false;
            }
            return tikrinimas;
        }
        private void Visibility()
        {
            Neprisijunges.Visible = false;
            PrisijungimasLink.Visible = false;
            RegistracijaLink.Visible = false;
            Arba.Visible = false;
        }

        //****************************************************************************

        /// <summary>
        /// Pagaminimo datos skaiciavimas
        /// </summary>
        /// <returns>Pagaminimo data</returns>

        private DateTime SkaiciuotiData(out double zmogvalandes)
        {
            zmogvalandes = 0;
            double temp = 0;

            var kiekis = sienu_kiekis_box.Text;
            int tikrasKiekis = Convert.ToInt32(kiekis);

            // Pasirinkimu tikrinimas

            var medziaiAdapter = new DataSetTableAdapters.MedziaiTableAdapter();
            var medziaiSet = medziaiAdapter.GetData();
            var sienosMedziaiPasirinkimas = sienos_medis_list.SelectedValue;

            foreach (var item in medziaiSet)
            {
                if (item.Numeris == sienosMedziaiPasirinkimas)
                {
                    temp = item.Zmogvalande;
                }
            }
            zmogvalandes += temp * tikrasKiekis; // dauginti is sienu kiekio

            var spalvosAdapter = new DataSetTableAdapters.SpalvosTableAdapter();
            var spalvosSet = spalvosAdapter.GetData();
            var sienosSpalvosPasirinkimas = sienos_spalva_list.SelectedValue;

            foreach (var item in spalvosSet)
            {
                if (item.Numeris == sienosSpalvosPasirinkimas)
                {
                    temp = item.Zmogvalandes;
                }
            }
            zmogvalandes += temp * tikrasKiekis; // dauginti is sienu kiekio

            var angosAdapter = new DataSetTableAdapters.AngosTableAdapter();
            var angosSet = angosAdapter.GetData();
            var angosPasirinkimas = sienos_anga_list.SelectedValue;

            foreach (var item in angosSet)
            {
                if (item.Numeris == angosPasirinkimas)
                {
                    temp = item.Zmogvalandes;
                }
            }
            zmogvalandes += temp;

            var dydziaiAdapter = new DataSetTableAdapters.DydziaiTableAdapter();
            var dydziaiSet = dydziaiAdapter.GetData();
            var dydziaiPasirinkimas = sienos_dydziai_list.SelectedValue;

            foreach (var item in dydziaiSet)
            {
                if (item.Numeris == dydziaiPasirinkimas)
                {
                    temp = item.Zmogvalandes;
                }
            }
            zmogvalandes += temp * tikrasKiekis; // dauginti is sienu kiekio

            var stogoMedziaiPasirinkimas = stogo_medis_list.SelectedValue;

            foreach (var item in medziaiSet)
            {
                if (item.Numeris == stogoMedziaiPasirinkimas)
                {
                    temp = item.Zmogvalande;
                }
            }
            zmogvalandes += temp;

            var stogoSpalvosPasirinkimas = stogo_spalva_list.SelectedValue;

            foreach (var item in spalvosSet)
            {
                if (item.Numeris == stogoSpalvosPasirinkimas)
                {
                    temp = item.Zmogvalandes;
                }
            }
            zmogvalandes += temp;

            var irangosAdapter = new DataSetTableAdapters.IrangosTableAdapter();
            var irangosSet = irangosAdapter.GetData();

            foreach (ListItem item in irangos_list.Items)
            {
                if (item.Selected)
                {
                    foreach (var anotherItem in irangosSet)
                    {
                        if (anotherItem.Numeris == item.Value)
                        {
                            temp = anotherItem.Zmogvalandes;
                            zmogvalandes += temp; // visi irangos pasirinkimai skaiciuojami
                        }
                    }
                }
            }

            var atributaiAdapter = new DataSetTableAdapters.AtributaiTableAdapter();
            var atributaiSet = atributaiAdapter.GetData();

            foreach (ListItem item in atributai_list.Items)
            {
                if (item.Selected)
                {
                    foreach (var anotherItem in atributaiSet)
                    {
                        if (anotherItem.Numeris == item.Value)
                        {
                            temp = anotherItem.Zmogvalandes;
                            zmogvalandes += temp; // visi atributu pasirinkimai skaiciuojami
                        }
                    }
                }
            }

            // Esamu uzsakymu datu suformavimas

            DateTime currentTime = DateTime.Today;

            var uzimtumaiAdapter = new DataSetTableAdapters.UzimtumaiTableAdapter();
            var uzsakymaiAdapter = new DataSetTableAdapters.UzsakymaiTableAdapter();
            var uzimtumaiSet = uzimtumaiAdapter.GetData();
            var uzsakymaiSet = uzsakymaiAdapter.GetData();

            List<int> dienos = new List<int>(); // galbut reikes pagaminimo datom formuoti

            foreach (var item in uzimtumaiSet)
            {
                double uzsakymoZmogvalandes = item.Zmogvalandes;
                int dienuSkaicius = 0;
                bool pridetiStatus = false;
                foreach (var anotherItem in uzsakymaiSet)
                {
                    if (item.Uzsakymas == anotherItem.Id)
                    {
                        if (anotherItem.Busena == "Vykdomas")
                        {
                            pridetiStatus = true;
                        }
                    }
                }
                if (pridetiStatus == true)
                {
                    while (uzsakymoZmogvalandes > 0)
                    {
                        DayOfWeek currentDay = currentTime.DayOfWeek;
                        if (currentDay == DayOfWeek.Monday)
                        {
                            uzsakymoZmogvalandes -= 6;
                            dienuSkaicius += 1;
                            currentTime = currentTime.AddDays(1);
                        }
                        if (currentDay == DayOfWeek.Tuesday)
                        {
                            uzsakymoZmogvalandes -= 6;
                            dienuSkaicius += 1;
                            currentTime = currentTime.AddDays(1);
                        }
                        if (currentDay == DayOfWeek.Wednesday)
                        {
                            uzsakymoZmogvalandes -= 6;
                            dienuSkaicius += 1;
                            currentTime = currentTime.AddDays(1);
                        }
                        if (currentDay == DayOfWeek.Thursday)
                        {
                            uzsakymoZmogvalandes -= 6;
                            dienuSkaicius += 1;
                            currentTime = currentTime.AddDays(1);
                        }
                        if (currentDay == DayOfWeek.Friday)
                        {
                            uzsakymoZmogvalandes -= 6;
                            dienuSkaicius += 1;
                            currentTime = currentTime.AddDays(1);
                        }
                        if (currentDay == DayOfWeek.Saturday)
                        {
                            dienuSkaicius += 1;
                            currentTime = currentTime.AddDays(1);
                        }
                        if (currentDay == DayOfWeek.Sunday)
                        {
                            dienuSkaicius += 1;
                            currentTime = currentTime.AddDays(1);
                        }
                    }
                }
                dienos.Add(dienuSkaicius);
            }

            // Suskaiciuotu zmogvalandziu pridejimas

            double zmogvalandesSk = zmogvalandes;
            int dienuSkaiciusTemp = 0;
            while (zmogvalandesSk > 0)
            {
                DayOfWeek currentDay = currentTime.DayOfWeek;
                if (currentDay == DayOfWeek.Monday)
                {
                    zmogvalandesSk -= 6;
                    dienuSkaiciusTemp += 1;
                    currentTime = currentTime.AddDays(1);
                }
                if (currentDay == DayOfWeek.Tuesday)
                {
                    zmogvalandesSk -= 6;
                    dienuSkaiciusTemp += 1;
                    currentTime = currentTime.AddDays(1);
                }
                if (currentDay == DayOfWeek.Wednesday)
                {
                    zmogvalandesSk -= 6;
                    dienuSkaiciusTemp += 1;
                    currentTime = currentTime.AddDays(1);
                }
                if (currentDay == DayOfWeek.Thursday)
                {
                    zmogvalandesSk -= 6;
                    dienuSkaiciusTemp += 1;
                    currentTime = currentTime.AddDays(1);
                }
                if (currentDay == DayOfWeek.Friday)
                {
                    zmogvalandesSk -= 6;
                    dienuSkaiciusTemp += 1;
                    currentTime = currentTime.AddDays(1);
                }
                if (currentDay == DayOfWeek.Saturday)
                {
                    dienuSkaiciusTemp += 1;
                    currentTime = currentTime.AddDays(1);
                }
                if (currentDay == DayOfWeek.Sunday)
                {
                    dienuSkaiciusTemp += 1;
                    currentTime = currentTime.AddDays(1);
                }
            }
            dienos.Add(dienuSkaiciusTemp);

            return currentTime;
        }

        protected void Uzsakyti_Click(object sender, EventArgs e)
        {
            if (Session["Name"] == null)
            {
                Neprisijunges.Visible = true;
                PrisijungimasLink.Visible = true;
                RegistracijaLink.Visible = true;
                Arba.Visible = true;
            }
            else
            {
                // Adapters

                var sienosAdapter = new DataSetTableAdapters.SienosTableAdapter();
                var stogaiAdapter = new DataSetTableAdapters.StogaiTableAdapter();

                // Pasirinkimai

                int sienu_kiekis = Convert.ToInt32(sienu_kiekis_box.Text);
                string sienu_dydis = sienos_dydziai_list.SelectedValue;
                string anga = sienos_anga_list.SelectedValue;
                string uzdengimas = uzdengimas_status.Checked.ToString();
                string sienos_spalva = sienos_spalva_list.SelectedValue;
                string sienos_medis = sienos_medis_list.SelectedValue;

                string kaminas = kaminas_status.Checked.ToString();
                string stogo_spalva = stogo_spalva_list.SelectedValue;
                string stogo_medis = stogo_medis_list.SelectedValue;

                // Pridejimas

                sienosAdapter.Insert(sienu_kiekis, sienu_dydis, anga, uzdengimas, sienos_spalva, sienos_medis);
                stogaiAdapter.Insert(kaminas, stogo_spalva, stogo_medis);

                // Adapters & Data

                var uzsakymaiAdapter = new DataSetTableAdapters.UzsakymaiTableAdapter();
                var sienos = sienosAdapter.GetData();
                var stogai = stogaiAdapter.GetData();

                // Pasirinkimai

                DateTime today = DateTime.Today;
                string busena = "Laukiama";
                int siena = 0;
                foreach (var item in sienos)
                {
                    siena = item.Id;
                }
                int stogas = 0;
                foreach (var item in stogai)
                {
                    stogas = item.Id;
                }
                string klientas = Session["Name"].ToString();
                double sienuKaina = SienosKaina();
                double stogoKaina = StogoKaina();
                double irangosKaina = IrangosKaina();
                double papildomuKaina = PapildomuKaina();
                double bendraKaina = sienuKaina + stogoKaina + irangosKaina + papildomuKaina;
                DateTime preliminari_data = SkaiciuotiData(out double zmogvalandes);

                // Pridejimas

                uzsakymaiAdapter.Insert(today, busena, siena, stogas, klientas, bendraKaina, preliminari_data);

                // Adapters & Data

                var itraukimaiAdapter = new DataSetTableAdapters.ItraukimaiTableAdapter();
                var priskyrimaiAdapter = new DataSetTableAdapters.PriskyrimaiTableAdapter();
                var uzimtumaiAdapter = new DataSetTableAdapters.UzimtumaiTableAdapter();
                var uzsakymai = uzsakymaiAdapter.GetData();

                // Pasirinkimai & Pridejimas

                int uzsakymas_a = 0;
                int uzsakymas_i = 0;
                int uzsakymas = 0;
                foreach (var item in uzsakymai)
                {
                    uzsakymas_a = item.Id;
                    uzsakymas_i = item.Id;
                    uzsakymas = item.Id;
                }
                foreach (ListItem item in atributai_list.Items)
                {
                    string atributas = " ";
                    int itraukimai_kiekis = 0;
                    string komentaras = "Blank";
                    if (item.Selected)
                    {
                        atributas = item.Value;
                        itraukimai_kiekis = 1;
                        itraukimaiAdapter.Insert(uzsakymas_a, atributas, itraukimai_kiekis, komentaras);
                    }
                }
                foreach (ListItem item in irangos_list.Items)
                {
                    string iranga = " ";
                    int priskyrimai_kiekis = 0;
                    if (item.Selected)
                    {
                        iranga = item.Value;
                        priskyrimai_kiekis = 1;
                        priskyrimaiAdapter.Insert(uzsakymas_i, iranga, priskyrimai_kiekis);
                    }
                }

                uzimtumaiAdapter.Insert(zmogvalandes, uzsakymas);

            }
        }
    }

}