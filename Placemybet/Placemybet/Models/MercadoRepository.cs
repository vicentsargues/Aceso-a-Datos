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
            string database = "database=mybd;";
            string usuario = "uid=root;";
            string password = "pwd=;";

            string connString = server + port + database + usuario + password;
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal Mercado Retrive()
        {
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "select * from mercado";
            con.Open();
            MySqlDataReader res = comand.ExecuteReader();
            Mercado ap = null;
            if (res.Read())
            {
                ap = new Mercado(res.GetString(0), res.GetDouble(1),  res.GetString(2));

            }
            con.Close();
            return ap;
        }

        internal List<MercadoDTO> GetMercadosDTO()
        {
            List<MercadoDTO> mercados = new List<MercadoDTO>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from mercados";
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string over_under = reader.GetString(2);
                    float over_cuota = reader.GetFloat(3);
                    float under_cuota = reader.GetFloat(4);
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



        internal Mercado RetriveT(string id)
        {
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "select * from mercado WHERE `OVER/UNDER` = @id;";
            comand.Parameters.AddWithValue("@id", id);
            con.Open();
            MySqlDataReader res = comand.ExecuteReader();
            Mercado ap = null;
            if (res.Read())
            {
                ap = new Mercado(res.GetInt32(0),res.GetString(1), res.GetDouble(2), res.GetString(3));

            }
            con.Close();
            return ap;
        }

        internal Mercado Retrive2(int ID)
        {
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "select * from mercado WHERE `idMercado` = @id;";
            comand.Parameters.AddWithValue("@id", ID);
            con.Open();
            MySqlDataReader res = comand.ExecuteReader();
            Mercado ap = null;
            if (res.Read())
            {
                ap = new Mercado(res.GetInt32(0),res.GetString(0), res.GetDouble(1), res.GetString(2));

            }
            con.Close();
            return ap;
        }




    }
}