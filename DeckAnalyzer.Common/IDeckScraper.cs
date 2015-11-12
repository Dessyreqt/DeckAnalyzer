using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckAnalyzer.Common
{
    public interface IDeckScraper
    {
        void GetDecks(string url, string outputLocation);
        string GetDeck(string url);
    }
}
