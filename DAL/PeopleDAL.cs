using Google.Protobuf.WellKnownTypes;
using Malshinon.DB;
using Malshinon.models;
using MySql.Data.MySqlClient;
using Mysqlx.Resultset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.Dal
{
    public class PeopleDAL
    {
        DBConnction conn = new DBConnction();
        public void AddRowPeople(PeopleRow peopleRow)
        {
            try
            {
                //conn.GetConnect();
                //Console.WriteLine(peopleRow.FirstName, peopleRow.LastName, peopleRow.SecretCode, peopleRow.Type);
                MySqlCommand cmd = new MySqlCommand("INSERT INTO people (first_name,last_name,secret_code,type) VALUES (@FirstName,@LastName,@SecretCode,@Type)", conn.GetConnect());
                cmd.Parameters.AddWithValue(@"FirstName", peopleRow.FirstName);
                cmd.Parameters.AddWithValue(@"LastName", peopleRow.LastName);
                cmd.Parameters.AddWithValue(@"SecretCode", peopleRow.SecretCode);
                cmd.Parameters.AddWithValue(@"Type", peopleRow.Type);
                cmd.ExecuteReader();
                conn.CloseConnect();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error connecting to MySql dadabase: {ex}");
            }
        }

        public List<PeopleRow> GetAllPeople()
        {
            List<PeopleRow> peopleRows = new List<PeopleRow>();
            try
            {
                
                var connect = conn.GetConnect();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM people;");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PeopleRow peopleRow = new PeopleRow();
                    peopleRow.Id = reader.GetInt32("id");
                    peopleRow.FirstName = reader.GetString("first_name");
                    peopleRow.LastName = reader.GetString("last_name");
                    peopleRow.SecretCode = reader.GetString("secret_code");
                    peopleRow.Type = reader.GetString("type");
                    peopleRow.NumReports = reader.GetInt32("num_reports");
                    peopleRow.NumMentions = reader.GetInt32("num_mentions");
                    peopleRows.Add(peopleRow);
                }
                conn.CloseConnect();
            }
            
            catch (Exception ex)
            {

                Console.WriteLine($"Error connecting to MySql dadabase: {ex}");
            }
            return peopleRows;
        }
        public PeopleRow FindPeopleBySecretCode(string secretCode)
        {
            PeopleRow peopleRow = new PeopleRow();
            try
            {
                var connect = conn.GetConnect();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM people WHERE id = @secret_code;", connect);
                cmd.Parameters.AddWithValue(@"id", secretCode);
                var reader = cmd.ExecuteReader();
                
                peopleRow.Id = reader.GetInt32("id");
                peopleRow.FirstName = reader.GetString("first_name");
                peopleRow.LastName = reader.GetString("last_name");
                peopleRow.SecretCode = reader.GetString("secret_code");
                peopleRow.Type = reader.GetString("type");
                peopleRow.NumReports = reader.GetInt32("num_reporters");
                peopleRow.NumMentions = reader.GetInt32("num_mentions");
                conn.CloseConnect();
                
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error connecting to MySql dadabase: {ex}");
            }
            return peopleRow;
        }
        public void UpdatePeopleValueInt(int id,string column,int value)
        {
            try
            {
                DBConnction conn = new DBConnction();
                conn.GetConnect();
                MySqlCommand cmd = new MySqlCommand($"ALTER TABLE people SET @{column} = @value WHERE id = @id", conn.GetConnect());
                cmd.Parameters.AddWithValue(@"id", id);
                cmd.Parameters.AddWithValue(@"value", value);
                var reader = cmd.ExecuteReader();
                conn.CloseConnect();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error connecting to MySql dadabase: {ex}");
            }
        }
        public void UpdatePeopleValueString(int id, string column, string value)
        {
            try
            {
                
                
                MySqlCommand cmd = new MySqlCommand($"UPDATE people SET people.{column} = @value WHERE id = {id};", conn.GetConnect());
                cmd.Parameters.AddWithValue(@"id", id);
                cmd.Parameters.AddWithValue(@"value",value);
                var reader = cmd.ExecuteReader();
                conn.CloseConnect();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error connecting to MySql dadabase: {ex}");
            }
        }
        public void DeletePeopleRow(int id)
        {
            try
            {


                MySqlCommand cmd = new MySqlCommand($"DELETE FROM people WHERE id = {id};", conn.GetConnect());
                
                var reader = cmd.ExecuteReader();
                conn.CloseConnect();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error connecting to MySql dadabase: {ex}");
            }
        }
    }
}
