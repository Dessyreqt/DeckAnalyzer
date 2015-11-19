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
            DeckContents = new List<string>();
            Errors = new List<string>();
            SideboardContents = new List<string>();
        }

        public bool IsValid()
        {
            Errors.Clear();

            if (DeckContents.Count < MtgDeckRules.MinDeckSize)
            {
                Errors.Add(string.Format("Deck must have at least {0} cards.", MtgDeckRules.MinDeckSize));
            }

            if (SideboardContents.Count > MtgDeckRules.MaxSideboardSize)
            {
                Errors.Add(string.Format("Sideboard must have at most {0} cards.", MtgDeckRules.MaxSideboardSize));
            }

            foreach (var card in DeckContents)
            {
                if (MtgDeckRules.IgnoreMaxCards.Contains(card))
                {
                    continue;
                }

                if (DeckContents.Count(x => x == card) + SideboardContents.Count(x => x == card) > MtgDeckRules.MaxPerCard)
                {
                    Errors.Add(string.Format("Deck and sideboard cannot contain more than {0} cards named \"{1}\"", MtgDeckRules.MaxPerCard, card));
                }
            }

            foreach (var card in SideboardContents)
            {
                if (MtgDeckRules.IgnoreMaxCards.Contains(card))
                {
                    continue;
                }

                if (DeckContents.Count(x => x == card) + SideboardContents.Count(x => x == card) > MtgDeckRules.MaxPerCard)
                {
                    Errors.Add(string.Format("Deck and sideboard cannot contain more than {0} cards named \"{1}\"", MtgDeckRules.MaxPerCard, card));
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
            DeckContents.Sort();
            SideboardContents.Sort();

            var retVal = new List<string>();

            for (int i = 0; i < DeckContents.Count; i++)
            {
                var card = DeckContents[i];
                retVal.Add(string.Format("{0} #{1}", card, DeckContents.GetRange(0, i).Count(x => x == card) + 1));
            }

            for (int i = 0; i < SideboardContents.Count; i++)
            {
                var card = SideboardContents[i];
                retVal.Add(string.Format("SB: {0} #{1}", card, SideboardContents.GetRange(0, i).Count(x => x == card) + 1));
            }

            return retVal;
        }

        public string GetFormattedList()
        {
            DeckContents.Sort();
            SideboardContents.Sort();

            var retVal = new StringBuilder();

            WriteContents(retVal, DeckContents);
            retVal.AppendLine();
            retVal.AppendLine("Sideboard");
            WriteContents(retVal, SideboardContents);

            return retVal.ToString();
        }

        private void WriteContents(StringBuilder retVal, List<string> contents)
        {
            var count = 1;

            for (int i = 0; i < contents.Count(); i++)
            {
                if (i + 1 < contents.Count)
                {
                    if (contents[i] == contents[i + 1])
                    {
                        count++;
                    }
                    else
                    {
                        retVal.AppendLine(string.Format("{0} {1}", count, contents[i]));
                        count = 1;
                    }
                }
                else
                {
                    retVal.AppendLine(string.Format("{0} {1}", count, contents[i]));
                }
            }
        }
    }
}
