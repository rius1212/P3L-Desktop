using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtmaAuto
{
    public partial class LaporanForm : Form
    {
        public LaporanForm()
        {
            InitializeComponent();
        }

        private void LaporanForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SpTerlaris st = new SpTerlaris();
            st.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PendapatanBln pb = new PendapatanBln();
            pb.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PendapatanTahunForm pb = new PendapatanTahunForm();
            pb.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PengeluaranForm pg = new PengeluaranForm();
            pg.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PenJasaForm jas = new PenJasaForm();
            jas.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SisaStokForm st = new SisaStokForm();
            st.Show();
        }
    }
}
