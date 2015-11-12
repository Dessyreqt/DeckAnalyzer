using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckAnalyzer.Mtg
{
    public class MtgDeckRules
    {
        public const int MaxPerCard = 4;
        public const int MinDeckSize = 60;
        public const int MaxSideboardSize = 15;
        public const List<string> IgnoreMaxCards = new List<string> 
        {
            "Plains",
            "Island",
        };

    }
}
