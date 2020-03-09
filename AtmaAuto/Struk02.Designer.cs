namespace AtmaAuto
{
    partial class Struk02
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Struk02));
            this.crystalReportView = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportView
            // 
            this.crystalReportView.ActiveViewIndex = -1;
            this.crystalReportView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportView.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportView.Location = new System.Drawing.Point(0, 0);
            this.crystalReportView.Name = "crystalReportView";
            this.crystalReportView.Size = new System.Drawing.Size(619, 498);
            this.crystalReportView.TabIndex = 0;
            this.crystalReportView.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // Struk02
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 498);
            this.Controls.Add(this.crystalReportView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Struk02";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Struk";
            this.Load += new System.EventHandler(this.Struk02_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportView;
    }
}