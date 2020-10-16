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


    public class MercadoDTO
    {
        public MercadoDTO(float over_under, float cuota_over, float cuota_under)
        {
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
        }

        public float Over_under { get; set; }
        public float Cuota_over { get; set; }
        public float Cuota_under { get; set; }
    }
}