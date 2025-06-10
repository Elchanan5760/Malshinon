using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.models;
using MySql.Data.MySqlClient;

namespace Malshinon.DB
{
    public class DBConnction
    {
        private MySqlConnection connection;

        private string connectionString = "Server=localhost;Database=malshinon;User=root;Password='';Port=3306;";
        public void Connect()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            connection = conn;
            try
            {
                conn.Open();
                Console.WriteLine("Connected succesfuly");
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error connecting to MySql dadabase: {ex.Message}");
            }
        }
        public MySqlConnection GetConnect()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            connection = conn;
            try
            {
                conn.Open();

                return conn;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error connecting to MySql dadabase: {ex.Message}");
                return null;
            }
        }

        public void CloseConnect()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            connection = conn;
            try
            {
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error connecting to MySql dadabase: {ex.Message}");
            }
        }
    }
}
