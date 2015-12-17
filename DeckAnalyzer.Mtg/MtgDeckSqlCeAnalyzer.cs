using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DeckAnalyzer.Data;

namespace DeckAnalyzer.Mtg
{
    public class MtgDeckSqlCeAnalyzer : BaseSqlCeDeckDatabase, IDeckAnalyzer
    {
        public string SeedDeck { get; set; }

        public void AnalyzeDecks(int order)
        {
            if (ConnectionString == null)
            {
                throw new InvalidOperationException("The ConnectionString property must be set before calling WriteDeck.");
            }

            var filename = GetFileNameFromConnectionString();
            var deckIndex = -1;

            if (!File.Exists(filename))
            {
                throw new InvalidOperationException("The Database must be created.");
            }
            using (var conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

            }
        }

    }
}
