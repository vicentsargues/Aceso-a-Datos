﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Placemybet.Models
{
    public class ApuestaRepositorio
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
        internal Apuesta Retrive()
        {
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "select * from apuesta";
            con.Open();
            MySqlDataReader res = comand.ExecuteReader();
            Apuesta ap = null;
            if (res.Read())
            {
                ap = new Apuesta(res.GetInt32(0), res.GetDateTime(1), res.GetString(2), res.GetDouble(3), res.GetInt32(4), res.GetString(5));

            }
            con.Close();
            return ap;
        }

        internal List<ApuestaDTO> GetApuestasDTO()
        {
            List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from apuestas";
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string user = reader.GetString(1);
                    string tipo_apuesta = reader.GetString(3);
                    float cuota = reader.GetFloat(4);
                    float apuesta = reader.GetFloat(5);
                    string fecha = reader.GetString(6);
                    apuestas.Add(new ApuestaDTO(user, tipo_apuesta, cuota, apuesta, fecha));
                }
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return apuestas;
        }


        internal void Save(Apuesta a)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "INSERT INTO apuestas(idapuesta,fecha,dinero,tipoapuesta,usuario_email,mercado_over/under) VALUES ('" + a.IdApuesta + "' , '" + a.Fecha + "' ,'" + a.Dinero + "' ,'" + a.TipoApuesta + "' ,'" + a.MailUsuario + "' , '" + a.MercadoOverUnder + "' );";
          
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Insert Apuesta");
            }
        }








    }

}