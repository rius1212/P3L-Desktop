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
    public partial class User : Form
    {
        public static int tipex;
        public User()
        {
            InitializeComponent();
        }

        private void kelolaPegawaiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kelolaSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AtmaAuto peg = new AtmaAuto();
            peg.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tipex = 1;
           transaksiFormJs peg = new transaksiFormJs();
            peg.Show();
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            transaksiSp peg = new transaksiSp();
            peg.Show();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tipex = 2;
            TransaksiForm peg = new TransaksiForm();
            peg.Show();
        }

        private void User_Load(object sender, EventArgs e)
        {
            datelbl.Text = DateTime.Now.ToLongDateString();
            timelbl.Text = DateTime.Now.ToLongTimeString();
            label2.Text = AtmaAuto.namas;
        }
        private void timerup_Tick(object sender, EventArgs e)
        {
            timelbl.Text = DateTime.Now.ToLongTimeString();
            timerup.Start();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin Log Out ?", "LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                AtmaAuto peg = new AtmaAuto();
                AtmaAuto.log = "LogOut";
                peg.Show();
                this.Hide();
                MessageBox.Show("Berhasil Log Out !");
            }
            else
            {
                MessageBox.Show("Batal Log Out", "LOG OUT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            ChangeStatusForm peg = new ChangeStatusForm();
            peg.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            EditProfile peg = new EditProfile();
            peg.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            CekRiwayat peg = new CekRiwayat();
            peg.Show();
        }
    }
}
