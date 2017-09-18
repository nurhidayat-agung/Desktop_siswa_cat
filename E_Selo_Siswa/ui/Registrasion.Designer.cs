namespace E_Selo_Siswa.ui
{
    partial class Registrasion
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
            this.skinLogin = new FlatUI.FormSkin();
            this.abx5 = new FlatUI.FlatAlertBox();
            this.btnCek = new FlatUI.FlatButton();
            this.abx4 = new FlatUI.FlatAlertBox();
            this.abx3 = new FlatUI.FlatAlertBox();
            this.tbxNis = new System.Windows.Forms.TextBox();
            this.abx2 = new FlatUI.FlatAlertBox();
            this.abx1 = new FlatUI.FlatAlertBox();
            this.btn_reg = new FlatUI.FlatStickyButton();
            this.cbxAngkatan = new FlatUI.FlatComboBox();
            this.flatLabel6 = new FlatUI.FlatLabel();
            this.cbxKompi = new FlatUI.FlatComboBox();
            this.flatLabel5 = new FlatUI.FlatLabel();
            this.cbxPleton = new FlatUI.FlatComboBox();
            this.flatLabel4 = new FlatUI.FlatLabel();
            this.tbx_pass = new FlatUI.FlatTextBox();
            this.flatLabel3 = new FlatUI.FlatLabel();
            this.tbx_nama = new FlatUI.FlatTextBox();
            this.flatLabel2 = new FlatUI.FlatLabel();
            this.flatLabel1 = new FlatUI.FlatLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_close = new FlatUI.FlatButton();
            this.skinLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // skinLogin
            // 
            this.skinLogin.BackColor = System.Drawing.Color.White;
            this.skinLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.skinLogin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.skinLogin.Controls.Add(this.abx5);
            this.skinLogin.Controls.Add(this.btnCek);
            this.skinLogin.Controls.Add(this.abx4);
            this.skinLogin.Controls.Add(this.abx3);
            this.skinLogin.Controls.Add(this.tbxNis);
            this.skinLogin.Controls.Add(this.abx2);
            this.skinLogin.Controls.Add(this.abx1);
            this.skinLogin.Controls.Add(this.btn_reg);
            this.skinLogin.Controls.Add(this.cbxAngkatan);
            this.skinLogin.Controls.Add(this.flatLabel6);
            this.skinLogin.Controls.Add(this.cbxKompi);
            this.skinLogin.Controls.Add(this.flatLabel5);
            this.skinLogin.Controls.Add(this.cbxPleton);
            this.skinLogin.Controls.Add(this.flatLabel4);
            this.skinLogin.Controls.Add(this.tbx_pass);
            this.skinLogin.Controls.Add(this.flatLabel3);
            this.skinLogin.Controls.Add(this.tbx_nama);
            this.skinLogin.Controls.Add(this.flatLabel2);
            this.skinLogin.Controls.Add(this.flatLabel1);
            this.skinLogin.Controls.Add(this.pictureBox1);
            this.skinLogin.Controls.Add(this.btn_close);
            this.skinLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinLogin.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.skinLogin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.skinLogin.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.skinLogin.HeaderMaximize = false;
            this.skinLogin.Location = new System.Drawing.Point(0, 0);
            this.skinLogin.Name = "skinLogin";
            this.skinLogin.Size = new System.Drawing.Size(744, 542);
            this.skinLogin.TabIndex = 0;
            this.skinLogin.Text = "Registrasion";
            // 
            // abx5
            // 
            this.abx5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.abx5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.abx5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.abx5.kind = FlatUI.FlatAlertBox._Kind.Error;
            this.abx5.Location = new System.Drawing.Point(99, 70);
            this.abx5.Name = "abx5";
            this.abx5.Size = new System.Drawing.Size(576, 42);
            this.abx5.TabIndex = 21;
            this.abx5.Text = "Mohon NIS diisi terlebih dahulu";
            this.abx5.Visible = false;
            // 
            // btnCek
            // 
            this.btnCek.BackColor = System.Drawing.Color.Transparent;
            this.btnCek.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btnCek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCek.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCek.Location = new System.Drawing.Point(613, 80);
            this.btnCek.Name = "btnCek";
            this.btnCek.Rounded = false;
            this.btnCek.Size = new System.Drawing.Size(48, 32);
            this.btnCek.TabIndex = 20;
            this.btnCek.Text = "Cek";
            this.btnCek.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btnCek.Click += new System.EventHandler(this.btnCek_Click);
            // 
            // abx4
            // 
            this.abx4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.abx4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.abx4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.abx4.kind = FlatUI.FlatAlertBox._Kind.Error;
            this.abx4.Location = new System.Drawing.Point(99, 249);
            this.abx4.Name = "abx4";
            this.abx4.Size = new System.Drawing.Size(576, 42);
            this.abx4.TabIndex = 19;
            this.abx4.Text = "siswa gagal didaftarkan periksa apakah data sudah di input dengan benar";
            this.abx4.Visible = false;
            // 
            // abx3
            // 
            this.abx3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.abx3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.abx3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.abx3.kind = FlatUI.FlatAlertBox._Kind.Success;
            this.abx3.Location = new System.Drawing.Point(99, 249);
            this.abx3.Name = "abx3";
            this.abx3.Size = new System.Drawing.Size(576, 42);
            this.abx3.TabIndex = 18;
            this.abx3.Text = "Siswa berhasil didaftarkan";
            this.abx3.Visible = false;
            // 
            // tbxNis
            // 
            this.tbxNis.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tbxNis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxNis.Location = new System.Drawing.Point(433, 90);
            this.tbxNis.Name = "tbxNis";
            this.tbxNis.Size = new System.Drawing.Size(174, 22);
            this.tbxNis.TabIndex = 17;
            this.tbxNis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNis_KeyPress);
            // 
            // abx2
            // 
            this.abx2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.abx2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.abx2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.abx2.kind = FlatUI.FlatAlertBox._Kind.Info;
            this.abx2.Location = new System.Drawing.Point(99, 249);
            this.abx2.Name = "abx2";
            this.abx2.Size = new System.Drawing.Size(576, 42);
            this.abx2.TabIndex = 16;
            this.abx2.Text = "Mohon Tunggu Registrasi data sedang dikirim ke Server";
            this.abx2.Visible = false;
            // 
            // abx1
            // 
            this.abx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.abx1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.abx1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.abx1.kind = FlatUI.FlatAlertBox._Kind.Error;
            this.abx1.Location = new System.Drawing.Point(99, 249);
            this.abx1.Name = "abx1";
            this.abx1.Size = new System.Drawing.Size(576, 42);
            this.abx1.TabIndex = 15;
            this.abx1.Text = "Silahkan Pilih Pleton,Kompi dan Angkatan terlebih dahulu";
            this.abx1.Visible = false;
            this.abx1.Click += new System.EventHandler(this.flatAlertBox1_Click);
            // 
            // btn_reg
            // 
            this.btn_reg.BackColor = System.Drawing.Color.Transparent;
            this.btn_reg.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btn_reg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_reg.Enabled = false;
            this.btn_reg.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_reg.Location = new System.Drawing.Point(456, 487);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Rounded = false;
            this.btn_reg.Size = new System.Drawing.Size(181, 32);
            this.btn_reg.TabIndex = 14;
            this.btn_reg.Text = "Daftar";
            this.btn_reg.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btn_reg.Click += new System.EventHandler(this.tbx_reg_Click);
            // 
            // cbxAngkatan
            // 
            this.cbxAngkatan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cbxAngkatan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxAngkatan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxAngkatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAngkatan.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbxAngkatan.ForeColor = System.Drawing.Color.White;
            this.cbxAngkatan.FormattingEnabled = true;
            this.cbxAngkatan.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cbxAngkatan.ItemHeight = 18;
            this.cbxAngkatan.Location = new System.Drawing.Point(433, 429);
            this.cbxAngkatan.Name = "cbxAngkatan";
            this.cbxAngkatan.Size = new System.Drawing.Size(228, 24);
            this.cbxAngkatan.TabIndex = 13;
            // 
            // flatLabel6
            // 
            this.flatLabel6.AutoSize = true;
            this.flatLabel6.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel6.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel6.ForeColor = System.Drawing.Color.White;
            this.flatLabel6.Location = new System.Drawing.Point(430, 413);
            this.flatLabel6.Name = "flatLabel6";
            this.flatLabel6.Size = new System.Drawing.Size(82, 13);
            this.flatLabel6.TabIndex = 12;
            this.flatLabel6.Text = "Pilih Angkatan";
            // 
            // cbxKompi
            // 
            this.cbxKompi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cbxKompi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxKompi.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxKompi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxKompi.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbxKompi.ForeColor = System.Drawing.Color.White;
            this.cbxKompi.FormattingEnabled = true;
            this.cbxKompi.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cbxKompi.ItemHeight = 18;
            this.cbxKompi.Location = new System.Drawing.Point(433, 359);
            this.cbxKompi.Name = "cbxKompi";
            this.cbxKompi.Size = new System.Drawing.Size(228, 24);
            this.cbxKompi.TabIndex = 11;
            // 
            // flatLabel5
            // 
            this.flatLabel5.AutoSize = true;
            this.flatLabel5.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel5.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel5.ForeColor = System.Drawing.Color.White;
            this.flatLabel5.Location = new System.Drawing.Point(430, 343);
            this.flatLabel5.Name = "flatLabel5";
            this.flatLabel5.Size = new System.Drawing.Size(64, 13);
            this.flatLabel5.TabIndex = 10;
            this.flatLabel5.Text = "Pilih Kompi";
            // 
            // cbxPleton
            // 
            this.cbxPleton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cbxPleton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbxPleton.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxPleton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPleton.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbxPleton.ForeColor = System.Drawing.Color.White;
            this.cbxPleton.FormattingEnabled = true;
            this.cbxPleton.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cbxPleton.ItemHeight = 18;
            this.cbxPleton.Location = new System.Drawing.Point(433, 294);
            this.cbxPleton.Name = "cbxPleton";
            this.cbxPleton.Size = new System.Drawing.Size(228, 24);
            this.cbxPleton.TabIndex = 9;
            // 
            // flatLabel4
            // 
            this.flatLabel4.AutoSize = true;
            this.flatLabel4.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel4.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel4.ForeColor = System.Drawing.Color.White;
            this.flatLabel4.Location = new System.Drawing.Point(430, 278);
            this.flatLabel4.Name = "flatLabel4";
            this.flatLabel4.Size = new System.Drawing.Size(65, 13);
            this.flatLabel4.TabIndex = 8;
            this.flatLabel4.Text = "Pilih Pleton";
            // 
            // tbx_pass
            // 
            this.tbx_pass.BackColor = System.Drawing.Color.Transparent;
            this.tbx_pass.FocusOnHover = false;
            this.tbx_pass.Location = new System.Drawing.Point(433, 226);
            this.tbx_pass.MaxLength = 32767;
            this.tbx_pass.Multiline = false;
            this.tbx_pass.Name = "tbx_pass";
            this.tbx_pass.ReadOnly = false;
            this.tbx_pass.Size = new System.Drawing.Size(228, 29);
            this.tbx_pass.TabIndex = 7;
            this.tbx_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbx_pass.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tbx_pass.UseSystemPasswordChar = true;
            // 
            // flatLabel3
            // 
            this.flatLabel3.AutoSize = true;
            this.flatLabel3.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel3.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel3.ForeColor = System.Drawing.Color.White;
            this.flatLabel3.Location = new System.Drawing.Point(430, 209);
            this.flatLabel3.Name = "flatLabel3";
            this.flatLabel3.Size = new System.Drawing.Size(56, 13);
            this.flatLabel3.TabIndex = 6;
            this.flatLabel3.Text = "Password";
            // 
            // tbx_nama
            // 
            this.tbx_nama.BackColor = System.Drawing.Color.Transparent;
            this.tbx_nama.FocusOnHover = false;
            this.tbx_nama.Location = new System.Drawing.Point(433, 158);
            this.tbx_nama.MaxLength = 32767;
            this.tbx_nama.Multiline = false;
            this.tbx_nama.Name = "tbx_nama";
            this.tbx_nama.ReadOnly = false;
            this.tbx_nama.Size = new System.Drawing.Size(228, 29);
            this.tbx_nama.TabIndex = 5;
            this.tbx_nama.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tbx_nama.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tbx_nama.UseSystemPasswordChar = false;
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(430, 141);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(68, 13);
            this.flatLabel2.TabIndex = 4;
            this.flatLabel2.Text = "Nama Siswa";
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(430, 73);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(24, 13);
            this.flatLabel1.TabIndex = 2;
            this.flatLabel1.Text = "NIS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::E_Selo_Siswa.Properties.Resources.lemdikpol;
            this.pictureBox1.Location = new System.Drawing.Point(33, 107);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(325, 367);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_close.Location = new System.Drawing.Point(626, 12);
            this.btn_close.Name = "btn_close";
            this.btn_close.Rounded = false;
            this.btn_close.Size = new System.Drawing.Size(106, 32);
            this.btn_close.TabIndex = 0;
            this.btn_close.Text = "Tutup";
            this.btn_close.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Registrasion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 542);
            this.Controls.Add(this.skinLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Registrasion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrasion";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.skinLogin.ResumeLayout(false);
            this.skinLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUI.FormSkin skinLogin;
        private FlatUI.FlatButton btn_close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FlatUI.FlatLabel flatLabel1;
        private FlatUI.FlatTextBox tbx_pass;
        private FlatUI.FlatLabel flatLabel3;
        private FlatUI.FlatTextBox tbx_nama;
        private FlatUI.FlatLabel flatLabel2;
        private FlatUI.FlatComboBox cbxAngkatan;
        private FlatUI.FlatLabel flatLabel6;
        private FlatUI.FlatComboBox cbxKompi;
        private FlatUI.FlatLabel flatLabel5;
        private FlatUI.FlatComboBox cbxPleton;
        private FlatUI.FlatLabel flatLabel4;
        private FlatUI.FlatStickyButton btn_reg;
        private FlatUI.FlatAlertBox abx1;
        private FlatUI.FlatAlertBox abx2;
        private System.Windows.Forms.TextBox tbxNis;
        private FlatUI.FlatAlertBox abx3;
        private FlatUI.FlatAlertBox abx4;
        private FlatUI.FlatButton btnCek;
        private FlatUI.FlatAlertBox abx5;
    }
}