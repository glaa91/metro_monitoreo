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
        protected static Label[] labelEstacionesA_l = new Label[1];
        protected static List<Label> labelEstacionesB_l = new List<Label>();
        protected static List<Label> labelEstacionesC_l = new List<Label>();
        protected static List<Label> labelEstacionesD_l = new List<Label>();
        protected static List<Label> labelEstacionesE_l = new List<Label>();
        protected static List<Label> labelEstacionesH_l = new List<Label>();

        protected static PictureBox[] pictureBoxEstacionesA_l = new PictureBox[1];
        protected static List<PictureBox> pictureBoxEstacionesB_l = new List<PictureBox>();
        protected static List<PictureBox> pictureBoxEstacionesC_l = new List<PictureBox>();
        protected static List<PictureBox> pictureBoxEstacionesD_l = new List<PictureBox>();
        protected static List<PictureBox> pictureBoxEstacionesE_l = new List<PictureBox>();
        protected static List<PictureBox> pictureBoxEstacionesH_l = new List<PictureBox>();

        protected static TableLayoutPanel tlpA = new TableLayoutPanel();
        protected static TableLayoutPanel tlpB = new TableLayoutPanel();
        protected static TableLayoutPanel tlpC = new TableLayoutPanel();
        protected static TableLayoutPanel tlpD = new TableLayoutPanel();
        protected static TableLayoutPanel tlpE = new TableLayoutPanel();
        protected static TableLayoutPanel tlpH = new TableLayoutPanel();

        public Form_monitor()
        {
            InitializeComponent();
            this.richTextBox_debug = new RichTextBox();
            //this.textBox_configuracion_refresh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            Form_login.monitor_b = true;
            loadEstaciones("datos.txt");
            setImages(0, 80);   //cargo las imagenes de las lineas
            loadInterface("calibri", 12, FontStyle.Regular);   //cargo la interfaz

        }
        private void setImages(int pos, int tam)    //Esta funcion carga las picturesBox con las letras de las lineas, POS= numero columna. tam, el anchoXlargo
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

            tableLayoutPanel_monitor.RowCount += 1;
            tableLayoutPanel_monitor.RowStyles.Add(new RowStyle(SizeType.Absolute));

            tableLayoutPanel_monitor.Controls.Add(pbA, 0, pos);
            tableLayoutPanel_monitor.Controls.Add(pbB, 1, pos);
            tableLayoutPanel_monitor.Controls.Add(pbC, 2, pos);
            tableLayoutPanel_monitor.Controls.Add(pbD, 3, pos);
            tableLayoutPanel_monitor.Controls.Add(pbE, 4, pos);
            tableLayoutPanel_monitor.Controls.Add(pbH, 5, pos);
        }

        private void loadEstaciones(string path)
        {
            string line = null, aux = null;
            System.IO.StreamReader file = new System.IO.StreamReader(path);  // Read the file and display it line by line.  
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
                    if (aux == "A")
                    {
                        Form_login.nombreEstacionesA_l.Add(line);
                    }
                    else if (aux == "B")
                    {
                        Form_login.nombreEstacionesB_l.Add(line);
                    }
                    else if (aux == "C")
                    {
                        Form_login.nombreEstacionesC_l.Add(line);
                    }
                    else if (aux == "D")
                    {
                        Form_login.nombreEstacionesD_l.Add(line);
                    }
                    else if (aux == "E")
                    {
                        Form_login.nombreEstacionesE_l.Add(line);
                    }
                    else if (aux == "H")
                    {
                        Form_login.nombreEstacionesH_l.Add(line);
                    }
                }
            }
            file.Close();
            int x= 0;
            for (int i = 0; i < Form_login.nombreEstacionesA_l.Count; i++)
            {
                for (int k = 0; k < Form_login.estaciones_l.Count; k++)
                {
                    //Form_login.Log("DEBUG", String.Format("{0} - {1}", Form_login.nombreEstacionesB_l[i], Form_login.estaciones_l[k].Estacionn));
                    if (Form_login.nombreEstacionesA_l[i].ToLower() == Form_login.estaciones_l[k].Estacionn.ToLower())
                    {
                        x++;
                    }
                }
                Form_login.cartelesPorEstacionA_l.Add(x);
                x = 0;
            }
            for (int i=0; i<Form_login.nombreEstacionesB_l.Count; i++)
            {
                for(int k=0; k< Form_login.estaciones_l.Count; k++)
                {
                    if (Form_login.nombreEstacionesB_l[i].ToLower() == Form_login.estaciones_l[k].Estacionn.ToLower())
                    {
                        x++;
                    }
                }
                Form_login.cartelesPorEstacionB_l.Add(x);
                x = 0;
            }
            for (int i = 0; i < Form_login.nombreEstacionesC_l.Count; i++)
            {
                for (int k = 0; k < Form_login.estaciones_l.Count; k++)
                {
                    if (Form_login.nombreEstacionesC_l[i].ToLower() == Form_login.estaciones_l[k].Estacionn.ToLower())
                    {
                        x++;
                    }
                }
                Form_login.cartelesPorEstacionC_l.Add(x);
                x = 0;
            }
            for (int i = 0; i < Form_login.nombreEstacionesD_l.Count; i++)
            {
                for (int k = 0; k < Form_login.estaciones_l.Count; k++)
                {
                    if (Form_login.nombreEstacionesD_l[i].ToLower() == Form_login.estaciones_l[k].Estacionn.ToLower())
                    {
                        x++;
                    }
                }
                Form_login.cartelesPorEstacionD_l.Add(x);
                x = 0;
            }
            for (int i = 0; i < Form_login.nombreEstacionesE_l.Count; i++)
            {
                for (int k = 0; k < Form_login.estaciones_l.Count; k++)
                {
                    if (Form_login.nombreEstacionesE_l[i].ToLower() == Form_login.estaciones_l[k].Estacionn.ToLower())
                    {
                        x++;
                    }
                }
                Form_login.cartelesPorEstacionE_l.Add(x);
                x = 0;
            }
            for (int i = 0; i < Form_login.nombreEstacionesH_l.Count; i++)
            {
                for (int k = 0; k < Form_login.estaciones_l.Count; k++)
                {
                    if (Form_login.nombreEstacionesH_l[i].ToLower() == Form_login.estaciones_l[k].Estacionn.ToLower())
                    {
                        x++;
                    }
                }
                Form_login.cartelesPorEstacionH_l.Add(x);
                x = 0;
            }
        }

        private void loadInterface(string fontType, float fontSize, FontStyle fontStyle)
        {
            int ant = 0;
            for(int i=0; i<Form_login.cartelesPorEstacionB_l.Count; i++)
            {
                ant = Math.Max(ant, Form_login.cartelesPorEstacionB_l[i]);
            }
            tlpB.Controls.Clear();
            tlpB.ColumnStyles.Clear();
            tlpB.RowStyles.Clear();
            tlpB.ColumnCount = ant+1;
            tlpB.RowCount = Form_login.nombreEstacionesB_l.Count;
            for (int x = 0; x < ant+1; x++)
            {
                //First add a column
                tlpB.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                for (int y = 0; y < Form_login.nombreEstacionesB_l.Count; y++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x == 0)
                    {
                        tlpB.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                    if (x > 0)
                    {
                        //Create the control, in this case we will add a button
                        PictureBox aux = new PictureBox();
                        aux.Image = Resource1.boton_rojo1;
                        aux.Size = new System.Drawing.Size(20, 20);
                        aux.SizeMode = PictureBoxSizeMode.CenterImage;
                        aux.SizeMode = PictureBoxSizeMode.StretchImage;
                        tlpB.Controls.Add(aux, x, y);
                    }
                    else
                    {
                        Label aux = new Label();
                        aux.Text = Form_login.nombreEstacionesB_l[y];
                        tlpB.Controls.Add(aux, 0, y);
                    }
                }
            }
            /*
                Array.Resize(ref pictureBoxEstacionesA_l, pictureBoxEstacionesA_l.Length + 1);
            pictureBoxEstacionesA_l[auxA] = new PictureBox();
            pictureBoxEstacionesA_l[auxA].Image = Resource1.boton_rojo1;
            pictureBoxEstacionesA_l[auxA].Size = new System.Drawing.Size(20, 20);
            pictureBoxEstacionesA_l[auxA].SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxEstacionesA_l[auxA].SizeMode = PictureBoxSizeMode.StretchImage;
            //tableLayoutPanel_monitor.Controls.Add(pictureBoxEstacionesA_l[auxA], 0, auxA);
            Array.Resize(ref labelEstacionesA_l, labelEstacionesA_l.Length + 1);
            labelEstacionesA_l[auxA] = new Label();
            labelEstacionesA_l[auxA].Text = line;
            labelEstacionesA_l[auxA].Font = new Font(fontType, fontSize, fontStyle);
            //tableLayoutPanel_monitor.Controls.Add(labelEstacionesA_l[auxA], 0, auxA);*/
            tableLayoutPanel_monitor.Controls.Add(tlpB, 1, 1);
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
    }
}

