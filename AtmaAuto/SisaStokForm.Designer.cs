namespace AtmaAuto
{
    partial class SisaStokForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SisaStokForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tipecb = new System.Windows.Forms.ComboBox();
            this.tahuncb = new System.Windows.Forms.ComboBox();
            this.crystalReportViewStok = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tipecb);
            this.panel1.Controls.Add(this.tahuncb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 102);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(24, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sisa Stok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tipe Sparepart";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tahun :";
            // 
            // tipecb
            // 
            this.tipecb.FormattingEnabled = true;
            this.tipecb.Location = new System.Drawing.Point(113, 73);
            this.tipecb.Name = "tipecb";
            this.tipecb.Size = new System.Drawing.Size(123, 21);
            this.tipecb.TabIndex = 1;
            this.tipecb.SelectedIndexChanged += new System.EventHandler(this.TipeCb_SelectedIndexChanged);
            // 
            // tahuncb
            // 
            this.tahuncb.FormattingEnabled = true;
            this.tahuncb.Location = new System.Drawing.Point(113, 49);
            this.tahuncb.Name = "tahuncb";
            this.tahuncb.Size = new System.Drawing.Size(123, 21);
            this.tahuncb.TabIndex = 0;
            this.tahuncb.SelectedIndexChanged += new System.EventHandler(this.TahunCb_SelectedIndexChanged);
            // 
            // crystalReportViewStok
            // 
            this.crystalReportViewStok.ActiveViewIndex = -1;
            this.crystalReportViewStok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewStok.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewStok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewStok.Location = new System.Drawing.Point(0, 102);
            this.crystalReportViewStok.Name = "crystalReportViewStok";
            this.crystalReportViewStok.Size = new System.Drawing.Size(498, 282);
            this.crystalReportViewStok.TabIndex = 1;
            this.crystalReportViewStok.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // SisaStokForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 384);
            this.Controls.Add(this.crystalReportViewStok);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SisaStokForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laporan Sisa Stok";
            this.Load += new System.EventHandler(this.SisaStokForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tipecb;
        private System.Windows.Forms.ComboBox tahuncb;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewStok;
    }
}