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
    public partial class változásjegyzék_tsz_üf_adatai : Form
    {
        public változásjegyzék_tsz_üf_adatai()
        {
            InitializeComponent();
        }

        private void változásjegyzék_ügyfél_természetes_személyazonosító_adatokBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.változásjegyzék_ügyfél_természetes_személyazonosító_adatokBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ügyfél_ds);

        }

        private void változásjegyzék_tsz_üf_adatai_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ügyfél_ds.változásjegyzék_ügyfél_természetes_személyazonosító_adatok' table. You can move, or remove it, as needed.
            this.változásjegyzék_ügyfél_természetes_személyazonosító_adatokTableAdapter.Fill(this.ügyfél_ds.változásjegyzék_ügyfél_természetes_személyazonosító_adatok);

        }
    }
}
