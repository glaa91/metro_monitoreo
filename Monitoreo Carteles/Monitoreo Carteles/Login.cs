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

namespace Monitoreo_Carteles
{
    public partial class Login : Form
    {
        private static System.Timers.Timer aTimer;
        private static List<Usuario> usuarios_l = new List<Usuario>();
        private static List<Cartel> carteles_l = new List<Cartel>();
        private static List<Estacion> estaciones_l = new List<Estacion>();
        //private static RichTextBox richTextBox;
        //private TabControl tabControl1;
        //private string tabMonitor_s = "MONITOR", tabDebug_s = "DEBUG", tabConfig_s = "CONFIGURACION";
        private static Boolean coneccionBaseDatos_b = false;

        public Login()
        {
            InitializeComponent();
            SetTimer();
            label_estadoConexion = new Label();
            
            //levanto por primera vez todo
            coneccionBaseDatos_b = loadServer();
            /*if (!coneccionBaseDatos_b)
            {
                // como no me pude conectar, tengo que esperar a que el el timer se termine y trate de cargarlo el.
                MessageBox.Show("ERROR al conectarse a la base de datos... /n reintentando en 60 segundos...");
                label_estadoConexion.Text = "ERROR al conectarse a la base de datos...";

            }*/
            Log("DEBUG", "HOLA");
            //label_estadoConexion.Text = "Coneccion EXITOSA a la base de datos...";
        }

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
                                /*
                                 * lo que hago es cargar los datos de los usuarios la clase. y para independizarme
                                 * lo hago dentro una List, asi con solo hacer un Count se el tamaño total.
                                */
                                var temp = new Usuario(reader.GetString(0), reader.GetString(1));
                                usuarios_l.Add(temp);
                            }
                            /*for(int i=0; i<usuarios_l.Count; i++)
                            {
                                Console.WriteLine("Usuario [{0}]: {1}", i, usuarios_l[i].Username);
                                Console.WriteLine("Password [{0}]: {1}", i, usuarios_l[i].Password);
                            }
                            Console.WriteLine();*/
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
                            /*for (int i = 0; i < estaciones_l.Count; i++)
                            {
                                Console.WriteLine("numeroSerie [{0}]: {1}", i, estaciones_l[i].NumeroSerie);
                                Console.WriteLine("numeroCartel [{0}]: {1}", i, estaciones_l[i].DateTime);
                                Console.WriteLine("ip [{0}]: {1}", i, estaciones_l[i].Ip);
                                Console.WriteLine("linea [{0}]: {1}", i, estaciones_l[i].Linea);
                                Console.WriteLine("estacion [{0}]: {1}", i, estaciones_l[i].Estacionn);
                                Console.WriteLine("dateTime [{0}]: {1}", i, estaciones_l[i].DateTime);
                                Console.WriteLine("ping [{0}]: {1}", i, estaciones_l[i].Ping);
                                Console.WriteLine();
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
                            }*/
                        }
                    }
                    conexion.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Conexion a la base de datos: ERROR", current.ToString());
                    conexion.Close();
                    estado = false;
                }
            }
            return estado;
        }

        public static void Log(string type, string logMessage)
        {
            DateTime dateValue = DateTime.Now;
            string texto = String.Format("{0} - {1} - {2}", dateValue.ToString("G"), type, logMessage); // la G indica el formato de la hora XX/XX/XX 12:12:12
            string path = "log.txt";
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
            }
            //richTextBox.AppendText(System.Environment.NewLine + texto);
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
            bool usuario_b = false;
            string username_s, password_s;
            if (!string.IsNullOrWhiteSpace(textBox_username.Text) && !string.IsNullOrWhiteSpace(textBox_password.Text))
            {   //veo que no esten vacio los text box
                username_s = textBox_username.Text;
                password_s = textBox_password.Text;
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
                }
                else
                {
                    MessageBox.Show("USUARIO INVALIDO! - Verifique usuario/contraseña", "Inicio sesion");
                }
            }
            else
            {
                MessageBox.Show("AUN NO SE HA CONECTADO A LA BASE DE DATOS...","Error de conexion a la base de datos");
            }
        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
