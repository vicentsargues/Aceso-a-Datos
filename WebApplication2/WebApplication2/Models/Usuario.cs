using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Usuario
    {
        public Usuario(string gmailId, string nombre, string apellidos, int edad, int idCuenta)
        {
            GmailId = gmailId;
            Nombre = nombre;
            Apellidos = apellidos;
            Edad = edad;
            IdCuenta = idCuenta;
        }

        public string GmailId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public int IdCuenta { get; set; }
    }
}