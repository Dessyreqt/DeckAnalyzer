using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckAnalyzer.Data
{
    public interface IDeckFileWriter
    {
        void WriteDeck(string deck, string outputLocation);
    }
}
