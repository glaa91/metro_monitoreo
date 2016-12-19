using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;
using System.Timers;
using System.Threading;
using System.Globalization;

/* 
 * DEBUG: Detailed information, typically of interest only when diagnosing problems.
 *      Log("DEBUG", "") --> YELLOW
 * INFO: Confirmation that things are working as expected.
 *      Log("INFO", "")
 * WARNING: An indication that something unexpected happened, or indicative of some problem in the near future (e.g. ‘disk space low’). The software is still working as expected.
 *      Log("WARNING", "")
 * ERROR: Due to a more serious problem, the software has not been able to perform some function.
 *      Log("ERROR", "")
 * CRITICAL: A serious error, indicating that the program itself may be unable to continue running.
 *      Log("CRITICAL", "")
*/
namespace Monitoreo_Carteles
{
    public partial class Form_login : Form
    {
        private static System.Timers.Timer aTimer;
        private static List<Usuario> usuarios_l = new List<Usuario>();
        private static List<Cartel> carteles_l = new List<Cartel>();
        public static List<Estacion> estaciones_l = new List<Estacion>();

        //  nombre de las estaciones en orden sin repetir
        public static List<string> nombreEstacionesA_l = new List<string>();
        public static List<string> nombreEstacionesB_l = new List<string>();
        public static List<string> nombreEstacionesC_l = new List<string>();
        public static List<string> nombreEstacionesD_l = new List<string>();
        public static List<string> nombreEstacionesE_l = new List<string>();
        public static List<string> nombreEstacionesH_l = new List<string>();
        // cantidad de carteles por estacion - esta en orden vector con nombreEstacionesX_l
        public static List<int> cartelesPorEstacionA_l = new List<int>();
        public static List<int> cartelesPorEstacionB_l = new List<int>();
        public static List<int> cartelesPorEstacionC_l = new List<int>();
        public static List<int> cartelesPorEstacionD_l = new List<int>();
        public static List<int> cartelesPorEstacionE_l = new List<int>();
        public static List<int> cartelesPorEstacionH_l = new List<int>();

        public static Boolean coneccionBaseDatos_b = false, monitor_b = false;
        public static int timeRefresh_i = 60000;

        public Form_login()
        {
            InitializeComponent();
            this.textBox_username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            this.textBox_password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
            SetTimer(timeRefresh_i, true);
            label_estadoConexion = new Label();
            
            //levanto por primera vez todo
            coneccionBaseDatos_b = loadServer();
            /*if (!coneccionBaseDatos_b)
            {
                // como no me pude conectar, tengo que esperar a que el el timer se termine y trate de cargarlo el.
                MessageBox.Show("ERROR al conectarse a la base de datos... /n reintentando en 60 segundos...");
                label_estadoConexion.Text = "ERROR al conectarse a la base de datos...";

            }*/
            //Log("DEBUG", "HOLA");
            //label_estadoConexion.Text = "Coneccion EXITOSA a la base de datos...";
        }

        public static void SetTimer(int time, Boolean fisrt)
        {
            if (fisrt)
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

        public static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Boolean caca = loadServer();
        }

        public static Boolean loadServer()
        {
            Boolean estado = false;
            DateTime current = DateTime.Now;
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
                    //MessageBox.Show("Conexion a la base de datos: OK", current.ToString());
                    Log("INFO", "Database OK");
                    Log("DEBUG", "ME CONECTE BIEN A LA BASE DE DATOS!");
                    estado = true;
                    coneccionBaseDatos_b = true;
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
                                /*
                                 * lo que hago es cargar los datos de los usuarios la clase. y para independizarme
                                 * lo hago dentro una List, asi con solo hacer un Count se el tamaño total.
                                */
                                var temp = new Usuario(reader.GetString(0), reader.GetString(1));
                                usuarios_l.Add(temp);
                            }
                            /*for(int i=0; i<usuarios_l.Count; i++)
                            {
                                Log("DEBUG", string.Format("Usuario [{0}]: {1}", i, usuarios_l[i].Username));
                                Log("DEBUG", string.Format("Usuario [{0}]: {1}", i, usuarios_l[i].Username));
                            }*/
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
                                Form_login.estaciones_l.Add(temp);
                            }
                            /*for (int i = 0; i < estaciones_l.Count; i++)
                            {
                                Log("DEBUG", string.Format("numeroSerie [{0}]: {1}", i, estaciones_l[i].NumeroSerie));
                                Log("DEBUG", string.Format("numeroCartel [{0}]: {1}", i, estaciones_l[i].DateTime));
                                Log("DEBUG", string.Format("ip [{0}]: {1}", i, estaciones_l[i].Ip));
                                Log("DEBUG", string.Format("linea [{0}]: {1}", i, estaciones_l[i].Linea));
                                Log("DEBUG", string.Format("estacion [{0}]: {1}", i, estaciones_l[i].Estacionn));
                                Log("DEBUG", string.Format("dateTime [{0}]: {1}", i, estaciones_l[i].DateTime));
                                Log("DEBUG", string.Format("ping [{0}]: {1}", i, estaciones_l[i].Ping));
                                Log("DEBUG", string.Format(""));
                            }*/
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
                            /*for (int i = 0; i < carteles_l.Count; i++)
                            {
                                Log("DEBUG", string.Format("numeroSerie [{0}]: {1}", i, carteles_l[i].NumeroSerie));
                                Log("DEBUG", string.Format("dateTime [{0}]: {1}", i, carteles_l[i].DateTime));
                                Log("DEBUG", string.Format("pila [{0}]: {1}", i, carteles_l[i].Pila));
                                Log("DEBUG", string.Format("temp [{0}]: {1}", i, carteles_l[i].Temp));
                                Log("DEBUG", string.Format("corriente [{0}]: {1}", i, carteles_l[i].Corriente));
                                Log("DEBUG", string.Format("fuente5v [{0}]: {1}", i, carteles_l[i].Fuente5v));
                                Log("DEBUG", string.Format("fuente24v [{0}]: {1}", i, carteles_l[i].Fuente24v));
                                Log("DEBUG", string.Format("fuentePpic [{0}]: {1}", i, carteles_l[i].FuentePpic));
                                Log("DEBUG", string.Format("fuente5pic [{0}]: {1}", i, carteles_l[i].Fuente5pic));
                                Log("DEBUG", string.Format("mensaje [{0}]: {1}", i, carteles_l[i].Mensaje));
                                Log("DEBUG", string.Format(""));
                            }*/
                        }
                    }
                    conexion.Close();
                }
                catch (Exception)
                {
                    //MessageBox.Show("Conexion a la base de datos: ERROR", current.ToString());
                    Log("DEBUG", string.Format("NO ME PUDE CENCTAR A LA BASE DE DATOS!"));
                    Log("INFO", string.Format("ERROR DATABASE"));
                    conexion.Close();
                    estado = false;
                    coneccionBaseDatos_b = false;
                }
            }
            return estado;
        }

        public static void Log(string type, string logMessage)
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
                        sw.WriteLine("ARCHIVO CREADO!");
                    }
                }
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(texto);
                    Console.Write(texto);
                    //if(monitor_b) Form_monitor.richTextBox_debug.AppendText(System.Environment.NewLine + texto);
                }
                
            }
            catch
            {

            }
        }
        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                checkUserPass();   
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            checkUserPass();
        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkUserPass()
        {
            bool usuario_b = false;
            string username_s, password_s;
            if (!string.IsNullOrWhiteSpace(textBox_username.Text) && !string.IsNullOrWhiteSpace(textBox_password.Text))
            {   //veo que no esten vacio los text box
                username_s = textBox_username.Text.ToLower();
                password_s = textBox_password.Text.ToLower();
                for (int i = 0; i < usuarios_l.Count; i++) //busco en mis objetos usuarios cargados para comparar
                {
                    if (usuarios_l[i].Username == username_s && usuarios_l[i].Password == password_s) // valido usuario y contraseña con lo que tengo cargado
                    {
                        //USUARIO VALIDADO!
                        usuario_b = true;
                    }
                }
            }
            if (coneccionBaseDatos_b)
            {
                if (usuario_b)
                {
                    MessageBox.Show("USUARIO VALIDO!", "Inicio sesion");
                    Form_monitor form_monitor = new Form_monitor();
                    form_monitor.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("USUARIO INVALIDO! - Verifique usuario/contraseña", "Inicio sesion");
                }
            }
            else
            {
                MessageBox.Show("AUN NO SE HA CONECTADO A LA BASE DE DATOS...", "Error de conexion a la base de datos");
            }
        }
    }
}
