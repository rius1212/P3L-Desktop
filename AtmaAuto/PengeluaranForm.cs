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
    public partial class PengeluaranForm : Form
    {
        CrystalReportPengeluaran cr = new CrystalReportPengeluaran();
        MySqlConnection conn = LoginDAL.getConnection();
        public PengeluaranForm()
        {
            InitializeComponent();
        }
        private void TahunCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tahuncb.Text == "==Pilih==" || tahuncb.Text == "")
            {
                crystalReportViewPeg.ReportSource = null;

            }
            else
            {

                conn.Close();
                Cek(tahuncb.Text);

            }

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
        public void Cek(string tahun)

        {
            DataTable kons = new DataTable();
            kons.Columns.Add("No", typeof(int));
            kons.Columns.Add("Bulan", typeof(string));
            kons.Columns.Add("Jumlah", typeof(double));
            kons.Columns.Add("Tahun", typeof(string));

            //  int bul = DateTime.ParseExact(bulan, "MMMM", CultureInfo.CurrentCulture).Month;

            string sql = "SELECT bln, thn,gg FROM (select monthname(a.TANGGALP) as bln,year(a.TANGGALP) as thn,sum(B.HARGA_BELI*b.JUMLAH_ADA) as gg from pengadaan a join detil_pengadaan b on a.ID_PENGADAAN=b.ID_PENGADAAN WHERE year(a.TANGGALP)=@tahun GROUP by monthname(a.TANGGALP) UNION SELECT m.bulan AS bln, year(p.TANGGALP) as thn,0 as gg FROM (SELECT 'January' AS bulan UNION SELECT 'February' AS bulan UNION SELECT 'March' AS bulan UNION SELECT 'April' AS bulan UNION SELECT 'May' AS bulan UNION SELECT 'June' AS bulan UNION SELECT 'July' AS bulan UNION SELECT 'August' AS bulan UNION SELECT 'September' AS bulan UNION SELECT 'October' AS bulan UNION SELECT 'November' AS bulan UNION SELECT 'December' AS bulan ) AS m LEFT JOIN pengadaan p ON MONTHNAME(p.TANGGALP) = m.bulan) a GROUP BY bln, thn HAVING @tahun ORDER BY str_to_date(bln,'%M')";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tahun", tahun);
            //cmd.Parameters.AddWithValue("@bulan", bulan);
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {

                 //string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(reader.GetString(1)));

                DataRow row = kons.NewRow();

                    x = x + 1;
                    row["No"] = x;
                    row["Bulan"] = reader.GetString(0);
                    row["Jumlah"] = double.Parse(reader.GetString(2));
                    row["Tahun"] = tahun;
                    kons.Rows.Add(row);
            }
            conn.Close();

            cr.Database.Tables["Pengeluaran"].SetDataSource(kons);
        }
        private void PengeluaranForm_Load(object sender, EventArgs e)
        {
            filltahun();
            crystalReportViewPeg.ReportSource = cr;
        }
    }
}
