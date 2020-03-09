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
    public partial class TransaksiCheck : Form
    {

        int te = 0;
        public TransaksiCheck()
        {
            InitializeComponent();
        }

        private void Yesbtn_Click(object sender, EventArgs e)
        {

            if (TransaksiLanjutForm.tesmasuk == 1)
            {
                TransaksiLanjutForm obj = (TransaksiLanjutForm)Application.OpenForms["TransaksiLanjutForm"];
                obj.Close();
                TransaksiForm admin = new TransaksiForm();
                TransaksiLanjutForm.tesmasuk = 0;
                admin.Show();
                this.Hide();
            }
            else if (TransaksiJs.tesmasuk == 1)
            {
                TransaksiJs obj = (TransaksiJs)Application.OpenForms["TransaksiJs"];
                obj.Close();
                transaksiFormJs admin = new transaksiFormJs();
                admin.Show();
                TransaksiJs.tesmasuk = 0;
                this.Hide();
            }
           
            

        }

        private void tidakbtn_Click(object sender, EventArgs e)
        {
        
            if (te == 0) {
                label1.Text = "Transaksi Berhasil !";
                label3.Text = "";
                Yesbtn.Text= "";
                Yesbtn.Enabled = false;
                Yesbtn.ForeColor = Color.White;
                Yesbtn.BackColor = Color.White;
                pictureBox1.Enabled = false;
                tidakbtn.Text = "OK";
                tidakbtn.BackColor = Color.Blue;
                te = 1;
            }else if(te==1){
                if (TransaksiLanjutForm.tesmasuk == 1)
                {
                    TransaksiLanjutForm obj = (TransaksiLanjutForm)Application.OpenForms["TransaksiLanjutForm"];
                    obj.Close();
                    TransaksiLanjutForm.tesmasuk = 0;
                    TransaksiLanjutForm.notrans=null;
                    this.Hide();
                }
                else if (TransaksiJs.tesmasuk == 1)
                {
                    TransaksiJs obj = (TransaksiJs)Application.OpenForms["TransaksiJs"];
                    obj.Close();
                    TransaksiJs.notrans = null;
                    TransaksiJs.tesmasuk = 0;
                    this.Hide();
                }
               
            }

        }

        private void TransaksiCheck_Load(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            if (TransaksiLanjutForm.tesmasuk == 1)
            {
                TransaksiLanjutForm obj = (TransaksiLanjutForm)Application.OpenForms["TransaksiLanjutForm"];
                obj.Close();
                TransaksiLanjutForm.tesmasuk = 0;
                TransaksiLanjutForm.notrans = null;
                this.Hide();
            }
            else if (TransaksiJs.tesmasuk == 1)
            {
                TransaksiJs obj = (TransaksiJs)Application.OpenForms["TransaksiJs"];
                obj.Close();
                TransaksiJs.notrans = null;
                TransaksiJs.tesmasuk = 0;
                this.Hide();
            }
        }
    }
}
