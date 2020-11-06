using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Mercado
    {
        public Mercado( int idd ,string overUnder, double cuota, double dinero, double cuota2, double dinero2)
        {
            id = idd; 
            OverUnder = overUnder;
            CuotaOver = cuota;
            DineroOver = dinero;
            CuotaUnder = cuota2;
            DineroUnder = dinero2;
        }

        public int id { get; set; }
        public string OverUnder { get; set; }
        public double CuotaOver { get; set; }
        public double DineroOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroUnder { get; set; }
    }


    public class MercadoDTO
    {
        public MercadoDTO(string over_under, double cuota_over, double cuota_under)
        {
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
        }

        public string Over_under { get; set; }
        public double Cuota_over { get; set; }
        public double Cuota_under { get; set; }
    }

}






