using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DeckAnalyzer.Common;
using DeckAnalyzer.Data;

namespace DeckAnalyzer.Mtg
{
    public class MtgDeckFileWriter : IDeckWriter
    {
        public string OutputFolder { get; set; }

        public void WriteDeck(IDeck deck)
        {
            var deckNum = -1;
            string fileName;

            do
            {
                deckNum++;
                fileName = string.Format("{0}{1}.txt", OutputFolder, deckNum.ToString("000"));
            } while (File.Exists(fileName));

            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(deck.GetFormattedList());
            }
        }
    }
}
