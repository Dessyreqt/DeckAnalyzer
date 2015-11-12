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
        public List<string> DeckContents { get; set; }
        public List<string> Errors { get; set; }
        public List<string> SideboardContents { get; set; }
        

        public bool IsValid()
        {
            Errors.Clear();

            if (DeckContents.Count < 60)
            {
                Errors.Add("Deck must have at least 60 cards.");
            }

            return Errors.Count == 0;
        }

        public void AddCard(string card)
        {
            throw new NotImplementedException();
        }

        public void RemoveCard(string card)
        {
            throw new NotImplementedException();
        }
    }
}
