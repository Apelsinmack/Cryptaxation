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
            Cryptaxation.GUI.Properties.Settings settings = new Cryptaxation.GUI.Properties.Settings();
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
            this.fullNameLabel.Location = new System.Drawing.Point(4, 19);
            this.fullNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(52, 13);
            this.fullNameLabel.TabIndex = 2;
            this.fullNameLabel.Text = "Full name";
            // 
            // personalIdentificationNumberLabel
            // 
            this.personalIdentificationNumberLabel.AutoSize = true;
            this.personalIdentificationNumberLabel.Location = new System.Drawing.Point(4, 59);
            this.personalIdentificationNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.personalIdentificationNumberLabel.Name = "personalIdentificationNumberLabel";
            this.personalIdentificationNumberLabel.Size = new System.Drawing.Size(148, 13);
            this.personalIdentificationNumberLabel.TabIndex = 4;
            this.personalIdentificationNumberLabel.Text = "Personal identification number";
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(569, 287);
            this.executeButton.Margin = new System.Windows.Forms.Padding(2);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(56, 25);
            this.executeButton.TabIndex = 26;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteClick);
            // 
            // processNameTextBox
            // 
            this.processNameTextBox.Location = new System.Drawing.Point(7, 115);
            this.processNameTextBox.Name = "processNameTextBox";
            this.processNameTextBox.Size = new System.Drawing.Size(151, 20);
            this.processNameTextBox.TabIndex = 2;
            this.processNameTextBox.Text = settings.ProcessName;
            // 
            // processNameLabel
            // 
            this.processNameLabel.AutoSize = true;
            this.processNameLabel.Location = new System.Drawing.Point(4, 99);
            this.processNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.processNameLabel.Name = "processNameLabel";
            this.processNameLabel.Size = new System.Drawing.Size(74, 13);
            this.processNameLabel.TabIndex = 8;
            this.processNameLabel.Text = "Process name";
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(7, 155);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.outputPathTextBox.TabIndex = 6;
            this.outputPathTextBox.Text = settings.OutputPath;
            // 
            // outputPathLabel
            // 
            this.outputPathLabel.AutoSize = true;
            this.outputPathLabel.Location = new System.Drawing.Point(4, 139);
            this.outputPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.outputPathLabel.Name = "outputPathLabel";
            this.outputPathLabel.Size = new System.Drawing.Size(63, 13);
            this.outputPathLabel.TabIndex = 15;
            this.outputPathLabel.Text = "Output path";
            // 
            // outputPathButton
            // 
            this.outputPathButton.Location = new System.Drawing.Point(382, 154);
            this.outputPathButton.Margin = new System.Windows.Forms.Padding(2);
            this.outputPathButton.Name = "outputPathButton";
            this.outputPathButton.Size = new System.Drawing.Size(60, 22);
            this.outputPathButton.TabIndex = 7;
            this.outputPathButton.Text = "Browse";
            this.outputPathButton.UseVisualStyleBackColor = true;
            this.outputPathButton.Click += new System.EventHandler(this.OutputPathButtonClick);
            // 
            // fiatRatesPathTextBox
            // 
            this.fiatRatesPathTextBox.Location = new System.Drawing.Point(7, 75);
            this.fiatRatesPathTextBox.Name = "fiatRatesPathTextBox";
            this.fiatRatesPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.fiatRatesPathTextBox.TabIndex = 2;
            this.fiatRatesPathTextBox.Text = settings.FiatRatesPath;
            // 
            // fiatRatesPathLabel
            // 
            this.fiatRatesPathLabel.AutoSize = true;
            this.fiatRatesPathLabel.Location = new System.Drawing.Point(4, 59);
            this.fiatRatesPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fiatRatesPathLabel.Name = "fiatRatesPathLabel";
            this.fiatRatesPathLabel.Size = new System.Drawing.Size(74, 13);
            this.fiatRatesPathLabel.TabIndex = 18;
            this.fiatRatesPathLabel.Text = "Fiat rates path";
            // 
            // fiatRatesPathButton
            // 
            this.fiatRatesPathButton.Location = new System.Drawing.Point(382, 74);
            this.fiatRatesPathButton.Margin = new System.Windows.Forms.Padding(2);
            this.fiatRatesPathButton.Name = "fiatRatesPathButton";
            this.fiatRatesPathButton.Size = new System.Drawing.Size(60, 22);
            this.fiatRatesPathButton.TabIndex = 3;
            this.fiatRatesPathButton.Text = "Browse";
            this.fiatRatesPathButton.UseVisualStyleBackColor = true;
            this.fiatRatesPathButton.Click += new System.EventHandler(this.FiatRatesPathButtonClick);
            // 
            // transactionsPathLabel
            // 
            this.transactionsPathLabel.AutoSize = true;
            this.transactionsPathLabel.Location = new System.Drawing.Point(4, 19);
            this.transactionsPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.transactionsPathLabel.Name = "transactionsPathLabel";
            this.transactionsPathLabel.Size = new System.Drawing.Size(92, 13);
            this.transactionsPathLabel.TabIndex = 21;
            this.transactionsPathLabel.Text = "Transactions path";
            // 
            // transactionsPathButton
            // 
            this.transactionsPathButton.Location = new System.Drawing.Point(382, 34);
            this.transactionsPathButton.Margin = new System.Windows.Forms.Padding(2);
            this.transactionsPathButton.Name = "transactionsPathButton";
            this.transactionsPathButton.Size = new System.Drawing.Size(60, 22);
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
            this.personalInformationGroup.Location = new System.Drawing.Point(9, 11);
            this.personalInformationGroup.Margin = new System.Windows.Forms.Padding(2);
            this.personalInformationGroup.Name = "personalInformationGroup";
            this.personalInformationGroup.Padding = new System.Windows.Forms.Padding(2);
            this.personalInformationGroup.Size = new System.Drawing.Size(164, 152);
            this.personalInformationGroup.TabIndex = 23;
            this.personalInformationGroup.TabStop = false;
            this.personalInformationGroup.Text = "Personal information";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(7, 35);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(151, 20);
            this.fullNameTextBox.TabIndex = 0;
            this.fullNameTextBox.Text = settings.FullName;
            // 
            // personalIdentificationNumberTextBox
            // 
            this.personalIdentificationNumberTextBox.Location = new System.Drawing.Point(7, 75);
            this.personalIdentificationNumberTextBox.Name = "personalIdentificationNumberTextBox";
            this.personalIdentificationNumberTextBox.Size = new System.Drawing.Size(151, 20);
            this.personalIdentificationNumberTextBox.TabIndex = 1;
            this.personalIdentificationNumberTextBox.Text = settings.PersonalIdentificationNumber;
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
            this.pathsGroup.Location = new System.Drawing.Point(177, 11);
            this.pathsGroup.Margin = new System.Windows.Forms.Padding(2);
            this.pathsGroup.Name = "pathsGroup";
            this.pathsGroup.Padding = new System.Windows.Forms.Padding(2);
            this.pathsGroup.Size = new System.Drawing.Size(448, 194);
            this.pathsGroup.TabIndex = 24;
            this.pathsGroup.TabStop = false;
            this.pathsGroup.Text = "Paths";
            // 
            // cryptoToFiatRatesPathTextBox
            // 
            this.cryptoToFiatRatesPathTextBox.Location = new System.Drawing.Point(7, 115);
            this.cryptoToFiatRatesPathTextBox.Name = "cryptoToFiatRatesPathTextBox";
            this.cryptoToFiatRatesPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.cryptoToFiatRatesPathTextBox.TabIndex = 4;
            this.cryptoToFiatRatesPathTextBox.Text = settings.CryptoToFiatRatesPath;
            // 
            // transactionsPathTextBox
            // 
            this.transactionsPathTextBox.Location = new System.Drawing.Point(7, 35);
            this.transactionsPathTextBox.Name = "transactionsPathTextBox";
            this.transactionsPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.transactionsPathTextBox.TabIndex = 0;
            this.transactionsPathTextBox.Text = settings.TransactionsPath;
            // 
            // cryptoToFiatRatesPathLabel
            // 
            this.cryptoToFiatRatesPathLabel.AutoSize = true;
            this.cryptoToFiatRatesPathLabel.Location = new System.Drawing.Point(4, 99);
            this.cryptoToFiatRatesPathLabel.Name = "cryptoToFiatRatesPathLabel";
            this.cryptoToFiatRatesPathLabel.Size = new System.Drawing.Size(116, 13);
            this.cryptoToFiatRatesPathLabel.TabIndex = 24;
            this.cryptoToFiatRatesPathLabel.Text = "Crypto to fiat rates path";
            // 
            // cryptoToFiatRatesPathButton
            // 
            this.cryptoToFiatRatesPathButton.Location = new System.Drawing.Point(382, 114);
            this.cryptoToFiatRatesPathButton.Name = "cryptoToFiatRatesPathButton";
            this.cryptoToFiatRatesPathButton.Size = new System.Drawing.Size(60, 22);
            this.cryptoToFiatRatesPathButton.TabIndex = 5;
            this.cryptoToFiatRatesPathButton.Text = "Browse";
            this.cryptoToFiatRatesPathButton.UseVisualStyleBackColor = true;
            this.cryptoToFiatRatesPathButton.Click += new System.EventHandler(this.cryptoToFiatRatesPathButton_Click);
            // 
            // years
            // 
            this.years.Controls.Add(this.year2018);
            this.years.Controls.Add(this.year2017);
            this.years.Controls.Add(this.year2016);
            this.years.Controls.Add(this.year2015);
            this.years.Controls.Add(this.year2014);
            this.years.Location = new System.Drawing.Point(9, 168);
            this.years.Name = "years";
            this.years.Size = new System.Drawing.Size(164, 144);
            this.years.TabIndex = 25;
            this.years.TabStop = false;
            this.years.Text = "Years";
            // 
            // year2018
            // 
            this.year2018.AutoSize = true;
            this.year2018.Checked = true;
            this.year2018.CheckState = System.Windows.Forms.CheckState.Checked;
            this.year2018.Location = new System.Drawing.Point(7, 115);
            this.year2018.Name = "year2018";
            this.year2018.Size = new System.Drawing.Size(50, 17);
            this.year2018.TabIndex = 4;
            this.year2018.Text = "2018";
            this.year2018.UseVisualStyleBackColor = true;
            // 
            // year2017
            // 
            this.year2017.AutoSize = true;
            this.year2017.Location = new System.Drawing.Point(7, 92);
            this.year2017.Name = "year2017";
            this.year2017.Size = new System.Drawing.Size(50, 17);
            this.year2017.TabIndex = 3;
            this.year2017.Text = "2017";
            this.year2017.UseVisualStyleBackColor = true;
            // 
            // year2016
            // 
            this.year2016.AutoSize = true;
            this.year2016.Location = new System.Drawing.Point(7, 68);
            this.year2016.Name = "year2016";
            this.year2016.Size = new System.Drawing.Size(50, 17);
            this.year2016.TabIndex = 2;
            this.year2016.Text = "2016";
            this.year2016.UseVisualStyleBackColor = true;
            // 
            // year2015
            // 
            this.year2015.AutoSize = true;
            this.year2015.Location = new System.Drawing.Point(7, 44);
            this.year2015.Name = "year2015";
            this.year2015.Size = new System.Drawing.Size(50, 17);
            this.year2015.TabIndex = 1;
            this.year2015.Text = "2015";
            this.year2015.UseVisualStyleBackColor = true;
            // 
            // year2014
            // 
            this.year2014.AutoSize = true;
            this.year2014.Location = new System.Drawing.Point(7, 20);
            this.year2014.Name = "year2014";
            this.year2014.Size = new System.Drawing.Size(50, 17);
            this.year2014.TabIndex = 0;
            this.year2014.Text = "2014";
            this.year2014.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(634, 318);
            this.Controls.Add(this.years);
            this.Controls.Add(this.pathsGroup);
            this.Controls.Add(this.personalInformationGroup);
            this.Controls.Add(this.executeButton);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.CheckBox year2018;
        private System.Windows.Forms.CheckBox year2017;
        private System.Windows.Forms.CheckBox year2016;
        private System.Windows.Forms.CheckBox year2015;
        private System.Windows.Forms.CheckBox year2014;
        private System.Windows.Forms.TextBox transactionsPathTextBox;
        private System.Windows.Forms.TextBox cryptoToFiatRatesPathTextBox;
    }
}

