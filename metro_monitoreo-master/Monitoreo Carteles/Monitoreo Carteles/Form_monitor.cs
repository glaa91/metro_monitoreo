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
        protected static Label[] labelEstacionesA_l = new Label[1];
        protected static List<Label> labelEstacionesB_l = new List<Label>();
        protected static List<Label> labelEstacionesC_l = new List<Label>();
        protected static List<Label> labelEstacionesD_l = new List<Label>();
        protected static List<Label> labelEstacionesE_l = new List<Label>();
        protected static List<Label> labelEstacionesH_l = new List<Label>();

        public static PictureBox[] pictureBoxEstacionesE_l = new PictureBox[0];
        public static List<PictureBox> pictureBoxEstacionesB_l = new List<PictureBox>();
        public static List<PictureBox> pictureBoxEstacionesC_l = new List<PictureBox>();
        public static List<PictureBox> pictureBoxEstacionesD_l = new List<PictureBox>();
        public static List<PictureBox> pictureBoxEstacionesA_l = new List<PictureBox>();
        public static List<PictureBox> pictureBoxEstacionesH_l = new List<PictureBox>();

        protected static TableLayoutPanel tlpA = new TableLayoutPanel();
        protected static TableLayoutPanel tlpB = new TableLayoutPanel();
        protected static TableLayoutPanel tlpC = new TableLayoutPanel();
        protected static TableLayoutPanel tlpD = new TableLayoutPanel();
        protected static TableLayoutPanel tlpE = new TableLayoutPanel();
        protected static TableLayoutPanel tlpH = new TableLayoutPanel();

        private static string[] lineas = { "A", "B", "C", "D", "E", "H" };
        private static string[] interface_lineas = {""};

        public Form_monitor()
        {
            InitializeComponent();
            SetTimer(Form_login.timeRefresh_i, true);
            //this.textBox_configuracion_refresh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            Form_login.monitor_b = true;
            loadInterface();
            setImages(0, 80);   //cargo las imagenes de las lineas
            //loadInterface("calibri", 14, FontStyle.Regular);   //cargo la interfaz

            //cargar lineas, estaciones, accesos en orden para la interfaz.


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

        private void loadEstaciones(ref string[] estaciones, ref int[] cartelesPorEstacion, ref string[] numeroCartel, string lin)
        {
            NpgsqlConnection conexion = new NpgsqlConnection();
            var cadena = string.Format("Server={0};Port=5432;User Id=postgres;Password=postgres;Database=scp;", Form_login.ip_i);
            if (!string.IsNullOrWhiteSpace(cadena))
            {
                try
                {
                    conexion = new NpgsqlConnection(cadena);
                    conexion.Open();
                    string aux = null, aux2=null, aux4=null;
                    int caca=0, caca2=0;
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
        }

        private void loadInterface()    //string fontType, float fontSize, FontStyle fontStyle
        {
            string[] estaciones_l = { null };
            string[] numeroDeCarteles_l = { null };
            int[] cartelesPorEstacion_l = { 0 };
            int ant = 0;

            for (int i = 0; i < lineas.Length; i++)
            {
                loadEstaciones(ref estaciones_l, ref cartelesPorEstacion_l, ref numeroDeCarteles_l, lineas[i]);
                for (int w = 0; w < estaciones_l.Length; w++)
                {
                    //Console.Write(estaciones_l[w]);
                    //Console.Write(cartelesPorEstacion_l[w]);




                    /*
                     * VER EL CAMBIO DE LOGICA, PRIMERO PASO ESTACIONES VECES
                     * Y AHI TENGO QUE IR AGREGANDO TODO.
                     * 
                     * SINO AGREGAR LAS COLUMNAS ARRIBA DE ESTO
                     * 
                     */


                    if(lineas[i] == "A")
                    {
                        if (i == 0)
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
                                for (int y = 0; y < estaciones_l.Length; y++)
                                {
                                    //Next, add a row.  Only do this when once, when creating the first column
                                    if (x == 0)
                                    {
                                        tlpA.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                        Label aux = new Label();
                                        aux.Text = estaciones_l[y];
                                        tlpA.Controls.Add(aux, 0, y);
                                    }
                                }
                            }
                        }
                        
                        for (int k = 0; k < numeroDeCarteles_l.Length; k++)
                        {
                            //Create the control, in this case we will add a button
                            PictureBox aux = new PictureBox();
                            aux.Image = Resource1.boton_rojo1;
                            aux.Size = new System.Drawing.Size(10, 10);
                            aux.SizeMode = PictureBoxSizeMode.CenterImage;
                            aux.SizeMode = PictureBoxSizeMode.StretchImage;

                            tlpA.Controls.Add(aux, k, w);

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
                            for (int y = 0; y < estaciones_l.Length; y++)
                            {
                                //Next, add a row.  Only do this when once, when creating the first column
                                if (x == 0)
                                {
                                    tlpB.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                }
                                if (x > 0)
                                {
                                    /*//Create the control, in this case we will add a button
                                    PictureBox aux = new PictureBox();
                                    aux.Image = Resource1.boton_amarillo;
                                    aux.Size = new System.Drawing.Size(10, 10);
                                    aux.SizeMode = PictureBoxSizeMode.CenterImage;
                                    aux.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBoxEstacionesA_l.Add(aux);
                                    tlpA.Controls.Add(aux, x, y);*/
                                }
                                else
                                {
                                    Label aux = new Label();
                                    aux.Text = estaciones_l[y];
                                    tlpB.Controls.Add(aux, 0, y);
                                }
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
                            for (int y = 0; y < estaciones_l.Length; y++)
                            {
                                //Next, add a row.  Only do this when once, when creating the first column
                                if (x == 0)
                                {
                                    tlpC.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                }
                                if (x > 0)
                                {
                                    /*//Create the control, in this case we will add a button
                                    PictureBox aux = new PictureBox();
                                    aux.Image = Resource1.boton_amarillo;
                                    aux.Size = new System.Drawing.Size(10, 10);
                                    aux.SizeMode = PictureBoxSizeMode.CenterImage;
                                    aux.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBoxEstacionesA_l.Add(aux);
                                    tlpA.Controls.Add(aux, x, y);*/
                                }
                                else
                                {
                                    Label aux = new Label();
                                    aux.Text = estaciones_l[y];
                                    tlpC.Controls.Add(aux, 0, y);
                                }
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
                            tlpA.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                            for (int y = 0; y < estaciones_l.Length; y++)
                            {
                                //Next, add a row.  Only do this when once, when creating the first column
                                if (x == 0)
                                {
                                    tlpD.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                }
                                if (x > 0)
                                {
                                    /*//Create the control, in this case we will add a button
                                    PictureBox aux = new PictureBox();
                                    aux.Image = Resource1.boton_amarillo;
                                    aux.Size = new System.Drawing.Size(10, 10);
                                    aux.SizeMode = PictureBoxSizeMode.CenterImage;
                                    aux.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBoxEstacionesA_l.Add(aux);
                                    tlpA.Controls.Add(aux, x, y);*/
                                }
                                else
                                {
                                    Label aux = new Label();
                                    aux.Text = estaciones_l[y];
                                    tlpD.Controls.Add(aux, 0, y);
                                }
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
                            for (int y = 0; y < estaciones_l.Length; y++)
                            {
                                //Next, add a row.  Only do this when once, when creating the first column
                                if (x == 0)
                                {
                                    tlpE.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                }
                                if (x > 0)
                                {
                                    /*//Create the control, in this case we will add a button
                                    PictureBox aux = new PictureBox();
                                    aux.Image = Resource1.boton_amarillo;
                                    aux.Size = new System.Drawing.Size(10, 10);
                                    aux.SizeMode = PictureBoxSizeMode.CenterImage;
                                    aux.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBoxEstacionesA_l.Add(aux);
                                    tlpA.Controls.Add(aux, x, y);*/
                                }
                                else
                                {
                                    Label aux = new Label();
                                    aux.Text = estaciones_l[y];
                                    tlpE.Controls.Add(aux, 0, y);
                                }
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
                            for (int y = 0; y < estaciones_l.Length; y++)
                            {
                                //Next, add a row.  Only do this when once, when creating the first column
                                if (x == 0)
                                {
                                    tlpH.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                                }
                                if (x > 0)
                                {
                                    /*//Create the control, in this case we will add a button
                                    PictureBox aux = new PictureBox();
                                    aux.Image = Resource1.boton_amarillo;
                                    aux.Size = new System.Drawing.Size(10, 10);
                                    aux.SizeMode = PictureBoxSizeMode.CenterImage;
                                    aux.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBoxEstacionesA_l.Add(aux);
                                    tlpA.Controls.Add(aux, x, y);*/
                                }
                                else
                                {
                                    Label aux = new Label();
                                    aux.Text = estaciones_l[y];
                                    tlpH.Controls.Add(aux, 0, y);
                                }
                            }
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
            
            

            
            
            
            /*
            tableLayoutPanel_listB.Controls.Add(tlpB, 0, 0);
            ant = 0;
            for (int i=0; i<Form_login.cartelesPorEstacionB_l.Count; i++) 
            {
                ant = Math.Max(ant, Form_login.cartelesPorEstacionB_l[i]);
            }
            tlpB.Controls.Clear();
            tlpB.ColumnStyles.Clear();
            tlpB.RowStyles.Clear();
            tlpB.ColumnCount = ant+1;
            tlpB.RowCount = Form_login.nombreEstacionesB_l.Count;
            tlpB.Dock = DockStyle.Fill;
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
                        aux.Image = Resource1.boton_amarillo;
                        aux.Size = new System.Drawing.Size(10, 10);
                        aux.SizeMode = PictureBoxSizeMode.CenterImage;
                        aux.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBoxEstacionesB_l.Add(aux);
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

            tableLayoutPanel_listC.Controls.Add(tlpC, 0, 0);
            ant = 0;
            for (int i = 0; i < Form_login.cartelesPorEstacionC_l.Count; i++)
            {
                ant = Math.Max(ant, Form_login.cartelesPorEstacionC_l[i]);
            }
            tlpC.Controls.Clear();
            tlpC.ColumnStyles.Clear();
            tlpC.RowStyles.Clear();
            tlpC.ColumnCount = ant + 1;
            tlpC.RowCount = Form_login.nombreEstacionesC_l.Count;
            tlpC.Dock = DockStyle.Fill;
            for (int x = 0; x < ant + 1; x++)
            {
                //First add a column
                tlpC.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                for (int y = 0; y < Form_login.nombreEstacionesC_l.Count; y++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x == 0)
                    {
                        tlpC.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                    if (x > 0)
                    {
                        //Create the control, in this case we will add a button
                        PictureBox aux = new PictureBox();
                        aux.Image = Resource1.boton_amarillo;
                        aux.Size = new System.Drawing.Size(10, 10);
                        aux.SizeMode = PictureBoxSizeMode.CenterImage;
                        aux.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBoxEstacionesC_l.Add(aux);
                        tlpC.Controls.Add(aux, x, y);
                    }
                    else
                    {
                        Label aux = new Label();
                        aux.Text = Form_login.nombreEstacionesC_l[y];
                        tlpC.Controls.Add(aux, 0, y);
                    }
                }
            }

            tableLayoutPanel_listD.Controls.Add(tlpD, 0, 0);
            ant = 0;
            for (int i = 0; i < Form_login.cartelesPorEstacionD_l.Count; i++)
            {
                ant = Math.Max(ant, Form_login.cartelesPorEstacionD_l[i]);
            }
            Form_login.Log("DEBUG", string.Format("{0}", ant));
            tlpD.Controls.Clear();
            tlpD.ColumnStyles.Clear();
            tlpD.RowStyles.Clear();
            tlpD.ColumnCount = ant + 1;
            tlpD.RowCount = Form_login.nombreEstacionesB_l.Count;
            tlpD.Dock = DockStyle.Fill;
            for (int x = 0; x < ant + 1; x++)
            {
                //First add a column
                tlpD.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                for (int y = 0; y < Form_login.nombreEstacionesD_l.Count; y++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x == 0)
                    {
                        tlpD.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                    if (x > 0)
                    {
                        //Create the control, in this case we will add a button
                        PictureBox aux = new PictureBox();
                        aux.Image = Resource1.boton_amarillo;
                        aux.Size = new System.Drawing.Size(10, 10);
                        aux.SizeMode = PictureBoxSizeMode.CenterImage;
                        aux.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBoxEstacionesD_l.Add(aux);
                        tlpD.Controls.Add(aux, x, y);
                    }
                    else
                    {
                        Label aux = new Label();
                        aux.Text = Form_login.nombreEstacionesD_l[y];
                        tlpD.Controls.Add(aux, 0, y);
                    }
                }
            }

            tableLayoutPanel_listE.Controls.Add(tlpE, 0, 0);
            ant = 0;
            for (int i = 0; i < Form_login.cartelesPorEstacionE_l.Count; i++)
            {
                ant = Math.Max(ant, Form_login.cartelesPorEstacionE_l[i]);
            }
            Form_login.Log("DEBUG", string.Format("{0}", ant));
            tlpE.Controls.Clear();
            tlpE.ColumnStyles.Clear();
            tlpE.RowStyles.Clear();
            tlpE.ColumnCount = ant + 1;
            tlpE.RowCount = Form_login.nombreEstacionesE_l.Count;
            tlpE.Dock = DockStyle.Fill;
            int z = 0;

            

            for (int x = 0; x < ant + 1; x++)
            {
                //First add a column
                tlpE.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                for (int y = 0; y < Form_login.nombreEstacionesE_l.Count; y++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x == 0)
                    {
                        tlpE.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    }
                    if (x > 0)
                    {
                        //Create the control, in this case we will add a button
                        PictureBox aux = new PictureBox();
                        aux.Image = Resource1.boton_amarillo;
                        aux.Size = new System.Drawing.Size(10, 10);
                        aux.SizeMode = PictureBoxSizeMode.CenterImage;
                        aux.SizeMode = PictureBoxSizeMode.StretchImage;
                        //pictureBoxEstacionesE_l.Add(aux);
                        tlpE.Controls.Add(aux, x, y);
                    }
                    else
                    {
                        Label aux = new Label();
                        aux.Text = Form_login.nombreEstacionesE_l[y];
                        tlpE.Controls.Add(aux, 0, y);
                    }
                }
            }
            tableLayoutPanel_listH.Controls.Add(tlpH, 0, 0);


            ant = 0;
            for (int i = 0; i < Form_login.cartelesPorEstacionH_l.Count; i++)
            {
                ant = Math.Max(ant, Form_login.cartelesPorEstacionH_l[i]);
            }
            tlpH.Controls.Clear();
            tlpH.ColumnStyles.Clear();
            tlpH.RowStyles.Clear();
            tlpH.ColumnCount = ant + 1;
            tlpH.RowCount = Form_login.nombreEstacionesH_l.Count;
            tlpH.Dock = DockStyle.Fill;
            for (int x = 0; x < ant + 1; x++)
            {
                //First add a column
                tlpH.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                for (int y = 0; y < Form_login.nombreEstacionesH_l.Count; y++)
                {
                    //Next, add a row.  Only do this when once, when creating the first column
                    if (x == 0)
                    {
                        tlpH.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            ss        }
                    if (x > 0)
                    {
                        //Create the control, in this case we will add a button
                        PictureBox aux = new PictureBox();
                        aux.Image = Resource1.boton_amarillo;
                        aux.Size = new System.Drawing.Size(10, 10);
                        aux.SizeMode = PictureBoxSizeMode.CenterImage;
                        aux.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBoxEstacionesH_l.Add(aux);
                        tlpH.Controls.Add(aux, x, y);
                    }
                    else
                    {
                        Label aux = new Label();
                        aux.Text = Form_login.nombreEstacionesH_l[y];
                        tlpH.Controls.Add(aux, 0, y);
                    }
                }
            }
            */



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

        private void tableLayoutPanel_monitor_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_configuracionIp_TextChanged(object sender, EventArgs e)
        {

        }

        private void getInfo(string numeroCartel, ref string linea, ref string estacion, ref string acceso)
        {
            Console.Write(numeroCartel);
            string lin = numeroCartel.Substring(0, 1);  //string para separar el numero de linea
            string est = numeroCartel.Substring(1, 2);
            string acce = numeroCartel.Substring(3, 4);
            Console.Write(String.Format("LINEA: {0} - ESTACION: {1} - ACCESO: {2}", lin, est, acce));

            for (int i = 0; i < lineas.Length; i++)
            {
                if (est == lineas[i])
                {
                    estacion = lineas[i];
                    Console.Write(estacion);
                    break;
                }
            }




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
            
        }

        private Boolean loadServer()
        {
            Boolean estado = false;
            DateTime current = DateTime.Now;
            NpgsqlConnection conexion = new NpgsqlConnection();
            //casa: 190.16.226.7
            //metrovias: 172.30.108.200
            //metrovias: 172.30.107.200
            var cadena = string.Format("Server={0};Port=5432;User Id=postgres;Password=postgres;Database=scp;", Form_login.ip_i);
            if (!string.IsNullOrWhiteSpace(cadena))
            {
                try
                {
                    conexion = new NpgsqlConnection(cadena);
                    conexion.Open();
                    //MessageBox.Show("Conexion a la base de datos: OK", current.ToString());
                    Log("INFO", "Database OK");
                    Log("DEBUG", "ME CONECTE BIEN A LA BASE DE DATOS!");
                    estado = true;
                    using (var cmd = new NpgsqlCommand())
                    {/*
                        //LEO TODAS LAS COLUMNAS DE ESTACIONES
                        cmd.CommandText = "SELECT * FROM v_estaciones";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var temp = new Estacion(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetBoolean(6));
                                Form_login.estaciones_l.Add(temp);
                            }
                        }
                        //LEO TODAS LAS COLUMNAS DE CARTELES
                        cmd.CommandText = "SELECT * FROM v_carteles";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var temp = new Cartel(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4), reader.GetBoolean(5), reader.GetBoolean(6),
                                    reader.GetBoolean(7), reader.GetBoolean(8), reader.GetString(9));
                                carteles_l.Add(temp);
                            }
                        }*/
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
            }
            return estado;
        }
    }
}

