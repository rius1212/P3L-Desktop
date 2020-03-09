namespace AtmaAuto
{
    partial class PendapatanTahunForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PendapatanTahunForm));
            this.crystalReportViewPt = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewPt
            // 
            this.crystalReportViewPt.ActiveViewIndex = -1;
            this.crystalReportViewPt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewPt.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewPt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewPt.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewPt.Name = "crystalReportViewPt";
            this.crystalReportViewPt.ShowCloseButton = false;
            this.crystalReportViewPt.ShowCopyButton = false;
            this.crystalReportViewPt.ShowGroupTreeButton = false;
            this.crystalReportViewPt.ShowLogo = false;
            this.crystalReportViewPt.ShowParameterPanelButton = false;
            this.crystalReportViewPt.Size = new System.Drawing.Size(585, 423);
            this.crystalReportViewPt.TabIndex = 0;
            this.crystalReportViewPt.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // PendapatanTahunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 423);
            this.Controls.Add(this.crystalReportViewPt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PendapatanTahunForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laporan Tahunan";
            this.Load += new System.EventHandler(this.PendapatanTahunForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewPt;
    }
}