using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clientura_pro
{
    public partial class Ügyleti_nyilv_jsz : Form
    {
        public Ügyleti_nyilv_jsz()
        {
            InitializeComponent();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //
        //
        //
       //Ez a Form még nélkülözi a többiben már megismert Keresés panelt. Kidolgozásra vár még annak a megoldása (Normalization), hogy 
       // az "egy cégnek több képviselője van" hogyan legyen nyilvántartva (meglesz természetesen).
       //
       //
       //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void Ügyleti_nyilv_jsz_Load(object sender, EventArgs e)
        {
           
            try
            {
                // TODO: This line of code loads data into the 'ügyfél_ds.kötelező_jogi_képv_ügyletekről_jsz_nyt' table. You can move, or remove it, as needed.
                this.kötelező_jogi_képv_ügyletekről_jsz_nytTableAdapter.Fill(this.ügyfél_ds.kötelező_jogi_képv_ügyletekről_jsz_nyt);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            //controlok szabályozása ütközések elkerüléséért
            this.mentés_button4.Enabled = false;
            this.visszavon_button5.Enabled = false;
            //
            this.groupBox1.Enabled = false;
            this.kötelező_jogi_képv_ügyletekről_jsz_nytDataGridView.Enabled = false;
            //
            this.kötelező_jogi_képv_ügyletekről_jsz_nytBindingNavigator.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.mentés_button4.Enabled == true)
            {
                if (MessageBox.Show("Nem mentette a megnyitott folyamatot. Kilép?", "Bezárás mentés nélkül", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    this.Close();
                    this.Dispose(); //memória felszabadítás
                }

            }
            else
            {
                this.Close();
                this.Dispose(); //memória felszabadítás
            }
        }

        

     

        private void button2_Click(object sender, EventArgs e)
        {
            //válaszfájl kiválasztása dialógból
            this.openFileDialog1.ShowDialog();
            string fájlnév;
            fájlnév = this.openFileDialog1.FileName;
            if (fájlnév == "openFileDialog1")
            {
                MessageBox.Show("Nincs kiválasztott fájl."); //enélkül az if nélkül hibaüzenettel kidobna
                return;
            }
            this.válasz_eléréseTextBox.Text = this.openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.process1.StartInfo = new System.Diagnostics.ProcessStartInfo(this.válasz_eléréseTextBox.Text);
                this.process1.Start();
                //megnyitja a kiválasztott fájlt a textboxban írt elérési úton, ha törölték, hibaüzenettel megússzuk
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        void mentés_visszav_gombok()  //gombok lenyomására funkció
        {
            this.új_button1.Enabled = true;
            this.szerk_button2.Enabled = true;
            this.törl_button3.Enabled = true;
            //
            this.mentés_button4.Enabled = false;
            this.visszavon_button5.Enabled = false;
            //this.keresés_button.Enabled = true;
            //this.button1.Enabled = true;
            //
            this.groupBox1.Enabled = false;
            this.kötelező_jogi_képv_ügyletekről_jsz_nytDataGridView.Enabled = false;
            this.kötelező_jogi_képv_ügyletekről_jsz_nytBindingNavigator.Enabled = true;
        }

        void új_szerk_töröl_gombok()  //gombok lenyomására funkció
        {
            this.új_button1.Enabled = false;
            this.szerk_button2.Enabled = false;
            this.törl_button3.Enabled = false;
            //
            this.mentés_button4.Enabled = true;
            this.visszavon_button5.Enabled = true;
            //this.keresés_button.Enabled = false;
            //this.button1.Enabled = false;
            //
            this.groupBox1.Enabled = true;
            this.kötelező_jogi_képv_ügyletekről_jsz_nytDataGridView.Enabled = false;
            this.kötelező_jogi_képv_ügyletekről_jsz_nytBindingNavigator.Enabled = false;
        }

        private void új_button1_Click(object sender, EventArgs e)
        {
            új_szerk_töröl_gombok(); //gomb funkciók hívása
            this.kötelező_jogi_képv_ügyletekről_jsz_nytBindingSource.AddNew();
        }

        private void visszavon_button5_Click(object sender, EventArgs e)
        {
            mentés_visszav_gombok(); //gomb funkciók hívása
            //
            this.kötelező_jogi_képv_ügyletekről_jsz_nytBindingSource.CancelEdit();
            this.ügyfél_ds.kötelező_jogi_képv_ügyletekről_jsz_nyt.RejectChanges();
            this.kötelező_jogi_képv_ügyletekről_jsz_nytBindingNavigator.Enabled = true;
        }

        private void új_button1_Click_1(object sender, EventArgs e)
        {
            új_szerk_töröl_gombok(); //gomb funkciók hívása
            this.kötelező_jogi_képv_ügyletekről_jsz_nytBindingSource.AddNew();
        }

        private void szerk_button2_Click_1(object sender, EventArgs e)
        {
            Int32 rc;
            rc = this.ügyfél_ds.kötelező_jogi_képv_ügyletekről_jsz_nyt.Rows.Count;

            if (rc == 0) //ha nem választott sort
            {
                MessageBox.Show("Kérem válasszon egy szerkesztendő sort!");
                return;
            }
            új_szerk_töröl_gombok(); //gomb funkciók hívása
        }

        private void törl_button3_Click_1(object sender, EventArgs e)
        {
            Int32 rc;

            try
            {
                rc = this.ügyfél_ds.kötelező_jogi_képv_ügyletekről_jsz_nyt.Rows.Count;

                if (rc == 0) //ha nem választott sort
                {
                    MessageBox.Show("Kérem válasszon egy törlendő sort!");
                    return;
                }

                új_szerk_töröl_gombok(); //gomb funkciók hívása

                this.kötelező_jogi_képv_ügyletekről_jsz_nytBindingSource.RemoveCurrent();
                this.groupBox1.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void mentés_button4_Click_1(object sender, EventArgs e)
        {
            //sql injection elleni védekezés, van tiltott karakter ='vtk', minden textbox átszűrése, tolower hogy kis_nagybetű ne legyen gond
            Boolean vtk = new Boolean();

            foreach (Control gb in this.Controls.OfType<GroupBox>())
            {
                foreach (Control textbox in this.groupBox1.Controls.OfType<TextBox>())
                {
                    if (textbox is TextBox)
                    {
                        if ((textbox.Text.ToLower().Contains("'") == true) || (textbox.Text.ToLower().Contains(";") == true)
                          || (textbox.Text.ToLower().Contains("--") == true) || (textbox.Text.ToLower().Contains("/*") == true)
                          || (textbox.Text.ToLower().Contains("*/") == true) || (textbox.Text.ToLower().Contains("xp_") == true)
                          || (textbox.Text.ToLower().Contains("drop") == true) || (textbox.Text.ToLower().Contains("aux") == true)
                          || (textbox.Text.ToLower().Contains("clock$") == true) || (textbox.Text.ToLower().Contains("com1") == true)
                          || (textbox.Text.ToLower().Contains("com2") == true) || (textbox.Text.ToLower().Contains("com3") == true)
                          || (textbox.Text.ToLower().Contains("com4") == true) || (textbox.Text.ToLower().Contains("com5") == true)
                          || (textbox.Text.ToLower().Contains("com6") == true) || (textbox.Text.ToLower().Contains("com7") == true)
                          || (textbox.Text.ToLower().Contains("com8") == true) || (textbox.Text.ToLower().Contains("con") == true)
                          || (textbox.Text.ToLower().Contains("config$") == true) || (textbox.Text.ToLower().Contains("lpt1") == true)
                          || (textbox.Text.ToLower().Contains("lpt2") == true) || (textbox.Text.ToLower().Contains("lpt3") == true)
                          || (textbox.Text.ToLower().Contains("lpt4") == true) || (textbox.Text.ToLower().Contains("lpt5") == true)
                          || (textbox.Text.ToLower().Contains("lpt6") == true) || (textbox.Text.ToLower().Contains("lpt7") == true)
                          || (textbox.Text.ToLower().Contains("lpt8") == true) || (textbox.Text.ToLower().Contains("nul") == true)
                          || (textbox.Text.ToLower().Contains("prn.") == true))
                        {
                            vtk = true;
                        }
                    }
                }
            }
            if (vtk == true)
            {
                MessageBox.Show("Tiltott karakter vagy szó!");
            }
            else
            {
                if (this.pmt_szerinti_adatokTextBox.Text != "A Pmt-ben meghatározott adatok kitöltése már megtörtént")
                {
                    MessageBox.Show("Ajánlott a Pénzmosásról szóló törvény szerinti ügyfél-átvilágítás űrlapjával folytatnia a kitöltést", "Figyelmeztetés");
                }
                //Figyelmeztetés egy tartalmi kérdésben, ez az űrlap megköveteli egy másik kitöltését is, a sorrend tetszőleges maradt.
                try
                {
                    mentés_visszav_gombok(); //gombfunkció hívása
                    this.kötelező_jogi_képv_ügyletekről_jsz_nytBindingSource.EndEdit();
                    //
                    Int32 r;
                    r = this.kötelező_jogi_képv_ügyletekről_jsz_nytTableAdapter.Update(ügyfél_ds.kötelező_jogi_képv_ügyletekről_jsz_nyt);
                    
                    //a mentés sikerességét az sql táblába, a mentett sorok számának megadásával közöljük, ha az > 0

                    if (r > 0)
                    {
                        MessageBox.Show("Mentve. " + "Száma: " + r.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Nem történt mentés.");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void visszavon_button5_Click_1(object sender, EventArgs e)
        {
            mentés_visszav_gombok(); //gombfunkció hívása
            //
            this.kötelező_jogi_képv_ügyletekről_jsz_nytBindingSource.CancelEdit();
            this.ügyfél_ds.kötelező_jogi_képv_ügyletekről_jsz_nyt.RejectChanges();
            this.kötelező_jogi_képv_ügyletekről_jsz_nytBindingNavigator.Enabled = true;
        }

        //panelek láthatóvá tétele, bennük comboboxból a válasz kiválasztása. így pótoljuk az sql ENUM hiányát.
        //Textboxok readonly-k, csak a felkínált választ adhatja a felhasználó.
        //A comboboxok dropdownlistek ugyanezért, kivéve az állampolgárit. Az dropdown, hogy pl
        // a kettős állampolgárságot is fel lehessen tüntetni
        //az állampolgárság kiválasztáshoz egyelőre csak angol nyelvű nemzetlistát találtam

        private void pmt_button_Click(object sender, EventArgs e)
        {
            this.pmt_panel.Visible = true;
            this.pmt_button.Enabled = false;
        }

        private void pmt2_button_Click(object sender, EventArgs e)
        {
            //ez átnevezve pmt_kész_button-ra!
            this.pmt_button.Enabled = true;
            this.pmt_panel.Visible = false;
            this.pmt_szerinti_adatokTextBox.Text = this.pmt_comboBox.Text;

        }

        private void állpolg_button_Click(object sender, EventArgs e)
        {
            this.állp_panel.Visible = true;
            this.állpolg_button.Enabled = false;
        }

        private void állp_kész_button_Click(object sender, EventArgs e)
        {
            this.állp_panel.Visible = false;
            this.állpolg_button.Enabled = true;
            this.képv_állampolgárság_stbTextBox.Text = this.állp_comboBox.Text;

        }
    }
}