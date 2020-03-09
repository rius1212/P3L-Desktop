using AtmaAuto.ClassAA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;
using System.Threading;

namespace AtmaAuto
{
    public partial class AtmaAuto : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();
        public static string ted;
        public static string log;
        public static string alamat;
        public static string nohp;
        public static string usernm;
        public static string pass;
        public static string idpeg;


        public AtmaAuto()
        {
            InitializeComponent();

        }
        private void formRun()
        {
            Application.Run(new WelcomeLoad());
        }
        public static string namas;
        public static string cbg;
        //LoginAA l = new LoginAA();
        //LoginDAL dal = new LoginDAL();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Usernametextbox.Text == "" && Passwordtextbox.Text == "")
            {
                MessageBox.Show("username atau password masih kosong !");
            }
            else {
                if (login(Usernametextbox.Text, Passwordtextbox.Text))
                {
                    MessageBox.Show("Login Berhasil");
                    //coba.Text = ted;
                    if (ted == "Owner")
                    {
                        AdminView admin = new AdminView();
                        ted = "Owner";
                        admin.Show();
                        this.Hide();
                    }
                    else if(ted=="CS")
                    {
                        User User = new User();
                        User.Show();
                        this.Hide();
                    }
                    else if (ted == "Kasir")
                    {
                        PembayaranForm User = new PembayaranForm();
                        User.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Login Gagal ");
                }
            }
            
        }
        private Boolean login(string sUsname, string sPass)
        {
            string sql = "SELECT USERNAME,PASSWORD,ROLE,NAMA_PEGAWAI,CABANG,ALAMAT_PEGAWAI,NO_TELP_PEGAWAI,IDPEGAWAI FROM pegawai";
         
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
             MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if ((sUsname == reader.GetString(0)) && (sPass == reader.GetString(1)))
                {
                     ted = reader.GetString(2);
                    usernm= reader.GetString(0);
                    pass= reader.GetString(1);
                    namas = reader.GetString(3);
                    cbg= reader.GetString(4);
                    alamat = reader.GetString(5);
                    nohp = reader.GetString(6);
                    idpeg = reader.GetString(7);
                    return true;
                }
            }
            conn.Close();
            return false;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AtmaAuto_Load(object sender, EventArgs e)
        {
            
            if (log == null)
            {
                Thread trd = new Thread(new ThreadStart(formRun));
                trd.Start();
                Thread.Sleep(3000);
                trd.Abort();
            }
            else if (log == "LogOut")
            {
               // InitializeComponent();
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Passwordtextbox.UseSystemPasswordChar = false;
            }else
            {
                Passwordtextbox.UseSystemPasswordChar = true;
            }
        }

        private void AtmaAuto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(this, new EventArgs());
            }

        }
    }
}
