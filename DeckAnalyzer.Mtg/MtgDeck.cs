using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using DeckAnalyzer.Common;

namespace DeckAnalyzer.Mtg
{
    public class MtgDeck : IDeck
    {
        private List<string> DeckContents { get; set; }
        private List<string> Errors { get; set; }
        private List<string> SideboardContents { get; set; }

        public MtgDeck()
        {
            MaindeckContents = new List<string>();
            Errors = new List<string>();
            SideboardContents = new List<string>();
        }

        public bool IsValid()
        {
            Errors.Clear();

            if (DeckContents.Count < 60)
            {
                Errors.Add("Deck must have at least 60 cards.");
            }

            if (SideboardContents.Count > 15)
            {
                Errors.Add("Sideboard must have at most 15 cards.");
            }

            foreach (var card in DeckContents)
            {
                if (DeckContents.Count((x) => x == card) + SideboardContents.Count((x) => x == card) > 4)
                {
                    Errors.Add(string.Format("Deck and sideboard cannot contain more than 4 cards named \"{0}\"", card));
                }
            }

            return Errors.Count == 0;
        }

        public void AddCard(string card)
        {
            DeckContents.Add(card);
        }

        public void AddSideboardCard(string card)
        {
            SideboardContents.Add(card);
        }

        public List<string> GetContents()
        {
            var retVal = new List<string>();
        }
    }
}
