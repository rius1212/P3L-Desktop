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

namespace AtmaAuto
{
    public partial class transaksiSp : Form
    {
        MySqlConnection conn = LoginDAL.getConnection();

        public int tekan = 0;
        public int tekanChange = 0;
        public string dateboom;
        public string datein;
        public float subtotal1sp;
        public float subtotal1js;
        public int maxid;
        public int stok;
        public static int idkonsave;
        public string iddetilsp;
        public static string notrans;
        public static float totfullsp;
        public static int tesmasuk;  
        public static float subtotal;
        
        public transaksiSp()
        {
            InitializeComponent();
        }
        //////////////////////////////////// Data Konsumen ////////////////////////////////////
        public void clear()
        {
            IDtb.Text = "";
            namatb.Text = "";
            alamattb.Text = "";
            nohptb.Text = "";
        }

        public void FillDGVKonsumen()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM konsumen", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridKonsumen.RowTemplate.Height = 60;
            dataGridKonsumen.AllowUserToAddRows = false;
            dataGridKonsumen.DataSource = table;
            dataGridKonsumen.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public bool validIdKonsum(string s)
        {
            //bool istrue = false;
            string str = "select * from konsumen";
            conn.Open();
            MySqlCommand command = new MySqlCommand(str, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                str = reader.GetString("ID_KONSUMEN");
                if (str == s)
                {
                    conn.Close();
                    return true;
                }
            }
            conn.Close();
            return false;
        }

        public void setBtnActive()
        {
            DeleteBtn.Enabled = true;
            UpdateBtn.Enabled = true;
            DeleteBtn.BackColor = Color.Red;
            UpdateBtn.BackColor = Color.Blue;
        }

        public void setBtnKonAll(bool cos, bool sin)
        {
            IDtb.Enabled = cos;
            namatb.Enabled = cos;
            alamattb.Enabled = cos;
            nohptb.Enabled = cos;
            dataGridKonsumen.Enabled = cos;
            DeleteBtn.Enabled = sin;
            UpdateBtn.Enabled = sin;
            InsertBtn.Enabled = cos;
            DeleteBtn.BackColor = Color.White;
            UpdateBtn.BackColor = Color.White;
            InsertBtn.BackColor = Color.White;
            textBox1.Enabled = cos;
        }
        public void setBtnDeactive()
        {
            DeleteBtn.Enabled = false;
            UpdateBtn.Enabled = false;
            DeleteBtn.BackColor = Color.White;
            UpdateBtn.BackColor = Color.White;
        }
        private void InsertBtn_Click(object sender, EventArgs e)
        {
            if (namatb.Text == "" && alamattb.Text == "" && nohptb.Text == "")
            {
                MessageBox.Show("Beberapa Inputan masih Kosong");

            }
            else if (validIdKonsum(IDtb.Text) == true)
            {
                MessageBox.Show("ID Konsumen sudah ada !");
            }
            else
            {
                conn.Open();
                string sql = "INSERT INTO konsumen(NAMA_KONSUMEN, ALAMAT_KON,NO_TELP_KON) VALUES(@nama,@alamat,@telp)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@telp", nohptb.Text);
                cmd.Parameters.AddWithValue("@nama", namatb.Text);
                cmd.Parameters.AddWithValue("@alamat", alamattb.Text);


                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("Gagal");
                }
                conn.Close();
                clear();
                FillDGVKonsumen();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nohptb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void dataGridKonsumen_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            IDtb.Text = dataGridKonsumen.Rows[rowIndex].Cells[0].Value.ToString();
            namatb.Text = dataGridKonsumen.Rows[rowIndex].Cells[1].Value.ToString();
            alamattb.Text = dataGridKonsumen.Rows[rowIndex].Cells[2].Value.ToString();
            nohptb.Text = dataGridKonsumen.Rows[rowIndex].Cells[3].Value.ToString();

            setBtnActive();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (namatb.Text == "" && alamattb.Text == "" && nohptb.Text == "")
            {
                MessageBox.Show("Beberapa Inputan masih Kosong");

            }
            else
            {
                conn.Open();
                string sql = "UPDATE konsumen SET NAMA_KONSUMEN=@nama, ALAMAT_KON=@alamat,NO_TELP_KON=@notlp WHERE ID_KONSUMEN=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", IDtb.Text);
                cmd.Parameters.AddWithValue("@notlp", nohptb.Text);
                cmd.Parameters.AddWithValue("@nama", namatb.Text);
                cmd.Parameters.AddWithValue("@alamat", alamattb.Text);
                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("Update Berhasil !");
                }
                else
                {
                    MessageBox.Show("Gagal Update !");
                }
                FillDGVKonsumen();
                setBtnDeactive();
                clear();
                conn.Close();
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus konsumen ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {

                conn.Open();
                string sql = "DELETE FROM konsumen WHERE ID_KONSUMEN=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", IDtb.Text);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show(" Berhasil Menghapus !");
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus !");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Konsumen Tdak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FillDGVKonsumen();
            setBtnDeactive();
            clear();
        }
        public DataTable search(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM konsumen WHERE NAMA_KONSUMEN LIKE '%" + key + "%' ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            if (key != null)
            {
                DataTable dt = search(key);
                dataGridKonsumen.DataSource = dt;
            }
            else
            {
                FillDGVKonsumen();
            }
        }
        //////////////////////////////////////////////// Ganti ///////////////////////////
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            if (tekan == 1)
            {
                setBtnKonAll(true, false);
                InsertBtn.BackColor = Color.Lime;
                ClearBtn.Text = "Kelola Sparepart";
                
                IDtb.Text = "";
                namatb.Text = "";
                nohptb.Text = "";
                alamattb.Text = "";
                tekan = 0;
            }
            else if (IDtb.Text == "")
            {
                MessageBox.Show("Calon Konsumen belum Ada !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                tekan = 1;
                setBtnKonAll(false, false);
                groupBox2.Enabled = true;
                FillDGVSparepart();
                FillDGVDetilSparepart();
                MakeIDtrans(checkmaxID());
                ClearBtn.Text = "Ganti Konsumen";
            }
        }
        ////////////////////////////////////////////// Load ///////////////////////////////
        private void transaksiSp_Load(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            setBtnDeactive();
            FillDGVKonsumen();
            timerup.Start();
            spiltconcatDate(DateTime.Now.ToShortDateString());
           
            idkonsave = TransaksiForm.idkon;
            idmax21.Text = (checkmaxID() + 1).ToString();
            
           
            tgltrans.Text = dateboom;
            dateshow.Text = DateTime.Now.ToLongDateString();
            timeshow.Text = DateTime.Now.ToLongTimeString();
            upbtn.Enabled = false;
            
            upbtn.BackColor = Color.WhiteSmoke;
            upbtn.Text = "";

        }

        ////////////////////////////////////////////////Tanggall////////////////////////
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
        private void timerup_Tick(object sender, EventArgs e)
        {
            timeshow.Text = DateTime.Now.ToLongTimeString();
            timerup.Start();
        }
        ////////////////////////// Buat No Trans ///////////////////////////////
        public int checkmaxID()
        {
            int value = 0;
            string q3;
            string sql = "SELECT NO_TRANSAKSI FROM transaksi_penjualan";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                char[] separator = { '-' };
                string[] str = null;
                str = reader.GetString(0).Split(separator);
                q3 = str[2];

                if (int.Parse(q3) > value)
                {
                    value = int.Parse(q3);
                }
            }
            conn.Close();
            return value;
            // idmax.Text = reader.GetString(0);

        }
        public void MakeIDtrans(int maxid)
        {

            if (tekanChange == 0)
            {
                int value = maxid + 1;
                idmax21.Text = value.ToString();
                notrans = "SP-" + tgltrans.Text + "-" + value.ToString();
                string sql = "INSERT INTO transaksi_penjualan(NO_TRANSAKSI,ID_KONSUMEN) VALUES(@notrans,@idkon) ";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@notrans", notrans);
                cmd.Parameters.AddWithValue("@idkon", IDtb.Text);
                cmd.Parameters.AddWithValue("@tggl", datein);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    //                MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("Terjadi Kesalahan dalam Generate ID Transaksi");
                }
                conn.Close();
                tekanChange = 1;
            }
            else if (tekanChange == 1)
            {


                notrans = "SP-" + tgltrans.Text + "-" + idmax21.Text;
                string sql = "UPDATE transaksi_penjualan SET ID_KONSUMEN=@id WHERE NO_TRANSAKSI=@notrans ";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@notrans", notrans);
                cmd.Parameters.AddWithValue("@id", int.Parse(IDtb.Text));


                if (cmd.ExecuteNonQuery() == 1)

                {
                    //                MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("Terjadi Kesalahan dalam Generate ID");
                }
                conn.Close();
            }

        }
        //////////////////////////////////// Transaksi ////////////////////////////////////

        public void FillDGVSparepart()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT KODE_SPAREPART,RAK,NAMA_SPAREPART,STOK,GAMBAR, HARGA_JUAL,MERK FROM sparepart", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridsp.RowTemplate.Height = 60;
            dataGridsp.AllowUserToAddRows = false;
            dataGridsp.DataSource = table;
            DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
            imgCol = (DataGridViewImageColumn)dataGridsp.Columns[4];
            imgCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridsp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }
        public void FillDGVDetilSparepart()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM detil_sparepart WHERE NO_TRANSAKSI=@kode", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@kode", notrans);
            DataTable table = new DataTable();
            adapter.Fill(table);

            detiSpDataGrid.RowTemplate.Height = 60;
            detiSpDataGrid.AllowUserToAddRows = false;
            detiSpDataGrid.DataSource = table;
            detiSpDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public DataTable searchSp(string key)
        {
            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT  KODE_SPAREPART,RAK,NAMA_SPAREPART,STOK,GAMBAR, HARGA_JUAL,MERK  FROM sparepart WHERE KODE_SPAREPART LIKE '%" + key + "%' OR NAMA_SPAREPART LIKE '%" + key + "%'  ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

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
            string key = cariSp.Text;
            if (key != null)
            {
                DataTable dt = searchSp(key);
                dataGridsp.DataSource = dt;
            }
            else
            {
                FillDGVSparepart();
            }
        }
        private void dataGridsp_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (int.Parse(dataGridsp.Rows[rowIndex].Cells[3].Value.ToString()) == 0)
            {
                MessageBox.Show("Stok Sparepart tersebut kosong ! ");
            }
            else
            {
                stok = int.Parse(dataGridsp.Rows[rowIndex].Cells[3].Value.ToString());

                kodesptb.Text = dataGridsp.Rows[rowIndex].Cells[0].Value.ToString();
                namasptb.Text = dataGridsp.Rows[rowIndex].Cells[2].Value.ToString();
                raksptb.Text = dataGridsp.Rows[rowIndex].Cells[1].Value.ToString();
                hargasptb.Text = dataGridsp.Rows[rowIndex].Cells[5].Value.ToString();
                
            }
           ;
        }
        private void jumlahsptb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (jumlahsptb.Text == "")
                {
                    totsptb.Text = "";
                }
                totsptb.Text = (float.Parse(hargasptb.Text) * float.Parse(jumlahsptb.Text)).ToString();

            }
            catch
            {

            }
        }
        public void clearK()

        {
            kodesptb.Text = "";
            raksptb.Text = "";
            namasptb.Text = "";
            hargasptb.Text = "";
            jumlahsptb.Text = "0";
            totsptb.Text = "0";
        }
        public int fullTotal()
        {
            int value = 0;
            string q3;
            string sql = "SELECT SUBTOTAL_SP FROM detil_sparepart WHERE NO_TRANSAKSI=@notrans";

            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@notrans", notrans);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                value = value + int.Parse(reader.GetString(0));

            }
            fulltot.Text = value.ToString();
            conn.Close();
            return value;
            // idmax.Text = reader.GetString(0);

        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (kodesptb.Text == "" || jumlahsptb.Text == "" || totsptb.Text == "" || totsptb.Text == "0")
            {
                totsptb.Text = "0";
                if (kodesptb.Text == "")
                {
                    MessageBox.Show("Sparepart belum dipilih ");

                }
                else
                {
                    MessageBox.Show("Jumlah item masih nol");
                }

            }
            else
            {
                string sql = "INSERT INTO detil_sparepart(NO_TRANSAKSI,KODE_SPAREPART,JUMLAH_SPAREPART,SUBTOTAL_SP) VALUES(@notrans,@kodesp,@jml,@subttl) ";

                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@notrans", notrans);
                cmd.Parameters.AddWithValue("@kodesp", kodesptb.Text);
                cmd.Parameters.AddWithValue("@jml", jumlahsptb.Text);
                cmd.Parameters.AddWithValue("@subttl", totsptb.Text);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("Sucess");
                }
                else
                {
                    MessageBox.Show("Terjadi Kesalahan");
                }

                
                conn.Close();
               /* int stoke;
                string sql2 = "UPDATE sparepart SET STOK=@stok WHERE KODE_SPAREPART=@kodesp";
                stoke = stok - int.Parse(jumlahsptb.Text);
                conn.Open();

                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

                cmd2.Parameters.AddWithValue("@kodesp", kodesptb.Text);
                cmd2.Parameters.AddWithValue("@stok", stoke);


                if (cmd2.ExecuteNonQuery() == 1)

                {
                    // MessageBox.Show("Sucess");
                }
                else
                {
                    MessageBox.Show("Terjadi Kesalahan");
                }
              
                string sql3 = "INSERT INTO histori_barang(KODE_SPAREPART,TANGGAL,JUMLAH, KET, SISA_STOK) VALUES(@id,@tggl,@jum,@ket,@stok)";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                cmd3.Parameters.AddWithValue("@jum", jumlahsptb.Text);
                cmd3.Parameters.AddWithValue("@stok", stoke);
                cmd3.Parameters.AddWithValue("@ket", "Keluar");
                cmd3.Parameters.AddWithValue("@id", kodesptb.Text);
                cmd3.Parameters.AddWithValue("@tggl", datein +" "+ DateTime.Now.ToLongTimeString());
                if (cmd3.ExecuteNonQuery() == 1)

                {
                    // MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("Gagal (2)");
                }
               
                conn.Close();*/
                FillDGVSparepart();
                FillDGVDetilSparepart();
                fullTotal();
                clearK();
            }

        }

        private void jumlahsptb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void detiSpDataGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int tem;
            kodesptb.Text = detiSpDataGrid.Rows[rowIndex].Cells[2].Value.ToString();
            jumlahsptb.Text = detiSpDataGrid.Rows[rowIndex].Cells[3].Value.ToString();
            tem = int.Parse(detiSpDataGrid.Rows[rowIndex].Cells[3].Value.ToString());
            iddetilsp = detiSpDataGrid.Rows[rowIndex].Cells[0].Value.ToString();
            upbtn.Enabled = true;
            upbtn.BackColor = Color.Blue;
            upbtn.Text = "UPDATE";
            addbbtn.Enabled = false;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT KODE_SPAREPART,RAK,NAMA_SPAREPART,HARGA_JUAL,STOK FROM sparepart ", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@sp", kodesptb.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (kodesptb.Text == reader.GetString(0))
                {
                    raksptb.Text = reader.GetString(1);
                    namasptb.Text = reader.GetString(2);
                    hargasptb.Text = reader.GetString(3);
                    stok = int.Parse(reader.GetString(4))+tem;
                }
            }

            conn.Close();
           
        }

        private void upbtn_Click(object sender, EventArgs e)
        {
            if (kodesptb.Text == "" || jumlahsptb.Text == "" || totsptb.Text == "" || totsptb.Text == "0")
            {
                totsptb.Text = "0";
                if (kodesptb.Text == "")
                {
                    MessageBox.Show("Sparepart belum dipilih ");

                }
                else
                {
                    MessageBox.Show("Jumlah item masih nol");
                }

            }
            else
            {
                string sql = "UPDATE detil_sparepart SET JUMLAH_SPAREPART=@jml ,SUBTOTAL_SP=@sub WHERE ID_DETIL_SPAREPART=@id";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@jml", jumlahsptb.Text);
                cmd.Parameters.AddWithValue("@id", iddetilsp);
                cmd.Parameters.AddWithValue("@sub", totsptb.Text);
                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show("update Sucess");
                }
                else
                {
                    MessageBox.Show("Terjadi Kesalahan");
                }
                upbtn.Enabled = false;
                upbtn.BackColor = Color.White;
                upbtn.Text = "";

               
                conn.Close();
              /*  int stoke;
                string sql2 = "UPDATE sparepart SET STOK=@stok WHERE KODE_SPAREPART=@kodesp";
                stoke = stok - int.Parse(jumlahsptb.Text);
                conn.Open();

                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

                cmd2.Parameters.AddWithValue("@kodesp", kodesptb.Text);
                cmd2.Parameters.AddWithValue("@stok", stoke);


                if (cmd2.ExecuteNonQuery() == 1)

                {
                    // MessageBox.Show("Sucess");
                }
                else
                {
                    MessageBox.Show("Terjadi Kesalahan");
                }
                string sql3 = "INSERT INTO histori_barang(KODE_SPAREPART,TANGGAL,JUMLAH, KET, SISA_STOK) VALUES(@id,@tggl,@jum,@ket,@stok)";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                cmd3.Parameters.AddWithValue("@jum", jumlahsptb.Text);
                cmd3.Parameters.AddWithValue("@stok", stoke);
                cmd3.Parameters.AddWithValue("@ket", "Keluar");
                cmd3.Parameters.AddWithValue("@id", kodesptb.Text);
                cmd3.Parameters.AddWithValue("@tggl", datein + " " + DateTime.Now.ToLongTimeString());
                if (cmd3.ExecuteNonQuery() == 1)

                {
                    // MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("Gagal (2)");
                }
                conn.Close();*/
                FillDGVSparepart();
                FillDGVDetilSparepart();
                fullTotal();
                clearK();
            }
        }

        private void detiSpDataGrid_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda ingin menghapus Sparepart ini ?", "Remove Row", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                int rowIndex = e.RowIndex;
                int sr;
                string kode;

                iddetilsp = detiSpDataGrid.Rows[rowIndex].Cells[0].Value.ToString();
                sr = int.Parse(detiSpDataGrid.Rows[rowIndex].Cells[3].Value.ToString());
                kode = detiSpDataGrid.Rows[rowIndex].Cells[2].Value.ToString();

                conn.Open();
                string sql = "DELETE FROM detil_sparepart WHERE ID_DETIL_SPAREPART=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", iddetilsp);

                if (cmd.ExecuteNonQuery() == 1)

                {
                    MessageBox.Show(" Berhasil Menghapus !");
                }
                else
                {
                    MessageBox.Show("Gagal Menghapus !");
                }
                conn.Close();
                conn.Open();
                MySqlCommand cmdx = new MySqlCommand("SELECT STOK FROM sparepart  WHERE KODE_SPAREPART=@sp ", conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                cmdx.Parameters.AddWithValue("@sp", kode);
                MySqlDataReader reader = cmdx.ExecuteReader();
                while (reader.Read())
                {
                    stok = int.Parse(reader.GetString(0));
                }

                conn.Close();
                int stoke;
                string sql2 = "UPDATE sparepart SET STOK=@stok WHERE KODE_SPAREPART=@kodesp";
                stoke = stok + sr;

                conn.Open();

                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);

                cmd2.Parameters.AddWithValue("@kodesp", kodesptb.Text);
                cmd2.Parameters.AddWithValue("@stok", stoke);


                if (cmd2.ExecuteNonQuery() == 1)

                {
                    // MessageBox.Show("Sucess");
                }
                else
                {
                    MessageBox.Show("Terjadi Kesalahan");
                }
                string sql3 = "INSERT INTO histori_barang(KODE_SPAREPART,TANGGAL,JUMLAH, KET, SISA_STOK) VALUES(@id,@tggl,@jum,@ket,@stok)";
                MySqlCommand cmd3 = new MySqlCommand(sql3, conn);
                cmd3.Parameters.AddWithValue("@jum",sr);
                cmd3.Parameters.AddWithValue("@stok", stoke);
                cmd3.Parameters.AddWithValue("@ket", "Masuk");
                cmd3.Parameters.AddWithValue("@id", kodesptb.Text);
                cmd3.Parameters.AddWithValue("@tggl", datein + " " + DateTime.Now.ToLongTimeString());
                if (cmd3.ExecuteNonQuery() == 1)

                {
                    // MessageBox.Show("success");
                }
                else
                {
                    MessageBox.Show("Gagal (2)");
                }
                conn.Close();

            }
            else
            {
                MessageBox.Show("Sparepart Tidak dihapus", "Remove Row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            fullTotal();
            upbtn.Enabled = false;
            upbtn.BackColor = Color.White;
            upbtn.Text = "";
            FillDGVSparepart();
            FillDGVDetilSparepart();

            clearK();
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (fulltot.Text == "")
            {
                MessageBox.Show("data masih kosong !");
            }
            else
            {
                if (fulltot.Text == "")
                {
                    fulltot.Text = "0";

                }


                totfullsp = float.Parse(fulltot.Text);
                subtotal = totfullsp;

                TransaksiCheck admin = new TransaksiCheck();
                admin.Show();



            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void konfirmbtn_Click(object sender, EventArgs e)
        {
          
            if (fulltot.Text == "")
            {
                MessageBox.Show("data masih kosong !");
            }
            else
            {
                if (fulltot.Text == "")
                {
                    fulltot.Text = "0";

                }

                totfullsp = float.Parse(fulltot.Text);
                subtotal = totfullsp;
                tesmasuk = 1;
                conn.Open();
                string sql = "UPDATE transaksi_penjualan SET SUB_TOTAL=@sub,CS=@cs,KEMBALIAN=-1,TANGGAL_TRANS=@tggl WHERE NO_TRANSAKSI=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@sub", subtotal);
                cmd.Parameters.AddWithValue("@tggl", datein + " " + DateTime.Now.ToLongTimeString());
                cmd.Parameters.AddWithValue("@cs", AtmaAuto.namas);
                cmd.Parameters.AddWithValue("@id", notrans);
                if (cmd.ExecuteNonQuery() == 1)

                {
                    //MessageBox.Show("Transaksi Berhasil !");
                }
                else
                {
                    MessageBox.Show("Gagal transaksi");
                }
                
                conn.Close();
                KonfirmasiSpOK admin = new KonfirmasiSpOK();
                admin.Show();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
