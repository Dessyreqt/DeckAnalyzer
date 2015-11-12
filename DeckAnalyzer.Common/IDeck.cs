using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DeckAnalyzer.Common
{
    public interface IDeck
    {
        bool IsValid();
        void AddCard(string card);
        List<string> GetContents();
    }
}
