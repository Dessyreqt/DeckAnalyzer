using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DeckAnalyzer.Common
{
    public interface IDeck
    {
        List<string> DeckContents { get; set; }
        List<string> Errors { get; set; } 

        bool IsValid();
        void AddCard(string card);
        void RemoveCard(string card);
    }
}
