using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Placemybet.Models
{
    public class MercadoRepository
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
        internal List<Mercado> Retrive()
        {
            List<Mercado> mercados = new List<Mercado>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `mercado`";


            Mercado ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();



                if (res.Read())
                {
                    ap = new Mercado(res.GetInt32(0), res.GetString(5), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {
                ap = new Mercado(1, "1", 1, 1,1,1);
                mercados.Add(ap);

            }
            con.Close();
            return mercados;
        }

        internal List<MercadoDTO> GetMercadosDTO()
        {
            List<MercadoDTO> mercados = new List<MercadoDTO>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from `mercado`";
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string over_under = reader.GetString(0);
                    double over_cuota = reader.GetDouble(1);
                    double under_cuota = reader.GetDouble(3);
                    mercados.Add(new MercadoDTO(over_under, over_cuota, under_cuota));
                }
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return mercados;
        }
        
        internal List<Mercado> RetriveOver(int id)
        {
            List<Mercado> mercados = new List<Mercado>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT `mercado`.*, `evento`.`idEVENTO` FROM `mercado` LEFT JOIN `evento` ON `evento`.`MERCADO_OVER/UNDER` = `mercado`.`id` WHERE `mercado`.`over/under` LIKE 'over' AND `evento`.`idEVENTO` LIKE '"+id+"'";


            Mercado ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();



                if (res.Read())
                {
                    ap = new Mercado(res.GetInt32(0), res.GetString(5), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {
                ap = new Mercado(1, "1", 1, 1,1,1);
                mercados.Add(ap);

            }
            con.Close();
            return mercados;
        }
        internal List<Mercado> RetriveUnder(int id)
        {
            List<Mercado> mercados = new List<Mercado>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT `mercado`.*, `evento`.`idEVENTO` FROM `mercado` LEFT JOIN `evento` ON `evento`.`MERCADO_OVER/UNDER` = `mercado`.`id` WHERE `mercado`.`over/under` LIKE 'under' AND `evento`.`idEVENTO` LIKE '"+12+"'";


            Mercado ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();



                if (res.Read())
                {
                    ap = new Mercado(res.GetInt32(0), res.GetString(5), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4));
                    mercados.Add(ap);
                }

            }
            catch (Exception e)
            {
                ap = new Mercado(1, "1", 1, 1, 1, 1);
                mercados.Add(ap);

            }
            con.Close();
            return mercados;
        }





        internal void calcular(string id)
        {
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "select * from `mercado` WHERE `id` = @id;";
            comand.Parameters.AddWithValue("@id", id);
            Double result1 = 0;
            Double result2 = 0;
            Double result3 = 0;
            Double result4 = 0;
            Double Dinero_under = 0;
            Double Dinero_over = 0;
            try
            {
                con.Open();
                MySqlDataReader reader = comand.ExecuteReader();


                while (reader.Read())
                {

                    Dinero_under = reader.GetDouble(4);

                     Dinero_over = reader.GetDouble(2);

                }
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            Debug.WriteLine(Dinero_under); Debug.WriteLine(Dinero_over);
            result1 = Dinero_over / (Dinero_over + Dinero_under);
            Debug.WriteLine(result1);
            result2 = Dinero_under / (Dinero_under + Dinero_over);
            result3 = (1 / result1) * 0.95;
            result4 = (1 / result2) * 0.95;
            Debug.WriteLine(result2); Debug.WriteLine(result3); Debug.WriteLine(result4);


            comand.CommandText = "UPDATE `mercado` SET `CuotaOver` = '"+result3+ "' , `CuotaUnder` = '"+result4+ "' WHERE `mercado`.`Id` = "+id;
            try
            {
                con.Open();
                comand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Insert Apuesta");
            }

        }




    }
}

