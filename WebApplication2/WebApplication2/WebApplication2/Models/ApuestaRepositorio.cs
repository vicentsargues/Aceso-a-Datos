using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Org.BouncyCastle.Asn1;

namespace Placemybet.Models
{
    public class ApuestaRepositorio
    {

        private MySqlConnection Connect()
        {
            string server = "server=127.0.0.1;";
            string port = "port=3306;";
            string database = "database=mydb;";
            string usuario = "uid=root;";
            string password = "pwd=;";

            string connString = server + port + database + usuario + password;
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Apuesta> Retrive()
        {
            List<Apuesta> mercados = new List<Apuesta>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `apuesta`";
            Apuesta ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                if (res.Read())
                {
                    ap = new Apuesta(res.GetInt32(0), res.GetString(1), res.GetInt32(2), res.GetDouble(3), res.GetString(4), res.GetString(5));
                    mercados.Add(ap);
                }
                else
                {
                    ap = new Apuesta(1, "1", 1, 1, "1", "1");
                    mercados.Add(ap);
                }
            }
            catch (Exception e)
            {

                ap = new Apuesta(1,"1",1,1,"1","1");
                mercados.Add(ap);
            }
            
            con.Close();
            return mercados;
        }
        





     internal List<Apuesta> Retrive2(int id)
        {
            List<Apuesta> mercados = new List<Apuesta>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT* FROM `apuesta` WHERE `USUARIO_EMAIL` = '"+id+"'";
            Apuesta ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                if (res.Read())
                {
                    ap = new Apuesta(res.GetInt32(0), res.GetString(1), res.GetInt32(2), res.GetDouble(3), res.GetString(4), res.GetString(5));
                    mercados.Add(ap);
                }
                else
                {
                    ap = new Apuesta(1, "1", 1, 1, "1", "1");
                    mercados.Add(ap);
                }
            }
            catch (Exception e)
            {

                ap = new Apuesta(1, "1", 1, 1, "1", "1");
                mercados.Add(ap);
            }

            con.Close();
            return mercados;
        }

        

     internal List<Apuesta> Retrive3over(int id)
        {
            List<Apuesta> mercados = new List<Apuesta>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT `apuesta`.* FROM `apuesta` LEFT JOIN `mercado` ON `apuesta`.`MERCADO_OVER/UNDER` = `mercado`.`id` WHERE `apuesta`.`USUARIO_EMAIL` LIKE '"+id+"' AND `mercado`.`over/under` LIKE 'over'";
            Apuesta ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                if (res.Read())
                {
                    ap = new Apuesta(res.GetInt32(0), res.GetString(1), res.GetInt32(2), res.GetDouble(3), res.GetString(4), res.GetString(5));
                    mercados.Add(ap);
                }
                else
                {
                    ap = new Apuesta(1, "1", 1, 1, "1", "1");
                    mercados.Add(ap);
                }
            }
            catch (Exception e)
            {

                ap = new Apuesta(1, "1", 1, 1, "1", "1");
                mercados.Add(ap);
            }

            con.Close();
            return mercados;
        }
        internal List<Apuesta> Retrive3under(int id)
        {
            List<Apuesta> mercados = new List<Apuesta>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT `apuesta`.* FROM `apuesta` LEFT JOIN `mercado` ON `apuesta`.`MERCADO_OVER/UNDER` = `mercado`.`id` WHERE `apuesta`.`USUARIO_EMAIL` LIKE '" + id + "' AND `mercado`.`over/under` LIKE 'under'";
            Apuesta ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                if (res.Read())
                {
                    ap = new Apuesta(res.GetInt32(0), res.GetString(1), res.GetInt32(2), res.GetDouble(3), res.GetString(4), res.GetString(5));
                    mercados.Add(ap);
                }
                else
                {
                    ap = new Apuesta(1, "1", 1, 1, "1", "1");
                    mercados.Add(ap);
                }
            }
            catch (Exception e)
            {

                ap = new Apuesta(1, "1", 1, 1, "1", "1");
                mercados.Add(ap);
            }

            con.Close();
            return mercados;
        }




        internal List<ApuestaDTO> GetApuestasDTO()
        {
            List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT `apuesta`.*, `mercado`.`CuotaOver`, `mercado`.`CuotaUnder` FROM `apuesta` LEFT JOIN `mercado` ON `apuesta`.`MERCADO_OVER/UNDER` = `mercado`.`over/under` ";
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    int user = reader.GetInt32(4);
                    double tipo_apuesta = reader.GetDouble(3);
                    double cuota = reader.GetDouble(6);
                    double cuota2 = reader.GetDouble(7);
                    double apuesta = reader.GetDouble(2);
                    string fecha = reader.GetString(1);
                    string tipo_apuesta2 = reader.GetString(5);
                    apuestas.Add(new ApuestaDTO(user, tipo_apuesta, cuota, apuesta, fecha, tipo_apuesta2,cuota2));
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
            //Apuesta a = new Apuesta(23, "2020-11-05 12:22:54", 1, 23, "123", "123");
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "INSERT INTO `apuesta` (`idAPUESTA`, `Fecha`, `Dinero`, `TipoApuesta`, `USUARIO_EMAIL`, `MERCADO_OVER/UNDER`) VALUES ('" + a.IdApuesta + "' , '" + a.Fecha + "' ,'" + a.Dinero + "' ,'" + a.TipoApuesta + "' ,'" + a.MailUsuario + "' , '" + a.MercadoOverUnder + "' );";
          
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


        /***  EJERCICIO PARA EXAMEN    ***/


        internal List<ApuestaExamen> RetriveExamen(string equipo)
        {
            List<ApuestaExamen> mercados = new List<ApuestaExamen>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT `apuesta`.`Dinero`, `evento`.`EqLocal`, `evento`.`EqVisitante`, `evento`.`EqVisitante`, `evento`.`EqLocal` FROM `apuesta` , `evento` WHERE `evento`.`EqVisitante` LIKE '"+equipo+ "' OR `evento`.`EqLocal` LIKE '" + equipo + "'";
            ApuestaExamen ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                while (res.Read())
                {
                    if (res.GetString(1) == equipo) {
                        ap = new ApuestaExamen(res.GetDouble(0), res.GetString(2));
                        mercados.Add(ap);
                    }
                    if (res.GetString(2) == equipo)
                    {
                        ap = new ApuestaExamen(res.GetDouble(0), res.GetString(1));
                        mercados.Add(ap);
                    }

                }
                
            }
            catch (Exception e)
            {

                Debug.WriteLine("No hay equipos con ese nombre");
                Console.WriteLine("No hay equipos con ese nombre");
            }

            con.Close();
            return mercados;
        }


        /***  EJERCICIO PARA EXAMEN    ***/


    }

}