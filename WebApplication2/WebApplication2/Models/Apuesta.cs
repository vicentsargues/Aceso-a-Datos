using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Apuesta 
    {
        private int idApuesta;
        private string fecha;
        private int dinero;
        private double tipoApuesta;
        private string mailUsuario;
        private string mercadoOverUnder;

        public Apuesta(int idApuesta, string fecha, int dinero, double tipoApuesta, string mailUsuario, string mercadoOverUnder)
        {
            IdApuesta = idApuesta;
            Fecha = fecha;
            Dinero = dinero;
            TipoApuesta = tipoApuesta;
            MailUsuario = mailUsuario;
            MercadoOverUnder = mercadoOverUnder;
        }



        public int IdApuesta { get; set; }
         public string Fecha { get; set; }
         public int Dinero { get; set; }
         public double TipoApuesta { get; set; }
         public string MailUsuario { get; set; }
         public string MercadoOverUnder { get; set; }


       

}
    public class ApuestaDTO
    {
        public ApuestaDTO(int email_user, double tipo_apuesta, double cuota, double apuesta, string fecha,  string tipo_apuesta2, double cuota2)
        {

            this.email_user = email_user;
            this.tipo_apuesta = tipo_apuesta;         
            this.cuota = cuota;
            this.apuesta = apuesta;
            this.fecha = fecha;
            this.tipo_apuesta2 = tipo_apuesta2;
            this.cuota2 = cuota2;
        }

        public int email_user { get; set; }
        public double tipo_apuesta { get; set; }
        public string tipo_apuesta2 { get; set; }
        public double cuota { get; set; }
        public double apuesta { get; set; }
        public string fecha { get; set; }

        public double cuota2 { get; set; }
    }


}
