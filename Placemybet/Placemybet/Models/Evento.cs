using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class Evento
    {
        public Evento(int idEvento, string eqLoc, DateTime fecha, string eqVis, string overUnder)
        {
            IdEvento = idEvento;
            EqLoc = eqLoc;
            Fecha = fecha;
            EqVis = eqVis;
            OverUnder = overUnder;
        }

        public int IdEvento { get; set; }
        public string EqLoc { get; set; }
        public DateTime Fecha { get; set; }
        public string EqVis { get; set; }
        public string OverUnder { get; set; }

    }
}