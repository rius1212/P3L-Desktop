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
    public partial class KonfirmasiSpOK : Form
    {
        int te = 0;
        public KonfirmasiSpOK()
        {
            InitializeComponent();
        }

        private void Yesbtn_Click(object sender, EventArgs e)
        {
            
                label1.Text = "Transaksi Berhasil !";
                label3.Text = "";
                Yesbtn.Text = "";
                Yesbtn.Enabled = false;
                Yesbtn.ForeColor = Color.White;
                Yesbtn.BackColor = Color.White;
                pictureBox1.Enabled = false;
                tidakbtn.Text = "OK";
                tidakbtn.BackColor = Color.Blue;
                te = 1;
           
        }

        private void tidakbtn_Click(object sender, EventArgs e)
        {
            if (te == 0)
            {
                this.Hide();
                
            }
            else if (te == 1)
            {
                transaksiSp obj = (transaksiSp)Application.OpenForms["transaksiSp"];
                obj.Close();
                
                this.Hide();

            }
        }
    }
}
