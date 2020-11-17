using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class CuentaRepository
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
        internal List<Cuenta> Retrive()
        {
            List<Cuenta> mercados = new List<Cuenta>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `cuenta bancaria`";
            Cuenta ap = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();
               
                if (res.Read())
                {
                    ap = new Cuenta(res.GetInt32(0), res.GetInt32(1), res.GetString(2), res.GetString(3));
                    mercados.Add(ap);

                }
                else
                {
                    ap= new Cuenta(1, 2, "uwu", "uwu4");
                }
                con.Close();

            }
            catch(Exception e)
            {
                ap = new Cuenta(1, 2, "uwu", "uwu3");
            }
           
            return mercados;
        }

    }
}