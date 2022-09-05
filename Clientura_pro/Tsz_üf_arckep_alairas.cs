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
    public partial class Tsz_üf_arckep_alairas : Form
    {
        public Tsz_üf_arckep_alairas()
        {
            InitializeComponent();
        }


        private void Tsz_ügyfél_arckep_alairas_Load(object sender, EventArgs e)
        {
            //controlok kezdő státuszának meghatározása

            this.mentés_button4.Enabled = false;
            this.visszavon_button5.Enabled = false;
            //
            this.groupBox1.Enabled = false;
            this.ügyfél_természetes_személyazonosító_adatok_arck_aláíDataGridView.Enabled = false;
            //
            this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingNavigator.Enabled = true;

        }
        void új_szerk_töröl_gombok() 
        {
            //az adott gombok kattintási eseményeihez funkció

            this.új_button1.Enabled = false;
            this.szerk_button2.Enabled = false;
            this.törl_button3.Enabled = false;
            //
            this.mentés_button4.Enabled = true;
            this.visszavon_button5.Enabled = true;
            this.keresés_button.Enabled = false;
            this.button5.Enabled = false;
            //
            this.groupBox1.Enabled = true;
            this.ügyfél_természetes_személyazonosító_adatok_arck_aláíDataGridView.Enabled = false;
            this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingNavigator.Enabled = false;
        }

        private void mentés_button4_Click(object sender, EventArgs e)
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
                //az adott gombok kattintási eseményeihez funkció
                mentés_visszav_gombok();

                //a két képfájl választó openfiledialog szabályozása
                string arc_fájlnév;
                arc_fájlnév = this.openFileDialog_kép.FileName;


                string alá_fájlnév;
                alá_fájlnév = this.openFileDialog_aláírás.FileName;


                try
                {
                    if (arc_fájlnév == "openFileDialog2")
                    {
                        MessageBox.Show("Nincs kiválasztott arckép fájl!");
                        return;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


                try
                {
                    if (alá_fájlnév == "openFileDialog2")
                    {
                        MessageBox.Show("Nincs kiválasztott aláírásminta fájl!");
                        return;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


                // képek konvertálása binary-be, mert az sql táblában varbinary(max) lesz az adattípusa
                byte[] img_arck;
                img_arck = System.IO.File.ReadAllBytes(arc_fájlnév);
                //----------------
                byte[] img_aláí;
                img_aláí = System.IO.File.ReadAllBytes(alá_fájlnév);

                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                try
                {
                    this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingSource.EndEdit();

                    //a mentés sikerességét az sql táblába, a mentett sorok számának megadásával közöljük, ha az > 0
                    Int32 r;
                    r = this.ügyfél_természetes_személyazonosító_adatok_arck_aláíTableAdapter.Update(ügyfél_ds.ügyfél_természetes_személyazonosító_adatok_arck_aláí);

                    if (r > 0)
                    {
                        MessageBox.Show("Mentve. " + "Mentett sorok száma: " + r.ToString());
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

       
       

      
        void mentés_visszav_gombok()
        {
            //az adott gombok kattintási eseményeihez funkció

            this.új_button1.Enabled = true;
            this.szerk_button2.Enabled = true;
            this.törl_button3.Enabled = true;
            //
            this.mentés_button4.Enabled = false;
            this.visszavon_button5.Enabled = false;
            this.keresés_button.Enabled = true;
            this.button5.Enabled = true;
            //
            this.groupBox1.Enabled = false;
            this.ügyfél_természetes_személyazonosító_adatok_arck_aláíDataGridView.Enabled = false;
            this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingNavigator.Enabled = true;
        }


       

        private void új_button1_Click_1(object sender, EventArgs e)
        {
            //az adott gombok kattintási eseményeihez funkció
            új_szerk_töröl_gombok();
            //ezen a formon az 'Új' láthatatlan, mert ez csak járuléka az Adatok formnak, ahonnan triggerrel jönnek át
            //az itt látható adatok

            try
            {
                //mssql tábla nevéhez
                this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingSource.AddNew();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void szerk_button2_Click_1(object sender, EventArgs e)
        {
            Int32 rc;
            try
            {
                //dataset > mssql tábla > sorok száma
                rc = this.ügyfél_ds.ügyfél_természetes_személyazonosító_adatok_arck_aláí.Rows.Count;

                if (rc == 0) //ha a felhasználó nem választott sort
                {
                    MessageBox.Show("Kérem válasszon egy szerkesztendő sort!");
                    return;


                }

                új_szerk_töröl_gombok(); //gomb események
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void törl_button3_Click_1(object sender, EventArgs e)
        {
            Int32 rc;
            try
            {
                rc = this.ügyfél_ds.ügyfél_természetes_személyazonosító_adatok_arck_aláí.Rows.Count;

                if (rc == 0) //ha a felhasználó nem választott sort
                {
                    MessageBox.Show("Kérem válasszon egy törlendő sort!");
                    return;
                }

                új_szerk_töröl_gombok(); //az adott gombok kattintási eseményeihez funkció

                //ezzel távolítja el, de utána mentenie is kell!

                this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingSource.RemoveCurrent();
                this.groupBox1.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void visszavon_button5_Click_1(object sender, EventArgs e)
        {
            mentés_visszav_gombok(); //gomb események
            //
            try
            {
                this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingSource.CancelEdit();
                this.ügyfél_ds.ügyfél_természetes_személyazonosító_adatok_arck_aláí.RejectChanges();
                this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingNavigator.Enabled = true;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Tsz_üf_arckep_alairas_Load(object sender, EventArgs e)
        {
           
            try
            {
                // TODO: This line of code loads data into the 'ügyfél_ds.ügyfél_természetes_személyazonosító_adatok_arck_aláí' table. You can move, or remove it, as needed.
                this.ügyfél_természetes_személyazonosító_adatok_arck_aláíTableAdapter.Fill(this.ügyfél_ds.ügyfél_természetes_személyazonosító_adatok_arck_aláí);
                //triggerrel jönnek át a term. személyek táblájából
                this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingSource.Filter = "id=-123";

                //tehát mindent betöltött, de egy teljesíthetetlen szűrési feltétel (-123) miatt nem láthatóak még az adatok

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
            this.ügyfél_természetes_személyazonosító_adatok_arck_aláíDataGridView.Enabled = false;
            //
            this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingNavigator.Enabled = true;
        }

        private void minimize_button1_Click(object sender, EventArgs e)
        {
            //kis méret
            this.WindowState = FormWindowState.Minimized;
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            //Bezárás gomb

            if (this.mentés_button4.Enabled == true)
            {
                //hogy ne zárja be véletlenül mentés nélkül
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
            //szövegfájl kiválasztása, annak elérési útját lehet menteni
            this.openFileDialog1.ShowDialog();
            string fájlnév;
            fájlnév = this.openFileDialog1.FileName;
            if (fájlnév == "openFileDialog1")
            {
                MessageBox.Show("Nincs kiválasztott fájl."); //különben hibaüzenettel leállna, ha
                                                             //kiválasztás nélkül bezártuk a párbeszédet
                return;
            }
            this.aláírásmint_ügyv_nyilTextBox.Text = this.openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //megnyitja a fájlt a textboxban levő elérési úton, ha az már nem létezik, hibaüzenetet küld
                this.process1.StartInfo = new System.Diagnostics.ProcessStartInfo(this.aláírásmint_ügyv_nyilTextBox.Text);
                this.process1.Start();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void arcképfájl_Click(object sender, EventArgs e)
        {
            try
            {
                //képfájl kiválasztó párbeszédablak
                this.openFileDialog_kép.ShowDialog();
                string fájlnév;
                fájlnév = this.openFileDialog_kép.FileName;
                if (fájlnév == "openFileDialog2")
                {
                    this.arckép_pictureBox.Image = Clientura_pro.Properties.Resources.nincs_kép;
                    //figyelmeztető kép, hogy nem lett képfájl még kiválasztva
                    return;
                }
            this.arckép_pictureBox.Image = Image.FromFile(fájlnév);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            
            
            
        }

        

        private void al_minta_button_Click(object sender, EventArgs e)
        {
            try
            {
            //aláírásminta képfájl kiválasztása
                this.openFileDialog_aláírás.ShowDialog();
            string fájlnév;
            fájlnév = this.openFileDialog_aláírás.FileName;
            if (fájlnév == "openFileDialog2")
            {
                this.aláírásminta_pictureBox.Image = Clientura_pro.Properties.Resources.nincs_kép;
                return; //figyelmeztető kép, hogy nem lett képfájl még kiválasztva
            }

            this.aláírásminta_pictureBox.Image = Image.FromFile(fájlnév);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
           ;
        }

    

        private void openFileDialog_kép_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ker_panel_elrejt_button_Click(object sender, EventArgs e)
        {
            //a keresőpanel elrejtésekor
            this.gép_közben_checkBox.Checked = false; //nem szabad bejelölve maradnia, mert akkor a következő resettextek miatt újratölti
            //szűretlenül az adatsort

            this.keresés_panel.Visible = false; //és a következő megnyitáskor(láthatóvá tételkor) üres mezőkbe írhatunk
            this.keres_id_textBox.ResetText();
            this.keres_ügyaz_textBox.ResetText();
            this.keres_ügyfcs_textBox.ResetText();
            
        }

        private void keres_id_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //id alapján szűr, ennél a like operátor nem használható
                this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingSource.Filter = "id=" + this.keres_id_textBox.Text;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void keres_ügyaz_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //ügyaznosító alapján szűr
                this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingSource.Filter = "ügyvédi_ügyazonosító like '%" + this.keres_ügyaz_textBox.Text + "%'";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void keres_ügyfcs_button_Click(object sender, EventArgs e)
        {
            try
            {
                //valójában ügyfél teljes neve alapján szűr
                this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingSource.Filter = "ügyfél_teljes_neve like '%" + this.keres_ügyfcs_textBox.Text + "%'";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // a szűrő eltávolítása miatt lesz látható az egyébként az sql db-ből már betöltött egész adatsor
           //triggerrel jönnek át a term. személyek táblájából
            this.ügyfél_természetes_személyazonosító_adatok_arck_aláíBindingSource.RemoveFilter();
        }

        private void keresés_button_Click(object sender, EventArgs e)
        {
            this.keresés_panel.Visible = true;
        }

        //a következő textchanged-k a szűrésnek már a gépelés alatti folyamatos végrehajtását biztosítják
        
        private void keres_id_textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.gép_közben_checkBox.Checked == true)
            {
                keres_id_Button_Click(sender, e);
            }
        }

        private void keres_ügyaz_textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.gép_közben_checkBox.Checked == true)
            {
                keres_ügyaz_Button_Click(sender, e);
            }
        }

        private void keres_ügyfcs_textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.gép_közben_checkBox.Checked == true)
            {
                keres_ügyfcs_button_Click(sender, e);
            }
        }
    }
}
