namespace staj
{
    partial class Kategori
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kategori));
            this.TextKategori = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnKategoriEkle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextKategori
            // 
            this.TextKategori.BackColor = System.Drawing.Color.White;
            this.TextKategori.Location = new System.Drawing.Point(122, 127);
            this.TextKategori.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.TextKategori.Name = "TextKategori";
            this.TextKategori.Size = new System.Drawing.Size(100, 20);
            this.TextKategori.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Kategori:";
            // 
            // btnKategoriEkle
            // 
            this.btnKategoriEkle.BackColor = System.Drawing.Color.Silver;
            this.btnKategoriEkle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnKategoriEkle.Font = new System.Drawing.Font("Impact", 10.25F);
            this.btnKategoriEkle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnKategoriEkle.Location = new System.Drawing.Point(148, 174);
            this.btnKategoriEkle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnKategoriEkle.Name = "btnKategoriEkle";
            this.btnKategoriEkle.Size = new System.Drawing.Size(74, 27);
            this.btnKategoriEkle.TabIndex = 25;
            this.btnKategoriEkle.Text = "EKLE";
            this.btnKategoriEkle.UseVisualStyleBackColor = false;
            this.btnKategoriEkle.Click += new System.EventHandler(this.btnKategoriEkle_Click);
            // 
            // Kategori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(270, 294);
            this.Controls.Add(this.btnKategoriEkle);
            this.Controls.Add(this.TextKategori);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Kategori";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kategori";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextKategori;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKategoriEkle;
    }
}