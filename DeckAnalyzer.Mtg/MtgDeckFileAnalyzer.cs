using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using DeckAnalyzer.Data;

namespace DeckAnalyzer.Mtg
{
    public class MtgDeckFileAnalyzer : IDeckAnalyzer
    {
        public string InputFolder { get; set; }
        public string OutputFile { get; set; }
        public string SeedDeck { get; set; }
        private string OutputFolder { get { return string.Format("{0}\\output", InputFolder); } }

        public void AnalyzeDecks(int order)
        {
            if (string.IsNullOrWhiteSpace(InputFolder))
            {
                throw new InvalidOperationException("InputFolder needs to be defined before analyzing decks.");
            }
            if (string.IsNullOrWhiteSpace(OutputFile))
            {
                throw new InvalidOperationException("OutputFile needs to be defined before analyzing decks.");
            }

            DeleteTempFile();

            if (!Directory.Exists(OutputFolder))
            {
                Directory.CreateDirectory(OutputFolder);
            }

            var args = new StringBuilder();

            args.Append("-v");
            args.AppendFormat(" -r {0}", order);
            args.AppendFormat(" -o output\\{0}.txt", OutputFile);

            if (!string.IsNullOrWhiteSpace(SeedDeck))
            {
                using (var writer = new StreamWriter(string.Format("{0}_.tmp", InputFolder)))
                {
                    writer.Write(SeedDeck);
                }

                args.Append(" -i _.tmp");
            }

            foreach (var filename in Directory.EnumerateFiles(InputFolder, "*.txt", SearchOption.TopDirectoryOnly))
            {
                args.AppendFormat(" {0}", filename.Substring(filename.LastIndexOf('\\') + 1));
            }


            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "mtg-builder",
                    Arguments = args.ToString(),
                    //UseShellExecute = false,
                    //RedirectStandardOutput = true,
                    //CreateNoWindow = true,
                    WorkingDirectory = InputFolder,
                }
            };

            proc.Start();

            //while (!proc.StandardOutput.EndOfStream)
            //{
            //    string line = proc.StandardOutput.ReadLine();
            //    outputDeckText.Text += line;
            //    Application.DoEvents();
            //}

            DeleteTempFile();
        }

        private void DeleteTempFile()
        {
            var filename = string.Format("{0}_.txt", InputFolder);

            File.Delete(filename);
        }
    }
}
