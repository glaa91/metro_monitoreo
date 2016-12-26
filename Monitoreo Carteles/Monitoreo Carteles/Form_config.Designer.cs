namespace Monitoreo_Carteles
{
    partial class Form_config
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
            this.label13 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.config_labelMensajeActual = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.config_groupBoxMensaje = new System.Windows.Forms.GroupBox();
            this.config_comboBox = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.config_groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.config_labelLinea = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.config_labelNumeroSerie = new System.Windows.Forms.Label();
            this.config_labelEstacion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.config_labelIp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.config_labelCorriente = new System.Windows.Forms.Label();
            this.config_labelPila = new System.Windows.Forms.Label();
            this.config_labelUltimaActualizacion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.config_groupBoxParametros = new System.Windows.Forms.GroupBox();
            this.config_labelFuente24v = new System.Windows.Forms.Label();
            this.config_labelFuentePpic = new System.Windows.Forms.Label();
            this.config_labelFuente5Pic = new System.Windows.Forms.Label();
            this.config_labelFuente5v = new System.Windows.Forms.Label();
            this.config_labelTemp = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.config_listBoxCarteles = new System.Windows.Forms.ListBox();
            this.config_labelCarteles = new System.Windows.Forms.Label();
            this.config_buttonEnviarComando = new System.Windows.Forms.Button();
            this.config_groupBoxMensaje.SuspendLayout();
            this.config_groupBoxDatos.SuspendLayout();
            this.config_groupBoxParametros.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 150);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 24);
            this.label13.TabIndex = 4;
            this.label13.Text = "label13";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(8, 80);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 24);
            this.label20.TabIndex = 3;
            this.label20.Text = "Enviar Señal:";
            // 
            // config_labelMensajeActual
            // 
            this.config_labelMensajeActual.AutoSize = true;
            this.config_labelMensajeActual.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelMensajeActual.Location = new System.Drawing.Point(160, 31);
            this.config_labelMensajeActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelMensajeActual.Name = "config_labelMensajeActual";
            this.config_labelMensajeActual.Size = new System.Drawing.Size(51, 24);
            this.config_labelMensajeActual.TabIndex = 2;
            this.config_labelMensajeActual.Text = "label";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(8, 31);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(144, 24);
            this.label18.TabIndex = 0;
            this.label18.Text = "Mensaje Actual:";
            // 
            // config_groupBoxMensaje
            // 
            this.config_groupBoxMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.config_groupBoxMensaje.Controls.Add(this.config_buttonEnviarComando);
            this.config_groupBoxMensaje.Controls.Add(this.label13);
            this.config_groupBoxMensaje.Controls.Add(this.label20);
            this.config_groupBoxMensaje.Controls.Add(this.config_labelMensajeActual);
            this.config_groupBoxMensaje.Controls.Add(this.config_comboBox);
            this.config_groupBoxMensaje.Controls.Add(this.label18);
            this.config_groupBoxMensaje.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_groupBoxMensaje.Location = new System.Drawing.Point(13, 402);
            this.config_groupBoxMensaje.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.config_groupBoxMensaje.MinimumSize = new System.Drawing.Size(625, 0);
            this.config_groupBoxMensaje.Name = "config_groupBoxMensaje";
            this.config_groupBoxMensaje.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.config_groupBoxMensaje.Size = new System.Drawing.Size(625, 206);
            this.config_groupBoxMensaje.TabIndex = 13;
            this.config_groupBoxMensaje.TabStop = false;
            this.config_groupBoxMensaje.Text = "Mensaje";
            // 
            // config_comboBox
            // 
            this.config_comboBox.FormattingEnabled = true;
            this.config_comboBox.Location = new System.Drawing.Point(133, 77);
            this.config_comboBox.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.config_comboBox.Name = "config_comboBox";
            this.config_comboBox.Size = new System.Drawing.Size(200, 32);
            this.config_comboBox.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(280, 127);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(125, 24);
            this.label17.TabIndex = 12;
            this.label17.Text = "Fuente 5v Pic:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(280, 103);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(112, 24);
            this.label16.TabIndex = 11;
            this.label16.Text = "Fuente Ppic:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(280, 79);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 24);
            this.label15.TabIndex = 10;
            this.label15.Text = "Fuente 24v:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(280, 31);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 24);
            this.label14.TabIndex = 9;
            this.label14.Text = "Fuente 5v:";
            // 
            // config_groupBoxDatos
            // 
            this.config_groupBoxDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.config_groupBoxDatos.AutoSize = true;
            this.config_groupBoxDatos.Controls.Add(this.config_labelLinea);
            this.config_groupBoxDatos.Controls.Add(this.label21);
            this.config_groupBoxDatos.Controls.Add(this.config_labelNumeroSerie);
            this.config_groupBoxDatos.Controls.Add(this.config_labelEstacion);
            this.config_groupBoxDatos.Controls.Add(this.label1);
            this.config_groupBoxDatos.Controls.Add(this.config_labelIp);
            this.config_groupBoxDatos.Controls.Add(this.label2);
            this.config_groupBoxDatos.Controls.Add(this.label3);
            this.config_groupBoxDatos.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_groupBoxDatos.Location = new System.Drawing.Point(184, 62);
            this.config_groupBoxDatos.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.config_groupBoxDatos.MinimumSize = new System.Drawing.Size(415, 134);
            this.config_groupBoxDatos.Name = "config_groupBoxDatos";
            this.config_groupBoxDatos.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.config_groupBoxDatos.Size = new System.Drawing.Size(454, 134);
            this.config_groupBoxDatos.TabIndex = 11;
            this.config_groupBoxDatos.TabStop = false;
            this.config_groupBoxDatos.Text = "Datos del cartel:";
            this.config_groupBoxDatos.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // config_labelLinea
            // 
            this.config_labelLinea.AutoSize = true;
            this.config_labelLinea.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelLinea.Location = new System.Drawing.Point(408, 31);
            this.config_labelLinea.Name = "config_labelLinea";
            this.config_labelLinea.Size = new System.Drawing.Size(38, 24);
            this.config_labelLinea.TabIndex = 8;
            this.config_labelLinea.Text = "null";
            this.config_labelLinea.Click += new System.EventHandler(this.config_labelLinea_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(318, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 24);
            this.label21.TabIndex = 7;
            this.label21.Text = "Linea:";
            // 
            // config_labelNumeroSerie
            // 
            this.config_labelNumeroSerie.AutoSize = true;
            this.config_labelNumeroSerie.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelNumeroSerie.Location = new System.Drawing.Point(100, 31);
            this.config_labelNumeroSerie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelNumeroSerie.Name = "config_labelNumeroSerie";
            this.config_labelNumeroSerie.Size = new System.Drawing.Size(38, 24);
            this.config_labelNumeroSerie.TabIndex = 4;
            this.config_labelNumeroSerie.Text = "null";
            // 
            // config_labelEstacion
            // 
            this.config_labelEstacion.AutoSize = true;
            this.config_labelEstacion.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelEstacion.Location = new System.Drawing.Point(408, 79);
            this.config_labelEstacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelEstacion.Name = "config_labelEstacion";
            this.config_labelEstacion.Size = new System.Drawing.Size(38, 24);
            this.config_labelEstacion.TabIndex = 6;
            this.config_labelEstacion.Text = "null";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero \r\nde serie:";
            // 
            // config_labelIp
            // 
            this.config_labelIp.AutoSize = true;
            this.config_labelIp.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelIp.Location = new System.Drawing.Point(100, 79);
            this.config_labelIp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelIp.Name = "config_labelIp";
            this.config_labelIp.Size = new System.Drawing.Size(38, 24);
            this.config_labelIp.TabIndex = 5;
            this.config_labelIp.Text = "null";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(318, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 3;
            this.label3.Text = "Estación:";
            // 
            // config_labelCorriente
            // 
            this.config_labelCorriente.AutoSize = true;
            this.config_labelCorriente.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelCorriente.Location = new System.Drawing.Point(140, 127);
            this.config_labelCorriente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelCorriente.Name = "config_labelCorriente";
            this.config_labelCorriente.Size = new System.Drawing.Size(42, 24);
            this.config_labelCorriente.TabIndex = 7;
            this.config_labelCorriente.Text = "null";
            // 
            // config_labelPila
            // 
            this.config_labelPila.AutoSize = true;
            this.config_labelPila.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelPila.Location = new System.Drawing.Point(140, 79);
            this.config_labelPila.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelPila.Name = "config_labelPila";
            this.config_labelPila.Size = new System.Drawing.Size(42, 24);
            this.config_labelPila.TabIndex = 6;
            this.config_labelPila.Text = "null";
            // 
            // config_labelUltimaActualizacion
            // 
            this.config_labelUltimaActualizacion.AutoSize = true;
            this.config_labelUltimaActualizacion.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelUltimaActualizacion.Location = new System.Drawing.Point(140, 31);
            this.config_labelUltimaActualizacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelUltimaActualizacion.Name = "config_labelUltimaActualizacion";
            this.config_labelUltimaActualizacion.Size = new System.Drawing.Size(42, 24);
            this.config_labelUltimaActualizacion.TabIndex = 5;
            this.config_labelUltimaActualizacion.Text = "null";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 127);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 24);
            this.label9.TabIndex = 2;
            this.label9.Text = "Corriente:";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(8, 79);
            this.label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(45, 24);
            this.label.TabIndex = 1;
            this.label.Text = "Pila:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 48);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ultima\r\nactualizacion:";
            // 
            // config_groupBoxParametros
            // 
            this.config_groupBoxParametros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.config_groupBoxParametros.AutoSize = true;
            this.config_groupBoxParametros.Controls.Add(this.config_labelFuente24v);
            this.config_groupBoxParametros.Controls.Add(this.config_labelFuentePpic);
            this.config_groupBoxParametros.Controls.Add(this.config_labelFuente5Pic);
            this.config_groupBoxParametros.Controls.Add(this.config_labelFuente5v);
            this.config_groupBoxParametros.Controls.Add(this.config_labelTemp);
            this.config_groupBoxParametros.Controls.Add(this.label5);
            this.config_groupBoxParametros.Controls.Add(this.label4);
            this.config_groupBoxParametros.Controls.Add(this.label17);
            this.config_groupBoxParametros.Controls.Add(this.label16);
            this.config_groupBoxParametros.Controls.Add(this.label15);
            this.config_groupBoxParametros.Controls.Add(this.label14);
            this.config_groupBoxParametros.Controls.Add(this.config_labelCorriente);
            this.config_groupBoxParametros.Controls.Add(this.config_labelPila);
            this.config_groupBoxParametros.Controls.Add(this.config_labelUltimaActualizacion);
            this.config_groupBoxParametros.Controls.Add(this.label9);
            this.config_groupBoxParametros.Controls.Add(this.label);
            this.config_groupBoxParametros.Controls.Add(this.label7);
            this.config_groupBoxParametros.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_groupBoxParametros.Location = new System.Drawing.Point(184, 208);
            this.config_groupBoxParametros.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.config_groupBoxParametros.MinimumSize = new System.Drawing.Size(415, 182);
            this.config_groupBoxParametros.Name = "config_groupBoxParametros";
            this.config_groupBoxParametros.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.config_groupBoxParametros.Size = new System.Drawing.Size(454, 182);
            this.config_groupBoxParametros.TabIndex = 12;
            this.config_groupBoxParametros.TabStop = false;
            this.config_groupBoxParametros.Text = "Parametros";
            // 
            // config_labelFuente24v
            // 
            this.config_labelFuente24v.AutoSize = true;
            this.config_labelFuente24v.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelFuente24v.Location = new System.Drawing.Point(408, 79);
            this.config_labelFuente24v.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelFuente24v.Name = "config_labelFuente24v";
            this.config_labelFuente24v.Size = new System.Drawing.Size(38, 24);
            this.config_labelFuente24v.TabIndex = 19;
            this.config_labelFuente24v.Text = "null";
            // 
            // config_labelFuentePpic
            // 
            this.config_labelFuentePpic.AutoSize = true;
            this.config_labelFuentePpic.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelFuentePpic.Location = new System.Drawing.Point(408, 103);
            this.config_labelFuentePpic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelFuentePpic.Name = "config_labelFuentePpic";
            this.config_labelFuentePpic.Size = new System.Drawing.Size(38, 24);
            this.config_labelFuentePpic.TabIndex = 18;
            this.config_labelFuentePpic.Text = "null";
            // 
            // config_labelFuente5Pic
            // 
            this.config_labelFuente5Pic.AutoSize = true;
            this.config_labelFuente5Pic.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelFuente5Pic.Location = new System.Drawing.Point(408, 127);
            this.config_labelFuente5Pic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelFuente5Pic.Name = "config_labelFuente5Pic";
            this.config_labelFuente5Pic.Size = new System.Drawing.Size(38, 24);
            this.config_labelFuente5Pic.TabIndex = 17;
            this.config_labelFuente5Pic.Text = "null";
            // 
            // config_labelFuente5v
            // 
            this.config_labelFuente5v.AutoSize = true;
            this.config_labelFuente5v.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelFuente5v.Location = new System.Drawing.Point(408, 31);
            this.config_labelFuente5v.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelFuente5v.Name = "config_labelFuente5v";
            this.config_labelFuente5v.Size = new System.Drawing.Size(38, 24);
            this.config_labelFuente5v.TabIndex = 16;
            this.config_labelFuente5v.Text = "null";
            // 
            // config_labelTemp
            // 
            this.config_labelTemp.AutoSize = true;
            this.config_labelTemp.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelTemp.Location = new System.Drawing.Point(140, 103);
            this.config_labelTemp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.config_labelTemp.Name = "config_labelTemp";
            this.config_labelTemp.Size = new System.Drawing.Size(42, 24);
            this.config_labelTemp.TabIndex = 15;
            this.config_labelTemp.Text = "null";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Temp:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 24);
            this.label4.TabIndex = 13;
            // 
            // config_listBoxCarteles
            // 
            this.config_listBoxCarteles.FormattingEnabled = true;
            this.config_listBoxCarteles.ItemHeight = 24;
            this.config_listBoxCarteles.Location = new System.Drawing.Point(13, 62);
            this.config_listBoxCarteles.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.config_listBoxCarteles.Name = "config_listBoxCarteles";
            this.config_listBoxCarteles.Size = new System.Drawing.Size(163, 316);
            this.config_listBoxCarteles.TabIndex = 10;
            this.config_listBoxCarteles.SelectedIndexChanged += new System.EventHandler(this.listBox_config_SelectedIndexChanged);
            // 
            // config_labelCarteles
            // 
            this.config_labelCarteles.AutoSize = true;
            this.config_labelCarteles.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.config_labelCarteles.Location = new System.Drawing.Point(12, 21);
            this.config_labelCarteles.Name = "config_labelCarteles";
            this.config_labelCarteles.Size = new System.Drawing.Size(115, 35);
            this.config_labelCarteles.TabIndex = 14;
            this.config_labelCarteles.Text = "Carteles:";
            this.config_labelCarteles.Click += new System.EventHandler(this.label21_Click);
            // 
            // config_buttonEnviarComando
            // 
            this.config_buttonEnviarComando.Location = new System.Drawing.Point(340, 61);
            this.config_buttonEnviarComando.Name = "config_buttonEnviarComando";
            this.config_buttonEnviarComando.Size = new System.Drawing.Size(113, 68);
            this.config_buttonEnviarComando.TabIndex = 5;
            this.config_buttonEnviarComando.Text = "Enviar comando";
            this.config_buttonEnviarComando.UseVisualStyleBackColor = true;
            this.config_buttonEnviarComando.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(649, 626);
            this.Controls.Add(this.config_labelCarteles);
            this.Controls.Add(this.config_groupBoxMensaje);
            this.Controls.Add(this.config_groupBoxDatos);
            this.Controls.Add(this.config_groupBoxParametros);
            this.Controls.Add(this.config_listBoxCarteles);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_config";
            this.Text = "Config";
            this.config_groupBoxMensaje.ResumeLayout(false);
            this.config_groupBoxMensaje.PerformLayout();
            this.config_groupBoxDatos.ResumeLayout(false);
            this.config_groupBoxDatos.PerformLayout();
            this.config_groupBoxParametros.ResumeLayout(false);
            this.config_groupBoxParametros.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label config_labelMensajeActual;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox config_groupBoxMensaje;
        private System.Windows.Forms.ComboBox config_comboBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox config_groupBoxDatos;
        private System.Windows.Forms.Label config_labelNumeroSerie;
        private System.Windows.Forms.Label config_labelEstacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label config_labelIp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label config_labelCorriente;
        private System.Windows.Forms.Label config_labelPila;
        private System.Windows.Forms.Label config_labelUltimaActualizacion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox config_groupBoxParametros;
        private System.Windows.Forms.ListBox config_listBoxCarteles;
        private System.Windows.Forms.Label config_labelCarteles;
        private System.Windows.Forms.Label config_labelLinea;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label config_labelTemp;
        private System.Windows.Forms.Label config_labelFuente24v;
        private System.Windows.Forms.Label config_labelFuentePpic;
        private System.Windows.Forms.Label config_labelFuente5Pic;
        private System.Windows.Forms.Label config_labelFuente5v;
        private System.Windows.Forms.Button config_buttonEnviarComando;
    }
}