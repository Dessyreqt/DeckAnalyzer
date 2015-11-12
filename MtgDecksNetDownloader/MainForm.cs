using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Net;
using System.Windows.Forms;
using MtgDecksNetDownloader.Properties;

namespace MtgDecksNetDownloader
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            outputFolderText.Text = Settings.Default.OutputFolder;
            eventAddressText.Text = Settings.Default.EventAddress;
            order.Value = Settings.Default.Order;
            outputFileText.Text = Settings.Default.OutputDeck;
            seedDeckText.Text = Settings.Default.SeedDeck;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var browser = new FolderBrowserDialog();
            browser.SelectedPath = outputFolderText.Text;

            if (browser.ShowDialog() == DialogResult.OK)
            {
                outputFolderText.Text = browser.SelectedPath;
                Settings.Default.OutputFolder = browser.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void getDecksButton_Click(object sender, EventArgs e)
        {
            FixOutputFolder();

            outputText.Text = "";

            Settings.Default.EventAddress = eventAddressText.Text;
            Settings.Default.Save();

            var response = GetResponse(eventAddressText.Text);

            if (string.IsNullOrWhiteSpace(response))
                return;

            var urlPattern = new Regex(@"/decks/view/\d+");
            var matches = urlPattern.Matches(response);
            var deckUrls = new List<string>();

            foreach (Match match in matches)
            {
                var deckUrl = string.Format("http://mtgdecks.net{0}/txt", match.Value);

                deckUrls.Add(deckUrl);
                outputText.Text += string.Format("{0}{1}", deckUrl, Environment.NewLine);
            }

            var deckNum = 0;

            foreach (var deckUrl in deckUrls)
            {
                var deckList = GetResponse(deckUrl);

                while (File.Exists(string.Format("{0}{1}.txt", outputFolderText.Text, deckNum.ToString("000"))))
                {
                    deckNum++;
                }

                using (var writer = new StreamWriter(string.Format("{0}{1}.txt", outputFolderText.Text, deckNum.ToString("000"))))
                {
                    writer.Write(deckList);
                }
            }
        }

        private void FixOutputFolder()
        {
            if (!outputFolderText.Text.EndsWith("\\"))
            {
                outputFolderText.Text += "\\";
                Settings.Default.OutputFolder = outputFolderText.Text;
                Settings.Default.Save();
            }
        }

        private static string GetResponse(string address)
        {
            var httpRequest = WebRequest.Create(address);
            var response = httpRequest.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }

        private void buildDeckButton_Click(object sender, EventArgs e)
        {
            FixOutputFolder();
            DeleteTempFile();

            Settings.Default.Order = (int)order.Value;
            Settings.Default.OutputDeck = outputFileText.Text;
            Settings.Default.SeedDeck = seedDeckText.Text;
            Settings.Default.Save();

            if (!Directory.Exists(string.Format("{0}\\output", outputFolderText.Text)))
            {
                Directory.CreateDirectory(string.Format("{0}\\output", outputFolderText.Text));
            }

            if (string.IsNullOrWhiteSpace(outputFileText.Text))
            {
                MessageBox.Show("Need an output file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            var args = new StringBuilder();

            args.Append("-v");
            args.AppendFormat(" -r {0}", order.Value);
            args.AppendFormat(" -o output\\{0}.txt", outputFileText.Text);
            
            if (!string.IsNullOrWhiteSpace(seedDeckText.Text))
            {
                using (var writer = new StreamWriter(string.Format("{0}_.tmp", outputFolderText.Text)))
                {
                    writer.Write(seedDeckText.Text);
                }

                args.Append(" -i _.tmp");
            }

            foreach (var filename in Directory.EnumerateFiles(outputFolderText.Text, "*.txt", SearchOption.TopDirectoryOnly))
            {
                args.AppendFormat(" {0}", filename.Substring(filename.LastIndexOf('\\') + 1));
            }


            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "mtg-builder",
                    Arguments = args.ToString(),
                    //UseShellExecute = false,
                    //RedirectStandardOutput = true,
                    //CreateNoWindow = true,
                    WorkingDirectory = outputFolderText.Text,
                }
            };

            proc.Start();
            outputDeckText.Text = "";

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
            var filename = string.Format("{0}_.txt", outputFolderText.Text);

            File.Delete(filename);
        }
    }
}
