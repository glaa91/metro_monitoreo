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
        private static System.Timers.Timer aTimer;
        private string tabMonitor_s = "MONITOR", tabDebug_s = "DEBUG", tabConfig_s = "CONFIGURACION";
        protected static Label[] labelEstacionesA_l = new Label[0];
        protected static Label[] labelEstacionesB_l = new Label[0];
        protected static Label[] labelEstacionesC_l = new Label[0];
        protected static Label[] labelEstacionesD_l = new Label[0];
        protected static Label[] labelEstacionesE_l = new Label[0];
        protected static Label[] labelEstacionesH_l = new Label[0];

        public static PictureBox[] pictureBoxEstacionesA_l = new PictureBox[0];
        public static PictureBox[] pictureBoxEstacionesB_l = new PictureBox[0];
        public static PictureBox[] pictureBoxEstacionesC_l = new PictureBox[0];
        public static PictureBox[] pictureBoxEstacionesD_l = new PictureBox[0];
        public static PictureBox[] pictureBoxEstacionesE_l = new PictureBox[0];
        public static PictureBox[] pictureBoxEstacionesH_l = new PictureBox[0];

        protected static TableLayoutPanel tlpA = new TableLayoutPanel();
        protected static TableLayoutPanel tlpB = new TableLayoutPanel();
        protected static TableLayoutPanel tlpC = new TableLayoutPanel();
        protected static TableLayoutPanel tlpD = new TableLayoutPanel();
        protected static TableLayoutPanel tlpE = new TableLayoutPanel();
        protected static TableLayoutPanel tlpH = new TableLayoutPanel();

        public static string[] lineas = { "A", "B", "C", "D", "E", "H" };
        private static string[] interface_lineas = {""};

        public Form_monitor()
        {
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_monitor_FormClosing);
            InitializeComponent();
            this.Text = Form_login.infoMonitoreo_s;
            SetTimer(Form_login.timeRefresh_i, true);
            //this.textBox_configuracion_refresh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            Form_login.monitor_b = true;
            loadInterface("calibri", 12);
            setImages(0, 80);   //cargo las imagenes de las lineas
            updateInterface();


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

            tableLayoutPanel_a.Controls.Add(pbA, 0, 0);
            tableLayoutPanel_b.Controls.Add(pbB, 0, 0);
            tableLayoutPanel_c.Controls.Add(pbC, 0, 0);
            tableLayoutPanel_d.Controls.Add(pbD, 0, 0);
            tableLayoutPanel_e.Controls.Add(pbE, 0, 0);
            tableLayoutPanel_h.Controls.Add(pbH, 0, 0);
        }

        private void loadInterface(string font, int tam)    //string fontType, float fontSize, FontStyle fontStyle
        {
            string[] estaciones_l = { null };
            string[] numeroDeCarteles_l = { null };
            int[] cartelesPorEstacion_l = { 0 };
            int ant = 0, tmp = 0;
            for (int i = 0; i < lineas.Length; i++)
            {
                int caquita = 0;
                loadEstaciones(ref estaciones_l, ref cartelesPorEstacion_l, ref numeroDeCarteles_l, lineas[i]);
                if (lineas[i] == "A")
                {
                    tableLayoutPanel_listA.Controls.Add(tlpA, 0, 0);
                    ant = 0;
                    for (int j = 0; j < cartelesPorEstacion_l.Length; j++)
                    {
                        ant = Math.Max(ant, cartelesPorEstacion_l[j]);
                    }
                    tlpA.Controls.Clear();
                    tlpA.ColumnStyles.Clear();
                    tlpA.RowStyles.Clear();
                    tlpA.ColumnCount = ant + 1;
                    tlpA.RowCount = estaciones_l.Length;
                    tlpA.Dock = DockStyle.Fill;
                    for (int x = 0; x < ant + 1; x++)
                    {
                        //First add a column
                        tlpA.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
                    caquita = 0;
                    for (int y = 0; y < estaciones_l.Length; y++)
                    {
                        //Next, add a row.  Only do this when once, when creating the first column
                        tlpA.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        Label aux = new Label();
                        aux.Text = estaciones_l[y];
                        aux.Click += new EventHandler(checkClickLabel);
                        aux.Font = new Font(font, tam, FontStyle.Regular);
                        tlpA.Controls.Add(aux, 0, y);
                        Array.Resize(ref labelEstacionesA_l, labelEstacionesA_l.Length + 1);
                        labelEstacionesA_l[y] = new Label();
                        labelEstacionesA_l[y] = aux;
                        for (int k = 0; k < cartelesPorEstacion_l[y]; k++)
                        {
                            PictureBox aux2 = new PictureBox();
                            aux2.Image = Resource1.boton_rojo3;
                            aux2.Size = new System.Drawing.Size(12, 12);
                            aux2.SizeMode = PictureBoxSizeMode.CenterImage;
                            aux2.SizeMode = PictureBoxSizeMode.StretchImage;
                            aux2.Click += new EventHandler(checkClickImage);
                            aux2.Name = Form_login.estaciones_l[tmp].NumeroCartel;  // le cargo el numero de cartel a la imagen, para depues saber cual es al hacer click
                            tmp++;
                            tlpA.Controls.Add(aux2, k+1, y);
                            Array.Resize(ref pictureBoxEstacionesA_l, pictureBoxEstacionesA_l.Length + 1);
                            pictureBoxEstacionesA_l[caquita] = new PictureBox();
                            pictureBoxEstacionesA_l[caquita] = aux2;
                            caquita++;
                        }
                    }
                }
                else if (lineas[i] == "B")
                {
                    tableLayoutPanel_listB.Controls.Add(tlpB, 0, 0);
                    ant = 0;
                    for (int j = 0; j < cartelesPorEstacion_l.Length; j++)
                    {
                        ant = Math.Max(ant, cartelesPorEstacion_l[j]);
                    }
                    tlpB.Controls.Clear();
                    tlpB.ColumnStyles.Clear();
                    tlpB.RowStyles.Clear();
                    tlpB.ColumnCount = ant + 1;
                    tlpB.RowCount = estaciones_l.Length;
                    tlpB.Dock = DockStyle.Fill;
                    for (int x = 0; x < ant + 1; x++)
                    {
                        //First add a column
                        tlpB.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
                    caquita = 0;
                    for (int y = 0; y < estaciones_l.Length; y++)
                    {
                        //Next, add a row.  Only do this when once, when creating the first column
                        tlpA.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        Label aux = new Label();
                        aux.Text = estaciones_l[y];
                        aux.Click += new EventHandler(checkClickLabel);
                        aux.Font = new Font(font, tam, FontStyle.Regular);
                        tlpB.Controls.Add(aux, 0, y);
                        Array.Resize(ref labelEstacionesB_l, labelEstacionesB_l.Length + 1);
                        labelEstacionesB_l[y] = new Label();
                        labelEstacionesB_l[y] = aux;
                        for (int k = 0; k < cartelesPorEstacion_l[y]; k++)
                        {
                            PictureBox aux2 = new PictureBox();
                            aux2.Image = Resource1.boton_rojo3;
                            aux2.Size = new System.Drawing.Size(12, 12);
                            aux2.SizeMode = PictureBoxSizeMode.CenterImage;
                            aux2.SizeMode = PictureBoxSizeMode.StretchImage;
                            aux2.Click += new EventHandler(checkClickImage);
                            aux2.Name = Form_login.estaciones_l[tmp].NumeroCartel;
                            tmp++;
                            tlpB.Controls.Add(aux2, k + 1, y);
                            Array.Resize(ref pictureBoxEstacionesB_l, pictureBoxEstacionesB_l.Length + 1);
                            pictureBoxEstacionesB_l[caquita] = new PictureBox();
                            pictureBoxEstacionesB_l[caquita] = aux2;
                            caquita++;
                        }
                    }
                }
                else if (lineas[i] == "C")
                {
                    tableLayoutPanel_listC.Controls.Add(tlpC, 0, 0);
                    ant = 0;
                    for (int j = 0; j < cartelesPorEstacion_l.Length; j++)
                    {
                        ant = Math.Max(ant, cartelesPorEstacion_l[j]);
                    }
                    tlpC.Controls.Clear();
                    tlpC.ColumnStyles.Clear();
                    tlpC.RowStyles.Clear();
                    tlpC.ColumnCount = ant + 1;
                    tlpC.RowCount = estaciones_l.Length;
                    tlpC.Dock = DockStyle.Fill;
                    for (int x = 0; x < ant + 1; x++)
                    {
                        //First add a column
                        tlpC.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
                    caquita = 0;
                    for (int y = 0; y < estaciones_l.Length; y++)
                    {
                        //Next, add a row.  Only do this when once, when creating the first column
                        tlpC.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        Label aux = new Label();
                        aux.Text = estaciones_l[y];
                        aux.Click += new EventHandler(checkClickLabel);
                        aux.Font = new Font(font, tam, FontStyle.Regular);
                        tlpC.Controls.Add(aux, 0, y);
                        Array.Resize(ref labelEstacionesC_l, labelEstacionesC_l.Length + 1);
                        labelEstacionesC_l[y] = new Label();
                        labelEstacionesC_l[y] = aux;
                        for (int k = 0; k < cartelesPorEstacion_l[y]; k++)
                        {
                            PictureBox aux2 = new PictureBox();
                            aux2.Image = Resource1.boton_rojo3;
                            aux2.Size = new System.Drawing.Size(12, 12);
                            aux2.SizeMode = PictureBoxSizeMode.CenterImage;
                            aux2.SizeMode = PictureBoxSizeMode.StretchImage;
                            aux2.Click += new EventHandler(checkClickImage);
                            aux2.Name = Form_login.estaciones_l[tmp].NumeroCartel;
                            tmp++;
                            tlpC.Controls.Add(aux2, k + 1, y);
                            Array.Resize(ref pictureBoxEstacionesC_l, pictureBoxEstacionesC_l.Length + 1);
                            pictureBoxEstacionesC_l[caquita] = new PictureBox();
                            pictureBoxEstacionesC_l[caquita] = aux2;
                            caquita++;
                        }
                    }
                }
                else if (lineas[i] == "D")
                {
                    tableLayoutPanel_listD.Controls.Add(tlpD, 0, 0);
                    ant = 0;
                    for (int j = 0; j < cartelesPorEstacion_l.Length; j++)
                    {
                        ant = Math.Max(ant, cartelesPorEstacion_l[j]);
                    }
                    tlpD.Controls.Clear();
                    tlpD.ColumnStyles.Clear();
                    tlpD.RowStyles.Clear();
                    tlpD.ColumnCount = ant + 1;
                    tlpD.RowCount = estaciones_l.Length;
                    tlpD.Dock = DockStyle.Fill;
                    for (int x = 0; x < ant + 1; x++)
                    {
                        //First add a column
                        tlpD.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
                    caquita = 0;
                    for (int y = 0; y < estaciones_l.Length; y++)
                    {
                        //Next, add a row.  Only do this when once, when creating the first column
                        tlpD.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        Label aux = new Label();
                        aux.Text = estaciones_l[y];
                        aux.Click += new EventHandler(checkClickLabel);
                        aux.Font = new Font(font, tam, FontStyle.Regular);
                        tlpD.Controls.Add(aux, 0, y);
                        Array.Resize(ref labelEstacionesD_l, labelEstacionesD_l.Length + 1);
                        labelEstacionesD_l[y] = new Label();
                        labelEstacionesD_l[y] = aux;
                        for (int k = 0; k < cartelesPorEstacion_l[y]; k++)
                        {
                            PictureBox aux2 = new PictureBox();
                            aux2.Image = Resource1.boton_rojo3;
                            aux2.Size = new System.Drawing.Size(12, 12);
                            aux2.SizeMode = PictureBoxSizeMode.CenterImage;
                            aux2.SizeMode = PictureBoxSizeMode.StretchImage;
                            aux2.Click += new EventHandler(checkClickImage);
                            aux2.Name = Form_login.estaciones_l[tmp].NumeroCartel;
                            tmp++;
                            tlpD.Controls.Add(aux2, k + 1, y);
                            Array.Resize(ref pictureBoxEstacionesD_l, pictureBoxEstacionesD_l.Length + 1);
                            pictureBoxEstacionesD_l[caquita] = new PictureBox();
                            pictureBoxEstacionesD_l[caquita] = aux2;
                            caquita++;
                        }
                    }
                }
                else if (lineas[i] == "E")
                {
                    tableLayoutPanel_listE.Controls.Add(tlpE, 0, 0);
                    ant = 0;
                    for (int j = 0; j < cartelesPorEstacion_l.Length; j++)
                    {
                        ant = Math.Max(ant, cartelesPorEstacion_l[j]);
                    }
                    tlpE.Controls.Clear();
                    tlpE.ColumnStyles.Clear();
                    tlpE.RowStyles.Clear();
                    tlpE.ColumnCount = ant + 1;
                    tlpE.RowCount = estaciones_l.Length;
                    tlpE.Dock = DockStyle.Fill;
                    for (int x = 0; x < ant + 1; x++)
                    {
                        //First add a column
                        tlpE.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
                    caquita = 0;
                    for (int y = 0; y < estaciones_l.Length; y++)
                    {
                        //Next, add a row.  Only do this when once, when creating the first column
                        tlpE.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        Label aux = new Label();
                        aux.Text = estaciones_l[y];
                        aux.Click += new EventHandler(checkClickLabel);
                        aux.Font = new Font(font, tam, FontStyle.Regular);
                        tlpE.Controls.Add(aux, 0, y);
                        Array.Resize(ref labelEstacionesE_l, labelEstacionesE_l.Length + 1);
                        labelEstacionesE_l[y] = new Label();
                        labelEstacionesE_l[y] = aux;
                        for (int k = 0; k < cartelesPorEstacion_l[y]; k++)
                        {
                            PictureBox aux2 = new PictureBox();
                            aux2.Image = Resource1.boton_rojo3;
                            aux2.Size = new System.Drawing.Size(12, 12);
                            aux2.SizeMode = PictureBoxSizeMode.CenterImage;
                            aux2.SizeMode = PictureBoxSizeMode.StretchImage;
                            aux2.Click += new EventHandler(checkClickImage);
                            aux2.Name = Form_login.estaciones_l[tmp].NumeroCartel;
                            tmp++;
                            tlpE.Controls.Add(aux2, k + 1, y);
                            Array.Resize(ref pictureBoxEstacionesE_l, pictureBoxEstacionesE_l.Length + 1);
                            pictureBoxEstacionesE_l[caquita] = new PictureBox();
                            pictureBoxEstacionesE_l[caquita] = aux2;
                            caquita++;
                        }
                    }
                }
                else if (lineas[i] == "H")
                {
                    tableLayoutPanel_listH.Controls.Add(tlpH, 0, 0);
                    ant = 0;
                    for (int j = 0; j < cartelesPorEstacion_l.Length; j++)
                    {
                        ant = Math.Max(ant, cartelesPorEstacion_l[j]);
                    }
                    tlpH.Controls.Clear();
                    tlpH.ColumnStyles.Clear();
                    tlpH.RowStyles.Clear();
                    tlpH.ColumnCount = ant + 1;
                    tlpH.RowCount = estaciones_l.Length;
                    tlpH.Dock = DockStyle.Fill;
                    for (int x = 0; x < ant + 1; x++)
                    {
                        //First add a column
                        tlpH.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                    }
                    caquita = 0;
                    for (int y = 0; y < estaciones_l.Length; y++)
                    {
                        //Next, add a row.  Only do this when once, when creating the first column
                        tlpH.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                        Label aux = new Label();
                        aux.Text = estaciones_l[y];
                        aux.Click += new EventHandler(checkClickLabel);
                        aux.Font = new Font(font, tam, FontStyle.Regular);
                        tlpH.Controls.Add(aux, 0, y);
                        Array.Resize(ref labelEstacionesH_l, labelEstacionesH_l.Length + 1);
                        labelEstacionesH_l[y] = new Label();
                        labelEstacionesH_l[y] = aux;
                        for (int k = 0; k < cartelesPorEstacion_l[y]; k++)
                        {
                            PictureBox aux2 = new PictureBox();
                            aux2.Image = Resource1.boton_rojo3;
                            aux2.Size = new System.Drawing.Size(12, 12);
                            aux2.SizeMode = PictureBoxSizeMode.CenterImage;
                            aux2.SizeMode = PictureBoxSizeMode.StretchImage;
                            aux2.Click += new EventHandler(checkClickImage);
                            aux2.Name = Form_login.estaciones_l[tmp].NumeroCartel;
                            tmp++;
                            tlpH.Controls.Add(aux2, k + 1, y);
                            Array.Resize(ref pictureBoxEstacionesH_l, pictureBoxEstacionesH_l.Length + 1);
                            pictureBoxEstacionesH_l[caquita] = new PictureBox();
                            pictureBoxEstacionesH_l[caquita] = aux2;
                            caquita++;
                        }
                    }
                }
                Array.Resize(ref estaciones_l, 1);
                estaciones_l[0] = null;
                Array.Resize(ref numeroDeCarteles_l, 1);
                numeroDeCarteles_l[0] = null;
                Array.Resize(ref cartelesPorEstacion_l, 1);
                cartelesPorEstacion_l[0] = 0;
            }
        }

        private void loadEstaciones(ref string[] estaciones, ref int[] cartelesPorEstacion, ref string[] numeroCartel, string lin)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            try
            {
                conexion = new NpgsqlConnection(Form_login.conexion_s);
                conexion.Open();
                string aux = null, aux2 = null, aux4 = null;
                int caca = 0, caca2 = 0;
                Boolean aux3 = false;
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conexion;
                    cmd.CommandText = String.Format("SELECT * FROM v_estaciones{0}", lin);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {   //  0-numeroCartel, 3-linea, 4-estacion
                            //reader.GetString(0)
                            //reader.GetString(3)
                            aux4 = reader.GetString(0);
                            Array.Resize(ref numeroCartel, numeroCartel.Length + 1);
                            numeroCartel[caca2] = aux4;
                            caca2++;
                            aux2 = reader.GetString(4);
                            if (aux != aux2)
                            {
                                if (aux3)
                                {
                                    caca++;
                                    Array.Resize(ref estaciones, estaciones.Length + 1);
                                    Array.Resize(ref cartelesPorEstacion, cartelesPorEstacion.Length + 1);
                                }
                                estaciones[caca] = aux2;
                                cartelesPorEstacion[caca] = 1;
                                aux = aux2;
                                aux3 = true;
                            }
                            else
                            {
                                cartelesPorEstacion[caca]++;
                            }
                        }
                    }
                }
                Console.Write("\n");
                conexion.Close();
            }
            catch (Exception)
            {
                conexion.Close();
                
            }
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

        private void checkClickLabel(object sender, EventArgs e)    //si clickeo el nombre de la estacion
        {
            string labelText = ((Label)sender).Text;
            Form_config form_config = new Form_config(labelText, null);
            form_config.Show();
            //this.Hide();
        }

        private void checkClickImage(object sender, EventArgs e)    //si clickeo una imagen
        {
            string pictureImageName = ((PictureBox)sender).Name;
            //Form_config form_config = new Form_config(null,pictureImageName);
            //form_config.Show();
            Console.Write(pictureImageName);
        }

        private void Form_monitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            aTimer.Stop();
            aTimer.Dispose();
            Application.Exit();
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

        private void tableLayoutPanel_monitor_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_configuracionIp_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean cambios = false;
            if (Convert.ToUInt16(numericUpDown_configuracion_refresh.Value) >= 60)
            {
                Form_login.timeRefresh_i = 1000 * Convert.ToUInt16(this.numericUpDown_configuracion_refresh.Value);
                Log("INFO", String.Format("Refresh time OK: {0}", Form_login.timeRefresh_i));
                cambios = true;
                SetTimer(Form_login.timeRefresh_i, false);
            }
            else
            {
                Log("INFO", String.Format("ERROR Refresh time: {0}", Form_login.timeRefresh_i));
                MessageBox.Show("ERROR Refresh Time...");
                cambios = false;
            }

            if(cambios) MessageBox.Show("Se guardaron los cambios");
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }

        private void Log(string type, string logMessage)
        {
            try
            {
                DateTime dateValue = DateTime.Now;
                string texto = String.Format("{0} - {1} - {2}\n", dateValue.ToString("G"), type, logMessage); // la G indica el formato de la hora XX/XX/XX 12:12:12
                string path = Directory.GetCurrentDirectory();
                path = String.Format(path + "log.txt");
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("ARCHIVO CREADO");
                    }
                }
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(texto);
                    Console.Write(texto);
                    richTextBox_debug.AppendText(System.Environment.NewLine + texto);
                }

            }
            catch
            {

            }
        }

        private void SetTimer(int time, Boolean first)
        {
            if (first)
            {
                aTimer = new System.Timers.Timer(time);
            }
            else
            {
                aTimer.Stop();
                aTimer.Dispose();
                aTimer = new System.Timers.Timer(time);
            }
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Boolean caca = loadServer();
            updateInterface();
        }

        private Boolean loadServer()
        {
            Boolean estado = false;
            DateTime current = DateTime.Now;
            NpgsqlConnection conexion = new NpgsqlConnection();
            //casa: 190.16.226.7
            //metrovias: 172.30.108.200
            //metrovias: 172.30.107.200
            try
            {
                conexion = new NpgsqlConnection(Form_login.conexion_s);
                conexion.Open();
                //MessageBox.Show("Conexion a la base de datos: OK", current.ToString());
                Log("INFO", "Database OK");
                Log("DEBUG", "ME CONECTE BIEN A LA BASE DE DATOS!");
                estado = true;
                string aux1 = null, aux2 = null, aux3 = null, aux4 = null, aux5 = null, aux6 = null;
                Boolean aux7 = false;
                using (var cmd = new NpgsqlCommand())
                {
                    for (int i = 0; i < lineas.Length; i++)
                    {
                        cmd.Connection = conexion;
                        cmd.CommandText = String.Format("SELECT * FROM v_estaciones{0}", lineas[i]);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {// numeroSerie, numeroCartel, ip, linea, estacion, dateTime, ping
                                aux1 = reader.GetString(0);
                                aux2 = reader.GetString(1);
                                aux3 = reader.GetString(2);
                                aux4 = reader.GetString(3);
                                aux5 = reader.GetString(4);
                                aux6 = reader.GetString(5);
                                aux7 = reader.GetBoolean(6);
                                updateEstacion(aux1, aux2, aux3, aux4, aux5, aux6, aux7);
                            }
                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception)
            {
                Log("DEBUG", string.Format("NO ME PUDE CONECTAR A LA BASE DE DATOS!"));
                Log("INFO", string.Format("ERROR DATABASE"));
                conexion.Close();
                estado = false;
            }
            return estado;
        }

        private static void updateEstacion(string numeroSerie, string numeroCartel, string ip, string linea, 
            string estacion, string dateTime, Boolean ping)
        {
            for(int i=0; i < Form_login.estaciones_l.Count; i++)
            {
                if (Form_login.estaciones_l[i].NumeroCartel == numeroCartel)
                {   
                    //Lo encontre actualizo
                    Form_login.estaciones_l[i].NumeroSerie = numeroSerie;
                    Form_login.estaciones_l[i].NumeroCartel = numeroCartel;
                    Form_login.estaciones_l[i].Ip = ip;
                    Form_login.estaciones_l[i].Linea = linea;
                    Form_login.estaciones_l[i].Estacionn = estacion;
                    Form_login.estaciones_l[i].DateTime = dateTime;
                    Form_login.estaciones_l[i].Ping = ping;
                }
            }
        }

        private static void updateInterface()
        {
            int aux=0;
            for (int k = 0; k < pictureBoxEstacionesA_l.Length; k++)
            {
                aux = k;
                if (Form_login.estaciones_l[aux].Ping == true)
                {
                    for (int i = 0; i < Form_login.carteles_l.Count; i++)    //busco en todos los carteles el numero del serie del primero
                    {
                        if (Form_login.carteles_l[i].NumeroSerie == Form_login.estaciones_l[aux].NumeroSerie)
                        {
                            //busco los datos para ver si son correctos, si lo son lo pongo en verde, sino en amarillo
                            if (Form_login.carteles_l[i].Fuente5v == true && Form_login.carteles_l[i].Fuente24v == true &&
                                Form_login.carteles_l[i].FuentePpic == true && Form_login.carteles_l[i].Fuente5pic == true &&
                                Form_login.carteles_l[i].Corriente != null && Form_login.carteles_l[i].Temp != null &&
                                Form_login.carteles_l[i].Pila != null)
                            {
                                pictureBoxEstacionesA_l[k].Image = Resource1.boton_verde3;
                            }
                            else
                            {
                                pictureBoxEstacionesA_l[k].Image = Resource1.boton_amarillo;
                            }
                        }
                    }
                }
                else
                {
                    pictureBoxEstacionesA_l[k].Image = Resource1.boton_rojo3;
                }
                pictureBoxEstacionesA_l[k].Size = new System.Drawing.Size(10, 10);
                pictureBoxEstacionesA_l[k].SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxEstacionesA_l[k].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            for (int k = 0; k < pictureBoxEstacionesB_l.Length; k++)
            {
                aux = k + pictureBoxEstacionesA_l.Length;
                if (Form_login.estaciones_l[aux].Ping == true)
                {
                    for (int i = 0; i < Form_login.carteles_l.Count; i++)    //busco en todos los carteles el numero del serie del primero
                    {
                        if (Form_login.carteles_l[i].NumeroSerie == Form_login.estaciones_l[aux].NumeroSerie)
                        {
                            //busco los datos para ver si son correctos, si lo son lo pongo en verde, sino en amarillo
                            if (Form_login.carteles_l[i].Fuente5v == true && Form_login.carteles_l[i].Fuente24v == true &&
                                Form_login.carteles_l[i].FuentePpic == true && Form_login.carteles_l[i].Fuente5pic == true &&
                                Form_login.carteles_l[i].Corriente != null && Form_login.carteles_l[i].Temp != null &&
                                Form_login.carteles_l[i].Pila != null)
                            {
                                pictureBoxEstacionesB_l[k].Image = Resource1.boton_verde3;
                            }
                            else
                            {
                                pictureBoxEstacionesB_l[k].Image = Resource1.boton_amarillo;
                            }
                        }
                    }
                }
                else
                {
                    pictureBoxEstacionesB_l[k].Image = Resource1.boton_rojo3;
                }
                pictureBoxEstacionesB_l[k].Size = new System.Drawing.Size(10, 10);
                pictureBoxEstacionesB_l[k].SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxEstacionesB_l[k].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            for (int k = 0; k < pictureBoxEstacionesC_l.Length; k++)
            {
                aux = k + pictureBoxEstacionesA_l.Length + pictureBoxEstacionesB_l.Length;
                if (Form_login.estaciones_l[aux].Ping == true)
                {
                    for (int i = 0; i < Form_login.carteles_l.Count; i++)    //busco en todos los carteles el numero del serie del primero
                    {
                        if (Form_login.carteles_l[i].NumeroSerie == Form_login.estaciones_l[aux].NumeroSerie)
                        {
                            //busco los datos para ver si son correctos, si lo son lo pongo en verde, sino en amarillo
                            if (Form_login.carteles_l[i].Fuente5v == true && Form_login.carteles_l[i].Fuente24v == true &&
                                Form_login.carteles_l[i].FuentePpic == true && Form_login.carteles_l[i].Fuente5pic == true &&
                                Form_login.carteles_l[i].Corriente != null && Form_login.carteles_l[i].Temp != null &&
                                Form_login.carteles_l[i].Pila != null)
                            {
                                pictureBoxEstacionesC_l[k].Image = Resource1.boton_verde3;
                            }
                            else
                            {
                                pictureBoxEstacionesC_l[k].Image = Resource1.boton_amarillo;
                            }
                        }
                    }
                }
                else
                {
                    pictureBoxEstacionesC_l[k].Image = Resource1.boton_rojo3;
                }
                pictureBoxEstacionesC_l[k].Size = new System.Drawing.Size(10, 10);
                pictureBoxEstacionesC_l[k].SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxEstacionesC_l[k].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            for (int k = 0; k < pictureBoxEstacionesD_l.Length; k++)
            {
                aux = k + pictureBoxEstacionesA_l.Length + pictureBoxEstacionesB_l.Length +
                    pictureBoxEstacionesC_l.Length;
                if (Form_login.estaciones_l[aux].Ping == true)
                {
                    for (int i = 0; i < Form_login.carteles_l.Count; i++)    //busco en todos los carteles el numero del serie del primero
                    {
                        if (Form_login.carteles_l[i].NumeroSerie == Form_login.estaciones_l[aux].NumeroSerie)
                        {
                            //busco los datos para ver si son correctos, si lo son lo pongo en verde, sino en amarillo
                            if (Form_login.carteles_l[i].Fuente5v == true && Form_login.carteles_l[i].Fuente24v == true &&
                                Form_login.carteles_l[i].FuentePpic == true && Form_login.carteles_l[i].Fuente5pic == true &&
                                Form_login.carteles_l[i].Corriente != null && Form_login.carteles_l[i].Temp != null &&
                                Form_login.carteles_l[i].Pila != null)
                            {
                                pictureBoxEstacionesD_l[k].Image = Resource1.boton_verde3;
                            }
                            else
                            {
                                pictureBoxEstacionesD_l[k].Image = Resource1.boton_amarillo;
                            }
                        }
                    }
                }
                else
                {
                    pictureBoxEstacionesD_l[k].Image = Resource1.boton_rojo3;
                }
                pictureBoxEstacionesD_l[k].Size = new System.Drawing.Size(10, 10);
                pictureBoxEstacionesD_l[k].SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxEstacionesD_l[k].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
            for (int k = 0; k < pictureBoxEstacionesE_l.Length; k++)
            {
                aux = k + pictureBoxEstacionesA_l.Length + pictureBoxEstacionesB_l.Length +
                    pictureBoxEstacionesC_l.Length + pictureBoxEstacionesD_l.Length;
                if (Form_login.estaciones_l[aux].Ping == true)
                {
                    for (int i = 0; i < Form_login.carteles_l.Count; i++)    //busco en todos los carteles el numero del serie del primero
                    {
                        if (Form_login.carteles_l[i].NumeroSerie == Form_login.estaciones_l[aux].NumeroSerie)
                        {
                            //busco los datos para ver si son correctos, si lo son lo pongo en verde, sino en amarillo
                            if (Form_login.carteles_l[i].Fuente5v == true && Form_login.carteles_l[i].Fuente24v == true &&
                                Form_login.carteles_l[i].FuentePpic == true && Form_login.carteles_l[i].Fuente5pic == true &&
                                Form_login.carteles_l[i].Corriente != null && Form_login.carteles_l[i].Temp != null &&
                                Form_login.carteles_l[i].Pila != null)
                            {
                                pictureBoxEstacionesE_l[k].Image = Resource1.boton_verde3;
                            }
                            else
                            {
                                pictureBoxEstacionesE_l[k].Image = Resource1.boton_amarillo;
                            }
                        }
                    }
                }
                else
                {
                    pictureBoxEstacionesE_l[k].Image = Resource1.boton_rojo3;
                }
                pictureBoxEstacionesE_l[k].Size = new System.Drawing.Size(10, 10);
                pictureBoxEstacionesE_l[k].SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxEstacionesE_l[k].SizeMode = PictureBoxSizeMode.StretchImage;
            }
            for (int k = 0; k < pictureBoxEstacionesH_l.Length; k++)
            {
                aux = k + pictureBoxEstacionesA_l.Length +
                    pictureBoxEstacionesB_l.Length + pictureBoxEstacionesC_l.Length + pictureBoxEstacionesD_l.Length +
                    pictureBoxEstacionesE_l.Length;
                if (Form_login.estaciones_l[aux].Ping == true)
                {
                    for (int i = 0; i < Form_login.carteles_l.Count; i++)    //busco en todos los carteles el numero del serie del primero
                    {
                        if (Form_login.carteles_l[i].NumeroSerie == Form_login.estaciones_l[aux].NumeroSerie)
                        {
                            //busco los datos para ver si son correctos, si lo son lo pongo en verde, sino en amarillo
                            if (Form_login.carteles_l[i].Fuente5v == true && Form_login.carteles_l[i].Fuente24v == true &&
                                Form_login.carteles_l[i].FuentePpic == true && Form_login.carteles_l[i].Fuente5pic == true &&
                                Form_login.carteles_l[i].Corriente != null && Form_login.carteles_l[i].Temp != null &&
                                Form_login.carteles_l[i].Pila != null)
                            {
                                pictureBoxEstacionesH_l[k].Image = Resource1.boton_verde3;
                            }
                            else
                            {
                                pictureBoxEstacionesH_l[k].Image = Resource1.boton_amarillo;
                            }
                        }
                    }
                }
                else
                {
                    pictureBoxEstacionesH_l[k].Image = Resource1.boton_rojo3;
                }
                pictureBoxEstacionesH_l[k].Size = new System.Drawing.Size(10, 10);
                pictureBoxEstacionesH_l[k].SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBoxEstacionesH_l[k].SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}

