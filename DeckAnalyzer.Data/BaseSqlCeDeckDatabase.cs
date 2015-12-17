using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DeckAnalyzer.Data
{
    public abstract class BaseSqlCeDeckDatabase
    {
        public string ConnectionString { get; set; }

        protected string GetFileNameFromConnectionString()
        {
            var regex = new Regex(@"DataSource=""(?<filename>[^/*?\""<>|]+)""");

            Match match = regex.Match(ConnectionString);

            if (match.Success)
            {
                return match.Groups["filename"].Value;
            }

            throw new InvalidOperationException("Could not get database filename from connection string. Please verify the connection string and retry.");
        }

        protected int GetDeckIndex(SqlCeConnection conn)
        {
            const string cmdText = "select DeckNum from DeckIndex order by DeckNum desc";
            var cmd = new SqlCeCommand(cmdText, conn);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return int.Parse(reader["DeckNum"].ToString());
            }

            throw new DataException("Could not read DeckNum from database.");
        }

        protected void InitializeDatabase(SqlCeConnection conn)
        {
            const string cmdText = "create table DeckIndex (DeckNum int)";
            var cmd = new SqlCeCommand(cmdText, conn);
            cmd.ExecuteNonQuery();
            WriteNewDeckIndex(conn, 0);
        }

        protected void WriteNewDeckIndex(SqlCeConnection conn, int deckIndex)
        {
            var cmdText = string.Format("insert into DeckIndex (DeckNum) values ({0})", deckIndex);
            var cmd = new SqlCeCommand(cmdText, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
