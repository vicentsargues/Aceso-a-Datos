using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Apuesta 
    {
        private int v1;
        private DateTime dateTime;
        private string v2;
        private double v3;
        private int v4;
        private string v5;

        public Apuesta(int idApuesta, DateTime fecha, int dinero, double tipoApuesta, string mailUsuario, string mercadoOverUnder)
        {
            IdApuesta = idApuesta;
            Fecha = fecha;
            Dinero = dinero;
            TipoApuesta = tipoApuesta;
            MailUsuario = mailUsuario;
            MercadoOverUnder = mercadoOverUnder;
        }

        public Apuesta(int v1, DateTime dateTime, string v2, double v3, int v4, string v5)
        {
            this.v1 = v1;
            this.dateTime = dateTime;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
        }

        public int IdApuesta { get; set; }
         public DateTime Fecha { get; set; }
         public int Dinero { get; set; }
         public double TipoApuesta { get; set; }
         public string MailUsuario { get; set; }
         public string MercadoOverUnder { get; set; }


       

}
    public class ApuestaDTO
    {
        public ApuestaDTO(string email_user, string tipo_apuesta, float cuota, float apuesta, string fecha, string over_under)
        {
            this.over_under = over_under;
            this.email_user = email_user;
            this.tipo_apuesta = tipo_apuesta;
            this.cuota = cuota;
            this.apuesta = apuesta;
            this.fecha = fecha;
        }

        public string over_under { get; set; }
        public string email_user { get; set; }
        public string tipo_apuesta { get; set; }
        public float cuota { get; set; }
        public float apuesta { get; set; }
        public string fecha { get; set; }
    }


}
