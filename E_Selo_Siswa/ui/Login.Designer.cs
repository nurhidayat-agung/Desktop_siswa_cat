namespace E_Selo_Siswa.ui
{
    partial class Login
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
            this.flatClose1 = new FlatUI.FlatClose();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_nis = new FlatUI.FlatTextBox();
            this.tb_pass = new FlatUI.FlatTextBox();
            this.btn_login = new FlatUI.FlatButton();
            this.flatMini1 = new FlatUI.FlatMini();
            this.pg_login = new FlatUI.FlatProgressBar();
            this.btn_register = new FlatUI.FlatButton();
            this.formSkin1 = new FlatUI.FormSkin();
            this.abx1 = new FlatUI.FlatAlertBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.formSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flatClose1
            // 
            this.flatClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatClose1.BackColor = System.Drawing.Color.White;
            this.flatClose1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.flatClose1.Font = new System.Drawing.Font("Marlett", 10F);
            this.flatClose1.Location = new System.Drawing.Point(424, 16);
            this.flatClose1.Name = "flatClose1";
            this.flatClose1.Size = new System.Drawing.Size(18, 18);
            this.flatClose1.TabIndex = 0;
            this.flatClose1.Text = "flatClose1";
            this.flatClose1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::E_Selo_Siswa.Properties.Resources.sekpol;
            this.pictureBox1.Location = new System.Drawing.Point(138, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tb_nis
            // 
            this.tb_nis.BackColor = System.Drawing.Color.Transparent;
            this.tb_nis.FocusOnHover = false;
            this.tb_nis.Location = new System.Drawing.Point(120, 262);
            this.tb_nis.MaxLength = 32767;
            this.tb_nis.Multiline = false;
            this.tb_nis.Name = "tb_nis";
            this.tb_nis.ReadOnly = false;
            this.tb_nis.Size = new System.Drawing.Size(213, 29);
            this.tb_nis.TabIndex = 2;
            this.tb_nis.Text = "Masukan NIS";
            this.tb_nis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_nis.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_nis.UseSystemPasswordChar = false;
            this.tb_nis.Enter += new System.EventHandler(this.tb_nis_Enter);
            this.tb_nis.Leave += new System.EventHandler(this.tb_nis_Leave);
            // 
            // tb_pass
            // 
            this.tb_pass.BackColor = System.Drawing.Color.Transparent;
            this.tb_pass.FocusOnHover = false;
            this.tb_pass.Location = new System.Drawing.Point(120, 314);
            this.tb_pass.MaxLength = 32767;
            this.tb_pass.Multiline = false;
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.ReadOnly = false;
            this.tb_pass.Size = new System.Drawing.Size(213, 29);
            this.tb_pass.TabIndex = 3;
            this.tb_pass.Text = "lalila";
            this.tb_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_pass.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_pass.UseSystemPasswordChar = true;
            this.tb_pass.Enter += new System.EventHandler(this.tb_pass_Enter);
            this.tb_pass.Leave += new System.EventHandler(this.tb_pass_Leave);
            // 
            // btn_login
            // 
            this.btn_login.BackColor = System.Drawing.Color.Transparent;
            this.btn_login.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_login.Location = new System.Drawing.Point(101, 369);
            this.btn_login.Name = "btn_login";
            this.btn_login.Rounded = false;
            this.btn_login.Size = new System.Drawing.Size(106, 32);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Login";
            this.btn_login.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // flatMini1
            // 
            this.flatMini1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flatMini1.BackColor = System.Drawing.Color.White;
            this.flatMini1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatMini1.Font = new System.Drawing.Font("Marlett", 12F);
            this.flatMini1.Location = new System.Drawing.Point(400, 16);
            this.flatMini1.Name = "flatMini1";
            this.flatMini1.Size = new System.Drawing.Size(18, 18);
            this.flatMini1.TabIndex = 5;
            this.flatMini1.Text = "flatMini1";
            this.flatMini1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // pg_login
            // 
            this.pg_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.pg_login.DarkerProgress = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(148)))), ((int)(((byte)(92)))));
            this.pg_login.Location = new System.Drawing.Point(51, 407);
            this.pg_login.Maximum = 100;
            this.pg_login.Name = "pg_login";
            this.pg_login.Pattern = true;
            this.pg_login.PercentSign = false;
            this.pg_login.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.pg_login.ShowBalloon = true;
            this.pg_login.Size = new System.Drawing.Size(348, 42);
            this.pg_login.TabIndex = 6;
            this.pg_login.Text = "flatProgressBar1";
            this.pg_login.Value = 0;
            // 
            // btn_register
            // 
            this.btn_register.BackColor = System.Drawing.Color.Transparent;
            this.btn_register.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.btn_register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_register.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btn_register.Location = new System.Drawing.Point(244, 369);
            this.btn_register.Name = "btn_register";
            this.btn_register.Rounded = false;
            this.btn_register.Size = new System.Drawing.Size(106, 32);
            this.btn_register.TabIndex = 7;
            this.btn_register.Text = "Register";
            this.btn_register.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.abx1);
            this.formSkin1.Controls.Add(this.btn_register);
            this.formSkin1.Controls.Add(this.pg_login);
            this.formSkin1.Controls.Add(this.flatMini1);
            this.formSkin1.Controls.Add(this.btn_login);
            this.formSkin1.Controls.Add(this.tb_pass);
            this.formSkin1.Controls.Add(this.tb_nis);
            this.formSkin1.Controls.Add(this.pictureBox1);
            this.formSkin1.Controls.Add(this.flatClose1);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(460, 486);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "E-Selo Login";
            // 
            // abx1
            // 
            this.abx1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.abx1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.abx1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.abx1.kind = FlatUI.FlatAlertBox._Kind.Info;
            this.abx1.Location = new System.Drawing.Point(25, 369);
            this.abx1.Name = "abx1";
            this.abx1.Size = new System.Drawing.Size(406, 42);
            this.abx1.TabIndex = 8;
            this.abx1.Text = "Mohon Tunggu";
            this.abx1.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 486);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.formSkin1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUI.FormSkin formSkin1;
        private FlatUI.FlatButton btn_register;
        private FlatUI.FlatProgressBar pg_login;
        private FlatUI.FlatMini flatMini1;
        private FlatUI.FlatButton btn_login;
        private FlatUI.FlatTextBox tb_pass;
        private FlatUI.FlatTextBox tb_nis;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FlatUI.FlatClose flatClose1;
        private FlatUI.FlatAlertBox abx1;
    }
}