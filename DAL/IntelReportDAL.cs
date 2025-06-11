using Malshinon.DB;
using Malshinon.models;
using Malshinon.models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon.DAL
{
    public class IntelReportDAL
    {
        DBConnction conn = new DBConnction();
        
        public void AddRowReports(IntelReportRow intelReportRow)
        {
            try
            {
                Console.WriteLine($"{intelReportRow.reporterId} {intelReportRow.targetId} {intelReportRow.text}");
                MySqlCommand cmd = new MySqlCommand("INSERT INTO intelreports (reporter_id,target_id,text) VALUES (@reporterId,@targetId,@text);", conn.GetConnect());
                cmd.Parameters.AddWithValue(@"reporterId",intelReportRow.reporterId );
                cmd.Parameters.AddWithValue(@"targetId", intelReportRow.targetId);
                cmd.Parameters.AddWithValue(@"text", intelReportRow.text);
                cmd.ExecuteReader();
                conn.CloseConnect();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error connecting to MySql dadabase: {ex}");
            }
        }

        public List<IntelReportRow> GetAllPeople()
        {
            List<IntelReportRow> intelReportRows = new List<IntelReportRow>();
            try
            {

                var connect = conn.GetConnect();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM intelreports;");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IntelReportRow intelReportRow = new IntelReportRow();
                    intelReportRow.ConstractorReport(reader.GetInt32("reporter_id"), reader.GetInt32("target_id"),reader.GetString("text"));
                    //intelReportRow.(reader.GetInt32("id"),reader.GetString("timestamp"));
                    intelReportRows.Add(intelReportRow);
                }
                conn.CloseConnect();
            }

            catch (Exception ex)
            {

                Console.WriteLine($"Error connecting to MySql dadabase: {ex}");
            }
            return intelReportRows;
        }
        //public IntelReportRow FindPeopleBySecretCode(string id)
        //{
        //    PeopleRow peopleRow = new PeopleRow();
        //    try
        //    {
        //        var connect = conn.GetConnect();
        //        MySqlCommand cmd = new MySqlCommand("SELECT * FROM people WHERE secret_code = @secret_code;", connect);
        //        cmd.Parameters.AddWithValue(@"secret_code", secretCode);
        //        var reader = cmd.ExecuteReader();
        //        conn.CloseConnect();
        //        if (reader.Read() != null)
        //        {
        //            peopleRow.ConstractorPerson(reader.GetString("first_name"), reader.GetString("last_name"), reader.GetString("secret_code"), reader.GetString("type"));
        //            peopleRow.ConstractorDefultValuesPerson(reader.GetInt32("id"), reader.GetInt32("num_reports"), reader.GetInt32("num_mentions"));

        //            return peopleRow;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine($"Error connecting to MySql dadabase: {ex.Message}");
        //    }
        //    return null;
        //}
        public void UpdatePeopleValueInt(int id, string column, int value)
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
                cmd.Parameters.AddWithValue(@"value", value);
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

