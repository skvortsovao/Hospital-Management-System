namespace HospitalManagementSystem
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnShowLogin = new System.Windows.Forms.Button();
            this.btnShowRegister = new System.Windows.Forms.Button();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.btnBackFromLogin = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.txtLoginUsername = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelRegister = new System.Windows.Forms.Panel();
            this.btnBackFromRegister = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtRegisterPassword = new System.Windows.Forms.TextBox();
            this.txtRegisterUsername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelLogin.SuspendLayout();
            this.panelRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(263, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1001, 97);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hospital Management System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnShowLogin
            // 
            this.btnShowLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowLogin.Location = new System.Drawing.Point(394, 152);
            this.btnShowLogin.Name = "btnShowLogin";
            this.btnShowLogin.Size = new System.Drawing.Size(263, 73);
            this.btnShowLogin.TabIndex = 1;
            this.btnShowLogin.Text = "Login";
            this.btnShowLogin.UseVisualStyleBackColor = true;
            this.btnShowLogin.Click += new System.EventHandler(this.btnShowLogin_Click);
            // 
            // btnShowRegister
            // 
            this.btnShowRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowRegister.Location = new System.Drawing.Point(872, 152);
            this.btnShowRegister.Name = "btnShowRegister";
            this.btnShowRegister.Size = new System.Drawing.Size(263, 73);
            this.btnShowRegister.TabIndex = 2;
            this.btnShowRegister.Text = "Register";
            this.btnShowRegister.UseVisualStyleBackColor = true;
            this.btnShowRegister.Click += new System.EventHandler(this.btnShowRegister_Click);
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.btnBackFromLogin);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.txtLoginPassword);
            this.panelLogin.Controls.Add(this.txtLoginUsername);
            this.panelLogin.Controls.Add(this.label3);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Location = new System.Drawing.Point(57, 309);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(600, 381);
            this.panelLogin.TabIndex = 3;
            this.panelLogin.Visible = false;
            // 
            // btnBackFromLogin
            // 
            this.btnBackFromLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnBackFromLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBackFromLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackFromLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackFromLogin.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnBackFromLogin.Location = new System.Drawing.Point(227, 309);
            this.btnBackFromLogin.Name = "btnBackFromLogin";
            this.btnBackFromLogin.Size = new System.Drawing.Size(144, 46);
            this.btnBackFromLogin.TabIndex = 5;
            this.btnBackFromLogin.Text = "Go Back";
            this.btnBackFromLogin.UseVisualStyleBackColor = false;
            this.btnBackFromLogin.Click += new System.EventHandler(this.btnBackFromLogin_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(196, 216);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(211, 60);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.Location = new System.Drawing.Point(269, 124);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Size = new System.Drawing.Size(272, 26);
            this.txtLoginPassword.TabIndex = 3;
            this.txtLoginPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.Location = new System.Drawing.Point(269, 64);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.Size = new System.Drawing.Size(272, 26);
            this.txtLoginUsername.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 37);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "Username:";
            // 
            // panelRegister
            // 
            this.panelRegister.Controls.Add(this.btnBackFromRegister);
            this.panelRegister.Controls.Add(this.label6);
            this.panelRegister.Controls.Add(this.cmbRole);
            this.panelRegister.Controls.Add(this.btnRegister);
            this.panelRegister.Controls.Add(this.txtRegisterPassword);
            this.panelRegister.Controls.Add(this.txtRegisterUsername);
            this.panelRegister.Controls.Add(this.label4);
            this.panelRegister.Controls.Add(this.label5);
            this.panelRegister.Location = new System.Drawing.Point(872, 309);
            this.panelRegister.Name = "panelRegister";
            this.panelRegister.Size = new System.Drawing.Size(600, 381);
            this.panelRegister.TabIndex = 5;
            this.panelRegister.Visible = false;
            // 
            // btnBackFromRegister
            // 
            this.btnBackFromRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnBackFromRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBackFromRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackFromRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackFromRegister.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnBackFromRegister.Location = new System.Drawing.Point(237, 321);
            this.btnBackFromRegister.Name = "btnBackFromRegister";
            this.btnBackFromRegister.Size = new System.Drawing.Size(159, 48);
            this.btnBackFromRegister.TabIndex = 6;
            this.btnBackFromRegister.Text = "Go Back";
            this.btnBackFromRegister.UseVisualStyleBackColor = false;
            this.btnBackFromRegister.Click += new System.EventHandler(this.btnBackFromRegister_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(134, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 37);
            this.label6.TabIndex = 6;
            this.label6.Text = "Role:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "admin",
            "doctor",
            "nurse",
            "patient"});
            this.cmbRole.Location = new System.Drawing.Point(269, 193);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(272, 28);
            this.cmbRole.TabIndex = 5;
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(211, 246);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(211, 60);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtRegisterPassword
            // 
            this.txtRegisterPassword.Location = new System.Drawing.Point(269, 124);
            this.txtRegisterPassword.Name = "txtRegisterPassword";
            this.txtRegisterPassword.Size = new System.Drawing.Size(272, 26);
            this.txtRegisterPassword.TabIndex = 3;
            // 
            // txtRegisterUsername
            // 
            this.txtRegisterUsername.Location = new System.Drawing.Point(269, 64);
            this.txtRegisterUsername.Name = "txtRegisterUsername";
            this.txtRegisterUsername.Size = new System.Drawing.Size(272, 26);
            this.txtRegisterUsername.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 37);
            this.label4.TabIndex = 1;
            this.label4.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 37);
            this.label5.TabIndex = 0;
            this.label5.Text = "Username:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1558, 987);
            this.Controls.Add(this.panelRegister);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.btnShowRegister);
            this.Controls.Add(this.btnShowLogin);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Hospital Management System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelRegister.ResumeLayout(false);
            this.panelRegister.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnShowLogin;
        private System.Windows.Forms.Button btnShowRegister;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.TextBox txtLoginUsername;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panelRegister;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtRegisterPassword;
        private System.Windows.Forms.TextBox txtRegisterUsername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Button btnBackFromLogin;
        private System.Windows.Forms.Button btnBackFromRegister;
    }
}

