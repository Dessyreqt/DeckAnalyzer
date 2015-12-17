using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DeckAnalyzer.Common;
using DeckAnalyzer.Data;

namespace DeckAnalyzer.Mtg
{
    public class MtgDeckSqlCeWriter : BaseSqlCeDeckDatabase, IDeckWriter
    {
        public void WriteDeck(IDeck deck)
        {
            if (ConnectionString == null)
            {
                throw new InvalidOperationException("The ConnectionString property must be set before calling WriteDeck.");
            }

            if (!(deck is MtgDeck))
            {
                throw new ArgumentException("Deck must be an MtgDeck.", "deck");
            }

            var filename = GetFileNameFromConnectionString();
            var deckIndex = -1;
            var initializeData = false;

            if (!File.Exists(filename))
            {
                var en = new SqlCeEngine(ConnectionString);
                en.CreateDatabase();
                initializeData = true;
            }

            using (var conn = new SqlCeConnection(ConnectionString))
            {
                conn.Open();

                if (initializeData)
                {
                    InitializeDatabase(conn);
                    deckIndex = 0;
                }

                if (deckIndex == -1)
                {
                    deckIndex = GetDeckIndex(conn) + 1;
                    WriteNewDeckIndex(conn, deckIndex);
                }

                InsertDecklist(conn, deckIndex, (MtgDeck)deck);
            }                                                        
        }

        private void InsertDecklist(SqlCeConnection conn, int deckIndex, MtgDeck deck)
        {
            CreateDecklistTable(conn, deckIndex);
            InsertCards(conn, deckIndex, deck);
        }

        private void InsertCards(SqlCeConnection conn, int deckIndex, MtgDeck deck)
        {
            var deckList = deck.GetContents();

            foreach (var card in deckList)
            {
                var cmdText = string.Format("insert into deck{0} (Card) values (@card)", deckIndex.ToString("000"));
                var cmd = new SqlCeCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@card", card);
                cmd.ExecuteNonQuery();
            }
        }

        private void CreateDecklistTable(SqlCeConnection conn, int deckIndex)
        {
            var cmdText = string.Format("create table deck{0} (Card nvarchar(255))", deckIndex.ToString("000"));
            var cmd = new SqlCeCommand(cmdText, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
