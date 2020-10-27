using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Placemybet.Models
{
    public class EventoRepository
    {

        private MySqlConnection Connect()
        {




            string server = "server=127.0.0.1;";
            string port = "port=3306;";
            string database = "database=mybd;";
            string usuario = "uid=root;";
            string password = "pwd=;";

            string connString = server + port + database + usuario + password;
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal Evento Retrive()
        {
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "select * from evento";
            con.Open();
            MySqlDataReader res = comand.ExecuteReader();
            Evento ap = null;
            if (res.Read())
            {
                ap = new Evento(res.GetInt32(0),res.GetString(1), res.GetDateTime(2) , res.GetString(3), res.GetString(4));

            }
            con.Close();
            return ap;
        }





        internal List<EventoDTO> GetEventosDTO()
        {
            List<EventoDTO> eventos = new List<EventoDTO>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM eventos";
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string equipo_local = reader.GetString(1);
                    string equipo_visitante = reader.GetString(2);
                    string fecha = reader.GetString(3);
                    eventos.Add(new EventoDTO(equipo_local, equipo_visitante, fecha));
                }
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return eventos;
        }

    }
}