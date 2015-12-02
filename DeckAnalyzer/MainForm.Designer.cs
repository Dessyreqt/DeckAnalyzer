namespace DeckAnalyzer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.outputFolderText = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.eventAddressText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.getDecksButton = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.TextBox();
            this.outputDeckText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.order = new System.Windows.Forms.NumericUpDown();
            this.outputFileText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.seedDeckText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buildDeckButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TextFileOption = new System.Windows.Forms.RadioButton();
            this.DatabaseOption = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.order)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output Folder";
            // 
            // outputFolderText
            // 
            this.outputFolderText.Location = new System.Drawing.Point(16, 30);
            this.outputFolderText.Name = "outputFolderText";
            this.outputFolderText.Size = new System.Drawing.Size(268, 20);
            this.outputFolderText.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(290, 27);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // eventAddressText
            // 
            this.eventAddressText.Location = new System.Drawing.Point(16, 70);
            this.eventAddressText.Name = "eventAddressText";
            this.eventAddressText.Size = new System.Drawing.Size(268, 20);
            this.eventAddressText.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "MtgDecks.Net Event Address";
            // 
            // getDecksButton
            // 
            this.getDecksButton.Location = new System.Drawing.Point(290, 67);
            this.getDecksButton.Name = "getDecksButton";
            this.getDecksButton.Size = new System.Drawing.Size(75, 23);
            this.getDecksButton.TabIndex = 5;
            this.getDecksButton.Text = "Get Decks";
            this.getDecksButton.UseVisualStyleBackColor = true;
            this.getDecksButton.Click += new System.EventHandler(this.getDecksButton_Click);
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(16, 144);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputText.Size = new System.Drawing.Size(349, 221);
            this.outputText.TabIndex = 6;
            // 
            // outputDeckText
            // 
            this.outputDeckText.Location = new System.Drawing.Point(371, 214);
            this.outputDeckText.Multiline = true;
            this.outputDeckText.Name = "outputDeckText";
            this.outputDeckText.ReadOnly = true;
            this.outputDeckText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputDeckText.Size = new System.Drawing.Size(276, 151);
            this.outputDeckText.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(368, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ranking Order";
            // 
            // order
            // 
            this.order.Location = new System.Drawing.Point(371, 31);
            this.order.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.order.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.order.Name = "order";
            this.order.Size = new System.Drawing.Size(73, 20);
            this.order.TabIndex = 9;
            this.order.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // outputFileText
            // 
            this.outputFileText.Location = new System.Drawing.Point(453, 30);
            this.outputFileText.Name = "outputFileText";
            this.outputFileText.Size = new System.Drawing.Size(194, 20);
            this.outputFileText.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Output File (extension will be appended)";
            // 
            // seedDeckText
            // 
            this.seedDeckText.Location = new System.Drawing.Point(371, 85);
            this.seedDeckText.Multiline = true;
            this.seedDeckText.Name = "seedDeckText";
            this.seedDeckText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.seedDeckText.Size = new System.Drawing.Size(276, 123);
            this.seedDeckText.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(368, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Seed Deck";
            // 
            // buildDeckButton
            // 
            this.buildDeckButton.Location = new System.Drawing.Point(572, 56);
            this.buildDeckButton.Name = "buildDeckButton";
            this.buildDeckButton.Size = new System.Drawing.Size(75, 23);
            this.buildDeckButton.TabIndex = 14;
            this.buildDeckButton.Text = "Build Deck";
            this.buildDeckButton.UseVisualStyleBackColor = true;
            this.buildDeckButton.Click += new System.EventHandler(this.buildDeckButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DatabaseOption);
            this.groupBox1.Controls.Add(this.TextFileOption);
            this.groupBox1.Location = new System.Drawing.Point(16, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 42);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results to:";
            // 
            // TextFileOption
            // 
            this.TextFileOption.AutoSize = true;
            this.TextFileOption.Checked = true;
            this.TextFileOption.Location = new System.Drawing.Point(6, 19);
            this.TextFileOption.Name = "TextFileOption";
            this.TextFileOption.Size = new System.Drawing.Size(70, 17);
            this.TextFileOption.TabIndex = 0;
            this.TextFileOption.TabStop = true;
            this.TextFileOption.Text = "Text Files";
            this.TextFileOption.UseVisualStyleBackColor = true;
            // 
            // DatabaseOption
            // 
            this.DatabaseOption.AutoSize = true;
            this.DatabaseOption.Location = new System.Drawing.Point(82, 19);
            this.DatabaseOption.Name = "DatabaseOption";
            this.DatabaseOption.Size = new System.Drawing.Size(71, 17);
            this.DatabaseOption.TabIndex = 1;
            this.DatabaseOption.TabStop = true;
            this.DatabaseOption.Text = "Database";
            this.DatabaseOption.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 377);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buildDeckButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.seedDeckText);
            this.Controls.Add(this.outputFileText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.order);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputDeckText);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.getDecksButton);
            this.Controls.Add(this.eventAddressText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.outputFolderText);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MtgDecks.Net Downloader";
            ((System.ComponentModel.ISupportInitialize)(this.order)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox outputFolderText;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox eventAddressText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getDecksButton;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.TextBox outputDeckText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown order;
        private System.Windows.Forms.TextBox outputFileText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox seedDeckText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buildDeckButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton DatabaseOption;
        private System.Windows.Forms.RadioButton TextFileOption;
    }
}

