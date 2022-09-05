using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
//using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Clientura_pro
{
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// 
    /// 
    /// 
    /// 
    /// Ez a projekt egyelőre a fejlesztés kezdeti szakaszán áll. .
    /// A végcél egy ügyvédi ügyviteli szoftver létrehozása, amely a szakmai és adminisztratív ügyvédi feladatok ellátását teljeskörűen
    /// támogatja.
    /// Messze nem került még kialakításra az összes funkció és a meglévőket is
    /// hatékonyabbá kell tenni
    /// A jelen közzététel célja kizárólag egy saját mssql, Microsoft Visual Studio, C#, .net keretrendszerbeli fejlesztésem
    /// bemutatása szakmai érdeklődők számára.
    /// Az adatbázis koncepcióját ezen ügyvédi irodai honlap jogszabályoknak megfelelő, nyilvántartási kötelezettségekre vonatkozó
    /// részletes tájékoztatója határozza meg:
    /// https://www.bdolegal.hu/hu-hu/legal-privacy-hu/adatkezelesi-tajekoztato
    /// További részletes, az ügyadatokat átláthatóvá tevő kereső rendszer, dokumentum rendszerező funkciók, precíz
    /// határidőnapló és postakönyv kidolgozása tervben van. Csakúgy a felhasználók általi testreszabás és egymás közti üzenetváltás,
    /// jegyzetelés lehetőségének megteremtése, összeférhetetlenség vizsgáló modul kialakítása.
    /// Tanácsokat, véleményeket köszönettel fogadok.
    /// 
    /// 
    /// 
    /// Budapest, 2022. szeptember 5.
    /// 
    /// Üdvözlettel
    /// 
    /// dr. Somogyi Ábel
    /// 
    /// a Clientura_pro alkalmazás fejlesztője
    /// 
    /// email cím: somogyiabel1987@gmail.com
    /// 
    /// 
    /// 
    /// 
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kilép a programból?", "Kilépés", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void minimize_button1_Click(object sender, EventArgs e)
        {
            //szintén 'kis méret' gomb
            this.WindowState = FormWindowState.Minimized;
        }

        public void get_time()
        {
            this.pontosidő_label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            get_time();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //pontos idő és naptár betöltése
            get_time();
            get_calendar();
            //verzió és fejlesztő betöltése alsó sorba
            this.verzió_label2.Text = Application.ProductVersion;
            this.company_label2.Text = Application.CompanyName;
        }
        public void get_calendar()
        {
            try
            {
                System.Globalization.GregorianCalendar g = new System.Globalization.GregorianCalendar();
                this.év_label1.Text = g.GetYear(DateTime.Now).ToString();
             
                this.nap_label3.Text = g.GetDayOfMonth(DateTime.Now).ToString();
                this.hét_napja_label4.Text = g.GetDayOfWeek(DateTime.Now).ToString();
                
                //eredetileg angol nyelvű napneveket magyarra kell átírni

                if (this.hét_napja_label4.Text == "Monday")
                {
                    this.hét_napja_label4.Text = "Hétfő";
                }

                if (this.hét_napja_label4.Text == "Tuesday")
                {
                    this.hét_napja_label4.Text = "Kedd";
                }

                if (this.hét_napja_label4.Text == "Wednesday")
                {
                    this.hét_napja_label4.Text = "Szerda";
                }

                if (this.hét_napja_label4.Text == "Thursday")
                {
                    this.hét_napja_label4.Text = "Csütörtök";
                }

                if (this.hét_napja_label4.Text == "Friday")
                {
                    this.hét_napja_label4.Text = "Péntek";
                }

                if (this.hét_napja_label4.Text == "Saturday")
                {
                    this.hét_napja_label4.Text = "Szombat";
                }

                if (this.hét_napja_label4.Text == "Sunday")
                {
                    this.hét_napja_label4.Text = "Vasárnap";
                }
                //----------------------------------------------------------------
                Int32 m;
                string mnum;
                mnum = g.GetMonth(DateTime.Now).ToString();
                Int32.TryParse(mnum, out m);
                //-----------------------------------------------------------

                //hónap nevének beíratása
                this.hónap_label2.Text = month_num_to_name(m);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string month_num_to_name(Int32 month_num)
        {


            string mn;

            switch (month_num)
            {
                case 1:
                    mn = "Január";
                    break;

                case 2:
                    mn = "Február";
                    break;

                case 3:
                    mn = "Március";
                    break;

                case 4:
                    mn = "Április";
                    break;
                case 5:
                    mn = "Május";
                    break;

                case 6:
                    mn = "Június";
                    break;

                case 7:
                    mn = "Július";
                    break;

                case 8:
                    mn = "Augusztus";
                    break;

                case 9:
                    mn = "Szeptember";
                    break;

                case 10:
                    mn = "Október";
                    break;

                case 11:
                    mn = "November";
                    break;

                case 12:
                    mn = "December";
                    break;

                default:
                    mn = "Unknown";
                    break;
            }
            return mn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //a 'kis méret' gomb
            this.WindowState = FormWindowState.Minimized;
        }

        


        //a toolstrip menüből az űrlap-formok megnyitásai
        
        
        private void jogiSzemélyekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ügyleti_nyilv_jsz frm5 = new Ügyleti_nyilv_jsz();
                frm5.MdiParent = this;
                frm5.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void jSzKépviselőjénekOkmánymásolataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void adatokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Tsz_ügyfél_azonosítás frm2 = new Tsz_ügyfél_azonosítás();
                frm2.MdiParent = this;
                frm2.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void ííarcképÉsAláírásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clientura_pro.Tsz_üf_arckep_alairas frm3 = new Tsz_üf_arckep_alairas();
                frm3.MdiParent = this;
                frm3.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void verzió_label2_Click(object sender, EventArgs e)
        {

        }

        private void természetesSzemélyekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ügyleti_nyilv_t_szem frm4 = new Ügyleti_nyilv_t_szem();
                frm4.MdiParent = this;
                frm4.Show();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void ügyletiNyilvántartásToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void természetesSzemélyÜgyfélAdataiToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            //az adott form összes korábbi adata időponttal
                változásjegyzék_tsz_üf_adatai frm6 = new változásjegyzék_tsz_üf_adatai();
                frm6.MdiParent = this;
            frm6.Show();
            
        }
    }
}
