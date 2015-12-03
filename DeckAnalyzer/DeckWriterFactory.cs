using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckAnalyzer.Data;
using DeckAnalyzer.Mtg;

namespace DeckAnalyzer
{
    public enum DeckWriterGameType
    {
        Mtg = 0,
    }

    public enum DeckWriterOutputType
    {
        TextFile = 0,
        Database = 1,
    }

    public class DeckWriterFactory
    {
        private static Func<string, IDeckWriter>[][] outputObjects = new[] 
        { 
            new [] // Output Type: File
            {
                new Func<string, IDeckWriter>((output) => 
                {
                    var retVal = new MtgDeckFileWriter();
                    retVal.OutputFolder = output;
                    return retVal; 
                })
            },
            new [] // Output Type: Database
            {
                new Func<string, IDeckWriter>((output) => 
                { 
                    var retVal = new MtgDeckSqlCeWriter();
                    retVal.ConnectionString = string.Format("“DataSource=\"{0}\";", output);
                    return retVal; 
                })
            }
        };

        public static IDeckWriter GetDeckWriter(DeckWriterOutputType outputType, DeckWriterGameType gameType, string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException("Location cannot be blank.");
            }

            return outputObjects[(int)outputType][(int)gameType](location);
        }
    }
}
