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
            string database = "database=mydb;";
            string usuario = "uid=root;";
            string password = "pwd=;";

            string connString = server + port + database + usuario + password;
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Usuario> Retrive()
        {
            List<Usuario> Usuarios = new List<Usuario>();
            MySqlConnection con = Connect();
            MySqlCommand comand = con.CreateCommand();
            comand.CommandText = "SELECT * FROM `usuario`";
            Usuario user = null;
            try
            {
                con.Open();
                MySqlDataReader res = comand.ExecuteReader();

                
                if (res.Read())
                {
                    user = new Usuario(res.GetString(0), res.GetString(1), res.GetString(2), res.GetInt32(3), res.GetInt32(4));
                    Usuarios.Add(user);

                }
            }
            catch(Exception e)
            {
                user = new Usuario("1", "1", "1", 1, 1);
                Usuarios.Add(user);
            }
            con.Close();
            return Usuarios;
        }




        internal void RetrieveBetsByEmail(string idEmail, double tipoMercado)
        {

            string query = "SELECT * FROM apuestas " +
                "INNER JOIN mercados ON apuestas.refMercado = mercados.idMercado " +
                "INNER JOIN eventos ON eventos.idEvento = mercados.refEvento " +
                "WHERE `Email` = @Email AND `OVER/UNDER` = @OVER/UNDER;";

            MySqlCommand command = new MySqlCommand(query);
            command.Parameters.AddWithValue("@Email", idEmail);
            command.Parameters.AddWithValue("@OVER/UNDER", tipoMercado);

        
        }




    }
}