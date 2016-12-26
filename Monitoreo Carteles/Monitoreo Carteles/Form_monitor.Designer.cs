namespace Monitoreo_Carteles
{
    partial class Form_monitor
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl_monitor = new System.Windows.Forms.TabControl();
            this.tabPage_monitoreo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel_monitor = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_listH = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_listE = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_listD = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_listC = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_listB = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_listA = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_h = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_e = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_d = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_c = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_b = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_a = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage_debug = new System.Windows.Forms.TabPage();
            this.richTextBox_debug = new System.Windows.Forms.RichTextBox();
            this.tabPage_configuracion = new System.Windows.Forms.TabPage();
            this.button_configuracion_guardar = new System.Windows.Forms.Button();
            this.numericUpDown_configuracion_refresh = new System.Windows.Forms.NumericUpDown();
            this.label_configuracion_refresh = new System.Windows.Forms.Label();
            this.label_configuracionIp = new System.Windows.Forms.Label();
            this.textBox_configuracionIp = new System.Windows.Forms.TextBox();
            this.tabControl_monitor.SuspendLayout();
            this.tabPage_monitoreo.SuspendLayout();
            this.tableLayoutPanel_monitor.SuspendLayout();
            this.tabPage_debug.SuspendLayout();
            this.tabPage_configuracion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_configuracion_refresh)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_monitor
            // 
            this.tabControl_monitor.Controls.Add(this.tabPage_monitoreo);
            this.tabControl_monitor.Controls.Add(this.tabPage_debug);
            this.tabControl_monitor.Controls.Add(this.tabPage_configuracion);
            this.tabControl_monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_monitor.Location = new System.Drawing.Point(0, 0);
            this.tabControl_monitor.Name = "tabControl_monitor";
            this.tabControl_monitor.SelectedIndex = 0;
            this.tabControl_monitor.Size = new System.Drawing.Size(1174, 660);
            this.tabControl_monitor.TabIndex = 0;
            // 
            // tabPage_monitoreo
            // 
            this.tabPage_monitoreo.AutoScroll = true;
            this.tabPage_monitoreo.Controls.Add(this.tableLayoutPanel_monitor);
            this.tabPage_monitoreo.Location = new System.Drawing.Point(4, 29);
            this.tabPage_monitoreo.Name = "tabPage_monitoreo";
            this.tabPage_monitoreo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_monitoreo.Size = new System.Drawing.Size(1166, 627);
            this.tabPage_monitoreo.TabIndex = 0;
            this.tabPage_monitoreo.Text = "MONITOR";
            this.tabPage_monitoreo.UseVisualStyleBackColor = true;
            this.tabPage_monitoreo.Click += new System.EventHandler(this.tabPage_monitoreo_Click);
            // 
            // tableLayoutPanel_monitor
            // 
            this.tableLayoutPanel_monitor.AutoScroll = true;
            this.tableLayoutPanel_monitor.AutoSize = true;
            this.tableLayoutPanel_monitor.ColumnCount = 6;
            this.tableLayoutPanel_monitor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_monitor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_monitor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_monitor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_monitor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_monitor.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_listH, 5, 1);
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_listE, 4, 1);
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_listD, 3, 1);
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_listC, 2, 1);
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_listB, 1, 1);
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_listA, 0, 1);
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_h, 5, 0);
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_e, 4, 0);
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_d, 3, 0);
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_c, 2, 0);
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_b, 1, 0);
            this.tableLayoutPanel_monitor.Controls.Add(this.tableLayoutPanel_a, 0, 0);
            this.tableLayoutPanel_monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_monitor.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_monitor.Name = "tableLayoutPanel_monitor";
            this.tableLayoutPanel_monitor.RowCount = 2;
            this.tableLayoutPanel_monitor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.tableLayoutPanel_monitor.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.19048F));
            this.tableLayoutPanel_monitor.Size = new System.Drawing.Size(1160, 621);
            this.tableLayoutPanel_monitor.TabIndex = 0;
            this.tableLayoutPanel_monitor.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_monitor_Paint);
            // 
            // tableLayoutPanel_listH
            // 
            this.tableLayoutPanel_listH.ColumnCount = 1;
            this.tableLayoutPanel_listH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_listH.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_listH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_listH.Location = new System.Drawing.Point(968, 150);
            this.tableLayoutPanel_listH.Name = "tableLayoutPanel_listH";
            this.tableLayoutPanel_listH.RowCount = 1;
            this.tableLayoutPanel_listH.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_listH.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.tableLayoutPanel_listH.Size = new System.Drawing.Size(189, 468);
            this.tableLayoutPanel_listH.TabIndex = 11;
            // 
            // tableLayoutPanel_listE
            // 
            this.tableLayoutPanel_listE.ColumnCount = 1;
            this.tableLayoutPanel_listE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_listE.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_listE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_listE.Location = new System.Drawing.Point(775, 150);
            this.tableLayoutPanel_listE.Name = "tableLayoutPanel_listE";
            this.tableLayoutPanel_listE.RowCount = 1;
            this.tableLayoutPanel_listE.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_listE.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.tableLayoutPanel_listE.Size = new System.Drawing.Size(187, 468);
            this.tableLayoutPanel_listE.TabIndex = 10;
            // 
            // tableLayoutPanel_listD
            // 
            this.tableLayoutPanel_listD.ColumnCount = 1;
            this.tableLayoutPanel_listD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_listD.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_listD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_listD.Location = new System.Drawing.Point(582, 150);
            this.tableLayoutPanel_listD.Name = "tableLayoutPanel_listD";
            this.tableLayoutPanel_listD.RowCount = 1;
            this.tableLayoutPanel_listD.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_listD.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.tableLayoutPanel_listD.Size = new System.Drawing.Size(187, 468);
            this.tableLayoutPanel_listD.TabIndex = 9;
            // 
            // tableLayoutPanel_listC
            // 
            this.tableLayoutPanel_listC.ColumnCount = 1;
            this.tableLayoutPanel_listC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_listC.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_listC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_listC.Location = new System.Drawing.Point(389, 150);
            this.tableLayoutPanel_listC.Name = "tableLayoutPanel_listC";
            this.tableLayoutPanel_listC.RowCount = 1;
            this.tableLayoutPanel_listC.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_listC.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.tableLayoutPanel_listC.Size = new System.Drawing.Size(187, 468);
            this.tableLayoutPanel_listC.TabIndex = 8;
            // 
            // tableLayoutPanel_listB
            // 
            this.tableLayoutPanel_listB.ColumnCount = 1;
            this.tableLayoutPanel_listB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_listB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_listB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_listB.Location = new System.Drawing.Point(196, 150);
            this.tableLayoutPanel_listB.Name = "tableLayoutPanel_listB";
            this.tableLayoutPanel_listB.RowCount = 1;
            this.tableLayoutPanel_listB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_listB.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.tableLayoutPanel_listB.Size = new System.Drawing.Size(187, 468);
            this.tableLayoutPanel_listB.TabIndex = 7;
            // 
            // tableLayoutPanel_listA
            // 
            this.tableLayoutPanel_listA.ColumnCount = 1;
            this.tableLayoutPanel_listA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_listA.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_listA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_listA.Location = new System.Drawing.Point(3, 150);
            this.tableLayoutPanel_listA.Name = "tableLayoutPanel_listA";
            this.tableLayoutPanel_listA.RowCount = 1;
            this.tableLayoutPanel_listA.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_listA.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 468F));
            this.tableLayoutPanel_listA.Size = new System.Drawing.Size(187, 468);
            this.tableLayoutPanel_listA.TabIndex = 6;
            // 
            // tableLayoutPanel_h
            // 
            this.tableLayoutPanel_h.ColumnCount = 1;
            this.tableLayoutPanel_h.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_h.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_h.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_h.Location = new System.Drawing.Point(968, 3);
            this.tableLayoutPanel_h.Name = "tableLayoutPanel_h";
            this.tableLayoutPanel_h.RowCount = 1;
            this.tableLayoutPanel_h.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_h.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel_h.Size = new System.Drawing.Size(189, 141);
            this.tableLayoutPanel_h.TabIndex = 5;
            // 
            // tableLayoutPanel_e
            // 
            this.tableLayoutPanel_e.ColumnCount = 1;
            this.tableLayoutPanel_e.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_e.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_e.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_e.Location = new System.Drawing.Point(775, 3);
            this.tableLayoutPanel_e.Name = "tableLayoutPanel_e";
            this.tableLayoutPanel_e.RowCount = 1;
            this.tableLayoutPanel_e.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_e.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel_e.Size = new System.Drawing.Size(187, 141);
            this.tableLayoutPanel_e.TabIndex = 4;
            // 
            // tableLayoutPanel_d
            // 
            this.tableLayoutPanel_d.ColumnCount = 1;
            this.tableLayoutPanel_d.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_d.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_d.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_d.Location = new System.Drawing.Point(582, 3);
            this.tableLayoutPanel_d.Name = "tableLayoutPanel_d";
            this.tableLayoutPanel_d.RowCount = 1;
            this.tableLayoutPanel_d.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_d.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel_d.Size = new System.Drawing.Size(187, 141);
            this.tableLayoutPanel_d.TabIndex = 3;
            // 
            // tableLayoutPanel_c
            // 
            this.tableLayoutPanel_c.ColumnCount = 1;
            this.tableLayoutPanel_c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_c.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_c.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_c.Location = new System.Drawing.Point(389, 3);
            this.tableLayoutPanel_c.Name = "tableLayoutPanel_c";
            this.tableLayoutPanel_c.RowCount = 1;
            this.tableLayoutPanel_c.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_c.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel_c.Size = new System.Drawing.Size(187, 141);
            this.tableLayoutPanel_c.TabIndex = 2;
            // 
            // tableLayoutPanel_b
            // 
            this.tableLayoutPanel_b.ColumnCount = 1;
            this.tableLayoutPanel_b.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_b.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_b.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_b.Location = new System.Drawing.Point(196, 3);
            this.tableLayoutPanel_b.Name = "tableLayoutPanel_b";
            this.tableLayoutPanel_b.RowCount = 1;
            this.tableLayoutPanel_b.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_b.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel_b.Size = new System.Drawing.Size(187, 141);
            this.tableLayoutPanel_b.TabIndex = 1;
            // 
            // tableLayoutPanel_a
            // 
            this.tableLayoutPanel_a.ColumnCount = 1;
            this.tableLayoutPanel_a.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_a.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_a.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_a.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_a.Name = "tableLayoutPanel_a";
            this.tableLayoutPanel_a.RowCount = 1;
            this.tableLayoutPanel_a.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_a.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel_a.Size = new System.Drawing.Size(187, 141);
            this.tableLayoutPanel_a.TabIndex = 0;
            // 
            // tabPage_debug
            // 
            this.tabPage_debug.Controls.Add(this.richTextBox_debug);
            this.tabPage_debug.Location = new System.Drawing.Point(4, 29);
            this.tabPage_debug.Name = "tabPage_debug";
            this.tabPage_debug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_debug.Size = new System.Drawing.Size(1166, 627);
            this.tabPage_debug.TabIndex = 1;
            this.tabPage_debug.Text = "DEBUG";
            this.tabPage_debug.UseVisualStyleBackColor = true;
            // 
            // richTextBox_debug
            // 
            this.richTextBox_debug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_debug.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_debug.Name = "richTextBox_debug";
            this.richTextBox_debug.Size = new System.Drawing.Size(1160, 621);
            this.richTextBox_debug.TabIndex = 0;
            this.richTextBox_debug.Text = "";
            // 
            // tabPage_configuracion
            // 
            this.tabPage_configuracion.Controls.Add(this.textBox_configuracionIp);
            this.tabPage_configuracion.Controls.Add(this.label_configuracionIp);
            this.tabPage_configuracion.Controls.Add(this.button_configuracion_guardar);
            this.tabPage_configuracion.Controls.Add(this.numericUpDown_configuracion_refresh);
            this.tabPage_configuracion.Controls.Add(this.label_configuracion_refresh);
            this.tabPage_configuracion.Location = new System.Drawing.Point(4, 29);
            this.tabPage_configuracion.Name = "tabPage_configuracion";
            this.tabPage_configuracion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_configuracion.Size = new System.Drawing.Size(1166, 627);
            this.tabPage_configuracion.TabIndex = 2;
            this.tabPage_configuracion.Text = "CONFIGURACION";
            this.tabPage_configuracion.UseVisualStyleBackColor = true;
            // 
            // button_configuracion_guardar
            // 
            this.button_configuracion_guardar.Location = new System.Drawing.Point(298, 385);
            this.button_configuracion_guardar.Name = "button_configuracion_guardar";
            this.button_configuracion_guardar.Size = new System.Drawing.Size(96, 41);
            this.button_configuracion_guardar.TabIndex = 3;
            this.button_configuracion_guardar.Text = "Guardar";
            this.button_configuracion_guardar.UseVisualStyleBackColor = true;
            this.button_configuracion_guardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown_configuracion_refresh
            // 
            this.numericUpDown_configuracion_refresh.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_configuracion_refresh.Location = new System.Drawing.Point(319, 25);
            this.numericUpDown_configuracion_refresh.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numericUpDown_configuracion_refresh.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown_configuracion_refresh.Name = "numericUpDown_configuracion_refresh";
            this.numericUpDown_configuracion_refresh.Size = new System.Drawing.Size(75, 26);
            this.numericUpDown_configuracion_refresh.TabIndex = 2;
            this.numericUpDown_configuracion_refresh.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label_configuracion_refresh
            // 
            this.label_configuracion_refresh.AutoSize = true;
            this.label_configuracion_refresh.Location = new System.Drawing.Point(22, 27);
            this.label_configuracion_refresh.Name = "label_configuracion_refresh";
            this.label_configuracion_refresh.Size = new System.Drawing.Size(249, 20);
            this.label_configuracion_refresh.TabIndex = 0;
            this.label_configuracion_refresh.Text = "Tiempo de actualizacion: (60 seg.)";
            this.label_configuracion_refresh.Click += new System.EventHandler(this.label_configuracion_refresh_Click);
            // 
            // label_configuracionIp
            // 
            this.label_configuracionIp.AutoSize = true;
            this.label_configuracionIp.Location = new System.Drawing.Point(22, 83);
            this.label_configuracionIp.Name = "label_configuracionIp";
            this.label_configuracionIp.Size = new System.Drawing.Size(87, 20);
            this.label_configuracionIp.TabIndex = 4;
            this.label_configuracionIp.Text = "IP servidor:";
            this.label_configuracionIp.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_configuracionIp
            // 
            this.textBox_configuracionIp.Location = new System.Drawing.Point(319, 77);
            this.textBox_configuracionIp.Name = "textBox_configuracionIp";
            this.textBox_configuracionIp.Size = new System.Drawing.Size(159, 26);
            this.textBox_configuracionIp.TabIndex = 5;
            this.textBox_configuracionIp.TextChanged += new System.EventHandler(this.textBox_configuracionIp_TextChanged);
            // 
            // Form_monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 660);
            this.Controls.Add(this.tabControl_monitor);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_monitor";
            this.Text = "Monitoreo carteles - SCP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl_monitor.ResumeLayout(false);
            this.tabPage_monitoreo.ResumeLayout(false);
            this.tabPage_monitoreo.PerformLayout();
            this.tableLayoutPanel_monitor.ResumeLayout(false);
            this.tabPage_debug.ResumeLayout(false);
            this.tabPage_configuracion.ResumeLayout(false);
            this.tabPage_configuracion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_configuracion_refresh)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private System.Windows.Forms.TabControl tabControl_monitor;
        private System.Windows.Forms.TabPage tabPage_debug;
        private System.Windows.Forms.TabPage tabPage_configuracion;
        private  System.Windows.Forms.RichTextBox richTextBox_debug;
        private System.Windows.Forms.Label label_configuracion_refresh;
        private System.Windows.Forms.Button button_configuracion_guardar;
        private System.Windows.Forms.NumericUpDown numericUpDown_configuracion_refresh;
        private System.Windows.Forms.TabPage tabPage_monitoreo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_monitor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_listB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_listA;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_h;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_e;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_d;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_c;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_b;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_a;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_listH;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_listE;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_listD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_listC;
        private System.Windows.Forms.Label label_configuracionIp;
        private System.Windows.Forms.TextBox textBox_configuracionIp;
    }
}

