using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Datos de la tabla CARTELES
    //numeroSerie
    //dateTime
    //pila
    //temp
    //corriente
    //fuente5v
    //fuente24v
    //fuentePpic
    //fuente5pic
    //mensaje

namespace Monitoreo_Carteles
{
    class Cartel
    {
        public string NumeroSerie { get; set; }
        public string DateTime { get; set; }
        public string Pila { get; set; }
        public string Temp { get; set; }
        public string Corriente { get; set; }
        public Boolean Fuente5v { get; set; }
        public Boolean Fuente24v { get; set; }
        public Boolean FuentePpic { get; set; }
        public Boolean Fuente5pic { get; set; }
        public string Mensaje { get; set; }
        public Cartel(string numeroSerie, string dateTime, string pila, string temp, string corriente,
            Boolean fuente5v, Boolean fuente24v, Boolean fuentePpic, Boolean fuente5pic, string mensaje)
        {
            NumeroSerie = numeroSerie;
            DateTime = dateTime;
            Pila = pila;
            Temp = temp;
            Corriente = corriente;
            Fuente5v = fuente5v;
            Fuente24v = fuente24v;
            FuentePpic = fuentePpic;
            Fuente5pic = Fuente5pic;
            Mensaje = mensaje;
        }
        //Other properties, methods, events...
    }
}
