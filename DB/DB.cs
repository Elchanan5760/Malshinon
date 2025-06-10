using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Malshinon.models;
using MySql.Data.MySqlClient;

namespace Malshinon.DAL
{
    public class DAL
    {
        private PeopleRow _row;
        private string connectionString = "Server=localhost;Database=malshinon;User=root;Password='';Port=3306;";
        public object Connection(string cmdSql)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(cmdSql);
                var reader = cmd.ExecuteReader();
                conn.Close();
                return reader;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error connecting to MySql dadabase: {ex.Message}");
                return null;
            }
        }
    }
}
