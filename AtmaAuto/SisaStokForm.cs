using AtmaAuto.ClassAA;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtmaAuto
{
    public partial class SisaStokForm : Form
    {
        CrystalReportSisaStok cr = new CrystalReportSisaStok();
        MySqlConnection conn = LoginDAL.getConnection();
        public SisaStokForm()
        {
            InitializeComponent();
        }
        public void filltahun()
        {
            string sql = "select DISTINCT year(TANGGAL_TRANS) as tahun from  transaksi_penjualan";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@notrans", PembayaranForm.notrans);
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                tahuncb.Items.Add(reader["tahun"]);
            }
            tahuncb.SelectedIndex = 0;
            conn.Close();

        }
        public void filltipe()
        {
            string sql = "select TIPEBARANG as tipe from  sparepart GROUP BY TIPEBARANG";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@notrans", PembayaranForm.notrans);
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                tipecb.Items.Add(reader["tipe"]);
            }
            tipecb.SelectedIndex = 0;
            conn.Close();

        }
        private void TahunCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tahuncb.Text == "==Pilih==" || tahuncb.Text == "")
            {
                crystalReportViewStok.ReportSource = null;

            }
            else
            {

                conn.Close();
                Cek(tahuncb.Text,tipecb.Text);

            }

        }
        private void TipeCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tipecb.Text == "==Pilih==" || tahuncb.Text == "")
            {
                crystalReportViewStok.ReportSource = null;

            }
            else
            {

                conn.Close();
                Cek(tahuncb.Text, tipecb.Text);

            }

        }
        public void Cek(string tahun,string tipe)

        {
            DataTable kons = new DataTable();
            kons.Columns.Add("No", typeof(int));
            kons.Columns.Add("Bulan", typeof(string));
            kons.Columns.Add("Sisa", typeof(int));
            kons.Columns.Add("NamaSp", typeof(string));
            kons.Columns.Add("Tahun", typeof(string));

            //  int bul = DateTime.ParseExact(bulan, "MMMM", CultureInfo.CurrentCulture).Month;

            string sql = "SELECT bln, kode, tipe, stok FROM(SELECT MONTHNAME(TANGGAL) as bln, KODE_SPAREPART as kode, TIPEBARANG as tipe, SUM(SISA_STOK) as stok FROM histori_barang JOIN sparepart USING(KODE_SPAREPART) WHERE TIPEBARANG = @tipe AND TANGGAL IN(SELECT MAX(TANGGAL) FROM histori_barang JOIN sparepart USING(KODE_SPAREPART) WHERE YEAR(TANGGAL) = @tahun AND TIPEBARANG = @tipe GROUP BY NAMA_SPAREPART, MONTH(TANGGAL), YEAR(TANGGAL))GROUP BY TIPEBARANG, MONTHNAME(TANGGAL)  UNION SELECT m.bulan AS bln, '-' as kode, '-' as tipe, 0 as stok FROM(SELECT 'January' AS bulan UNION SELECT 'February' AS bulan UNION SELECT 'March' AS bulan UNION SELECT 'April' AS bulan UNION SELECT 'May' AS bulan UNION SELECT 'June' AS bulan UNION SELECT 'July' AS bulan UNION SELECT 'August' AS bulan UNION SELECT 'September' AS bulan UNION SELECT 'October' AS bulan UNION SELECT 'November' AS bulan UNION SELECT 'December' AS bulan) AS m LEFT JOIN histori_barang p ON MONTHNAME(p.TANGGAL) = m.bulan) a GROUP BY bln ORDER BY str_to_date(bln, '%M')";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tahun", tahun);
            cmd.Parameters.AddWithValue("@tipe", tipe);
            //cmd.Parameters.AddWithValue("@bulan", bulan);
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {

                //string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(reader.GetString(0)));

                DataRow row = kons.NewRow();

                x = x + 1;
                row["No"] = x;
                row["Bulan"] = reader.GetString(0);
                row["Sisa"] = int.Parse(reader.GetString(3));
                row["Tahun"] = tahun;
                row["NamaSp"] = tipe;
                kons.Rows.Add(row);
            }
            conn.Close();

            cr.Database.Tables["Sisa_Stok"].SetDataSource(kons);
        }
        private void SisaStokForm_Load(object sender, EventArgs e)
        {
            filltahun();
            filltipe();
            crystalReportViewStok.ReportSource = cr;
        }
    }
}
