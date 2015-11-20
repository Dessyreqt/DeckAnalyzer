using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using DeckAnalyzer.Common;
using DeckAnalyzer.Data;

namespace DeckAnalyzer.Mtg
{
    public class MtgDeckSqlCeWriter : IDeckDatabaseWriter
    {
        public string ConnectionString { get; set; }

        public void WriteDeck(IDeck deck)
        {
            if (ConnectionString == null)
            {
                throw new InvalidOperationException("The ConnectionString property must be set before calling WriteDeck.");
            }

            
        }
    }
}
