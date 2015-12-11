using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckAnalyzer.Data;
using DeckAnalyzer.Mtg;

namespace DeckAnalyzer
{
    public class DeckAnalyzerFactory
    {
        public static IDeckAnalyzer GetDeckAnalyzer(DeckWriterOutputType outputType, string foldername, string filename, string seedDeck)
        {
            IDeckAnalyzer retVal;

            switch (outputType)
            {
                case DeckWriterOutputType.TextFile:
                    retVal = new MtgDeckFileAnalyzer
                                 {
                                     InputFolder = foldername,
                                     OutputFile = filename,
                                     SeedDeck = seedDeck
                                 };
                    return retVal;
                case DeckWriterOutputType.Database:
                    retVal = new MtgDeckSqlCeAnalyzer
                                 {
                                     ConnectionString = string.Format("DataSource=\"{0}{1}.sdf\";", foldername, filename),
                                     SeedDeck = seedDeck
                                 };
                    return retVal;
            }

            throw new ArgumentException("Output type is not valid", "outputType");
        }
    }
}
