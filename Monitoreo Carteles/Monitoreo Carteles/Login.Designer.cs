namespace Monitoreo_Carteles
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
            this.label_estadoConexion = new System.Windows.Forms.Label();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_estadoConexion
            // 
            this.label_estadoConexion.AutoSize = true;
            this.label_estadoConexion.Location = new System.Drawing.Point(180, 464);
            this.label_estadoConexion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_estadoConexion.Name = "label_estadoConexion";
            this.label_estadoConexion.Size = new System.Drawing.Size(295, 20);
            this.label_estadoConexion.TabIndex = 6;
            this.label_estadoConexion.Text = "Estado de Conexion con base de datos..";
            this.label_estadoConexion.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(228, 284);
            this.textBox_password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(148, 26);
            this.textBox_password.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 248);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            // 
            // textBox_username
            // 
            this.textBox_username.Location = new System.Drawing.Point(228, 244);
            this.textBox_username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(148, 26);
            this.textBox_username.TabIndex = 2;
            this.textBox_username.TextChanged += new System.EventHandler(this.textBox_username_TextChanged);
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(140, 351);
            this.button_login.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(152, 65);
            this.button_login.TabIndex = 0;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label_estadoConexion);
            this.groupBox1.Controls.Add(this.textBox_password);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_username);
            this.groupBox1.Controls.Add(this.button_login);
            this.groupBox1.Location = new System.Drawing.Point(22, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(483, 489);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Monitoreo_Carteles.Resource1.metrovias;
            this.pictureBox1.Location = new System.Drawing.Point(77, 29);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(324, 154);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 517);
            this.Controls.Add(this.groupBox1);
            this.Name = "Login";
            this.Text = "Login";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_estadoConexion;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}