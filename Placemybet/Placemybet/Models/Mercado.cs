using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Mercado
    {
        public Mercado(string overUnder, double cuota, string dinero)
        {
            OverUnder = overUnder;
            Cuota = cuota;
            Dinero = dinero;
        }

        public string OverUnder { get; set; }
        public double Cuota { get; set; }
        public String Dinero { get; set; }
    }
}