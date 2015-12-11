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
using DeckAnalyzer.Common;
using DeckAnalyzer.Data;
using DeckAnalyzer.Properties;

namespace DeckAnalyzer
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

            switch (Settings.Default.DeckWriterOutputType)
            {
                case DeckWriterOutputType.TextFile:
                    TextFileOption.Checked = true;
                    break;
                case DeckWriterOutputType.Database:
                    DatabaseOption.Checked = true;
                    break;
            }
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
            SetDeckWriterOutputType();
            Settings.Default.Save();

            outputText.Text += String.Format("Grabbing decks from {0}{1}", eventAddressText.Text, Environment.NewLine);
            Application.DoEvents();

            try
            {
                IDeckScraper scraper = DeckScraperFactory.GetDeckScraper(eventAddressText.Text);

                var outputType = GetOutputType();
                var gameType = GetGameType();

                IDeckWriter writer = DeckWriterFactory.GetDeckWriter(outputType, gameType, GetOutputLocation(outputType));
                scraper.GetDecks(eventAddressText.Text, writer);
            }
            catch (ArgumentException ex)
            {
                outputText.Text += String.Format("{0}{1}", ex.Message, Environment.NewLine);
            }
            outputText.Text += String.Format("Finished grabbing decks.");
        }

        private void SetDeckWriterOutputType()
        {
            if (TextFileOption.Checked)
            {
                Settings.Default.DeckWriterOutputType = DeckWriterOutputType.TextFile;
            }
            else if (DatabaseOption.Checked)
            {
                Settings.Default.DeckWriterOutputType = DeckWriterOutputType.Database;
            }
        }

        private string GetOutputLocation(DeckWriterOutputType outputType)
        {
            FixOutputFolder();

            switch (outputType)
            {
                case DeckWriterOutputType.TextFile:
                    return outputFolderText.Text;
                case DeckWriterOutputType.Database:
                    return string.Format("{0}{1}.sdf", outputFolderText.Text, outputFileText.Text);
                default:
                    throw new ArgumentException("Output type must be set.", "outputType");
            }
        }

        private DeckWriterOutputType GetOutputType()
        {
            if (TextFileOption.Checked)
            {
                return DeckWriterOutputType.TextFile;
            }

            if (DatabaseOption.Checked)
            {
                return DeckWriterOutputType.Database;
            }

            throw new InvalidOperationException("The output type must be specified.");
        }

        private DeckWriterGameType GetGameType()
        {
            return DeckWriterGameType.Mtg;
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

        private void buildDeckButton_Click(object sender, EventArgs e)
        {
            FixOutputFolder();
            Settings.Default.Order = (int)order.Value;
            Settings.Default.OutputDeck = outputFileText.Text;
            Settings.Default.SeedDeck = seedDeckText.Text;
            SetDeckWriterOutputType();
            Settings.Default.Save();

            IDeckAnalyzer deckAnalyzer = DeckAnalyzerFactory.GetDeckAnalyzer(GetOutputType(), outputFolderText.Text, outputFileText.Text, seedDeckText.Text);
            deckAnalyzer.AnalyzeDecks((int)order.Value);
        }

    }
}
