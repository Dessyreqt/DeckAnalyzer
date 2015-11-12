﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckAnalyzer.Mtg;

namespace DeckAnalyzer.Common
{
    public class DeckScraperFactory
    {
        public static IDeckScraper GetDeckScraper(string url)
        {
            if (url.Contains("mtgdecks.net"))
                return new MtgDecksNetScraper();
            else
                throw new ArgumentException(string.Format("Could not generate scraper for url: {0}", url));
        }
    }
}