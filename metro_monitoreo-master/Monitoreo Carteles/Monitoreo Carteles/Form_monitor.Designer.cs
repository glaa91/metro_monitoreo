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
            this.tabPage_debug = new System.Windows.Forms.TabPage();
            this.richTextBox_debug = new System.Windows.Forms.RichTextBox();
            this.tabPage_configuracion = new System.Windows.Forms.TabPage();
            this.button_configuracion_guardar = new System.Windows.Forms.Button();
            this.numericUpDown_configuracion_refresh = new System.Windows.Forms.NumericUpDown();
            this.label_configuracion_refresh = new System.Windows.Forms.Label();
            this.tabControl_monitor.SuspendLayout();
            this.tabPage_monitoreo.SuspendLayout();
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
            this.tabControl_monitor.Size = new System.Drawing.Size(974, 520);
            this.tabControl_monitor.TabIndex = 0;
            // 
            // tabPage_monitoreo
            // 
            this.tabPage_monitoreo.AutoScroll = true;
            this.tabPage_monitoreo.Controls.Add(this.tableLayoutPanel_monitor);
            this.tabPage_monitoreo.Location = new System.Drawing.Point(4, 29);
            this.tabPage_monitoreo.Name = "tabPage_monitoreo";
            this.tabPage_monitoreo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_monitoreo.Size = new System.Drawing.Size(966, 487);
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
            this.tableLayoutPanel_monitor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_monitor.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_monitor.Name = "tableLayoutPanel_monitor";
            this.tableLayoutPanel_monitor.RowCount = 2;
            this.tableLayoutPanel_monitor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_monitor.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_monitor.Size = new System.Drawing.Size(960, 481);
            this.tableLayoutPanel_monitor.TabIndex = 0;
            this.tableLayoutPanel_monitor.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_monitor_Paint);
            // 
            // tabPage_debug
            // 
            this.tabPage_debug.Controls.Add(this.richTextBox_debug);
            this.tabPage_debug.Location = new System.Drawing.Point(4, 29);
            this.tabPage_debug.Name = "tabPage_debug";
            this.tabPage_debug.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_debug.Size = new System.Drawing.Size(966, 487);
            this.tabPage_debug.TabIndex = 1;
            this.tabPage_debug.Text = "DEBUG";
            this.tabPage_debug.UseVisualStyleBackColor = true;
            // 
            // richTextBox_debug
            // 
            this.richTextBox_debug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_debug.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_debug.Name = "richTextBox_debug";
            this.richTextBox_debug.Size = new System.Drawing.Size(960, 481);
            this.richTextBox_debug.TabIndex = 0;
            this.richTextBox_debug.Text = "";
            // 
            // tabPage_configuracion
            // 
            this.tabPage_configuracion.Controls.Add(this.button_configuracion_guardar);
            this.tabPage_configuracion.Controls.Add(this.numericUpDown_configuracion_refresh);
            this.tabPage_configuracion.Controls.Add(this.label_configuracion_refresh);
            this.tabPage_configuracion.Location = new System.Drawing.Point(4, 29);
            this.tabPage_configuracion.Name = "tabPage_configuracion";
            this.tabPage_configuracion.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_configuracion.Size = new System.Drawing.Size(966, 487);
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
            this.numericUpDown_configuracion_refresh.Location = new System.Drawing.Point(319, 27);
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
            // Form_monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 520);
            this.Controls.Add(this.tabControl_monitor);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_monitor";
            this.Text = "Monitoreo carteles - SCP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl_monitor.ResumeLayout(false);
            this.tabPage_monitoreo.ResumeLayout(false);
            this.tabPage_monitoreo.PerformLayout();
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
        private System.Windows.Forms.RichTextBox richTextBox_debug;
        private System.Windows.Forms.Label label_configuracion_refresh;
        private System.Windows.Forms.Button button_configuracion_guardar;
        private System.Windows.Forms.NumericUpDown numericUpDown_configuracion_refresh;
        private System.Windows.Forms.TabPage tabPage_monitoreo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_monitor;
    }
}

