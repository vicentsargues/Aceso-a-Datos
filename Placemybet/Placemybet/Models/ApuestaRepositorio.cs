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
                    string tipo_apuesta2 = reader.GetString(7);
                    apuestas.Add(new ApuestaDTO(user, tipo_apuesta, cuota, apuesta, fecha, tipo_apuesta2));
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



        internal void Save2(Apuesta a)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado where idMercado=" + a.IdApuesta + ";";
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                res.Read();
                Mercado m = new Mercado(res.GetInt32(0),res.GetString(1), res.GetDouble(2), res.GetString(3));




                double total;
                double probability;
                if (a.TipoApuesta == 1)
                    probability = m.Cuota / (m.Cuota + m.Cuota);
                else
                    probability = m.Cuota / (m.Cuota + m.Cuota);

                total = 1 / probability * 0.95;


               
                res.Close();
                con.Close();
                command.CommandText = "update mercado set cuota=" + Math.Round(total, 2) +  ", Dinero=" + m.Dinero + ";";
                try
                {
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                    double cuotaApuesta = 0;
             
                
                        cuotaApuesta = total;
                    
                    command.CommandText = "insert into apuesta(tipoMercado, cuota, dinero, fecha, idMercado, gmail, tipoCuota) values (" + a.MercadoOverUnder + ", " + Math.Round(cuotaApuesta, 2) + ", " + a.Dinero + ", '" + DateTime.Now.ToString("yyyy-MM-dd") + "', " + a.IdApuesta + ", '" + a.IdApuesta + "', '" + a.TipoApuesta + "');";
                    try
                    {
                        con.Open();
                        command.ExecuteNonQuery();
                        con.Close();
                    }
                    catch (MySqlException e)
                    {
                        Debug.WriteLine("Se ha producido un error de conexion");
                    }
                }
                catch (MySqlException e)
                {
                    Debug.WriteLine("Se ha producido un error de conexion");
                }

            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
            }


        }


        private double CalculateQuota(ApuestaDTO bet, MercadoDTO market)
        {
            double probability;

            if (bet.over_under == "Over")
                probability = market.Cuota_over / (market.Cuota_over + market.Cuota_under);
            else
                probability = market.Cuota_under / (market.Cuota_over + market.Cuota_under);

            return 1 / probability * 0.95;
        }








    }

}