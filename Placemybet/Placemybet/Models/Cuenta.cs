using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Cuenta
    {
        public Cuenta(int idCuenta, int saldo, string nombre, string tarjeta)
        {
            IdCuenta = idCuenta;
            Saldo = saldo;
            Nombre = nombre;
            Tarjeta = tarjeta;
        }

        public int IdCuenta { get; set; }
       public int Saldo { get; set; }
       public string Nombre { get; set; }
       public string Tarjeta { get; set; }

    }
}