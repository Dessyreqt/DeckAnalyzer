using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DeckAnalyzer.Common;
using DeckAnalyzer.Data;

namespace DeckAnalyzer.Mtg
{
    public class MtgDeckSqlCeWriter : IDeckWriter
    {
        public string ConnectionString { get; set; }

        public void WriteDeck(IDeck deck)
        {
            if (ConnectionString == null)
            {
                throw new InvalidOperationException("The ConnectionString property must be set before calling WriteDeck.");
            }

            var filename = GetFileNameFromConnectionString();

            if (!File.Exists(filename))
            {
                SqlCeEngine en = new SqlCeEngine(ConnectionString);
                en.CreateDatabase();
            }
        }

        private string GetFileNameFromConnectionString()
        {
            Regex regex = new Regex(@"DataSource=""(?<filename>[^\\/:*?\""<>|]+)""");

            Match match = regex.Match(ConnectionString);

            if (match.Success)
            {
                return match.Groups["filename"].Value;
            }

            throw new InvalidOperationException("Could not get database filename from connection string. Please verify the connection string and retry.");
        }
    }
}
