using AtmaAuto.ClassAA;
using MySql.Data.MySqlClient;
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
    public partial class AdminView : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public int pegWi;
        public static string nama=AtmaAuto.namas;
        public AdminView()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CabangForm peg = new CabangForm();

            peg.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 peg = new Form1();

            peg.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            JasaForm peg = new JasaForm();
            peg.Show();

        }
        public string LabelText
        {

            get
            {
                return this.lblnama.Text;
            }
            set
            {
                this.lblnama.Text = value;
            }
        }
        private void AdminView_Load(object sender, EventArgs e)
        {
            timerdate.Start();
            datelbl.Text = DateTime.Now.ToLongDateString();
            timelbl.Text = DateTime.Now.ToLongTimeString();
            lblnama.Text =nama;
            countpeg();
            transcout();
            countcbg();
        }
        public void countpeg() {
            conn.Open();
            string sql = "SELECT COUNT(*) FROM pegawai";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            pegWi = Convert.ToInt32(cmd.ExecuteScalar());
            peglbl.Text = pegWi.ToString();
            conn.Close();
        }
        public void transcout()
        {
            conn.Open();
            string sql = "SELECT COUNT(*) FROM transaksi_penjualan";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            pegWi = Convert.ToInt32(cmd.ExecuteScalar());
            translbl.Text = pegWi.ToString();
            conn.Close();
        }
        public void countcbg()
        {
            conn.Open();
            string sql = "SELECT COUNT(*) FROM cabang";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            pegWi = Convert.ToInt32(cmd.ExecuteScalar());
            cabanglbl.Text = pegWi.ToString();
            conn.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            KelolaSparepart peg = new KelolaSparepart();
            peg.Show();
           
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin Log Out ?", "LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                AtmaAuto peg = new AtmaAuto();
                AtmaAuto.log = "LogOut";
                peg.Show();
                this.Hide();
                MessageBox.Show(AtmaAuto.log);
            }
            else
            {
                MessageBox.Show("Batal Log Out", "LOG OUT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void timerdate_Tick(object sender, EventArgs e)
        {
            timelbl.Text = DateTime.Now.ToLongTimeString();
            timerdate.Start();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LaporanForm peg = new LaporanForm();
            peg.Show();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            EditProfile peg = new EditProfile();
            peg.Show();
        }
    }
}
