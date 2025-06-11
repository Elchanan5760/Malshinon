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
                cmd.Parameters.AddWithValue(@"reporterId", intelReportRow.reporterId);
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

        public List<IntelReportRow> GetAllReports()
        {
            List<IntelReportRow> intelReportRows = new List<IntelReportRow>();
            try
            {

                var connect = conn.GetConnect();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM intelreports;", connect);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    IntelReportRow intelReportRow = new IntelReportRow();
                    intelReportRow.ConstractorReport(reader.GetInt32("reporter_id"), reader.GetInt32("target_id"), reader.GetString("text"));
                    intelReportRow.ConstractorDefultValues(reader.GetInt32("id"), reader.GetDateTime("timestamp"));
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
        
    }
}

