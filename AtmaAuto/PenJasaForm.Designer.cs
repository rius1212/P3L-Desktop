namespace AtmaAuto
{
    partial class PenJasaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PenJasaForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bulancb = new System.Windows.Forms.ComboBox();
            this.tahuncb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewjas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.bulancb);
            this.panel1.Controls.Add(this.tahuncb);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(585, 85);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bulan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tahun";
            // 
            // bulancb
            // 
            this.bulancb.FormattingEnabled = true;
            this.bulancb.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.bulancb.Location = new System.Drawing.Point(260, 52);
            this.bulancb.Name = "bulancb";
            this.bulancb.Size = new System.Drawing.Size(121, 21);
            this.bulancb.TabIndex = 2;
            this.bulancb.SelectedIndexChanged += new System.EventHandler(this.bulancb_SelectedIndexChanged);
            // 
            // tahuncb
            // 
            this.tahuncb.FormattingEnabled = true;
            this.tahuncb.Location = new System.Drawing.Point(65, 52);
            this.tahuncb.Name = "tahuncb";
            this.tahuncb.Size = new System.Drawing.Size(121, 21);
            this.tahuncb.TabIndex = 1;
            this.tahuncb.SelectedIndexChanged += new System.EventHandler(this.TahunCb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Gothic Std B", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "PENJUALAN JASA";
            // 
            // crystalReportViewjas
            // 
            this.crystalReportViewjas.ActiveViewIndex = -1;
            this.crystalReportViewjas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewjas.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewjas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewjas.Location = new System.Drawing.Point(0, 85);
            this.crystalReportViewjas.Name = "crystalReportViewjas";
            this.crystalReportViewjas.Size = new System.Drawing.Size(585, 345);
            this.crystalReportViewjas.TabIndex = 1;
            this.crystalReportViewjas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PenJasaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 430);
            this.Controls.Add(this.crystalReportViewjas);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PenJasaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laporan Penjualan Jasa";
            this.Load += new System.EventHandler(this.PenJasaForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox bulancb;
        private System.Windows.Forms.ComboBox tahuncb;
        private System.Windows.Forms.Label label1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewjas;
    }
}