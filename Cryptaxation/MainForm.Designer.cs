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
            this.riksbankenRatesPathTextBox = new System.Windows.Forms.TextBox();
            this.riksbankenRatesPathLabel = new System.Windows.Forms.Label();
            this.riksbankenRatesPathButton = new System.Windows.Forms.Button();
            this.BitstampTransactionsPathTextBox = new System.Windows.Forms.TextBox();
            this.BitstampTransactionsPathLabel = new System.Windows.Forms.Label();
            this.bitstampTransactionsPathButton = new System.Windows.Forms.Button();
            this.personalInformationGroup = new System.Windows.Forms.GroupBox();
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.personalIdentificationNumberTextBox = new System.Windows.Forms.TextBox();
            this.PathsGroup = new System.Windows.Forms.GroupBox();
            this.bitstampRatesPathLabel = new System.Windows.Forms.Label();
            this.bitstampRatesPathButton = new System.Windows.Forms.Button();
            this.bitstampRatesPathTextBox = new System.Windows.Forms.TextBox();
            this.personalInformationGroup.SuspendLayout();
            this.PathsGroup.SuspendLayout();
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
            this.executeButton.Location = new System.Drawing.Point(569, 249);
            this.executeButton.Margin = new System.Windows.Forms.Padding(2);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(56, 19);
            this.executeButton.TabIndex = 11;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteClick);
            // 
            // processNameTextBox
            // 
            this.processNameTextBox.Location = new System.Drawing.Point(7, 115);
            this.processNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.processNameTextBox.Name = "processNameTextBox";
            this.processNameTextBox.Size = new System.Drawing.Size(151, 20);
            this.processNameTextBox.TabIndex = 2;
            this.processNameTextBox.Text = global::Cryptaxation.Properties.Settings.Default.ProcessName;
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
            // useTestDataCheckBox
            // 
            this.useTestDataCheckBox.AutoSize = true;
            this.useTestDataCheckBox.Location = new System.Drawing.Point(462, 251);
            this.useTestDataCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.useTestDataCheckBox.Name = "useTestDataCheckBox";
            this.useTestDataCheckBox.Size = new System.Drawing.Size(105, 17);
            this.useTestDataCheckBox.TabIndex = 12;
            this.useTestDataCheckBox.Text = "Use dummy data";
            this.useTestDataCheckBox.UseVisualStyleBackColor = true;
            // 
            // browseK4Button
            // 
            this.browseK4Button.Location = new System.Drawing.Point(386, 155);
            this.browseK4Button.Margin = new System.Windows.Forms.Padding(2);
            this.browseK4Button.Name = "browseK4Button";
            this.browseK4Button.Size = new System.Drawing.Size(56, 19);
            this.browseK4Button.TabIndex = 8;
            this.browseK4Button.Text = "Browse";
            this.browseK4Button.UseVisualStyleBackColor = true;
            this.browseK4Button.Click += new System.EventHandler(this.BrowseK4ButtonClick);
            // 
            // k4PathLabel
            // 
            this.k4PathLabel.AutoSize = true;
            this.k4PathLabel.Location = new System.Drawing.Point(4, 139);
            this.k4PathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.k4PathLabel.Name = "k4PathLabel";
            this.k4PathLabel.Size = new System.Drawing.Size(44, 13);
            this.k4PathLabel.TabIndex = 12;
            this.k4PathLabel.Text = "K4 path";
            // 
            // k4PathTextBox
            // 
            this.k4PathTextBox.Location = new System.Drawing.Point(7, 155);
            this.k4PathTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.k4PathTextBox.Name = "k4PathTextBox";
            this.k4PathTextBox.Size = new System.Drawing.Size(376, 20);
            this.k4PathTextBox.TabIndex = 7;
            this.k4PathTextBox.Text = global::Cryptaxation.Properties.Settings.Default.K4Path;
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(7, 195);
            this.outputPathTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.outputPathTextBox.TabIndex = 9;
            this.outputPathTextBox.Text = global::Cryptaxation.Properties.Settings.Default.OutputPath;
            // 
            // outputPathLabel
            // 
            this.outputPathLabel.AutoSize = true;
            this.outputPathLabel.Location = new System.Drawing.Point(4, 179);
            this.outputPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.outputPathLabel.Name = "outputPathLabel";
            this.outputPathLabel.Size = new System.Drawing.Size(63, 13);
            this.outputPathLabel.TabIndex = 15;
            this.outputPathLabel.Text = "Output path";
            // 
            // outputPathButton
            // 
            this.outputPathButton.Location = new System.Drawing.Point(386, 196);
            this.outputPathButton.Margin = new System.Windows.Forms.Padding(2);
            this.outputPathButton.Name = "outputPathButton";
            this.outputPathButton.Size = new System.Drawing.Size(56, 19);
            this.outputPathButton.TabIndex = 10;
            this.outputPathButton.Text = "Browse";
            this.outputPathButton.UseVisualStyleBackColor = true;
            this.outputPathButton.Click += new System.EventHandler(this.OutputPathButtonClick);
            // 
            // riksbankenRatesPathTextBox
            // 
            this.riksbankenRatesPathTextBox.Location = new System.Drawing.Point(7, 75);
            this.riksbankenRatesPathTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.riksbankenRatesPathTextBox.Name = "riksbankenRatesPathTextBox";
            this.riksbankenRatesPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.riksbankenRatesPathTextBox.TabIndex = 5;
            this.riksbankenRatesPathTextBox.Text = global::Cryptaxation.Properties.Settings.Default.RiksbankenRatesPath;
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
            this.riksbankenRatesPathButton.Location = new System.Drawing.Point(386, 75);
            this.riksbankenRatesPathButton.Margin = new System.Windows.Forms.Padding(2);
            this.riksbankenRatesPathButton.Name = "riksbankenRatesPathButton";
            this.riksbankenRatesPathButton.Size = new System.Drawing.Size(56, 19);
            this.riksbankenRatesPathButton.TabIndex = 6;
            this.riksbankenRatesPathButton.Text = "Browse";
            this.riksbankenRatesPathButton.UseVisualStyleBackColor = true;
            this.riksbankenRatesPathButton.Click += new System.EventHandler(this.RiksbankenRatesPathButtonClick);
            // 
            // BitstampTransactionsPathTextBox
            // 
            this.BitstampTransactionsPathTextBox.Location = new System.Drawing.Point(7, 35);
            this.BitstampTransactionsPathTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.BitstampTransactionsPathTextBox.Name = "BitstampTransactionsPathTextBox";
            this.BitstampTransactionsPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.BitstampTransactionsPathTextBox.TabIndex = 3;
            this.BitstampTransactionsPathTextBox.Text = global::Cryptaxation.Properties.Settings.Default.BitstampTransactionsPath;
            // 
            // BitstampTransactionsPathLabel
            // 
            this.BitstampTransactionsPathLabel.AutoSize = true;
            this.BitstampTransactionsPathLabel.Location = new System.Drawing.Point(4, 19);
            this.BitstampTransactionsPathLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BitstampTransactionsPathLabel.Name = "BitstampTransactionsPathLabel";
            this.BitstampTransactionsPathLabel.Size = new System.Drawing.Size(131, 13);
            this.BitstampTransactionsPathLabel.TabIndex = 21;
            this.BitstampTransactionsPathLabel.Text = "Bitstamp transactions path";
            // 
            // bitstampTransactionsPathButton
            // 
            this.bitstampTransactionsPathButton.Location = new System.Drawing.Point(386, 35);
            this.bitstampTransactionsPathButton.Margin = new System.Windows.Forms.Padding(2);
            this.bitstampTransactionsPathButton.Name = "bitstampTransactionsPathButton";
            this.bitstampTransactionsPathButton.Size = new System.Drawing.Size(56, 19);
            this.bitstampTransactionsPathButton.TabIndex = 4;
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
            this.personalInformationGroup.Size = new System.Drawing.Size(164, 182);
            this.personalInformationGroup.TabIndex = 23;
            this.personalInformationGroup.TabStop = false;
            this.personalInformationGroup.Text = "Personal information";
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(7, 35);
            this.fullNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(151, 20);
            this.fullNameTextBox.TabIndex = 0;
            this.fullNameTextBox.Text = global::Cryptaxation.Properties.Settings.Default.FullName;
            // 
            // personalIdentificationNumberTextBox
            // 
            this.personalIdentificationNumberTextBox.Location = new System.Drawing.Point(7, 75);
            this.personalIdentificationNumberTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.personalIdentificationNumberTextBox.Name = "personalIdentificationNumberTextBox";
            this.personalIdentificationNumberTextBox.Size = new System.Drawing.Size(151, 20);
            this.personalIdentificationNumberTextBox.TabIndex = 1;
            this.personalIdentificationNumberTextBox.Text = global::Cryptaxation.Properties.Settings.Default.PersonalIdentificationNumber;
            // 
            // PathsGroup
            // 
            this.PathsGroup.Controls.Add(this.bitstampRatesPathLabel);
            this.PathsGroup.Controls.Add(this.bitstampRatesPathButton);
            this.PathsGroup.Controls.Add(this.bitstampRatesPathTextBox);
            this.PathsGroup.Controls.Add(this.BitstampTransactionsPathLabel);
            this.PathsGroup.Controls.Add(this.bitstampTransactionsPathButton);
            this.PathsGroup.Controls.Add(this.outputPathTextBox);
            this.PathsGroup.Controls.Add(this.riksbankenRatesPathTextBox);
            this.PathsGroup.Controls.Add(this.outputPathLabel);
            this.PathsGroup.Controls.Add(this.outputPathButton);
            this.PathsGroup.Controls.Add(this.riksbankenRatesPathLabel);
            this.PathsGroup.Controls.Add(this.BitstampTransactionsPathTextBox);
            this.PathsGroup.Controls.Add(this.k4PathTextBox);
            this.PathsGroup.Controls.Add(this.riksbankenRatesPathButton);
            this.PathsGroup.Controls.Add(this.k4PathLabel);
            this.PathsGroup.Controls.Add(this.browseK4Button);
            this.PathsGroup.Location = new System.Drawing.Point(177, 11);
            this.PathsGroup.Margin = new System.Windows.Forms.Padding(2);
            this.PathsGroup.Name = "PathsGroup";
            this.PathsGroup.Padding = new System.Windows.Forms.Padding(2);
            this.PathsGroup.Size = new System.Drawing.Size(448, 234);
            this.PathsGroup.TabIndex = 24;
            this.PathsGroup.TabStop = false;
            this.PathsGroup.Text = "Paths";
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
            this.bitstampRatesPathButton.Location = new System.Drawing.Point(386, 115);
            this.bitstampRatesPathButton.Name = "bitstampRatesPathButton";
            this.bitstampRatesPathButton.Size = new System.Drawing.Size(56, 19);
            this.bitstampRatesPathButton.TabIndex = 23;
            this.bitstampRatesPathButton.Text = "Browse";
            this.bitstampRatesPathButton.UseVisualStyleBackColor = true;
            this.bitstampRatesPathButton.Click += new System.EventHandler(this.bitstampRatesPathButton_Click);
            // 
            // bitstampRatesPathTextBox
            // 
            this.bitstampRatesPathTextBox.Location = new System.Drawing.Point(7, 115);
            this.bitstampRatesPathTextBox.Name = "bitstampRatesPathTextBox";
            this.bitstampRatesPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.bitstampRatesPathTextBox.TabIndex = 22;
            this.bitstampRatesPathTextBox.Text = global::Cryptaxation.Properties.Settings.Default.BitstampRatesPath;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 277);
            this.Controls.Add(this.PathsGroup);
            this.Controls.Add(this.personalInformationGroup);
            this.Controls.Add(this.useTestDataCheckBox);
            this.Controls.Add(this.executeButton);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.TextBox riksbankenRatesPathTextBox;
        private System.Windows.Forms.Label riksbankenRatesPathLabel;
        private System.Windows.Forms.Button riksbankenRatesPathButton;
        private System.Windows.Forms.TextBox BitstampTransactionsPathTextBox;
        private System.Windows.Forms.Label BitstampTransactionsPathLabel;
        private System.Windows.Forms.Button bitstampTransactionsPathButton;
        private System.Windows.Forms.GroupBox personalInformationGroup;
        private System.Windows.Forms.GroupBox PathsGroup;
        private System.Windows.Forms.Label bitstampRatesPathLabel;
        private System.Windows.Forms.Button bitstampRatesPathButton;
        private System.Windows.Forms.TextBox bitstampRatesPathTextBox;
    }
}

