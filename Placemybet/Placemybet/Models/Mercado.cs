using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Mercado
    {
        public Mercado( int idd ,string overUnder, double cuota, string dinero)
        {
            id = idd; 
            OverUnder = overUnder;
            Cuota = cuota;
            Dinero = dinero;
        }

        public int id { get; set; }
        public string OverUnder { get; set; }
        public double Cuota { get; set; }
        public String Dinero { get; set; }
    }


    public class MercadoDTO
    {
        public MercadoDTO(string over_under, float cuota_over, float cuota_under)
        {
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
        }

        public string Over_under { get; set; }
        public float Cuota_over { get; set; }
        public float Cuota_under { get; set; }
    }
}