namespace AtmaAuto
{
    partial class PembayaranForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PembayaranForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.NOtrans12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tothartb = new System.Windows.Forms.TextBox();
            this.diskontb = new System.Windows.Forms.TextBox();
            this.subtot = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.bayartb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bayarverbtn = new System.Windows.Forms.Button();
            this.BayarDGV = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.kembalilbl = new System.Windows.Forms.Label();
            this.CetakStruk = new System.Windows.Forms.Button();
            this.labelsukses = new System.Windows.Forms.Label();
            this.namatbx = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.timeshow = new System.Windows.Forms.Label();
            this.dateshow = new System.Windows.Forms.Label();
            this.timerup = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cariTr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.logout = new System.Windows.Forms.PictureBox();
            this.cbgtxt = new System.Windows.Forms.Label();
            this.clrbtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BayarDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logout)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1377, 54);
            this.panel1.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Humnst777 Blk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(629, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "PEMBAYARAN";
            // 
            // NOtrans12
            // 
            this.NOtrans12.AutoSize = true;
            this.NOtrans12.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.NOtrans12.Font = new System.Drawing.Font("Humnst777 BlkCn BT", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NOtrans12.ForeColor = System.Drawing.Color.White;
            this.NOtrans12.Location = new System.Drawing.Point(129, 15);
            this.NOtrans12.Name = "NOtrans12";
            this.NOtrans12.Size = new System.Drawing.Size(19, 15);
            this.NOtrans12.TabIndex = 108;
            this.NOtrans12.Text = "SS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 107;
            this.label1.Text = "ID TRANSAKSI :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel2.Location = new System.Drawing.Point(18, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 18);
            this.panel2.TabIndex = 113;
            // 
            // tothartb
            // 
            this.tothartb.Enabled = false;
            this.tothartb.Location = new System.Drawing.Point(101, 91);
            this.tothartb.Name = "tothartb";
            this.tothartb.ReadOnly = true;
            this.tothartb.Size = new System.Drawing.Size(259, 20);
            this.tothartb.TabIndex = 119;
            // 
            // diskontb
            // 
            this.diskontb.Location = new System.Drawing.Point(101, 56);
            this.diskontb.Name = "diskontb";
            this.diskontb.Size = new System.Drawing.Size(156, 20);
            this.diskontb.TabIndex = 118;
            this.diskontb.TextChanged += new System.EventHandler(this.diskontb_TextChanged);
            this.diskontb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HargaSp_KeyPress);
            // 
            // subtot
            // 
            this.subtot.Location = new System.Drawing.Point(101, 18);
            this.subtot.Name = "subtot";
            this.subtot.ReadOnly = true;
            this.subtot.Size = new System.Drawing.Size(259, 20);
            this.subtot.TabIndex = 117;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Humnst777 Blk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 14);
            this.label9.TabIndex = 116;
            this.label9.Text = "Total Harga";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Humnst777 Blk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 14);
            this.label8.TabIndex = 115;
            this.label8.Text = "Diskon";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Humnst777 Blk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 14);
            this.label7.TabIndex = 114;
            this.label7.Text = "Sub Total";
            // 
            // bayartb
            // 
            this.bayartb.Location = new System.Drawing.Point(101, 142);
            this.bayartb.Name = "bayartb";
            this.bayartb.Size = new System.Drawing.Size(259, 20);
            this.bayartb.TabIndex = 120;
            this.bayartb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HargaSp_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Humnst777 Blk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 14);
            this.label2.TabIndex = 122;
            this.label2.Text = "Bayar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Humnst777 Blk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 223);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 14);
            this.label3.TabIndex = 123;
            this.label3.Text = "Kembalian";
            // 
            // bayarverbtn
            // 
            this.bayarverbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bayarverbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bayarverbtn.Font = new System.Drawing.Font("Humnst777 Blk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bayarverbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bayarverbtn.Location = new System.Drawing.Point(285, 168);
            this.bayarverbtn.Name = "bayarverbtn";
            this.bayarverbtn.Size = new System.Drawing.Size(75, 36);
            this.bayarverbtn.TabIndex = 124;
            this.bayarverbtn.Text = "Bayar";
            this.bayarverbtn.UseVisualStyleBackColor = false;
            this.bayarverbtn.Click += new System.EventHandler(this.bayarverbtn_Click);
            // 
            // BayarDGV
            // 
            this.BayarDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BayarDGV.Location = new System.Drawing.Point(12, 209);
            this.BayarDGV.Name = "BayarDGV";
            this.BayarDGV.Size = new System.Drawing.Size(704, 382);
            this.BayarDGV.TabIndex = 125;
            this.BayarDGV.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.bayardgv_RowHeaderMouseClick);
            this.BayarDGV.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BayarDGV_RowHeaderMouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.kembalilbl);
            this.groupBox1.Controls.Add(this.bayartb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.bayarverbtn);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.subtot);
            this.groupBox1.Controls.Add(this.diskontb);
            this.groupBox1.Controls.Add(this.tothartb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(736, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 319);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Adobe Gothic Std B", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(105, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 36);
            this.label15.TabIndex = 128;
            this.label15.Text = "Rp.";
            // 
            // kembalilbl
            // 
            this.kembalilbl.AutoSize = true;
            this.kembalilbl.Font = new System.Drawing.Font("Adobe Gothic Std B", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kembalilbl.Location = new System.Drawing.Point(170, 225);
            this.kembalilbl.Name = "kembalilbl";
            this.kembalilbl.Size = new System.Drawing.Size(0, 34);
            this.kembalilbl.TabIndex = 127;
            // 
            // CetakStruk
            // 
            this.CetakStruk.BackColor = System.Drawing.Color.Lime;
            this.CetakStruk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CetakStruk.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CetakStruk.ForeColor = System.Drawing.Color.White;
            this.CetakStruk.Location = new System.Drawing.Point(908, 534);
            this.CetakStruk.Name = "CetakStruk";
            this.CetakStruk.Size = new System.Drawing.Size(216, 34);
            this.CetakStruk.TabIndex = 0;
            this.CetakStruk.Text = "Cetak Struk";
            this.CetakStruk.UseVisualStyleBackColor = false;
            this.CetakStruk.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelsukses
            // 
            this.labelsukses.AutoSize = true;
            this.labelsukses.Font = new System.Drawing.Font("Humnst777 Blk BT", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelsukses.Location = new System.Drawing.Point(469, 370);
            this.labelsukses.Name = "labelsukses";
            this.labelsukses.Size = new System.Drawing.Size(0, 26);
            this.labelsukses.TabIndex = 128;
            // 
            // namatbx
            // 
            this.namatbx.Enabled = false;
            this.namatbx.Location = new System.Drawing.Point(132, 50);
            this.namatbx.Name = "namatbx";
            this.namatbx.Size = new System.Drawing.Size(200, 20);
            this.namatbx.TabIndex = 132;
            this.namatbx.TextChanged += new System.EventHandler(this.namatbx_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Humnst777 Blk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 14);
            this.label11.TabIndex = 129;
            this.label11.Text = "Nama Cusstomer";
            // 
            // timeshow
            // 
            this.timeshow.AutoSize = true;
            this.timeshow.Location = new System.Drawing.Point(1154, 86);
            this.timeshow.Name = "timeshow";
            this.timeshow.Size = new System.Drawing.Size(26, 13);
            this.timeshow.TabIndex = 134;
            this.timeshow.Text = "time";
            // 
            // dateshow
            // 
            this.dateshow.AutoSize = true;
            this.dateshow.Location = new System.Drawing.Point(1154, 66);
            this.dateshow.Name = "dateshow";
            this.dateshow.Size = new System.Drawing.Size(28, 13);
            this.dateshow.TabIndex = 133;
            this.dateshow.Text = "date";
            // 
            // timerup
            // 
            this.timerup.Enabled = true;
            this.timerup.Tick += new System.EventHandler(this.timerup_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Humnst777 Blk BT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 14);
            this.label6.TabIndex = 136;
            this.label6.Text = "Cari Transaksi";
            // 
            // cariTr
            // 
            this.cariTr.Location = new System.Drawing.Point(110, 172);
            this.cariTr.Name = "cariTr";
            this.cariTr.Size = new System.Drawing.Size(250, 20);
            this.cariTr.TabIndex = 135;
            this.cariTr.TextChanged += new System.EventHandler(this.cariSp_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("mileadilan", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 26);
            this.label5.TabIndex = 138;
            this.label5.Text = "Selamat Datang";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Geometr415 Blk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label12.Location = new System.Drawing.Point(22, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 19);
            this.label12.TabIndex = 137;
            this.label12.Text = "Badia Nommensen";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("News706 BT", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label13.Location = new System.Drawing.Point(1264, 605);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 18);
            this.label13.TabIndex = 140;
            this.label13.Text = "Kasir";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("News706 BT", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(1194, 605);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 18);
            this.label14.TabIndex = 139;
            this.label14.Text = "Status :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.namatbx);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.NOtrans12);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(193, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 85);
            this.groupBox2.TabIndex = 141;
            this.groupBox2.TabStop = false;
            // 
            // logout
            // 
            this.logout.Image = global::AtmaAuto.Properties.Resources.LOG_OUT;
            this.logout.Location = new System.Drawing.Point(1144, 541);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(195, 50);
            this.logout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logout.TabIndex = 127;
            this.logout.TabStop = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // cbgtxt
            // 
            this.cbgtxt.AutoSize = true;
            this.cbgtxt.Font = new System.Drawing.Font("Adobe Gothic Std B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbgtxt.Location = new System.Drawing.Point(1152, 110);
            this.cbgtxt.Name = "cbgtxt";
            this.cbgtxt.Size = new System.Drawing.Size(88, 26);
            this.cbgtxt.TabIndex = 142;
            this.cbgtxt.Text = "Cabang";
            // 
            // clrbtn
            // 
            this.clrbtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.clrbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clrbtn.Font = new System.Drawing.Font("Humnst777 Blk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clrbtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.clrbtn.Location = new System.Drawing.Point(783, 532);
            this.clrbtn.Name = "clrbtn";
            this.clrbtn.Size = new System.Drawing.Size(108, 36);
            this.clrbtn.TabIndex = 129;
            this.clrbtn.Text = "Clear";
            this.clrbtn.UseVisualStyleBackColor = false;
            this.clrbtn.Click += new System.EventHandler(this.clrbtn_Click);
            // 
            // PembayaranForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1362, 642);
            this.Controls.Add(this.clrbtn);
            this.Controls.Add(this.cbgtxt);
            this.Controls.Add(this.logout);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cariTr);
            this.Controls.Add(this.timeshow);
            this.Controls.Add(this.dateshow);
            this.Controls.Add(this.CetakStruk);
            this.Controls.Add(this.labelsukses);
            this.Controls.Add(this.BayarDGV);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PembayaranForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PembayaranForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PembayaranForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BayarDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label NOtrans12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tothartb;
        private System.Windows.Forms.TextBox diskontb;
        private System.Windows.Forms.TextBox subtot;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox bayartb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bayarverbtn;
        private System.Windows.Forms.DataGridView BayarDGV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelsukses;
        private System.Windows.Forms.Button CetakStruk;
        private System.Windows.Forms.TextBox namatbx;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label timeshow;
        private System.Windows.Forms.Label dateshow;
        private System.Windows.Forms.Timer timerup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cariTr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox logout;
        private System.Windows.Forms.Label kembalilbl;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label cbgtxt;
        private System.Windows.Forms.Button clrbtn;
    }
}