using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckAnalyzer.Mtg
{
    public class MtgDeckRules
    {
        public static int MaxPerCard = 4;
        public static int MinDeckSize = 60;
        public static int MaxSideboardSize = 15;
        public static List<string> IgnoreMaxCards = new List<string> 
        {
            "Plains",
            "Island",
            "Swamp",
            "Mountain",
            "Forest",
            "Snow-Covered Plains",
            "Snow-Covered Island",
            "Snow-Covered Swamp",
            "Snow-Covered Mountain",
            "Snow-Covered Forest",
            "Relentless Rats",
            "Shadowborn Apostle",
        };

    }
}
