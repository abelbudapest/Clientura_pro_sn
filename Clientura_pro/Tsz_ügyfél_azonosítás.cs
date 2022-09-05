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
    public partial class Tsz_ügyfél_azonosítás : Form
    {
        public Tsz_ügyfél_azonosítás()
        {
            InitializeComponent();
        }
      

        private void Tsz_ügyfél_azonosítás_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'ügyfél_ds.ügyfél_természetes_személyazonosító_adatok' table. You can move, or remove it, as needed.
                this.ügyfél_természetes_személyazonosító_adatokTableAdapter.Fill(this.ügyfél_ds.ügyfél_természetes_személyazonosító_adatok);
                this.ügyfél_természetes_személyazonosító_adatokBindingSource.Filter = "ügyfél_id=-123";

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
            this.ügyfél_természetes_személyazonosító_adatokDataGridView.Enabled = false;
            //
            this.ügyfél_természetes_személyazonosító_adatokBindingNavigator.Enabled = true;

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
            this.button1.Enabled = false;
            //
            this.groupBox1.Enabled = true;
            this.ügyfél_természetes_személyazonosító_adatokDataGridView.Enabled = false;
            this.ügyfél_természetes_személyazonosító_adatokBindingNavigator.Enabled = false;
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
                          || (textbox.Text.ToLower().Contains("*/") == true) || (textbox.Text.ToLower().Contains("xp_")==true)
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
            if (vtk==true)
            {
                MessageBox.Show("Tiltott karakter vagy szó!");
            }
            else
            {
                //-------------------------------------------------------------------------------------------------------------------------
                try
                {
                    mentés_visszav_gombok();
                    this.ügyfél_természetes_személyazonosító_adatokBindingSource.EndEdit();
                    //
                    Int32 r;
                    r = this.ügyfél_természetes_személyazonosító_adatokTableAdapter.Update(ügyfél_ds.ügyfél_természetes_személyazonosító_adatok);

                    //a mentés sikerességét az sql táblába, a mentett sorok számának megadásával közöljük, ha az > 0
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

        private void közhiteles_nyilvántartásba_való_bejegyzésre_irányuló_eljárásbanLabel_Click(object sender, EventArgs e)
        {

        }

        private void új_button1_Click(object sender, EventArgs e)
        {
            új_szerk_töröl_gombok(); //gombok funkciójának hívása
            this.ügyfél_természetes_személyazonosító_adatokBindingSource.AddNew();
            //a táblában új sor megkezdése
            

        }

        private void szerk_button2_Click(object sender, EventArgs e)
        {
            Int32 rc;
            rc = this.ügyfél_ds.ügyfél_természetes_személyazonosító_adatok.Rows.Count;

            if (rc==0) //ha nem választott sort
            {
                MessageBox.Show("Kérem válasszon egy szerkesztendő sort!");
                return;
            }
            új_szerk_töröl_gombok(); //ha megkezdhette a szerkesztést, ez a funkció legyen végrehajtva

            
        }

        private void törl_button3_Click(object sender, EventArgs e)
        {
            Int32 rc;

            try
            {
                rc = this.ügyfél_ds.ügyfél_természetes_személyazonosító_adatok.Rows.Count;

                if (rc == 0) //ha nem választott sort
                {
                    MessageBox.Show("Kérem válasszon egy törlendő sort!");
                    return;
                }

                új_szerk_töröl_gombok();

                this.ügyfél_természetes_személyazonosító_adatokBindingSource.RemoveCurrent();
                //ezzel eltávolítja, de külön még menteni kell
                this.groupBox1.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
            this.button1.Enabled = true;
            //
            this.groupBox1.Enabled = false;
            this.ügyfél_természetes_személyazonosító_adatokDataGridView.Enabled = false;
            this.ügyfél_természetes_személyazonosító_adatokBindingNavigator.Enabled = true;
        }

        private void visszavon_button5_Click(object sender, EventArgs e)
        {
            mentés_visszav_gombok();
            //
            //minden Új, szerk. és törlés visszavonható mentés nélkül
            this.ügyfél_természetes_személyazonosító_adatokBindingSource.CancelEdit();
            this.ügyfél_ds.ügyfél_természetes_személyazonosító_adatok.RejectChanges();
            this.ügyfél_természetes_személyazonosító_adatokBindingNavigator.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // a szűrő eltávolítása miatt lesz látható az egyébként az sql db-ből már betöltött egész adatsor
            this.ügyfél_természetes_személyazonosító_adatokBindingSource.RemoveFilter();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //dokumentumfájl kiválasztása párbeszéddel
            this.openFileDialog1.ShowDialog();
            string fájlnév;
            fájlnév = this.openFileDialog1.FileName;
            if (fájlnév== "openFileDialog1")
            {
                MessageBox.Show("Nincs kiválasztott fájl."); //hogy ne dobjon le hibaüzenettel, ha
                                                             //kiválasztás nélkül bezártuk a párbeszédet
                return;
            }
            this.válasz_fájljaTextBox.Text = this.openFileDialog1.FileName;
        }

        private void minimize_button1_Click(object sender, EventArgs e)
        {
            //kis méret - bár ez most láthatatlan
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.mentés_button4.Enabled==true)
            {
                if (MessageBox.Show("Nem mentette a megnyitott folyamatot. Kilép?", "Bezárás mentés nélkül", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //ne zárja be véletlenül mentés nélkül
                    this.Close();
                    this.Dispose();
                }
               
            }
            else
            {
                this.Close();
                this.Dispose(); //memória felszabadítás
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.process1.StartInfo = new System.Diagnostics.ProcessStartInfo(this.válasz_fájljaTextBox.Text);
                this.process1.Start();
                //megnyitja a dokfájlt amit kiválasztott, ha törölték: hibaüzenet
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }     

    
        //a Válasz módosítása lenyomásával láthatóvá válik egy amúgy rejtett combobox, amelyből a felhasználó kiválasztja a
        // az elvárt válaszok közül valemlyiket, a Kész gombbal beíratja a vonatkozó Readonly textboxba. Így történik az mssql-ből hiányzó 
        //ENUM kiváltása
        private void üfm_button_Click(object sender, EventArgs e)
        {
            this.üfm_panel.Visible = true;
            this.üfm_button.Enabled = false;
        }

        private void üfm_kész_button_Click(object sender, EventArgs e)
        {
            this.üfm_panel.Visible = false;
            this.üfm_button.Enabled = true;
            this.ügyfél_meghatalmazottja_jár_elTextBox.Text = this.comboBox1.Text;

        }

        private void ümell_button_Click(object sender, EventArgs e)
        {
            this.ümell_panel.Visible = true;
            this.ümell_button.Enabled = false;
        }

        private void ümell_kész_button_Click(object sender, EventArgs e)
        {
            this.ümell_panel.Visible = false;
            this.ümell_button.Enabled = true;
            this.az_ügyfél_külön_azonosítása_mellőzhető_mert_TextBox.Text = this.mellőzhető_comboBox.Text;
        }

        private void közhit1_button_Click(object sender, EventArgs e)
        {
            this.közhit1_panel.Visible = true;
            this.közhit1_button.Enabled = false;
        }

        private void közhit1_kész_button_Click(object sender, EventArgs e)
        {
            this.közhit1_panel.Visible = false;
            this.közhit1_button.Enabled = true;
            this.közhiteles_nyilvántartásba_való_bejegyzésre_irányuló_eljárásbanTextBox.Text = this.közhit1_combobox.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void közhit1_button_Click_1(object sender, EventArgs e)
        {
            this.közhit1_panel.Visible = true;
            this.közhit1_button.Enabled = false;
            
        }

        private void közhit2_button_Click(object sender, EventArgs e)
        {
            this.közhit2_panel.Visible = true;
            this.közhit2_button.Enabled = false;
        }

        private void közhit2_kész_button_Click(object sender, EventArgs e)
        {
            this.közhit2_panel.Visible = false;
            this.közhit2_button.Enabled = true;
            this.közhiteles_nyilvántartásba_szerkesztTextBox.Text = this.közhit2_comboBox.Text;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.segítség_panel.Visible = false;
        }

        //ezeknél a MouseHover-eknél láthatóvá válik egy láthatatlan Panel, ahol részletes információkat kap a kitöltő
        private void a1992_évi_LXVI_törvény_18Label_MouseHover(object sender, EventArgs e)
        {
            this.segítség_panel.Visible = true;
            this.segítség_textBox.Text = " a polgárok személyi adatainak és lakcímének nyilvántartásáról szóló 1992. évi LXVI. törvény 18. § (5) bekezdése szerinti tények";
        }

        private void a1998_évi_XII_törvény_24Label_MouseHover(object sender, EventArgs e)
        {
            this.segítség_panel.Visible = true;
            this.segítség_textBox.Text = "a külföldre utazásról szóló 1998. évi XII. törvény 24. § (1) bekezdés f) pontja szerinti adatok és az okmány érvényességi ideje";
        }

        private void a1999_évi_LXXXIV_törvény_8Label_MouseHover(object sender, EventArgs e)
        {
            this.segítség_panel.Visible = true;
            this.segítség_textBox.Text = " a közúti közlekedési nyilvántartásról szóló 1999. évi LXXXIV. törvény 8. § (1) bekezdés b) pont ba)-bb) alpontja szerinti adatok";
        }

        private void szabad_mozgás_és_tartózkodásLabel_MouseHover(object sender, EventArgs e)
        {
            this.segítség_panel.Visible = true;
            this.segítség_textBox.Text = " a szabad mozgás és tartózkodás jogával rendelkező személyek beutazásáról és tartózkodásáról szóló 2007.évi I.törvény 76. § d) pontja, 80. § (1) bekezdés b) és c) pontja, valamint a harmadik országbeli állampolgárok beutazásáról és tartózkodásáról szóló 2007.évi II.törvény 95. § (1) bekezdés g) pontja, 96. § (1) bekezdés g) pontja, továbbá 100. § (1) bekezdés b) és c) pontja szerinti adatok";
        }

        //a kövwetkező gombok lenyomásával közvetlenül interneten az adott törvény hatályos szövege nyitható meg
        private void button8_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://net.jogtar.hu/jogszabaly?docid=99200066.tv");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://net.jogtar.hu/jogszabaly?docid=99800012.tv");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://net.jogtar.hu/jogszabaly?docid=a0700001.tv");
        }

       

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://net.jogtar.hu/jogszabaly?docid=99900084.tv");
        }

        private void ügyfél_telefonszámaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            this.segítség_panel.Visible = false; //Segítség panel láthatatlanná tétele
        }

        private void szabad_mozgás_és_tartózkodásLabel_MouseHover_1(object sender, EventArgs e)
        {
            this.segítség_panel.Visible = true;
            this.segítség_textBox.Text = " a szabad mozgás és tartózkodás jogával rendelkező személyek beutazásáról és tartózkodásáról szóló 2007.évi I.törvény 76. § d) pontja, 80. § (1) bekezdés b) és c) pontja, valamint a harmadik országbeli állampolgárok beutazásáról és tartózkodásáról szóló 2007.évi II.törvény 95. § (1) bekezdés g) pontja, 96. § (1) bekezdés g) pontja, továbbá 100. § (1) bekezdés b) és c) pontja szerinti adatok";
        
    }

        private void button12_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://net.jogtar.hu/jogszabaly?docid=a0700002.tv");
        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://net.jogtar.hu/jogszabaly?docid=99200066.tv");
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://net.jogtar.hu/jogszabaly?docid=99800012.tv");
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://net.jogtar.hu/jogszabaly?docid=99900084.tv");
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://net.jogtar.hu/jogszabaly?docid=a0700001.tv");
        }

        private void keresés_button_Click(object sender, EventArgs e)
        {
            this.keresés_panel.Visible = true;
        }

        private void keres_id_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //id alapján szűr, ennél a like operátor nem használható
                this.ügyfél_természetes_személyazonosító_adatokBindingSource.Filter = "ügyfél_id=" + this.keres_id_textBox.Text;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
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
            this.keres_ügyfutn_textBox.ResetText();


        }

        private void keres_ügyaz_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //ügyaznosító alapján szűr, like, tehát ha tartalmaz karaktert már kiadja
                this.ügyfél_természetes_személyazonosító_adatokBindingSource.Filter = "ügyvédi_ügyazonosító like '%" + this.keres_ügyaz_textBox.Text+ "%'";
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
                //családnévre szűr, like, tehát ha tartalmaz karaktert már kiadja
                this.ügyfél_természetes_személyazonosító_adatokBindingSource.Filter = "családi_név like '%" + this.keres_ügyfcs_textBox.Text + "%'";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void keres_ügyfutn_button_Click(object sender, EventArgs e)
        {
            try
            {
                //utónévre szűr, like, tehát ha tartalmaz karaktert már kiadja
                this.ügyfél_természetes_személyazonosító_adatokBindingSource.Filter = "utónév like '%" + this.keres_ügyfutn_textBox.Text + "%'";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        //a következő textchanged-k a szűrésnek már a gépelés alatti folyamatos végrehajtását biztosítják
        private void keres_id_textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.gép_közben_checkBox.Checked==true)
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

        private void keres_ügyfutn_textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.gép_közben_checkBox.Checked == true)
            {
                keres_ügyfutn_button_Click(sender, e);
            }
        }

        // az állampolgárság kiválasztáshoz egyelőre csak angol nyelvű nemzetlistát találtam
        private void állpolg_button_Click(object sender, EventArgs e)
        {
            this.állpolg_panel.Visible = true;
            this.állpolg_button.Enabled = false;
        }

        private void állpolg_kész_button_Click(object sender, EventArgs e)
        {
            this.állpolg_panel.Visible = false;
            this.állpolg_button.Enabled = true;
            this.állampolgárság_stbTextBox.Text = this.állpolg_comboBox.Text;
        }
     
    }
}
