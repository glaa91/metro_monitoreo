using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Timers;
using System.Threading;
using System.Globalization;

namespace Monitoreo_Carteles
{
    public partial class Form_monitor : Form
    {
        private string tabMonitor_s = "MONITOR", tabDebug_s = "DEBUG", tabConfig_s = "CONFIGURACION";

        public Form_monitor()
        {
            InitializeComponent();
            this.richTextBox_debug = new RichTextBox();
            //this.textBox_configuracion_refresh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            Form_login.monitor_b = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tabControl_monitor = new TabControl();

            this.tabControl_monitor = new TabControl();

            this.tabPage_monitoreo = new TabPage();
            this.tabPage_debug = new TabPage();
            this.tabPage_configuracion = new TabPage();

            tabPage_monitoreo.Text = tabMonitor_s;    //le pongo el texto a cada tab
            tabPage_debug.Text = tabDebug_s;
            tabPage_configuracion.Text = tabConfig_s;

            //tab_debug.Controls.Add(richTextBox);

            //TabPage[] tabPages = { tab_monitor, tab_debug, tab_config };

            //this.tabControl1.SizeMode = TabSizeMode.FillToRight;    // Sizes the tabs so that each row fills the entire width of tabControl1.
            //this.tabControl1.Dock = DockStyle.Fill;     //hago que se llene con el tamaño de la ventana
            //this.tabControl1.Padding = new Point(15, 4);    //les deja un espacion entre vertical y horizontal
            //this.tabControl1.Controls.AddRange(new Control[] {tab_monitor, tab_debug, tab_config}); //agrego las pestañas
            //this.tabControl1.Location = new Point(0, 0);    //seteo en la posicion 0,0
            //this.Controls.Add(tabControl1);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_configuracion_refresh_Click(object sender, EventArgs e)
        {

        }

        private void tabPage_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean cambios = false;
            if (Convert.ToUInt16(numericUpDown_configuracion_refresh.Value) >= 60)
            {
                Form_login.timeRefresh_i = 1000 * Convert.ToUInt16(this.numericUpDown_configuracion_refresh.Value);
                Form_login.Log("INFO", String.Format("Refresh time OK: {0}", Form_login.timeRefresh_i));
                cambios = true;
                Form_login.SetTimer(Form_login.timeRefresh_i, false);
            }
            else
            {
                Form_login.Log("INFO", String.Format("ERROR Refresh time: {0}", Form_login.timeRefresh_i));
                MessageBox.Show("ERROR Refresh Time...");
                cambios = false;
            }

            if(cambios) MessageBox.Show("Se guardaron los cambios");
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }
    }
}

