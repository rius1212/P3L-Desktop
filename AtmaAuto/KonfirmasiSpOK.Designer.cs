﻿namespace AtmaAuto
{
    partial class KonfirmasiSpOK
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tidakbtn = new System.Windows.Forms.Button();
            this.Yesbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-6, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 40);
            this.panel1.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Adobe Gothic Std B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(205, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 26);
            this.label2.TabIndex = 49;
            this.label2.Text = "Konfirmasi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AtmaAuto.Properties.Resources.icons8_close_window_40;
            this.pictureBox1.Location = new System.Drawing.Point(479, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Adobe Gothic Std B", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(222, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 54;
            this.label3.Text = "Benar ?";
            // 
            // tidakbtn
            // 
            this.tidakbtn.BackColor = System.Drawing.Color.Red;
            this.tidakbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tidakbtn.Font = new System.Drawing.Font("Adobe Gothic Std B", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tidakbtn.ForeColor = System.Drawing.Color.White;
            this.tidakbtn.Location = new System.Drawing.Point(298, 168);
            this.tidakbtn.Name = "tidakbtn";
            this.tidakbtn.Size = new System.Drawing.Size(105, 39);
            this.tidakbtn.TabIndex = 53;
            this.tidakbtn.Text = "Tidak";
            this.tidakbtn.UseVisualStyleBackColor = false;
            this.tidakbtn.Click += new System.EventHandler(this.tidakbtn_Click);
            // 
            // Yesbtn
            // 
            this.Yesbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Yesbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Yesbtn.Font = new System.Drawing.Font("Adobe Gothic Std B", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Yesbtn.ForeColor = System.Drawing.Color.White;
            this.Yesbtn.Location = new System.Drawing.Point(108, 168);
            this.Yesbtn.Name = "Yesbtn";
            this.Yesbtn.Size = new System.Drawing.Size(105, 39);
            this.Yesbtn.TabIndex = 52;
            this.Yesbtn.Text = "Ya";
            this.Yesbtn.UseVisualStyleBackColor = false;
            this.Yesbtn.Click += new System.EventHandler(this.Yesbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Adobe Gothic Std B", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 26);
            this.label1.TabIndex = 51;
            this.label1.Text = "Apakah data sudah";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // KonfirmasiSpOK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 265);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tidakbtn);
            this.Controls.Add(this.Yesbtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KonfirmasiSpOK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KonfirmasiSpOK";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button tidakbtn;
        private System.Windows.Forms.Button Yesbtn;
        private System.Windows.Forms.Label label1;
    }
}