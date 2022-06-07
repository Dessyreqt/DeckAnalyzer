namespace DeckAnalyzer.Mtg
{
    using System;
    using System.Linq;
    using Common;

    public class MwsDeckParser : IDeckParser
    {
        public IDeck ParseDeck(string deck)
        {
            var retVal = new MtgDeck();

            var deckLines = deck.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var sideboard = false;

            foreach (var line in deckLines)
            {
                if (line.ToLower().Contains("sideboard"))
                {
                    sideboard = true;
                    continue;
                }
                if (line.StartsWith("//"))
                {
                    continue;
                }
                if (!line.Contains(' '))
                {
                    continue;
                }

                var countString = line.Split(' ')[0];
                if (!int.TryParse(countString, out var countNum))
                {
                    continue;
                }

                var cardName = line.Substring(line.IndexOf(' ')).Trim();
                for (int i = 0; i < countNum; i++)
                {
                    if (sideboard)
                    {
                        retVal.AddSideboardCard(cardName);
                    }
                    else
                    {
                        retVal.AddCard(cardName);
                    }
                }
            }

            return retVal;
        }
    }
}