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
    public partial class PembayaranForm : Form
    {
        public float totharga;
        public float diskon=0;
        public float subtotl;
        public double kembalian;
        public int stok;
        public int sisastok;
        public string dateboom;
        public string datein;
        public static string namacus;
        public static string notrans;
        MySqlConnection conn = LoginDAL.getConnection();
        public PembayaranForm()
        {
            InitializeComponent();
        }

        private void PembayaranForm_Load(object sender, EventArgs e)
         {
            label12.Text = AtmaAuto.namas;
            FillDGVBayar();
            spiltconcatDate(DateTime.Now.ToShortDateString());
            //tgltrans.Text = dateboom;
            cbgtxt.Text = AtmaAuto.cbg;
            dateshow.Text = DateTime.Now.ToLongDateString();
            timeshow.Text = DateTime.Now.ToLongTimeString();
      
        }

        private void diskontb_TextChanged(object sender, EventArgs e)
        {
           // MessageBox.Show(diskontb.Text);
            if (diskontb.Text == "")
            {
                diskontb.Text = "0";
                float tes = float.Parse("100");
                totharga = float.Parse(subtot.Text)-0;
                tothartb.Text = totharga.ToString();
            }
            else if (float.Parse(diskontb.Text) > float.Parse(subtot.Text))
                {
                    MessageBox.Show("diskon lebih dari total");
                }
                else
                {

                    float tes = float.Parse("100");
                    totharga = (float.Parse(subtot.Text) - float.Parse(diskontb.Text));
                    tothartb.Text = totharga.ToString();
                }
            
        }

        private void HargaSp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }
        private void bayarverbtn_Click(object sender, EventArgs e)
        {
            List<Sparepart> list = new List<Sparepart>();
            if (bayartb.Text == "" || int.Parse(bayartb.Text) == 0)
            {
                MessageBox.Show("Anda Belum Memasukan Nilai Uang !");
            } else 
            {
                if (float.Parse(bayartb.Text) == float.Parse(tothartb.Text))
                {
                    kembalilbl.Text = "0";
                }
                else if (float.Parse(bayartb.Text) < float.Parse(tothartb.Text))
                {
                    MessageBox.Show(" Jumlah uang Kurang dari total harga !");
                }

                else if (float.Parse(bayartb.Text) > float.Parse(tothartb.Text))
                {
                   
                        kembalian = double.Parse(bayartb.Text) - double.Parse(tothartb.Text);
                       // kembalitb.Text = kembalian.ToString();
                        kembalilbl.Text= kembalian.ToString();
                }
                if (kembalilbl.Text != "")
                {
                    //labelsukses.Text = "Pembayaran Sukses !";
                    conn.Open();
                    string sql = "UPDATE transaksi_penjualan SET DISKON=@diskon, TOTAL_HARGA=@totharga, KEMBALIAN=@kembali WHERE NO_TRANSAKSI=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@totharga", float.Parse(tothartb.Text));
                    cmd.Parameters.AddWithValue("@diskon", diskon);
                    cmd.Parameters.AddWithValue("@kembali", kembalian);
                    cmd.Parameters.AddWithValue("@id", NOtrans12.Text);
                    if (cmd.ExecuteNonQuery() == 1)

                    {
                        MessageBox.Show("Transaksi Berhasil !");
                    }
                    else
                    {
                        MessageBox.Show("Gagal transaksi");
                    }

                    conn.Close();
                    conn.Open();

                    MySqlCommand cmdx = new MySqlCommand("SELECT A.KODE_SPAREPART, A.JUMLAH_SPAREPART  FROM  detil_sparepart A WHERE A.NO_TRANSAKSI=@id", conn);
                    // MySqlDataAdapter adapter = new MySqlDataAdapter(cmdx);
                    cmdx.Parameters.AddWithValue("@id", NOtrans12.Text);
                    MySqlDataReader reader = cmdx.ExecuteReader();
                    while (reader.Read())
                    {
                        //  i = i + 1;
                        list.Add(new Sparepart() { kode = reader.GetString(0), jumlah = reader.GetInt32(1) });
                    }
                    conn.Close();

                  //  MessageBox.Show("Sucess 1");
                    for (int i = 0; i < list.Count; i++)
                    {
                       // MessageBox.Show(list[i].kode);
                        MySqlCommand cmd12 = new MySqlCommand("SELECT a.STOK  FROM  sparepart A WHERE A.KODE_SPAREPART=@sp", conn);
                        //MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd12);
                        cmd12.Parameters.AddWithValue("@sp", list[i].kode);
                        conn.Open();
                        MySqlDataReader reader12 = cmd12.ExecuteReader();
                        while (reader12.Read())
                        {
                            if (list[i].jumlah > int.Parse(reader12.GetString(0)))
                            {
                                MessageBox.Show("jumlah Sparepart tidak mencukupi !");
                            }
                            else {
                                sisastok = int.Parse(reader12.GetString(0)) - list[i].jumlah;
                            }
                            
                        }
                        conn.Close();
                        conn.Open();
                       // MessageBox.Show(sisastok.ToString());
                        MySqlCommand cmd2 = new MySqlCommand("UPDATE sparepart SET STOK=@stok WHERE KODE_SPAREPART=@sp", conn);
                        cmd2.Parameters.AddWithValue("@sp", list[i].kode);
                        cmd2.Parameters.AddWithValue("@stok", sisastok);
                        if (cmd2.ExecuteNonQuery() == 1)

                        {
                          //  MessageBox.Show("Sucess 1");
                        }
                        else
                        {
                            MessageBox.Show("Terjadi Kesalahan");
                        }
                        conn.Close();
                        conn.Open();
                        string sql3 = "INSERT INTO histori_barang(KODE_SPAREPART,TANGGAL,JUMLAH, KET, SISA_STOK) VALUES(@id,@tggl,@jum,@ket,@stok)";
                        MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                        cmd3.Parameters.AddWithValue("@jum", list[i].jumlah);
                        cmd3.Parameters.AddWithValue("@stok", sisastok);
                        cmd3.Parameters.AddWithValue("@ket", "Keluar");
                        cmd3.Parameters.AddWithValue("@id", list[i].kode);
                        cmd3.Parameters.AddWithValue("@tggl", datein + " " + DateTime.Now.ToLongTimeString());
                        if (cmd3.ExecuteNonQuery() == 1)

                        {
                          //  MessageBox.Show("success 2");
                        }
                        else
                        {
                            MessageBox.Show("Gagal (2)");
                        }
                        conn.Close();
                    }
                    
                    FillDGVBayar();

                }

            }
               
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NOtrans12.Text == "SS")
            {
                MessageBox.Show("Belum memilih Transaksi");
            }
            else if (kembalilbl.Text == "Rp.")
            {
                MessageBox.Show("Belum Melakukan Transaksi Pembayaran");
            }
            else {
                notrans = NOtrans12.Text;
                Struk f23 = new Struk();
                f23.Show();

            }
          
        }

        public void FillDGVBayar()
        {
            MySqlCommand cmd = new MySqlCommand("select a.NAMA_KONSUMEN AS KONSUMEN,b.NO_TRANSAKSI AS TRANSAKSI,b.TANGGAL_TRANS AS TANGGAL,b.SUB_TOTAL AS SUBTOTAL from konsumen a join transaksi_penjualan b ON a.ID_KONSUMEN=b.ID_KONSUMEN join pegawai c on b.CS=c.NAMA_PEGAWAI WHERE b.KEMBALIAN=-1 AND c.CABANG=@cbg", conn);
            cmd.Parameters.AddWithValue("@cbg", AtmaAuto.cbg);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            
            DataTable table = new DataTable();
            adapter.Fill(table);
            BayarDGV.RowTemplate.Height = 60;
            BayarDGV.AllowUserToAddRows = false;
            BayarDGV.DataSource = table;
            BayarDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void bayardgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            subtot.Text = BayarDGV.Rows[rowIndex].Cells[3].Value.ToString();
            tothartb.Text= BayarDGV.Rows[rowIndex].Cells[3].Value.ToString();
            NOtrans12.Text = BayarDGV.Rows[rowIndex].Cells[1].Value.ToString();
            namatbx.Text = BayarDGV.Rows[rowIndex].Cells[0].Value.ToString();
           
            
        }
        private void timerup_Tick(object sender, EventArgs e)
        {
            timeshow.Text = DateTime.Now.ToLongTimeString();
            timerup.Start();
        }
        public DataTable searchSp(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "select b.NO_TRANSAKSI, a.NAMA_KONSUMEN,b.TANGGAL_TRANS,b.SUB_TOTAL from konsumen a join transaksi_penjualan b ON a.ID_KONSUMEN=b.ID_KONSUMEN WHERE b.NO_TRANSAKSI LIKE '%" + key + "%' OR a.NAMA_KONSUMEN LIKE '%" + key + "%'  ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@merk", TransaksiForm.merkken);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;

        }
        private void cariSp_TextChanged(object sender, EventArgs e)
        {
            string key = cariTr.Text;
            if (key != null)
            {
                DataTable dt = searchSp(key);
                BayarDGV.DataSource = dt;
            }
            else
            {
                FillDGVBayar();
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void namatbx_TextChanged(object sender, EventArgs e)
        {

        }

        private void logout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin Log Out ?", "LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                AtmaAuto peg = new AtmaAuto();
                AtmaAuto.log = "LogOut";
                peg.Show();
                this.Hide();

                MessageBox.Show("Berhasil Log Out !");
            }
            else
            {
                MessageBox.Show("Batal Log Out", "LOG OUT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void spiltconcatDate(string kodes)
        {
            string q1;
            string q2;
            string q3;
            char[] separator = { '/' };
            string[] str = null;
            str = kodes.Split(separator);

            q1 = str[0];
            q2 = str[1];
            q3 = str[2];
            if (q1.Length <= 1)
            {
                q1 = "0" + q1;
            }
            if (q2.Length <= 1)
            {
                q2 = "0" + q2;
            }
            var length = q3.Length;
            var firstHalf = q3.Substring(0, length / 2);
            var secondHalf = q3.Substring(length / 2, length - (length / 2));
            dateboom = q2 + q1 + secondHalf;
            datein = q3 + "-" + q1 + "-" + q2;

        }
        class Sparepart
        {
            public string kode { get; set; }
            public int jumlah { get; set; }
        }
        private void BayarDGV_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string xi;
            //int i = 0;
           

            int rowIndex = e.RowIndex;
               xi = BayarDGV.Rows[rowIndex].Cells[1].Value.ToString();
             DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus transaksi ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                
                
                conn.Open();
                string sql = "DELETE FROM transaksi_penjualan WHERE NO_TRANSAKSI=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", xi);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show(" Berhasil Menghapus !");
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus !");
                }
               conn.Close();
                
                MessageBox.Show("Sucess 1");


                
            }
            else
            {
                MessageBox.Show("Sparepart Tidak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FillDGVBayar();
        }

        private void clrbtn_Click(object sender, EventArgs e)
        {
            NOtrans12.Text = "SS";
            subtot.Text = "0";
            tothartb.Text = "";
            diskontb.Text = "";
            kembalilbl.Text = "";
            // diskon = float.Parse(diskontb.Text);
            namatbx.Text = "";
            bayartb.Text = "";
        }
    }
}

