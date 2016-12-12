﻿using System;
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
    public partial class Form1 : Form
    {
        /*private static System.Timers.Timer aTimer;
        private static List<Usuario> usuarios_l = new List<Usuario>();
        private static List<Cartel> carteles_l = new List<Cartel>();
        private static List<Estacion> estaciones_l = new List<Estacion>();
        private static RichTextBox richTextBox;
        private TabControl tabControl1;
        private string tabMonitor_s = "MONITOR", tabDebug_s = "DEBUG", tabConfig_s = "CONFIGURACION";
        private static Boolean coneccionBaseDatos_b = false;*/

        public Form1()
        {
            /*richTextBox = new RichTextBox();
            SetTimer();
            //levanto por primera vez todo
            coneccionBaseDatos_b = loadServer();
            if (!coneccionBaseDatos_b)
            {
                // como no me pude conectar, tengo que esperar a que el el timer se termine y trate de cargarlo el.
                MessageBox.Show("ERROR al conectarse a la base de datos... /n reintentando en 60 segundos...");
            }
            InitializeComponent();
            Log("DEBUG", "HOLA");
            */
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*this.tabControl1 = new TabControl();
            
            TabControl tabMonitorControl = new TabControl();

            TabPage tab_monitor = new TabPage();
            TabPage tab_debug = new TabPage();
            TabPage tab_config = new TabPage();

            tab_monitor.Text = tabMonitor_s;    //le pongo el texto a cada tab
            tab_debug.Text = tabDebug_s;
            tab_config.Text = tabConfig_s;

            //richTextBox = new RichTextBox();
            tab_debug.Controls.Add(richTextBox);

            TabPage[] tabPages = { tab_monitor, tab_debug, tab_config };

            this.tabControl1.SizeMode = TabSizeMode.FillToRight;    // Sizes the tabs so that each row fills the entire width of tabControl1.
            this.tabControl1.Dock = DockStyle.Fill;     //hago que se llene con el tamaño de la ventana
            this.tabControl1.Padding = new Point(15, 4);    //les deja un espacion entre vertical y horizontal
            this.tabControl1.Controls.AddRange(new Control[] {tab_monitor, tab_debug, tab_config}); //agrego las pestañas
            this.tabControl1.Location = new Point(0, 0);    //seteo en la posicion 0,0
            this.Controls.Add(tabControl1);

            
            */
        }
        /*
        private static void SetTimer()
        {
            // Create a timer with a 60 second interval.
            aTimer = new System.Timers.Timer(60000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Boolean caca = loadServer();
        }

        private static Boolean loadServer()
        {
            Boolean estado = false;
            DateTime current = DateTime.Now;
            //Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
            NpgsqlConnection conexion = new NpgsqlConnection();
            //casa: 190.16.226.7
            //metrovias: 172.30.108.200
            var cadena = "Server=172.30.108.200;Port=5432;User Id=postgres;Password=postgres;Database=scp;";
            if (!string.IsNullOrWhiteSpace(cadena))
            {
                try
                {
                    conexion = new NpgsqlConnection(cadena);
                    conexion.Open();
                    MessageBox.Show("Conexion a la base de datos: OK - ", current.ToString());
                    estado = true;
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conexion;
                        //LEO TODAS LAS COLUMNAS DE CUENTAS
                        cmd.CommandText = "SELECT * FROM v_cuentas";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //string username = reader.GetString(0);    //username
                                //string password = reader.GetString(1);    //password
                                //Console.WriteLine(username); //username
                                //Console.WriteLine(password); //password
                                //
                                 // lo que hago es cargar los datos de los usuarios la clase. y para independizarme
                                // lo hago dentro una List, asi con solo hacer un Count se el tamaño total.
                                //
                                var temp = new Usuario(reader.GetString(0), reader.GetString(1));
                                usuarios_l.Add(temp);
                            }
                            for(int i=0; i<usuarios_l.Count; i++)
                            {
                                Console.WriteLine("Usuario [{0}]: {1}", i, usuarios_l[i].Username);
                                Console.WriteLine("Password [{0}]: {1}", i, usuarios_l[i].Password);
                            }
                            Console.WriteLine();
                        }
                        //LEO TODAS LAS COLUMNAS DE ESTACIONES
                        cmd.CommandText = "SELECT * FROM v_estaciones";
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var temp = new Estacion(reader.GetString(0), reader.GetString(1), reader.GetString(2),
                                    reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetBoolean(6));
                                estaciones_l.Add(temp);
                            }
                            for (int i = 0; i < estaciones_l.Count; i++)
                            {
                                Console.WriteLine("numeroSerie [{0}]: {1}", i, estaciones_l[i].NumeroSerie);
                                Console.WriteLine("numeroCartel [{0}]: {1}", i, estaciones_l[i].DateTime);
                                Console.WriteLine("ip [{0}]: {1}", i, estaciones_l[i].Ip);
                                Console.WriteLine("linea [{0}]: {1}", i, estaciones_l[i].Linea);
                                Console.WriteLine("estacion [{0}]: {1}", i, estaciones_l[i].Estacionn);
                                Console.WriteLine("dateTime [{0}]: {1}", i, estaciones_l[i].DateTime);
                                Console.WriteLine("ping [{0}]: {1}", i, estaciones_l[i].Ping);
                                Console.WriteLine();
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
                            for (int i = 0; i < carteles_l.Count; i++)
                            {
                                Console.WriteLine("numeroSerie [{0}]: {1}", i, carteles_l[i].NumeroSerie);
                                Console.WriteLine("dateTime [{0}]: {1}", i, carteles_l[i].DateTime);
                                Console.WriteLine("pila [{0}]: {1}", i, carteles_l[i].Pila);
                                Console.WriteLine("temp [{0}]: {1}", i, carteles_l[i].Temp);
                                Console.WriteLine("corriente [{0}]: {1}", i, carteles_l[i].Corriente);
                                Console.WriteLine("fuente5v [{0}]: {1}", i, carteles_l[i].Fuente5v);
                                Console.WriteLine("fuente24v [{0}]: {1}", i, carteles_l[i].Fuente24v);
                                Console.WriteLine("fuentePpic [{0}]: {1}", i, carteles_l[i].FuentePpic);
                                Console.WriteLine("fuente5pic [{0}]: {1}", i, carteles_l[i].Fuente5pic);
                                Console.WriteLine("mensaje [{0}]: {1}", i, carteles_l[i].Mensaje);
                                Console.WriteLine();
                            }
                        }
                    }
                    conexion.Close();
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Conexion a la base de datos: ERROR", current.ToString());
                    conexion.Close();
                    estado = false;
                }
            }
            return estado;
        }

        private void tabPage_Click(object sender, EventArgs e)
        {

        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {

        }
        public static void Log(string type, string logMessage)
        {
            StreamWriter w = File.AppendText("log.txt");
            DateTime dateValue = new System.DateTime();
            string texto = String.Format("{0} - {1}-{2}", dateValue.ToString("G"), type, logMessage);
            w.WriteLine(texto);
            Console.WriteLine(texto);
            richTextBox.AppendText(System.Environment.NewLine + texto);
        }*/
    }
}

