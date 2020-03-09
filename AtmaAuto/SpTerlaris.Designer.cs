namespace AtmaAuto
{
    partial class SpTerlaris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpTerlaris));
            this.TahunCb = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SP = new System.Windows.Forms.Label();
            this.crystalReportSp = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TahunCb
            // 
            this.TahunCb.FormattingEnabled = true;
            this.TahunCb.Location = new System.Drawing.Point(93, 39);
            this.TahunCb.Name = "TahunCb";
            this.TahunCb.Size = new System.Drawing.Size(121, 21);
            this.TahunCb.TabIndex = 0;
            this.TahunCb.SelectedIndexChanged += new System.EventHandler(this.TahunCb_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.SP);
            this.panel1.Controls.Add(this.TahunCb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 79);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("News706 BT", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(45, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tahun";
            // 
            // SP
            // 
            this.SP.AutoSize = true;
            this.SP.Font = new System.Drawing.Font("Adobe Gothic Std B", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SP.ForeColor = System.Drawing.Color.White;
            this.SP.Location = new System.Drawing.Point(15, 9);
            this.SP.Name = "SP";
            this.SP.Size = new System.Drawing.Size(199, 24);
            this.SP.TabIndex = 1;
            this.SP.Text = "SPAREPART TERLARIS";
            this.SP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // crystalReportSp
            // 
            this.crystalReportSp.ActiveViewIndex = -1;
            this.crystalReportSp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportSp.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportSp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportSp.Location = new System.Drawing.Point(0, 79);
            this.crystalReportSp.Name = "crystalReportSp";
            this.crystalReportSp.ShowCloseButton = false;
            this.crystalReportSp.ShowCopyButton = false;
            this.crystalReportSp.ShowGotoPageButton = false;
            this.crystalReportSp.ShowGroupTreeButton = false;
            this.crystalReportSp.ShowLogo = false;
            this.crystalReportSp.ShowParameterPanelButton = false;
            this.crystalReportSp.ShowTextSearchButton = false;
            this.crystalReportSp.Size = new System.Drawing.Size(725, 435);
            this.crystalReportSp.TabIndex = 2;
            this.crystalReportSp.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // SpTerlaris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(725, 514);
            this.Controls.Add(this.crystalReportSp);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpTerlaris";
            this.Text = "Laporan Sparepart Terlaris";
            this.Load += new System.EventHandler(this.SpTerlaris_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox TahunCb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SP;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportSp;
    }
}