using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DeckAnalyzer.Common;

namespace DeckAnalyzer.Mtg
{
    public class TcDecksScraper : DeckScraperBase
    {
        public override void GetDecks(string url, string outputLocation)
        {
            var response = GetResponse(url);

            if (String.IsNullOrWhiteSpace(response))
                return;

            var urlPattern = new Regex(@"id=\d+&iddeck=\d+");
            var matches = urlPattern.Matches(response);
            var deckUrls = (from Match match in matches select string.Format("http://tcdecks.net/download.php?ext=txt&{0}", match.Value)).ToList();

            var deckNum = -1;

            foreach (var deckUrl in deckUrls.Distinct())
            {
                var deck = GetDeck(deckUrl);
                string fileName;

                deck = CleanDeck(deck);

                do
                {
                    deckNum++;
                    fileName = string.Format("{0}{1}.txt", outputLocation, deckNum.ToString("000"));
                } while (File.Exists(fileName));

                var parser = new MtgoDeckParser();
                var parsedDeck = parser.ParseDeck(deck);
                if (parsedDeck.IsValid())
                {
                    var writer = new MtgDeckFileWriter();
                    writer.WriteDeck(parsedDeck, fileName);
                }
            }
        }

        public override string GetDeck(string url)
        {
            var deckList = GetResponse(url);
            return deckList;
        }
    }
}
