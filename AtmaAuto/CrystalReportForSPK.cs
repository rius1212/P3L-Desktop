using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using AtmaAuto.ClassAA;
using MySql.Data.MySqlClient;

namespace AtmaAuto
{
    public partial class CrystalReportForSPK : Form
    {
        private int count;
        private int idken;

        string crz;
        CrystalReportSPK cr = new CrystalReportSPK();
        MySqlConnection conn = LoginDAL.getConnection();
        public CrystalReportForSPK()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormClosingEventCancle_Closing);
   

    }
        private void FormClosingEventCancle_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo); if (dr == DialogResult.No)
                e.Cancel = true;
            else {
                TransaksiCheck admin = new TransaksiCheck();
                admin.Show();
                this.Hide();
                e.Cancel = false;
            }
        }
        public void testz(string cr2)
        {
            crz = cr2;
        }
        public void buat()
        {
            
            DataTable kons = new DataTable();
            kons.Columns.Add("Kode", typeof(string));
            kons.Columns.Add("Nama", typeof(string));
            kons.Columns.Add("Merk", typeof(string));
            kons.Columns.Add("Rak", typeof(string));
            kons.Columns.Add("Jumlah", typeof(string));

           
            string sql = " select a.KODE_SPAREPART, a.JUMLAH_SPAREPART,b.NAMA_SPAREPART,b.MERK,b.RAK from detil_sparepart a join sparepart b ON a.KODE_SPAREPART = b.KODE_SPAREPART WHERE a.NO_TRANSAKSI=@notrans AND a.NOKEN=@idken";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@notrans", crz);
            cmd.Parameters.AddWithValue("@idken", idken);
            MySqlDataReader reader = cmd.ExecuteReader();
            // kons.Load(reader);

            this.count = reader.FieldCount;
            while (reader.Read())
            {
                DataRow row = kons.NewRow();
                row["Kode"] = reader.GetString(0);
                row["Nama"] = reader.GetString(2);
                row["Merk"] = reader.GetString(3);
                row["Rak"] = reader.GetString(4);
                row["Jumlah"] = reader.GetString(1);
                kons.Rows.Add(row);
            }
            conn.Close();
            
            cr.Database.Tables["Sparepart"].SetDataSource(kons);
           
        }
        public void buatService()
        {

            DataTable konsa = new DataTable();
            konsa.Columns.Add("Kode", typeof(string));
            konsa.Columns.Add("Nama", typeof(string));
           
            konsa.Columns.Add("Jumlah", typeof(string));
            string sql = " select a.ID_JASA_SERVICE,b.NAMA_JASA,a.JUMLAH_SERVICE from detil_service a join jasa_service b ON a.ID_JASA_SERVICE=b.ID_JASA_SERVICE WHERE A.NO_TRANSAKSI=@notrans AND a.ID_KENDARAAN=@idken ";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@notrans", crz);
            cmd.Parameters.AddWithValue("@idken", idken);
            MySqlDataReader reader = cmd.ExecuteReader();
            // kons.Load(reader);

            this.count = reader.FieldCount;
            while (reader.Read())
            {
                DataRow row = konsa.NewRow();
                row["Kode"] = reader.GetString(0);
                row["Nama"] = reader.GetString(1);
                row["Jumlah"] = reader.GetString(2);
                konsa.Rows.Add(row);
            }
            conn.Close();
            
            cr.Database.Tables["Service"].SetDataSource(konsa);
          
        }

        private void CrystalReportForSPK_Load(object sender, EventArgs e)
        {
            
             
            TextObject ext = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["notransSPK"];
            TextObject namas = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["namaSPK"];
            TextObject hp = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["telpSPK"];
            TextObject motor = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["motorSPK"];
            TextObject cs = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["CSSPK"];
            TextObject montir = (TextObject)cr.ReportDefinition.Sections["Section1"].ReportObjects["MontirSPK"];
            ext.Text = crz;
            cs.Text = AtmaAuto.namas;
            if (KonfirmasiSp.x==1)
            {
               
                namas.Text = TransaksiLanjutForm.nama;
                hp.Text = TransaksiLanjutForm.hp;
                motor.Text = TransaksiLanjutForm.motor;
                montir.Text = TransaksiLanjutForm.montir;
                idken = TransaksiLanjutForm.idken;


            }
           
            else if (KonfirmasiSp.x==2)
            {
                namas.Text = TransaksiJs.nama;
                hp.Text = TransaksiJs.hp;
                motor.Text = TransaksiJs.motor;
                montir.Text = TransaksiJs.montir;
                idken = TransaksiJs.idken;
            }
            buat();
            buatService();
            crystalReportViewer1.ReportSource = cr;


        }

        private void CrystalReportForSPK_Leave(object sender, EventArgs e)
        {
           
        }
    }
}
