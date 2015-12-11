using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckAnalyzer.Data;

namespace DeckAnalyzer.Mtg
{
    public class MtgDeckSqlCeAnalyzer : IDeckAnalyzer
    {
        public string SeedDeck { get; set; }
        public string ConnectionString { get; set; }

        public void AnalyzeDecks(int order)
        {
            throw new NotImplementedException();
        }
    }
}
