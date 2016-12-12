using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoreo_Carteles
{
    class Estacion
    {
        public string NumeroSerie { get; set; }
        public string NumeroCartel { get; set; }
        public string Ip { get; set; }
        public string Linea { get; set; }
        public string Estacionn { get; set; }
        public string DateTime { get; set; }
        public Boolean Ping { get; set; }
        public Estacion(string numeroSerie, string numeroCartel, string ip, string linea, string estacionn,
            string dateTime, Boolean ping)
        {
            NumeroSerie = numeroSerie;
            NumeroCartel = numeroCartel;
            Ip = ip;
            Linea = linea;
            Estacionn = estacionn;
            DateTime = dateTime;
            Ping = ping;
        }
        //Other properties, methods, events...
    }
}
