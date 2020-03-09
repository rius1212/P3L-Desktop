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
    public partial class KonfirmasiSp : Form
    {
        public static int x;
        public static string nopol;
        public KonfirmasiSp()
        {
            InitializeComponent();
        }

        private void Yesbtn_Click(object sender, EventArgs e)
        {
            CrystalReportForSPK f23 = new CrystalReportForSPK();
           
            if (TransaksiLanjutForm.tesmasuk == 1)
            {
                f23.testz(TransaksiLanjutForm.notrans);
                // TransaksiLanjutForm.tesmasuk = 1;
                x = 1;
                nopol = TransaksiForm.nopol;
                f23.Show();
                this.Hide();

            }
            else if (TransaksiJs.tesmasuk == 1)
            {
                f23.testz(TransaksiJs.notrans);
                //TransaksiJs.tesmasuk = 1;
                nopol = transaksiFormJs.nopol;
                x = 2;
                f23.Show();
                this.Hide();
            }

           

        }

        private void tidakbtn_Click(object sender, EventArgs e)
        {
            TransaksiCheck admin = new TransaksiCheck();
            admin.Show();
            this.Hide();
        }

        private void KonfirmasiSp_Load(object sender, EventArgs e)
        {

        }
    }
}
