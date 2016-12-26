using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitoreo_Carteles
{
    public partial class Form_config : Form
    {

        private static string[] senales_l = { "Encender todo", "Apagar todo", "Reset", "Semaforo verde", "Semaforo rojo", "Mensaje 'Prueba de Display'"};

        public Form_config(string Label_Estacion, string cartel)
        {
            InitializeComponent();
            this.Text = String.Format("Estado de los carteles en {0} - {1}", Label_Estacion, Form_login.infoMonitoreo_s);
            int tmp = 0;
            for(int i = 0; i < Form_login.estaciones_l.Count; i++)  //cargo la lista de carteles de menor a mayor
            {
                if (Form_login.estaciones_l[i].Estacionn == Label_Estacion)
                {
                    this.config_listBoxCarteles.Items.Insert(tmp, Form_login.estaciones_l[i].NumeroCartel);
                    tmp++;
                }
            }
            if(cartel == null) //selecciono el primer item, pq aprete el nombre de la estacion
            {
                config_listBoxCarteles.SetSelected(0, true);
            }
            else
            {
                //selecciono el numero de cartel que aprete

            }

            for(int i=0; i < senales_l.Length; i++)
            {
                this.config_comboBox.Items.Add(senales_l[i]);
            }
            

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void config_labelLinea_Click(object sender, EventArgs e)
        {

        }

        private void listBox_config_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox listbox = (ListBox)sender;
            string labelText_numeroCartel = listbox.SelectedItem.ToString();
            Boolean aux = false, aux2 = false;
            for (int i = 0; i < Form_login.estaciones_l.Count; i++)
            {
                if (Form_login.estaciones_l[i].NumeroCartel == labelText_numeroCartel)
                {
                    config_labelNumeroSerie.Text = Form_login.estaciones_l[i].NumeroSerie;
                    config_labelIp.Text = Form_login.estaciones_l[i].Ip;
                    config_labelEstacion.Text = Form_login.estaciones_l[i].Estacionn;
                    config_labelLinea.Text = Form_login.estaciones_l[i].Linea;
                    aux = true;
                    if(Form_login.estaciones_l[i].NumeroSerie != null)
                    {
                        for(int k = 0; k < Form_login.carteles_l.Count; k++)
                        {
                            if (Form_login.estaciones_l[i].NumeroSerie == Form_login.carteles_l[k].NumeroSerie)
                            {
                                config_labelUltimaActualizacion.Text = Form_login.carteles_l[k].DateTime;
                                config_labelPila.Text = Form_login.carteles_l[k].Pila;
                                config_labelTemp.Text = Form_login.carteles_l[k].Temp;
                                config_labelFuente5v.Text = string.Format("{0}", Form_login.carteles_l[k].Fuente5v);
                                config_labelFuente24v.Text = string.Format("{0}", Form_login.carteles_l[k].Fuente24v);
                                config_labelFuente5Pic.Text = string.Format("{0}", Form_login.carteles_l[k].Fuente5pic);
                                config_labelFuentePpic.Text = string.Format("{0}", Form_login.carteles_l[k].Fuente5pic);
                                config_labelMensajeActual.Text = Form_login.carteles_l[k].Mensaje;
                                aux2 = true;
                            }
                        }
                    }
                }
                if (!aux)
                {
                    config_labelNumeroSerie.Text = "null";
                    config_labelIp.Text = "null";
                    config_labelEstacion.Text = "null";
                    config_labelLinea.Text = "null";
                }
                if (!aux2)
                {
                    config_labelUltimaActualizacion.Text = "null";
                    config_labelPila.Text = "null";
                    config_labelTemp.Text = "null";
                    config_labelFuente5v.Text = "null";
                    config_labelFuente24v.Text = "null";
                    config_labelFuente5Pic.Text = "null";
                    config_labelFuentePpic.Text = "null";
                }    
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
