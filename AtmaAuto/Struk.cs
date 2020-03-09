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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace AtmaAuto
{
    public partial class Struk : Form
    {
        CrystalReportStruk cr = new CrystalReportStruk();
        MySqlConnection conn = LoginDAL.getConnection();
        public Struk()
        {
            InitializeComponent();
        }

        private void Struk_Load(object sender, EventArgs e)
        {
            TextObject ext = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["notransSPK"];
            TextObject namas = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["namaSPK"];
            TextObject hp = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["telpSPK"];
           // TextObject motor = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["motorSPK"];
            TextObject cs = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["CSSPK"];
        //    TextObject montir = (TextObject)cr.ReportDefinition.Sections["Section2"].ReportObjects["MontirSPK"];
            TextObject Kasir = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["kasirSPK"];
            TextObject Cust = (TextObject)cr.ReportDefinition.Sections["Section4"].ReportObjects["namaCust"];
            ext.Text = PembayaranForm.notrans;
            //cs.Text = AtmaAuto.namas;
            Kasir.Text = AtmaAuto.namas;
            
            string sql = " select b.NAMA_KONSUMEN,b.NO_TELP_KON, a.CS from transaksi_penjualan a join konsumen b ON a.ID_KONSUMEN = b.ID_KONSUMEN  WHERE a.NO_TRANSAKSI=@notrans";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@notrans", PembayaranForm.notrans);
            MySqlDataReader reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {
                namas.Text = reader.GetString(0);
                Cust.Text = reader.GetString(0);
                cs.Text = reader.GetString(2);
                //montir.Text = reader.GetString(3);
                hp.Text = reader.GetString(1);
            }
            // kons.Load(reader);
            
            conn.Close();
            buatService();
            buat();
            trans();
            crystalReportView.ReportSource = cr;
        }
        
        public void buat()
        {

            DataTable kons = new DataTable();
            kons.Columns.Add("Kode", typeof(string));
            kons.Columns.Add("Nama", typeof(string));
            kons.Columns.Add("Merk", typeof(string));
            kons.Columns.Add("Harga", typeof(string));
            kons.Columns.Add("Jumlah", typeof(string));
            kons.Columns.Add("SubTotal", typeof(double));
           


            string sql = " select a.KODE_SPAREPART, b.NAMA_SPAREPART,b.MERK,b.HARGA_JUAL,a.JUMLAH_SPAREPART,a.SUBTOTAL_SP from detil_sparepart a join sparepart b ON a.KODE_SPAREPART = b.KODE_SPAREPART  WHERE a.NO_TRANSAKSI=@notrans";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@notrans", PembayaranForm.notrans);
            MySqlDataReader reader = cmd.ExecuteReader();
           
            while (reader.Read())
            {
                DataRow row = kons.NewRow();
                row["Kode"] = reader.GetString(0);
                row["Nama"] = reader.GetString(1);
                row["Merk"] = reader.GetString(2);
                row["Harga"] = reader.GetString(3);
                row["Jumlah"] = reader.GetString(4);
                row["SubTotal"] = double.Parse(reader.GetString(5));
               
                kons.Rows.Add(row);
            }
            conn.Close();
           
            cr.Database.Tables["Sparepart1"].SetDataSource(kons);
            
        }
        public void buatService()
        {
            string platmotor;
            DataTable konsa = new DataTable();
            konsa.Columns.Add("Kode", typeof(string));
            konsa.Columns.Add("Nama", typeof(string));
            konsa.Columns.Add("Harga", typeof(string));
            konsa.Columns.Add("Jumlah", typeof(string));
            konsa.Columns.Add("SubTotal", typeof(double));
            konsa.Columns.Add("Motor", typeof(string));
            konsa.Columns.Add("Montir", typeof(string));

            string sql = "select a.ID_JASA_SERVICE,b.NAMA_JASA,b.HARGA_JASA,a.JUMLAH_SERVICE,a.SUBTOTAL,c.NOPOL,c.TIPE_KEN,MERK_KEN,a.Montir from jasa_service b join detil_service a ON a.ID_JASA_SERVICE=b.ID_JASA_SERVICE join kendaraan c ON c.ID_KENDARAAN=a.ID_KENDARAAN WHERE a.NO_TRANSAKSI=@notrans";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@notrans", PembayaranForm.notrans);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                platmotor = reader.GetString(7) + " " + reader.GetString(6) + "" + reader.GetString(5);
                DataRow row = konsa.NewRow();
                row["Kode"] = reader.GetString(0);
                row["Nama"] = reader.GetString(1);
                row["Harga"] = reader.GetString(2);
                row["Jumlah"] = reader.GetString(3);
                row["SubTotal"] = double.Parse(reader.GetString(4));
                row["Motor"] = platmotor;
                row["Montir"] = reader.GetString(8);
                konsa.Rows.Add(row);
            }
            conn.Close();

            cr.Database.Tables["Service1"].SetDataSource(konsa);

        }
        public void trans()
        {
            double dis;
            DataTable konsa = new DataTable();
            konsa.Columns.Add("Diskon", typeof(double));
            konsa.Columns.Add("Total", typeof(double));
            konsa.Columns.Add("SubTotal", typeof(double));


            string sql = "select SUB_TOTAL,TOTAL_HARGA FROM transaksi_penjualan WHERE NO_TRANSAKSI=@notrans";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@notrans", PembayaranForm.notrans);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                dis = double.Parse(reader.GetString(0))-double.Parse(reader.GetString(1));
                DataRow row = konsa.NewRow();
                row["SubTotal"] = double.Parse(reader.GetString(0));
                row["Diskon"] =dis;
                row["Total"] = double.Parse(reader.GetString(1));
                konsa.Rows.Add(row);
            }
            conn.Close();

            cr.Database.Tables["Trans"].SetDataSource(konsa);

        }

    }
}
