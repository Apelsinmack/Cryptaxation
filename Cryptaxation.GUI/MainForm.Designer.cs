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
            Cryptaxation.Properties.Settings settings = new Cryptaxation.Properties.Settings();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.personalIdentificationNumberLabel = new System.Windows.Forms.Label();
            this.executeButton = new System.Windows.Forms.Button();
            this.processNameTextBox = new System.Windows.Forms.TextBox();
            this.processNameLabel = new System.Windows.Forms.Label();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.outputPathLabel = new System.Windows.Forms.Label();
            this.outputPathButton = new System.Windows.Forms.Button();
            this.riksbankenRatesPathTextBox = new System.Windows.Forms.TextBox();
            this.riksbankenRatesPathLabel = new System.Windows.Forms.Label();
            this.riksbankenRatesPathButton = new System.Windows.Forms.Button();
            this.bitstampTransactionsPathLabel = new System.Windows.Forms.Label();
            this.bitstampTransactionsPathButton = new System.Windows.Forms.Button();
            this.personalInformationGroup = new System.Windows.Forms.GroupBox();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.personalIdentificationNumberTextBox = new System.Windows.Forms.TextBox();
            this.pathsGroup = new System.Windows.Forms.GroupBox();
            this.bitstampRatesPathTextBox = new System.Windows.Forms.TextBox();
            this.bitstampTransactionsPathTextBox = new System.Windows.Forms.TextBox();
            this.bitstampRatesPathLabel = new System.Windows.Forms.Label();
            this.bitstampRatesPathButton = new System.Windows.Forms.Button();
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
            // riksbankenRatesPathTextBox
            // 
            this.riksbankenRatesPathTextBox.Location = new System.Drawing.Point(7, 75);
            this.riksbankenRatesPathTextBox.Name = "riksbankenRatesPathTextBox";
            this.riksbankenRatesPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.riksbankenRatesPathTextBox.TabIndex = 2;
            this.riksbankenRatesPathTextBox.Text = settings.RiksbankenRatesPath;
            // 
            // riksbankenRatesPathLabel
            // 
            this.riksbankenRatesPathLabel.AutoSize = true;
            this.riksbankenRatesPathLabel.Location = new System.Drawing.Point(4, 59);
            this.riksbankenRatesPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.riksbankenRatesPathLabel.Name = "riksbankenRatesPathLabel";
            this.riksbankenRatesPathLabel.Size = new System.Drawing.Size(114, 13);
            this.riksbankenRatesPathLabel.TabIndex = 18;
            this.riksbankenRatesPathLabel.Text = "Riksbanken rates path";
            // 
            // riksbankenRatesPathButton
            // 
            this.riksbankenRatesPathButton.Location = new System.Drawing.Point(382, 74);
            this.riksbankenRatesPathButton.Margin = new System.Windows.Forms.Padding(2);
            this.riksbankenRatesPathButton.Name = "riksbankenRatesPathButton";
            this.riksbankenRatesPathButton.Size = new System.Drawing.Size(60, 22);
            this.riksbankenRatesPathButton.TabIndex = 3;
            this.riksbankenRatesPathButton.Text = "Browse";
            this.riksbankenRatesPathButton.UseVisualStyleBackColor = true;
            this.riksbankenRatesPathButton.Click += new System.EventHandler(this.RiksbankenRatesPathButtonClick);
            // 
            // bitstampTransactionsPathLabel
            // 
            this.bitstampTransactionsPathLabel.AutoSize = true;
            this.bitstampTransactionsPathLabel.Location = new System.Drawing.Point(4, 19);
            this.bitstampTransactionsPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bitstampTransactionsPathLabel.Name = "bitstampTransactionsPathLabel";
            this.bitstampTransactionsPathLabel.Size = new System.Drawing.Size(92, 13);
            this.bitstampTransactionsPathLabel.TabIndex = 21;
            this.bitstampTransactionsPathLabel.Text = "Transactions path";
            // 
            // bitstampTransactionsPathButton
            // 
            this.bitstampTransactionsPathButton.Location = new System.Drawing.Point(382, 34);
            this.bitstampTransactionsPathButton.Margin = new System.Windows.Forms.Padding(2);
            this.bitstampTransactionsPathButton.Name = "bitstampTransactionsPathButton";
            this.bitstampTransactionsPathButton.Size = new System.Drawing.Size(60, 22);
            this.bitstampTransactionsPathButton.TabIndex = 1;
            this.bitstampTransactionsPathButton.Text = "Browse";
            this.bitstampTransactionsPathButton.UseVisualStyleBackColor = true;
            this.bitstampTransactionsPathButton.Click += new System.EventHandler(this.BitstampTransactionsPathButtonClick);
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
            this.pathsGroup.Controls.Add(this.bitstampRatesPathTextBox);
            this.pathsGroup.Controls.Add(this.bitstampTransactionsPathTextBox);
            this.pathsGroup.Controls.Add(this.bitstampRatesPathLabel);
            this.pathsGroup.Controls.Add(this.bitstampRatesPathButton);
            this.pathsGroup.Controls.Add(this.bitstampTransactionsPathLabel);
            this.pathsGroup.Controls.Add(this.bitstampTransactionsPathButton);
            this.pathsGroup.Controls.Add(this.outputPathTextBox);
            this.pathsGroup.Controls.Add(this.riksbankenRatesPathTextBox);
            this.pathsGroup.Controls.Add(this.outputPathLabel);
            this.pathsGroup.Controls.Add(this.outputPathButton);
            this.pathsGroup.Controls.Add(this.riksbankenRatesPathLabel);
            this.pathsGroup.Controls.Add(this.riksbankenRatesPathButton);
            this.pathsGroup.Location = new System.Drawing.Point(177, 11);
            this.pathsGroup.Margin = new System.Windows.Forms.Padding(2);
            this.pathsGroup.Name = "pathsGroup";
            this.pathsGroup.Padding = new System.Windows.Forms.Padding(2);
            this.pathsGroup.Size = new System.Drawing.Size(448, 194);
            this.pathsGroup.TabIndex = 24;
            this.pathsGroup.TabStop = false;
            this.pathsGroup.Text = "Paths";
            // 
            // bitstampRatesPathTextBox
            // 
            this.bitstampRatesPathTextBox.Location = new System.Drawing.Point(7, 115);
            this.bitstampRatesPathTextBox.Name = "bitstampRatesPathTextBox";
            this.bitstampRatesPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.bitstampRatesPathTextBox.TabIndex = 4;
            this.bitstampRatesPathTextBox.Text = settings.BitstampRatesPath;
            // 
            // bitstampTransactionsPathTextBox
            // 
            this.bitstampTransactionsPathTextBox.Location = new System.Drawing.Point(7, 35);
            this.bitstampTransactionsPathTextBox.Name = "bitstampTransactionsPathTextBox";
            this.bitstampTransactionsPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.bitstampTransactionsPathTextBox.TabIndex = 0;
            this.bitstampTransactionsPathTextBox.Text = settings.BitstampTransactionsPath;
            // 
            // bitstampRatesPathLabel
            // 
            this.bitstampRatesPathLabel.AutoSize = true;
            this.bitstampRatesPathLabel.Location = new System.Drawing.Point(4, 99);
            this.bitstampRatesPathLabel.Name = "bitstampRatesPathLabel";
            this.bitstampRatesPathLabel.Size = new System.Drawing.Size(97, 13);
            this.bitstampRatesPathLabel.TabIndex = 24;
            this.bitstampRatesPathLabel.Text = "Bitstamp rates path";
            // 
            // bitstampRatesPathButton
            // 
            this.bitstampRatesPathButton.Location = new System.Drawing.Point(382, 114);
            this.bitstampRatesPathButton.Name = "bitstampRatesPathButton";
            this.bitstampRatesPathButton.Size = new System.Drawing.Size(60, 22);
            this.bitstampRatesPathButton.TabIndex = 5;
            this.bitstampRatesPathButton.Text = "Browse";
            this.bitstampRatesPathButton.UseVisualStyleBackColor = true;
            this.bitstampRatesPathButton.Click += new System.EventHandler(this.bitstampRatesPathButton_Click);
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
            this.ClientSize = new System.Drawing.Size(634, 318);
            this.Controls.Add(this.years);
            this.Controls.Add(this.pathsGroup);
            this.Controls.Add(this.personalInformationGroup);
            this.Controls.Add(this.executeButton);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.TextBox riksbankenRatesPathTextBox;
        private System.Windows.Forms.Label riksbankenRatesPathLabel;
        private System.Windows.Forms.Button riksbankenRatesPathButton;
        private System.Windows.Forms.Label bitstampTransactionsPathLabel;
        private System.Windows.Forms.Button bitstampTransactionsPathButton;
        private System.Windows.Forms.GroupBox personalInformationGroup;
        private System.Windows.Forms.GroupBox pathsGroup;
        private System.Windows.Forms.Label bitstampRatesPathLabel;
        private System.Windows.Forms.Button bitstampRatesPathButton;
        private System.Windows.Forms.GroupBox years;
        private System.Windows.Forms.CheckBox year2018;
        private System.Windows.Forms.CheckBox year2017;
        private System.Windows.Forms.CheckBox year2016;
        private System.Windows.Forms.CheckBox year2015;
        private System.Windows.Forms.CheckBox year2014;
        private System.Windows.Forms.TextBox bitstampTransactionsPathTextBox;
        private System.Windows.Forms.TextBox bitstampRatesPathTextBox;
    }
}

