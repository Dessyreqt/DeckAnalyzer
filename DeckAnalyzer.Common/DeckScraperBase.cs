using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace DeckAnalyzer.Common
{
    public abstract class DeckScraperBase : IDeckScraper
    {
        public abstract void GetDecks(string url, string outputLocation);
        public abstract string GetDeck(string url);

        public static string GetResponse(string address)
        {
            var httpRequest = WebRequest.Create(address);
            var response = httpRequest.GetResponse();
            var responseStream = response.GetResponseStream();

            if (responseStream == null)
            {
                throw new Exception("Could not generate response stream.");
            }

            var reader = new StreamReader(responseStream);
            return reader.ReadToEnd();
        }

        public static string CleanDeck(string deck)
        {
            deck = Regex.Replace(deck, @"\s+(\d+) ", "$1 ");
            deck = Regex.Replace(deck, @"(\w+)(\d+) ", "$1\r\n$2 ");
            return deck;
        }
    }
}
