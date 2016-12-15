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
        protected static List<Label> labelEstacionesA_l = new List<Label>();
        protected static List<Label> labelEstacionesB_l = new List<Label>();
        protected static List<Label> labelEstacionesC_l = new List<Label>();
        protected static List<Label> labelEstacionesD_l = new List<Label>();
        protected static List<Label> labelEstacionesE_l = new List<Label>();
        protected static List<Label> labelEstacionesH_l = new List<Label>();


        public Form_monitor()
        {
            InitializeComponent();
            this.richTextBox_debug = new RichTextBox();
            //this.textBox_configuracion_refresh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            Form_login.monitor_b = true;

            setImages(0, 80);

            string line = null, aux = null;
            int auxA = 1, auxB = 1, auxC = 1, auxD = 1, auxE = 1, auxH = 1;
            System.IO.StreamReader file = new System.IO.StreamReader("datos.txt");  // Read the file and display it line by line.  
            while ((line = file.ReadLine()) != null)    // busco las letras que indican cada linea
            {
                if (line == "A:")   aux = "A";
                else if (line == "B:")  aux = "B";
                else if (line == "C:")  aux = "C";
                else if (line == "D:")  aux = "D";
                else if (line == "E:")  aux = "E";
                else if (line == "H:")  aux = "H";
                else
                {
                    tableLayoutPanel_monitor.RowCount = tableLayoutPanel_monitor.RowCount + 1;
                    if (aux == "A")
                    {
                        var temp = new Label();
                        temp.Text = line;
                        temp.Font = new Font("calibri", 12, FontStyle.Regular);
                        tableLayoutPanel_monitor.Controls.Add(temp, 0, auxA);
                        labelEstacionesA_l.Add(temp);
                        auxA++;
                    }
                    else if (aux == "B")
                    {
                        var temp = new Label();
                        temp.Text = line;
                        temp.Font = new Font("calibri", 12, FontStyle.Regular);
                        tableLayoutPanel_monitor.Controls.Add(temp, 1, auxB);
                        labelEstacionesB_l.Add(temp);
                        auxB++;
                    }
                    else if (aux == "C")
                    {
                        var temp = new Label();
                        temp.Text = line;
                        temp.Font = new Font("calibri", 12, FontStyle.Regular);
                        tableLayoutPanel_monitor.Controls.Add(temp, 2, auxC);
                        labelEstacionesC_l.Add(temp);
                        auxC++;
                    }
                    else if (aux == "D")
                    {
                        var temp = new Label();
                        temp.Text = line;
                        temp.Font = new Font("calibri", 12, FontStyle.Regular);
                        tableLayoutPanel_monitor.Controls.Add(temp, 3, auxD);
                        labelEstacionesD_l.Add(temp);
                        auxD++;
                    }
                    else if (aux == "E")
                    {
                        var temp = new Label();
                        temp.Text = line;
                        temp.Font = new Font("calibri", 12, FontStyle.Regular);
                        tableLayoutPanel_monitor.Controls.Add(temp, 4, auxE);
                        labelEstacionesE_l.Add(temp);
                        auxE++;
                    }
                    else if (aux == "H")
                    {
                        var temp = new Label();
                        temp.Text = line;
                        temp.Font = new Font("calibri", 12, FontStyle.Regular);
                        tableLayoutPanel_monitor.Controls.Add(temp, 5, auxH);
                        labelEstacionesH_l.Add(temp);
                        auxH++;
                    }
                }
            }

            file.Close();

            /*int auxA = 0, auxB = 0, auxC = 0, auxD = 0, auxE = 0, auxH = 0;
            string ant = null;
            for (int w = 0; w < Form_login.estaciones_l.Count; w++) //cuento cuantas estaciones hay sin repetir
            {
                if (Form_login.estaciones_l[w].Linea == "a")
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        auxA++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
                if (Form_login.estaciones_l[w].Linea == "b")
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        auxB++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
                if (Form_login.estaciones_l[w].Linea == "c")
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        auxC++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
                if (Form_login.estaciones_l[w].Linea == "d")
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        auxD++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
                if (Form_login.estaciones_l[w].Linea == "e")
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        auxE++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
                if (Form_login.estaciones_l[w].Linea == "h")
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        auxH++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
            }
            //calculo que linea tiene la mayor cantidad de estaciones para crear las verticales
            int max = Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(auxA, auxB), auxC), auxD), auxE), auxH);
            tableLayoutPanel_monitor.RowCount = tableLayoutPanel_monitor.RowCount + max;

            auxA = 1; auxB = 1; auxC = 1; auxD = 1; auxE = 1; auxH = 1;
            ant = null;
            for (int w=0; w < Form_login.estaciones_l.Count; w++)
            {
                var temp = new Label();
                temp.Text = Form_login.estaciones_l[w].Estacionn;
                if(Form_login.estaciones_l[w].Linea == "a")
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        tableLayoutPanel_monitor.Controls.Add(temp, 0, auxA);
                        labelEstacionesA_l.Add(temp);
                        auxA++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
                else if (Form_login.estaciones_l[w].Linea == "b")
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        tableLayoutPanel_monitor.Controls.Add(temp, 1, auxB);
                        labelEstacionesB_l.Add(temp);
                        auxB++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
                else if (Form_login.estaciones_l[w].Linea == "c")
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        tableLayoutPanel_monitor.Controls.Add(temp, 2, auxC);
                        labelEstacionesC_l.Add(temp);
                        auxC++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
                else if (Form_login.estaciones_l[w].Linea == "d")
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        tableLayoutPanel_monitor.Controls.Add(temp, 3, auxD);
                        labelEstacionesD_l.Add(temp);
                        auxD++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
                else if (Form_login.estaciones_l[w].Linea == "e")
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        tableLayoutPanel_monitor.Controls.Add(temp, 4, auxE);
                        labelEstacionesE_l.Add(temp);
                        auxD++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
                else
                {
                    if (Form_login.estaciones_l[w].Estacionn != ant)
                    {
                        tableLayoutPanel_monitor.Controls.Add(temp, 5, auxH);
                        labelEstacionesH_l.Add(temp);
                        auxH++;
                        ant = Form_login.estaciones_l[w].Estacionn;
                    }
                }
                //Form_login.Log("DEBUG", Form_login.estaciones_l[w].Estacionn);
            }*/
            


        }
        private void setImages(int pos, int tam)
        {
            PictureBox pbA = new PictureBox();
            PictureBox pbB = new PictureBox();
            PictureBox pbC = new PictureBox();
            PictureBox pbD = new PictureBox();
            PictureBox pbE = new PictureBox();
            PictureBox pbH = new PictureBox();

            pbA.Image = Resource1.Línea_A__SBASE__svg;
            pbA.Size = new System.Drawing.Size(tam, tam);
            pbA.SizeMode = PictureBoxSizeMode.CenterImage;
            pbA.SizeMode = PictureBoxSizeMode.StretchImage;
            pbB.Image = Resource1.Línea_B__SBASE__svg;
            pbB.Size = new System.Drawing.Size(tam, tam);
            pbB.SizeMode = PictureBoxSizeMode.CenterImage;
            pbB.SizeMode = PictureBoxSizeMode.StretchImage;
            pbC.Image = Resource1.Línea_C__SBASE__svg;
            pbC.Size = new System.Drawing.Size(tam, tam);
            pbC.SizeMode = PictureBoxSizeMode.CenterImage;
            pbC.SizeMode = PictureBoxSizeMode.StretchImage;
            pbD.Image = Resource1.Línea_D__SBASE__svg;
            pbD.Size = new System.Drawing.Size(tam, tam);
            pbD.SizeMode = PictureBoxSizeMode.CenterImage;
            pbD.SizeMode = PictureBoxSizeMode.StretchImage;
            pbE.Image = Resource1.Línea_E__SBASE__svg;
            pbE.Size = new System.Drawing.Size(tam, tam);
            pbE.SizeMode = PictureBoxSizeMode.CenterImage;
            pbE.SizeMode = PictureBoxSizeMode.StretchImage;
            pbH.Image = Resource1.Línea_H__SBASE__svg;
            pbH.Size = new System.Drawing.Size(tam, tam);
            pbH.SizeMode = PictureBoxSizeMode.CenterImage;
            pbH.SizeMode = PictureBoxSizeMode.StretchImage;

            tableLayoutPanel_monitor.Controls.Add(pbA, 0, pos);
            tableLayoutPanel_monitor.Controls.Add(pbB, 1, pos);
            tableLayoutPanel_monitor.Controls.Add(pbC, 2, pos);
            tableLayoutPanel_monitor.Controls.Add(pbD, 3, pos);
            tableLayoutPanel_monitor.Controls.Add(pbE, 4, pos);
            tableLayoutPanel_monitor.Controls.Add(pbH, 5, pos);
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

        private void tabPage_monitoreo_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
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
        private void Form_monitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.Equals((sender as Button).Name, @"CloseButton"))
            {
                this.Close();
            }
}
    }
}

