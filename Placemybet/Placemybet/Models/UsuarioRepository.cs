using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Placemybet.Models
{
    public class UsuarioRepository
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
        internal Usuario Retrive()
        {
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "select * from usuario";
            con.Open();
            MySqlDataReader res = comand.ExecuteReader();
            Usuario user = null;
            if (res.Read()) {
                user = new Usuario(res.GetString(0), res.GetString(1), res.GetString(2), res.GetInt32(3), res.GetInt32(4));
            
        }
            con.Close();
            return user;
        }




    }
}