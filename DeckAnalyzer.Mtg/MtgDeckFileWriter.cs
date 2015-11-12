using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DeckAnalyzer.Data;

namespace DeckAnalyzer.Mtg
{
    public class MtgDeckFileWriter : IDeckFileWriter
    {
        public void WriteDeck(string deck, string outputLocation)
        {
            using (var writer = new StreamWriter(outputLocation))
            {
                writer.Write(deck);
            }
        }
    }
}
