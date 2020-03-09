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
    public partial class PenJasaForm : Form
    {
        CrystalReportPenJasa cr = new CrystalReportPenJasa();
        MySqlConnection conn = LoginDAL.getConnection();
        public string merk=null;
        public string tipe = null;

        public PenJasaForm()
        {
            InitializeComponent();
        }
        private void TahunCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tahuncb.Text == "==Pilih==" || tahuncb.Text == "")
            {
                crystalReportViewjas.ReportSource = null;

            }
            else
            {
                
                conn.Close();
                Cek(tahuncb.Text,bulancb.Text);

            }

        }
        private void bulancb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bulancb.Text == "==Pilih==" || bulancb.Text == "")
            {
                crystalReportViewjas.ReportSource = null;

            }
            else
            {

                conn.Close();
                Cek(tahuncb.Text, bulancb.Text);

            }

        }
        public void Cek(string tahun,string bulan)

        {
            DataTable kons = new DataTable();
            kons.Columns.Add("No", typeof(int));
            kons.Columns.Add("Merk", typeof(string));
            kons.Columns.Add("Tipe", typeof(string));
            kons.Columns.Add("Nama", typeof(string));
            kons.Columns.Add("Jumlah", typeof(string));
            kons.Columns.Add("Tahun", typeof(string));
            kons.Columns.Add("Bulan", typeof(string));
            

            string sql = "select year(a.TANGGAL_TRANS) as tahun,monthname(a.TANGGAL_TRANS) as bulan,d.MERK_KEN,d.TIPE_KEN,SUM(b.JUMLAH_SERVICE),c.NAMA_JASA from transaksi_penjualan a join detil_service b on a.NO_TRANSAKSI=b.NO_TRANSAKSI join jasa_service c on c.ID_JASA_SERVICE=b.ID_JASA_SERVICE join kendaraan d on d.ID_KENDARAAN=b.ID_KENDARAAN WHERE monthname(a.TANGGAL_TRANS)=@bulan AND year(a.TANGGAL_TRANS)=@tahun GROUP by c.NAMA_JASA ORDER BY d.MERK_KEN,d.TIPE_KEN";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@tahun", tahun);
            cmd.Parameters.AddWithValue("@bulan", bulan);
            MySqlDataReader reader = cmd.ExecuteReader();
            int x = 0;
            while (reader.Read())
            {//   
                //\\x = x + 1;
               //  \\string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(bulan));
              //    \\ 
             //      \\
            //________\\
  //             ||  
                DataRow row = kons.NewRow();
                if (merk == reader.GetString(2))
                {
                    
                    if (tipe == reader.GetString(3))
                    {
                        row["Nama"] = reader.GetString(5);
                        row["Jumlah"] = reader.GetString(4);

                        if (tipe == reader.GetString(3))
                        {
                            row["Nama"] = reader.GetString(5);
                            row["Jumlah"] = reader.GetString(4);


                        }
                        else
                        {
                            row["Tipe"] = reader.GetString(3);
                            row["Nama"] = reader.GetString(5);
                            row["Jumlah"] = reader.GetString(4);
                            tipe = reader.GetString(3);
                        }
                    }
                    else
                    {
                        row["Tipe"] = reader.GetString(3);
                        row["Nama"] = reader.GetString(5);
                        row["Jumlah"] = reader.GetString(4);
                        tipe = reader.GetString(3);
                    }
                }
                else
                {
                    x = x + 1;
                    row["No"] = x;
                    row["Merk"] = reader.GetString(2);
                    row["Tipe"] = reader.GetString(3);
                    row["Nama"] = reader.GetString(5);
                    row["Jumlah"] = reader.GetString(4);
                    merk = reader.GetString(2); 
                }
                row["Bulan"] = bulan;
                row["Tahun"] = tahun;

                kons.Rows.Add(row);
            }
            conn.Close();

            cr.Database.Tables["JualJasa"].SetDataSource(kons);
        }
        public void fillbulan()
        {
            string sql = "select DISTINCT month(TANGGAL_TRANS) as bulan from  transaksi_penjualan";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            //cmd.Parameters.AddWithValue("@notrans", PembayaranForm.notrans);
            MySqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int.Parse(reader.GetString(0))));
                bulancb.Items.Add(monthName);
            }
            bulancb.SelectedIndex = 0;
            conn.Close();
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
        private void PenJasaForm_Load(object sender, EventArgs e)
        {
           // fillbulan();
            filltahun();

            crystalReportViewjas.ReportSource = cr;
        }
    }
}
