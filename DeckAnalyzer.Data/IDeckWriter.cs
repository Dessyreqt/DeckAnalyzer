using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckAnalyzer.Common;

namespace DeckAnalyzer.Data
{
    public interface IDeckWriter
    {
        void WriteDeck(IDeck deck);
    }
}
