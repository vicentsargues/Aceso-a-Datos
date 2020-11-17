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






    public class EventoDTO
    {
        public EventoDTO(string equipo_local, string equipo_visitante, string fecha)
        {

            Equipo_local = equipo_local;
            Equipo_visitante = equipo_visitante;
            Fecha = fecha;
        }

        public string Equipo_local { get; set; }
        public string Equipo_visitante { get; set; }
        public string Fecha { get; set; }
    }
    /***  EJERCICIO PARA EXAMEN (EJERCIOCIO 2) ***/

    public class EventoExamen
    {
        public EventoExamen(int idEvento, string eqLoc, DateTime fecha, string eqVis, string Mercadoo, string TMercado)
        {
            IdEvento = idEvento;
            EqLoc = eqLoc;
            Fecha = fecha;
            EqVis = eqVis;
            Mercado = Mercadoo;
            TipoMercado = TMercado;
        }

        public int IdEvento { get; set; }
        public string EqLoc { get; set; }
        public DateTime Fecha { get; set; }
        public string EqVis { get; set; }
        public string Mercado { get; set; }
        public string TipoMercado { get; set; }

    }



    /***  EJERCICIO PARA EXAMEN (EJERCIOCIO 2) ***/



}