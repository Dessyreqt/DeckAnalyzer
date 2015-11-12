using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using DeckAnalyzer.Common;

namespace DeckAnalyzer.Mtg
{
    public class MtgDecksNetScraper : DeckScraperBase
    {
        public override void GetDecks(string url, string outputLocation)
        {
            var response = GetResponse(url);

            if (String.IsNullOrWhiteSpace(response))
                return;

            var urlPattern = new Regex(@"/decks/view/\d+");
            var matches = urlPattern.Matches(response);
            var deckUrls = (from Match match in matches select string.Format("http://mtgdecks.net{0}/txt", match.Value)).ToList();

            var deckNum = -1;

            foreach (var deckUrl in deckUrls.Distinct<string>())
            {
                var deck = GetDeck(deckUrl);
                string fileName;

                do
                {
                    deckNum++;
                    fileName = string.Format("{0}{1}.txt", outputLocation, deckNum.ToString("000"));
                } while (File.Exists(fileName));

                var writer = new MtgDeckFileWriter();
                writer.WriteDeck(deck, fileName);
            }
        }

        public override string GetDeck(string url)
        {
            var deckList = GetResponse(url);
            return deckList;
        }
    }
}
