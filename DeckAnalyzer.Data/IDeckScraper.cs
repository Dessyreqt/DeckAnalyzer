using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckAnalyzer.Data
{
    public interface IDeckScraper
    {
        void GetDecks(string url, IDeckWriter writer);
        string GetDeck(string url);
    }                             
}
