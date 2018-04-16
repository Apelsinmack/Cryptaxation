namespace Cryptaxation
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
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.personalIdentificationNumberLabel = new System.Windows.Forms.Label();
            this.executeButton = new System.Windows.Forms.Button();
            this.processNameTextBox = new System.Windows.Forms.TextBox();
            this.processNameLabel = new System.Windows.Forms.Label();
            this.useTestDataCheckBox = new System.Windows.Forms.CheckBox();
            this.browseK4Button = new System.Windows.Forms.Button();
            this.k4PathLabel = new System.Windows.Forms.Label();
            this.k4PathTextBox = new System.Windows.Forms.TextBox();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.outputPathLabel = new System.Windows.Forms.Label();
            this.outputPathButton = new System.Windows.Forms.Button();
            this.ratesPathTextBox = new System.Windows.Forms.TextBox();
            this.ratesPathLabel = new System.Windows.Forms.Label();
            this.ratesPathButton = new System.Windows.Forms.Button();
            this.BitstampTransactionsPathTextBox = new System.Windows.Forms.TextBox();
            this.BitstampTransactionsPathLabel = new System.Windows.Forms.Label();
            this.bitstampTransactionsPathButton = new System.Windows.Forms.Button();
            this.personalInformationGroup = new System.Windows.Forms.GroupBox();
            this.PathsGroup = new System.Windows.Forms.GroupBox();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.personalIdentificationNumberTextBox = new System.Windows.Forms.TextBox();
            this.personalInformationGroup.SuspendLayout();
            this.PathsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.AutoSize = true;
            this.fullNameLabel.Location = new System.Drawing.Point(6, 23);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(69, 17);
            this.fullNameLabel.TabIndex = 2;
            this.fullNameLabel.Text = "Full name";
            // 
            // personalIdentificationNumberLabel
            // 
            this.personalIdentificationNumberLabel.AutoSize = true;
            this.personalIdentificationNumberLabel.Location = new System.Drawing.Point(6, 73);
            this.personalIdentificationNumberLabel.Name = "personalIdentificationNumberLabel";
            this.personalIdentificationNumberLabel.Size = new System.Drawing.Size(199, 17);
            this.personalIdentificationNumberLabel.TabIndex = 4;
            this.personalIdentificationNumberLabel.Text = "Personal identification number";
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(758, 254);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(75, 23);
            this.executeButton.TabIndex = 11;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteClick);
            // 
            // processNameTextBox
            // 
            this.processNameTextBox.Location = new System.Drawing.Point(9, 143);
            this.processNameTextBox.Name = "processNameTextBox";
            this.processNameTextBox.Size = new System.Drawing.Size(200, 22);
            this.processNameTextBox.TabIndex = 2;
            this.processNameTextBox.Text = global::Cryptaxation.Properties.Settings.Default.ProcessName;
            // 
            // processNameLabel
            // 
            this.processNameLabel.AutoSize = true;
            this.processNameLabel.Location = new System.Drawing.Point(6, 123);
            this.processNameLabel.Name = "processNameLabel";
            this.processNameLabel.Size = new System.Drawing.Size(98, 17);
            this.processNameLabel.TabIndex = 8;
            this.processNameLabel.Text = "Process name";
            // 
            // useTestDataCheckBox
            // 
            this.useTestDataCheckBox.AutoSize = true;
            this.useTestDataCheckBox.Location = new System.Drawing.Point(616, 256);
            this.useTestDataCheckBox.Name = "useTestDataCheckBox";
            this.useTestDataCheckBox.Size = new System.Drawing.Size(136, 21);
            this.useTestDataCheckBox.TabIndex = 12;
            this.useTestDataCheckBox.Text = "Use dummy data";
            this.useTestDataCheckBox.UseVisualStyleBackColor = true;
            // 
            // browseK4Button
            // 
            this.browseK4Button.Location = new System.Drawing.Point(515, 143);
            this.browseK4Button.Name = "browseK4Button";
            this.browseK4Button.Size = new System.Drawing.Size(75, 23);
            this.browseK4Button.TabIndex = 8;
            this.browseK4Button.Text = "Browse K4";
            this.browseK4Button.UseVisualStyleBackColor = true;
            this.browseK4Button.Click += new System.EventHandler(this.BrowseK4ButtonClick);
            // 
            // k4PathLabel
            // 
            this.k4PathLabel.AutoSize = true;
            this.k4PathLabel.Location = new System.Drawing.Point(6, 123);
            this.k4PathLabel.Name = "k4PathLabel";
            this.k4PathLabel.Size = new System.Drawing.Size(57, 17);
            this.k4PathLabel.TabIndex = 12;
            this.k4PathLabel.Text = "K4 path";
            // 
            // k4PathTextBox
            // 
            this.k4PathTextBox.Location = new System.Drawing.Point(9, 143);
            this.k4PathTextBox.Name = "k4PathTextBox";
            this.k4PathTextBox.Size = new System.Drawing.Size(500, 22);
            this.k4PathTextBox.TabIndex = 7;
            this.k4PathTextBox.Text = global::Cryptaxation.Properties.Settings.Default.K4Path;
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(9, 193);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(500, 22);
            this.outputPathTextBox.TabIndex = 9;
            this.outputPathTextBox.Text = global::Cryptaxation.Properties.Settings.Default.OutputPath;
            // 
            // outputPathLabel
            // 
            this.outputPathLabel.AutoSize = true;
            this.outputPathLabel.Location = new System.Drawing.Point(6, 173);
            this.outputPathLabel.Name = "outputPathLabel";
            this.outputPathLabel.Size = new System.Drawing.Size(83, 17);
            this.outputPathLabel.TabIndex = 15;
            this.outputPathLabel.Text = "Output path";
            // 
            // outputPathButton
            // 
            this.outputPathButton.Location = new System.Drawing.Point(515, 195);
            this.outputPathButton.Name = "outputPathButton";
            this.outputPathButton.Size = new System.Drawing.Size(75, 23);
            this.outputPathButton.TabIndex = 10;
            this.outputPathButton.Text = "Browse K4";
            this.outputPathButton.UseVisualStyleBackColor = true;
            this.outputPathButton.Click += new System.EventHandler(this.OutputPathButtonClick);
            // 
            // ratesPathTextBox
            // 
            this.ratesPathTextBox.Location = new System.Drawing.Point(9, 93);
            this.ratesPathTextBox.Name = "ratesPathTextBox";
            this.ratesPathTextBox.Size = new System.Drawing.Size(500, 22);
            this.ratesPathTextBox.TabIndex = 5;
            this.ratesPathTextBox.Text = global::Cryptaxation.Properties.Settings.Default.RatesPath;
            // 
            // ratesPathLabel
            // 
            this.ratesPathLabel.AutoSize = true;
            this.ratesPathLabel.Location = new System.Drawing.Point(6, 73);
            this.ratesPathLabel.Name = "ratesPathLabel";
            this.ratesPathLabel.Size = new System.Drawing.Size(77, 17);
            this.ratesPathLabel.TabIndex = 18;
            this.ratesPathLabel.Text = "Rates path";
            // 
            // ratesPathButton
            // 
            this.ratesPathButton.Location = new System.Drawing.Point(515, 93);
            this.ratesPathButton.Name = "ratesPathButton";
            this.ratesPathButton.Size = new System.Drawing.Size(75, 23);
            this.ratesPathButton.TabIndex = 6;
            this.ratesPathButton.Text = "Browse K4";
            this.ratesPathButton.UseVisualStyleBackColor = true;
            this.ratesPathButton.Click += new System.EventHandler(this.RatesPathButtonClick);
            // 
            // BitstampTransactionsPathTextBox
            // 
            this.BitstampTransactionsPathTextBox.Location = new System.Drawing.Point(9, 43);
            this.BitstampTransactionsPathTextBox.Name = "BitstampTransactionsPathTextBox";
            this.BitstampTransactionsPathTextBox.Size = new System.Drawing.Size(500, 22);
            this.BitstampTransactionsPathTextBox.TabIndex = 3;
            this.BitstampTransactionsPathTextBox.Text = global::Cryptaxation.Properties.Settings.Default.BitstampTransactionsPath;
            // 
            // BitstampTransactionsPathLabel
            // 
            this.BitstampTransactionsPathLabel.AutoSize = true;
            this.BitstampTransactionsPathLabel.Location = new System.Drawing.Point(6, 23);
            this.BitstampTransactionsPathLabel.Name = "BitstampTransactionsPathLabel";
            this.BitstampTransactionsPathLabel.Size = new System.Drawing.Size(175, 17);
            this.BitstampTransactionsPathLabel.TabIndex = 21;
            this.BitstampTransactionsPathLabel.Text = "Bitstamp transactions path";
            // 
            // bitstampTransactionsPathButton
            // 
            this.bitstampTransactionsPathButton.Location = new System.Drawing.Point(515, 43);
            this.bitstampTransactionsPathButton.Name = "bitstampTransactionsPathButton";
            this.bitstampTransactionsPathButton.Size = new System.Drawing.Size(75, 23);
            this.bitstampTransactionsPathButton.TabIndex = 4;
            this.bitstampTransactionsPathButton.Text = "Browse K4";
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
            this.personalInformationGroup.Location = new System.Drawing.Point(12, 14);
            this.personalInformationGroup.Name = "personalInformationGroup";
            this.personalInformationGroup.Size = new System.Drawing.Size(218, 224);
            this.personalInformationGroup.TabIndex = 23;
            this.personalInformationGroup.TabStop = false;
            this.personalInformationGroup.Text = "Personal information";
            // 
            // PathsGroup
            // 
            this.PathsGroup.Controls.Add(this.BitstampTransactionsPathLabel);
            this.PathsGroup.Controls.Add(this.bitstampTransactionsPathButton);
            this.PathsGroup.Controls.Add(this.outputPathTextBox);
            this.PathsGroup.Controls.Add(this.ratesPathTextBox);
            this.PathsGroup.Controls.Add(this.outputPathLabel);
            this.PathsGroup.Controls.Add(this.outputPathButton);
            this.PathsGroup.Controls.Add(this.ratesPathLabel);
            this.PathsGroup.Controls.Add(this.BitstampTransactionsPathTextBox);
            this.PathsGroup.Controls.Add(this.k4PathTextBox);
            this.PathsGroup.Controls.Add(this.ratesPathButton);
            this.PathsGroup.Controls.Add(this.k4PathLabel);
            this.PathsGroup.Controls.Add(this.browseK4Button);
            this.PathsGroup.Location = new System.Drawing.Point(236, 14);
            this.PathsGroup.Name = "PathsGroup";
            this.PathsGroup.Size = new System.Drawing.Size(597, 224);
            this.PathsGroup.TabIndex = 24;
            this.PathsGroup.TabStop = false;
            this.PathsGroup.Text = "Paths";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(9, 43);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(200, 22);
            this.fullNameTextBox.TabIndex = 0;
            this.fullNameTextBox.Text = global::Cryptaxation.Properties.Settings.Default.FullName;
            // 
            // personalIdentificationNumberTextBox
            // 
            this.personalIdentificationNumberTextBox.Location = new System.Drawing.Point(9, 93);
            this.personalIdentificationNumberTextBox.Name = "personalIdentificationNumberTextBox";
            this.personalIdentificationNumberTextBox.Size = new System.Drawing.Size(200, 22);
            this.personalIdentificationNumberTextBox.TabIndex = 1;
            this.personalIdentificationNumberTextBox.Text = global::Cryptaxation.Properties.Settings.Default.PersonalIdentificationNumber;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 295);
            this.Controls.Add(this.PathsGroup);
            this.Controls.Add(this.personalInformationGroup);
            this.Controls.Add(this.useTestDataCheckBox);
            this.Controls.Add(this.executeButton);
            this.Name = "MainForm";
            this.Text = "Cryptaxation";
            this.Closed += new System.EventHandler(this.SaveSettings);
            this.personalInformationGroup.ResumeLayout(false);
            this.personalInformationGroup.PerformLayout();
            this.PathsGroup.ResumeLayout(false);
            this.PathsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Label fullNameLabel;
        private System.Windows.Forms.Label personalIdentificationNumberLabel;
        private System.Windows.Forms.TextBox personalIdentificationNumberTextBox;
        private System.Windows.Forms.TextBox processNameTextBox;
        private System.Windows.Forms.Label processNameLabel;
        private System.Windows.Forms.CheckBox useTestDataCheckBox;
        private System.Windows.Forms.Button browseK4Button;
        private System.Windows.Forms.Label k4PathLabel;
        private System.Windows.Forms.TextBox k4PathTextBox;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Label outputPathLabel;
        private System.Windows.Forms.Button outputPathButton;
        private System.Windows.Forms.TextBox ratesPathTextBox;
        private System.Windows.Forms.Label ratesPathLabel;
        private System.Windows.Forms.Button ratesPathButton;
        private System.Windows.Forms.TextBox BitstampTransactionsPathTextBox;
        private System.Windows.Forms.Label BitstampTransactionsPathLabel;
        private System.Windows.Forms.Button bitstampTransactionsPathButton;
        private System.Windows.Forms.GroupBox personalInformationGroup;
        private System.Windows.Forms.GroupBox PathsGroup;
    }
}

