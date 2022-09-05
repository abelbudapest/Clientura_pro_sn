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
    public partial class Ügyleti_nyilv_t_szem : Form
    {
        public Ügyleti_nyilv_t_szem()
        {
            InitializeComponent();
        }

        private void kötelező_jogi_képv_ügyletekről_tsz_nytBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ügyfél_ds);

        }

        private void Ügyleti_nyilv_t_szem_Load(object sender, EventArgs e)
        {
            try
            {
            // TODO: This line of code loads data into the 'ügyfél_ds.kötelező_jogi_képv_ügyletekről_tsz_nyt' table. You can move, or remove it, as needed.
            this.kötelező_jogi_képv_ügyletekről_tsz_nytTableAdapter.Fill(this.ügyfél_ds.kötelező_jogi_képv_ügyletekről_tsz_nyt);
            this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingSource.Filter = "ügyfél_id=-123";

            //tehát mindent betöltött, de egy teljesíthetetlen szűrési feltétel (-123) miatt nem láthatóak még az adatok
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
            //
            //controlok szabályozása ütközések elkerüléséért
            this.mentés_button4.Enabled = false;
            this.visszavon_button5.Enabled = false;
            //
            this.groupBox1.Enabled = false;
            this.kötelező_jogi_képv_ügyletekről_tsz_nytDataGridView.Enabled = false;
            //
            this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingNavigator.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.mentés_button4.Enabled == true)
            {
                if (MessageBox.Show("Nem mentette a megnyitott folyamatot. Kilép?", "Bezárás mentés nélkül", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //Hogy ne zárja be véletlenül mentés nélkül.
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

        private void minimize_button1_Click(object sender, EventArgs e)
        {
            //kis méret
            this.WindowState = FormWindowState.Minimized;
        }

        void mentés_visszav_gombok() //gombok lenyomására funkció
        {
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
            this.kötelező_jogi_képv_ügyletekről_tsz_nytDataGridView.Enabled = false;
            this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingNavigator.Enabled = true;
        }
        void új_szerk_töröl_gombok()  //gombok lenyomására funkció
        {
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
            this.kötelező_jogi_képv_ügyletekről_tsz_nytDataGridView.Enabled = false;
            this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingNavigator.Enabled = false;
        }

        private void szerk_button2_Click(object sender, EventArgs e)
        {
            Int32 rc;
            rc = this.ügyfél_ds.kötelező_jogi_képv_ügyletekről_tsz_nyt.Rows.Count;

            if (rc == 0) // ha nem választott a felhasználó sort
            {
                MessageBox.Show("Kérem válasszon egy szerkesztendő sort!");
                return;
            }
            új_szerk_töröl_gombok();
        }

        private void törl_button3_Click(object sender, EventArgs e)
        {
            Int32 rc;

            try
            {
                rc = this.ügyfél_ds.kötelező_jogi_képv_ügyletekről_tsz_nyt.Rows.Count;

                if (rc == 0) // ha nem választott a felhasználó sort
                {
                    MessageBox.Show("Kérem válasszon egy törlendő sort!"); 
                    return;
                }

                új_szerk_töröl_gombok();

                this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingSource.RemoveCurrent();
                //ezzel eltávolítja, de külön még menteni kell
                this.groupBox1.Enabled = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
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
                if (this.pmt_szerinti_adatokTextBox.Text != "A Pmt-ben meghatározott adatok kitöltése már megtörtént")
                {
                    MessageBox.Show("Ajánlott a Pénzmosásról szóló törvény szerinti ügyfél-átvilágítás űrlapjával folytatnia a kitöltést", "Figyelmeztetés");
                }
                try
                {
                    mentés_visszav_gombok(); //gomb funkció hívása
                    this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingSource.EndEdit();
                    //
                    Int32 r;
                    r = this.kötelező_jogi_képv_ügyletekről_tsz_nytTableAdapter.Update(ügyfél_ds.kötelező_jogi_képv_ügyletekről_tsz_nyt);

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

        private void visszavon_button5_Click(object sender, EventArgs e)
        {
            mentés_visszav_gombok(); //gomb funkció hívása
            //
            this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingSource.CancelEdit();
            this.ügyfél_ds.kötelező_jogi_képv_ügyletekről_tsz_nyt.RejectChanges();
            this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingNavigator.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // a szűrő eltávolítása miatt lesz látható az egyébként az sql db-ből már betöltött egész adatsor
            // ebbe az sql táblába is triggerrel vannak átküldve alapadatok a természetes személyek táblájából
            this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingSource.RemoveFilter();
        }

        private void keresés_button_Click(object sender, EventArgs e)
        {
            this.keresés_panel.Visible = true;
        }

        private void ker_panel_elrejt_button_Click(object sender, EventArgs e)
        {
            //a keresőpanel elrejtésekor
            this.gép_közben_checkBox.Checked = false;
            this.keresés_panel.Visible = false; //nem szabad bejelölve maradnia, mert akkor a következő resettextek miatt újratölti
            //szűretlenül az adatsort
            this.keres_id_textBox.ResetText();
            this.keres_ügyaz_textBox.ResetText();
            this.keres_ügyfcs_textBox.ResetText();
            this.keres_ügyfutn_textBox.ResetText();
        }

        private void keres_id_Button_Click(object sender, EventArgs e)
        {
            try
            {
                //id alapján szűr, ennél a like operátor nem használható
                this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingSource.Filter = "ügyfél_id=" + this.keres_id_textBox.Text;
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
                //ügyaznosító alapján szűr, like, tehát ha tartalmaz karaktert már kiadja
                this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingSource.Filter = "ügyvédi_ügyazonosító like '%" + this.keres_ügyaz_textBox.Text + "%'";
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
                //családnév alapján szűr, like, tehát ha tartalmaz karaktert már kiadja
                this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingSource.Filter = "családi_név like '%" + this.keres_ügyfcs_textBox.Text + "%'";
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
                //utónév alapján szűr, like, tehát ha tartalmaz karaktert már kiadja
                this.kötelező_jogi_képv_ügyletekről_tsz_nytBindingSource.Filter = "utónév like '%" + this.keres_ügyfutn_textBox.Text + "%'";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog(); //válaszfájl kiválasztása dialógból
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

        //panelek láthatóvá tétele, bennük comboboxból a válasz kiválasztása. így pótoljuk az sql ENUM hiányát.
        //Textboxok readonly-k, csak a felkínált választ adhatja a felhasználó.
        //A comboboxok dropdownlistek ugyanezért, kivéve az állampolgárit. Az dropdown, hogy pl
        // a kettős állampolgárságot is fel lehessen tüntetni
        //az állampolgárság kiválasztáshoz egyelőre csak angol nyelvű nemzetlistát találtam

        private void állpolg_button_Click(object sender, EventArgs e)
        {
            this.állpolg_panel.Visible = true;
            this.állpolg_button.Enabled = false;
        }

        private void állpolg_kész_button_Click(object sender, EventArgs e)
        {
            this.állampolgárság_stbTextBox.Text = this.állpolg_comboBox.Text;
            this.állpolg_panel.Visible = false;
            this.állpolg_button.Enabled = true;
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

        private void keres_ügyfutn_textBox_TextChanged(object sender, EventArgs e)
        {
            if (this.gép_közben_checkBox.Checked == true)
            {
                keres_ügyfutn_button_Click(sender, e);
            }
        }

        //a Válasz módosítása lenyomásával láthatóvá válik egy amúgy rejtett combobox, amelyből a felhasználó kiválasztja a
        // az elvárt válaszok közül valemlyiket, a Kész gombbal beíratja a vonatkozó Readonly textboxba. Így történik az mssql-ből hiányzó 
        //ENUM kiváltása
        private void pmt_button_Click(object sender, EventArgs e)
        {
            this.pmt_panel.Visible = true;
            this.pmt_button.Enabled = false;
        }

        private void pmt_kész_button_Click(object sender, EventArgs e)
        {
            this.pmt_szerinti_adatokTextBox.Text = this.pmt_comboBox.Text;
            this.pmt_panel.Visible = false;
            this.pmt_button.Enabled = true;
        }
    }


}
