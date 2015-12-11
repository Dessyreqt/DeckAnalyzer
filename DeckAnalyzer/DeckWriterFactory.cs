using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeckAnalyzer.Data;
using DeckAnalyzer.Mtg;

namespace DeckAnalyzer
{
    public class DeckWriterFactory
    {
        private static readonly Func<string, IDeckWriter>[][] outputObjects = new[] 
        { 
            new [] // Output Type: File
            {
                new Func<string, IDeckWriter>(output => 
                {
                    var retVal = new MtgDeckFileWriter { OutputFolder = output };
                    return retVal; 
                })
            },
            new [] // Output Type: Database
            {
                new Func<string, IDeckWriter>(output => 
                { 
                    var retVal = new MtgDeckSqlCeWriter { ConnectionString = string.Format("DataSource=\"{0}\";", output) };
                    return retVal; 
                })
            }
        };

        public static IDeckWriter GetDeckWriter(DeckWriterOutputType outputType, DeckWriterGameType gameType, string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                throw new ArgumentException("Location cannot be blank.", "location");
            }

            return outputObjects[(int)outputType][(int)gameType](location);
        }
    }
}
