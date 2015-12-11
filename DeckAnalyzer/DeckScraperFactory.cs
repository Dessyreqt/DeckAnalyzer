using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckAnalyzer.Mtg;
using DeckAnalyzer.Data;

namespace DeckAnalyzer
{
    public class DeckScraperFactory
    {
        public static IDeckScraper GetDeckScraper(string url)
        {
            if (url.Contains("mtgdecks.net"))
            {
                return new MtgDecksNetScraper();
            }
            if (url.Contains("tcdecks.net"))
            {
                return new TcDecksScraper();
            }

            throw new ArgumentException(string.Format("Could not generate scraper for url: {0}", url), "url");
        }
    }
}
