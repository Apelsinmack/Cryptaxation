namespace Cryptaxation.GUI
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
            Cryptaxation.GUI.Properties.Settings settings1 = new Cryptaxation.GUI.Properties.Settings();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.personalIdentificationNumberLabel = new System.Windows.Forms.Label();
            this.executeButton = new System.Windows.Forms.Button();
            this.processNameTextBox = new System.Windows.Forms.TextBox();
            this.processNameLabel = new System.Windows.Forms.Label();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.outputPathLabel = new System.Windows.Forms.Label();
            this.outputPathButton = new System.Windows.Forms.Button();
            this.fiatRatesPathTextBox = new System.Windows.Forms.TextBox();
            this.fiatRatesPathLabel = new System.Windows.Forms.Label();
            this.fiatRatesPathButton = new System.Windows.Forms.Button();
            this.transactionsPathLabel = new System.Windows.Forms.Label();
            this.transactionsPathButton = new System.Windows.Forms.Button();
            this.personalInformationGroup = new System.Windows.Forms.GroupBox();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.personalIdentificationNumberTextBox = new System.Windows.Forms.TextBox();
            this.pathsGroup = new System.Windows.Forms.GroupBox();
            this.cryptoToFiatRatesPathTextBox = new System.Windows.Forms.TextBox();
            this.transactionsPathTextBox = new System.Windows.Forms.TextBox();
            this.cryptoToFiatRatesPathLabel = new System.Windows.Forms.Label();
            this.cryptoToFiatRatesPathButton = new System.Windows.Forms.Button();
            this.years = new System.Windows.Forms.GroupBox();
            this.year2028 = new System.Windows.Forms.CheckBox();
            this.year2027 = new System.Windows.Forms.CheckBox();
            this.year2026 = new System.Windows.Forms.CheckBox();
            this.year2025 = new System.Windows.Forms.CheckBox();
            this.year2024 = new System.Windows.Forms.CheckBox();
            this.year2023 = new System.Windows.Forms.CheckBox();
            this.year2022 = new System.Windows.Forms.CheckBox();
            this.year2021 = new System.Windows.Forms.CheckBox();
            this.year2020 = new System.Windows.Forms.CheckBox();
            this.year2019 = new System.Windows.Forms.CheckBox();
            this.year2018 = new System.Windows.Forms.CheckBox();
            this.year2017 = new System.Windows.Forms.CheckBox();
            this.year2016 = new System.Windows.Forms.CheckBox();
            this.year2015 = new System.Windows.Forms.CheckBox();
            this.year2014 = new System.Windows.Forms.CheckBox();
            this.personalInformationGroup.SuspendLayout();
            this.pathsGroup.SuspendLayout();
            this.years.SuspendLayout();
            this.SuspendLayout();
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.AutoSize = true;
            this.fullNameLabel.Location = new System.Drawing.Point(6, 29);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(78, 20);
            this.fullNameLabel.TabIndex = 2;
            this.fullNameLabel.Text = "Full name";
            // 
            // personalIdentificationNumberLabel
            // 
            this.personalIdentificationNumberLabel.AutoSize = true;
            this.personalIdentificationNumberLabel.Location = new System.Drawing.Point(6, 91);
            this.personalIdentificationNumberLabel.Name = "personalIdentificationNumberLabel";
            this.personalIdentificationNumberLabel.Size = new System.Drawing.Size(222, 20);
            this.personalIdentificationNumberLabel.TabIndex = 4;
            this.personalIdentificationNumberLabel.Text = "Personal identification number";
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(854, 442);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(84, 38);
            this.executeButton.TabIndex = 26;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteClick);
            // 
            // processNameTextBox
            // 
            this.processNameTextBox.Location = new System.Drawing.Point(10, 177);
            this.processNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.processNameTextBox.Name = "processNameTextBox";
            this.processNameTextBox.Size = new System.Drawing.Size(224, 26);
            this.processNameTextBox.TabIndex = 2;
            settings1.CryptoToFiatRatesPath = "";
            settings1.FiatRatesPath = "";
            settings1.FullName = "";
            settings1.OutputPath = "";
            settings1.PersonalIdentificationNumber = "";
            settings1.ProcessName = "";
            settings1.SettingsKey = "";
            settings1.TransactionsPath = "";
            this.processNameTextBox.Text = settings1.ProcessName;
            // 
            // processNameLabel
            // 
            this.processNameLabel.AutoSize = true;
            this.processNameLabel.Location = new System.Drawing.Point(6, 152);
            this.processNameLabel.Name = "processNameLabel";
            this.processNameLabel.Size = new System.Drawing.Size(110, 20);
            this.processNameLabel.TabIndex = 8;
            this.processNameLabel.Text = "Process name";
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(10, 238);
            this.outputPathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(562, 26);
            this.outputPathTextBox.TabIndex = 6;
            this.outputPathTextBox.Text = settings1.OutputPath;
            // 
            // outputPathLabel
            // 
            this.outputPathLabel.AutoSize = true;
            this.outputPathLabel.Location = new System.Drawing.Point(6, 214);
            this.outputPathLabel.Name = "outputPathLabel";
            this.outputPathLabel.Size = new System.Drawing.Size(94, 20);
            this.outputPathLabel.TabIndex = 15;
            this.outputPathLabel.Text = "Output path";
            // 
            // outputPathButton
            // 
            this.outputPathButton.Location = new System.Drawing.Point(573, 237);
            this.outputPathButton.Name = "outputPathButton";
            this.outputPathButton.Size = new System.Drawing.Size(90, 34);
            this.outputPathButton.TabIndex = 7;
            this.outputPathButton.Text = "Browse";
            this.outputPathButton.UseVisualStyleBackColor = true;
            this.outputPathButton.Click += new System.EventHandler(this.OutputPathButtonClick);
            // 
            // fiatRatesPathTextBox
            // 
            this.fiatRatesPathTextBox.Location = new System.Drawing.Point(10, 115);
            this.fiatRatesPathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fiatRatesPathTextBox.Name = "fiatRatesPathTextBox";
            this.fiatRatesPathTextBox.Size = new System.Drawing.Size(562, 26);
            this.fiatRatesPathTextBox.TabIndex = 2;
            this.fiatRatesPathTextBox.Text = settings1.FiatRatesPath;
            // 
            // fiatRatesPathLabel
            // 
            this.fiatRatesPathLabel.AutoSize = true;
            this.fiatRatesPathLabel.Location = new System.Drawing.Point(6, 91);
            this.fiatRatesPathLabel.Name = "fiatRatesPathLabel";
            this.fiatRatesPathLabel.Size = new System.Drawing.Size(112, 20);
            this.fiatRatesPathLabel.TabIndex = 18;
            this.fiatRatesPathLabel.Text = "Fiat rates path";
            // 
            // fiatRatesPathButton
            // 
            this.fiatRatesPathButton.Location = new System.Drawing.Point(573, 114);
            this.fiatRatesPathButton.Name = "fiatRatesPathButton";
            this.fiatRatesPathButton.Size = new System.Drawing.Size(90, 34);
            this.fiatRatesPathButton.TabIndex = 3;
            this.fiatRatesPathButton.Text = "Browse";
            this.fiatRatesPathButton.UseVisualStyleBackColor = true;
            this.fiatRatesPathButton.Click += new System.EventHandler(this.FiatRatesPathButtonClick);
            // 
            // transactionsPathLabel
            // 
            this.transactionsPathLabel.AutoSize = true;
            this.transactionsPathLabel.Location = new System.Drawing.Point(6, 29);
            this.transactionsPathLabel.Name = "transactionsPathLabel";
            this.transactionsPathLabel.Size = new System.Drawing.Size(136, 20);
            this.transactionsPathLabel.TabIndex = 21;
            this.transactionsPathLabel.Text = "Transactions path";
            // 
            // transactionsPathButton
            // 
            this.transactionsPathButton.Location = new System.Drawing.Point(573, 52);
            this.transactionsPathButton.Name = "transactionsPathButton";
            this.transactionsPathButton.Size = new System.Drawing.Size(90, 34);
            this.transactionsPathButton.TabIndex = 1;
            this.transactionsPathButton.Text = "Browse";
            this.transactionsPathButton.UseVisualStyleBackColor = true;
            this.transactionsPathButton.Click += new System.EventHandler(this.TransactionsPathButtonClick);
            // 
            // personalInformationGroup
            // 
            this.personalInformationGroup.Controls.Add(this.fullNameTextBox);
            this.personalInformationGroup.Controls.Add(this.fullNameLabel);
            this.personalInformationGroup.Controls.Add(this.personalIdentificationNumberTextBox);
            this.personalInformationGroup.Controls.Add(this.personalIdentificationNumberLabel);
            this.personalInformationGroup.Controls.Add(this.processNameLabel);
            this.personalInformationGroup.Controls.Add(this.processNameTextBox);
            this.personalInformationGroup.Location = new System.Drawing.Point(14, 17);
            this.personalInformationGroup.Name = "personalInformationGroup";
            this.personalInformationGroup.Size = new System.Drawing.Size(246, 234);
            this.personalInformationGroup.TabIndex = 23;
            this.personalInformationGroup.TabStop = false;
            this.personalInformationGroup.Text = "Personal information";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(10, 54);
            this.fullNameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(224, 26);
            this.fullNameTextBox.TabIndex = 0;
            this.fullNameTextBox.Text = settings1.FullName;
            // 
            // personalIdentificationNumberTextBox
            // 
            this.personalIdentificationNumberTextBox.Location = new System.Drawing.Point(10, 115);
            this.personalIdentificationNumberTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.personalIdentificationNumberTextBox.Name = "personalIdentificationNumberTextBox";
            this.personalIdentificationNumberTextBox.Size = new System.Drawing.Size(224, 26);
            this.personalIdentificationNumberTextBox.TabIndex = 1;
            this.personalIdentificationNumberTextBox.Text = settings1.PersonalIdentificationNumber;
            // 
            // pathsGroup
            // 
            this.pathsGroup.Controls.Add(this.cryptoToFiatRatesPathTextBox);
            this.pathsGroup.Controls.Add(this.transactionsPathTextBox);
            this.pathsGroup.Controls.Add(this.cryptoToFiatRatesPathLabel);
            this.pathsGroup.Controls.Add(this.cryptoToFiatRatesPathButton);
            this.pathsGroup.Controls.Add(this.transactionsPathLabel);
            this.pathsGroup.Controls.Add(this.transactionsPathButton);
            this.pathsGroup.Controls.Add(this.outputPathTextBox);
            this.pathsGroup.Controls.Add(this.fiatRatesPathTextBox);
            this.pathsGroup.Controls.Add(this.outputPathLabel);
            this.pathsGroup.Controls.Add(this.outputPathButton);
            this.pathsGroup.Controls.Add(this.fiatRatesPathLabel);
            this.pathsGroup.Controls.Add(this.fiatRatesPathButton);
            this.pathsGroup.Location = new System.Drawing.Point(266, 17);
            this.pathsGroup.Name = "pathsGroup";
            this.pathsGroup.Size = new System.Drawing.Size(672, 298);
            this.pathsGroup.TabIndex = 24;
            this.pathsGroup.TabStop = false;
            this.pathsGroup.Text = "Paths";
            // 
            // cryptoToFiatRatesPathTextBox
            // 
            this.cryptoToFiatRatesPathTextBox.Location = new System.Drawing.Point(10, 177);
            this.cryptoToFiatRatesPathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cryptoToFiatRatesPathTextBox.Name = "cryptoToFiatRatesPathTextBox";
            this.cryptoToFiatRatesPathTextBox.Size = new System.Drawing.Size(562, 26);
            this.cryptoToFiatRatesPathTextBox.TabIndex = 4;
            this.cryptoToFiatRatesPathTextBox.Text = settings1.CryptoToFiatRatesPath;
            // 
            // transactionsPathTextBox
            // 
            this.transactionsPathTextBox.Location = new System.Drawing.Point(10, 54);
            this.transactionsPathTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.transactionsPathTextBox.Name = "transactionsPathTextBox";
            this.transactionsPathTextBox.Size = new System.Drawing.Size(562, 26);
            this.transactionsPathTextBox.TabIndex = 0;
            this.transactionsPathTextBox.Text = settings1.TransactionsPath;
            // 
            // cryptoToFiatRatesPathLabel
            // 
            this.cryptoToFiatRatesPathLabel.AutoSize = true;
            this.cryptoToFiatRatesPathLabel.Location = new System.Drawing.Point(6, 152);
            this.cryptoToFiatRatesPathLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cryptoToFiatRatesPathLabel.Name = "cryptoToFiatRatesPathLabel";
            this.cryptoToFiatRatesPathLabel.Size = new System.Drawing.Size(175, 20);
            this.cryptoToFiatRatesPathLabel.TabIndex = 24;
            this.cryptoToFiatRatesPathLabel.Text = "Crypto to fiat rates path";
            // 
            // cryptoToFiatRatesPathButton
            // 
            this.cryptoToFiatRatesPathButton.Location = new System.Drawing.Point(573, 175);
            this.cryptoToFiatRatesPathButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cryptoToFiatRatesPathButton.Name = "cryptoToFiatRatesPathButton";
            this.cryptoToFiatRatesPathButton.Size = new System.Drawing.Size(90, 34);
            this.cryptoToFiatRatesPathButton.TabIndex = 5;
            this.cryptoToFiatRatesPathButton.Text = "Browse";
            this.cryptoToFiatRatesPathButton.UseVisualStyleBackColor = true;
            this.cryptoToFiatRatesPathButton.Click += new System.EventHandler(this.cryptoToFiatRatesPathButton_Click);
            // 
            // years
            // 
            this.years.Controls.Add(this.year2028);
            this.years.Controls.Add(this.year2027);
            this.years.Controls.Add(this.year2026);
            this.years.Controls.Add(this.year2025);
            this.years.Controls.Add(this.year2024);
            this.years.Controls.Add(this.year2023);
            this.years.Controls.Add(this.year2022);
            this.years.Controls.Add(this.year2021);
            this.years.Controls.Add(this.year2020);
            this.years.Controls.Add(this.year2019);
            this.years.Controls.Add(this.year2018);
            this.years.Controls.Add(this.year2017);
            this.years.Controls.Add(this.year2016);
            this.years.Controls.Add(this.year2015);
            this.years.Controls.Add(this.year2014);
            this.years.Location = new System.Drawing.Point(14, 258);
            this.years.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.years.Name = "years";
            this.years.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.years.Size = new System.Drawing.Size(246, 222);
            this.years.TabIndex = 25;
            this.years.TabStop = false;
            this.years.Text = "Years";
            // 
            // year2028
            // 
            this.year2028.AutoSize = true;
            this.year2028.Location = new System.Drawing.Point(168, 177);
            this.year2028.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2028.Name = "year2028";
            this.year2028.Size = new System.Drawing.Size(71, 24);
            this.year2028.TabIndex = 4;
            this.year2028.Text = "2028";
            this.year2028.UseVisualStyleBackColor = true;
            // 
            // year2027
            // 
            this.year2027.AutoSize = true;
            this.year2027.Location = new System.Drawing.Point(168, 142);
            this.year2027.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2027.Name = "year2027";
            this.year2027.Size = new System.Drawing.Size(71, 24);
            this.year2027.TabIndex = 3;
            this.year2027.Text = "2027";
            this.year2027.UseVisualStyleBackColor = true;
            // 
            // year2026
            // 
            this.year2026.AutoSize = true;
            this.year2026.Location = new System.Drawing.Point(168, 105);
            this.year2026.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2026.Name = "year2026";
            this.year2026.Size = new System.Drawing.Size(71, 24);
            this.year2026.TabIndex = 2;
            this.year2026.Text = "2026";
            this.year2026.UseVisualStyleBackColor = true;
            // 
            // year2025
            // 
            this.year2025.AutoSize = true;
            this.year2025.Location = new System.Drawing.Point(168, 68);
            this.year2025.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2025.Name = "year2025";
            this.year2025.Size = new System.Drawing.Size(71, 24);
            this.year2025.TabIndex = 1;
            this.year2025.Text = "2025";
            this.year2025.UseVisualStyleBackColor = true;
            // 
            // year2024
            // 
            this.year2024.AutoSize = true;
            this.year2024.Location = new System.Drawing.Point(168, 31);
            this.year2024.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2024.Name = "year2024";
            this.year2024.Size = new System.Drawing.Size(71, 24);
            this.year2024.TabIndex = 0;
            this.year2024.Text = "2024";
            this.year2024.UseVisualStyleBackColor = true;
            // 
            // year2023
            // 
            this.year2023.AutoSize = true;
            this.year2023.Location = new System.Drawing.Point(89, 177);
            this.year2023.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2023.Name = "year2023";
            this.year2023.Size = new System.Drawing.Size(71, 24);
            this.year2023.TabIndex = 4;
            this.year2023.Text = "2023";
            this.year2023.UseVisualStyleBackColor = true;
            // 
            // year2022
            // 
            this.year2022.AutoSize = true;
            this.year2022.Location = new System.Drawing.Point(89, 142);
            this.year2022.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2022.Name = "year2022";
            this.year2022.Size = new System.Drawing.Size(71, 24);
            this.year2022.TabIndex = 3;
            this.year2022.Text = "2022";
            this.year2022.UseVisualStyleBackColor = true;
            // 
            // year2021
            // 
            this.year2021.AutoSize = true;
            this.year2021.Location = new System.Drawing.Point(89, 105);
            this.year2021.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2021.Name = "year2021";
            this.year2021.Size = new System.Drawing.Size(71, 24);
            this.year2021.TabIndex = 2;
            this.year2021.Text = "2021";
            this.year2021.UseVisualStyleBackColor = true;
            // 
            // year2020
            // 
            this.year2020.AutoSize = true;
            this.year2020.Location = new System.Drawing.Point(89, 68);
            this.year2020.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2020.Name = "year2020";
            this.year2020.Size = new System.Drawing.Size(71, 24);
            this.year2020.TabIndex = 1;
            this.year2020.Text = "2020";
            this.year2020.UseVisualStyleBackColor = true;
            // 
            // year2019
            // 
            this.year2019.AutoSize = true;
            this.year2019.Location = new System.Drawing.Point(89, 31);
            this.year2019.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2019.Name = "year2019";
            this.year2019.Size = new System.Drawing.Size(71, 24);
            this.year2019.TabIndex = 0;
            this.year2019.Text = "2019";
            this.year2019.UseVisualStyleBackColor = true;
            // 
            // year2018
            // 
            this.year2018.AutoSize = true;
            this.year2018.Location = new System.Drawing.Point(10, 177);
            this.year2018.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2018.Name = "year2018";
            this.year2018.Size = new System.Drawing.Size(71, 24);
            this.year2018.TabIndex = 4;
            this.year2018.Text = "2018";
            this.year2018.UseVisualStyleBackColor = true;
            // 
            // year2017
            // 
            this.year2017.AutoSize = true;
            this.year2017.Location = new System.Drawing.Point(10, 142);
            this.year2017.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2017.Name = "year2017";
            this.year2017.Size = new System.Drawing.Size(71, 24);
            this.year2017.TabIndex = 3;
            this.year2017.Text = "2017";
            this.year2017.UseVisualStyleBackColor = true;
            // 
            // year2016
            // 
            this.year2016.AutoSize = true;
            this.year2016.Location = new System.Drawing.Point(10, 105);
            this.year2016.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2016.Name = "year2016";
            this.year2016.Size = new System.Drawing.Size(71, 24);
            this.year2016.TabIndex = 2;
            this.year2016.Text = "2016";
            this.year2016.UseVisualStyleBackColor = true;
            // 
            // year2015
            // 
            this.year2015.AutoSize = true;
            this.year2015.Location = new System.Drawing.Point(10, 68);
            this.year2015.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2015.Name = "year2015";
            this.year2015.Size = new System.Drawing.Size(71, 24);
            this.year2015.TabIndex = 1;
            this.year2015.Text = "2015";
            this.year2015.UseVisualStyleBackColor = true;
            // 
            // year2014
            // 
            this.year2014.AutoSize = true;
            this.year2014.Location = new System.Drawing.Point(10, 31);
            this.year2014.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.year2014.Name = "year2014";
            this.year2014.Size = new System.Drawing.Size(71, 24);
            this.year2014.TabIndex = 0;
            this.year2014.Text = "2014";
            this.year2014.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(951, 489);
            this.Controls.Add(this.years);
            this.Controls.Add(this.pathsGroup);
            this.Controls.Add(this.personalInformationGroup);
            this.Controls.Add(this.executeButton);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Cryptaxation";
            this.Closed += new System.EventHandler(this.SaveSettings);
            this.personalInformationGroup.ResumeLayout(false);
            this.personalInformationGroup.PerformLayout();
            this.pathsGroup.ResumeLayout(false);
            this.pathsGroup.PerformLayout();
            this.years.ResumeLayout(false);
            this.years.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Label fullNameLabel;
        private System.Windows.Forms.Label personalIdentificationNumberLabel;
        private System.Windows.Forms.TextBox personalIdentificationNumberTextBox;
        private System.Windows.Forms.TextBox processNameTextBox;
        private System.Windows.Forms.Label processNameLabel;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Label outputPathLabel;
        private System.Windows.Forms.Button outputPathButton;
        private System.Windows.Forms.TextBox fiatRatesPathTextBox;
        private System.Windows.Forms.Label fiatRatesPathLabel;
        private System.Windows.Forms.Button fiatRatesPathButton;
        private System.Windows.Forms.Label transactionsPathLabel;
        private System.Windows.Forms.Button transactionsPathButton;
        private System.Windows.Forms.GroupBox personalInformationGroup;
        private System.Windows.Forms.GroupBox pathsGroup;
        private System.Windows.Forms.Label cryptoToFiatRatesPathLabel;
        private System.Windows.Forms.Button cryptoToFiatRatesPathButton;
        private System.Windows.Forms.GroupBox years; 
        private System.Windows.Forms.CheckBox year2028;
        private System.Windows.Forms.CheckBox year2027;
        private System.Windows.Forms.CheckBox year2026;
        private System.Windows.Forms.CheckBox year2025;
        private System.Windows.Forms.CheckBox year2024;
        private System.Windows.Forms.CheckBox year2023;
        private System.Windows.Forms.CheckBox year2022;
        private System.Windows.Forms.CheckBox year2021;
        private System.Windows.Forms.CheckBox year2020;
        private System.Windows.Forms.CheckBox year2019;
        private System.Windows.Forms.CheckBox year2018;
        private System.Windows.Forms.CheckBox year2017;
        private System.Windows.Forms.CheckBox year2016;
        private System.Windows.Forms.CheckBox year2015;
        private System.Windows.Forms.CheckBox year2014;
        private System.Windows.Forms.TextBox transactionsPathTextBox;
        private System.Windows.Forms.TextBox cryptoToFiatRatesPathTextBox;
    }
}

