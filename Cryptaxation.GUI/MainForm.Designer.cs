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
            this.executeButton = new System.Windows.Forms.Button();
            this.outputPathTextBox = new System.Windows.Forms.TextBox();
            this.outputPathLabel = new System.Windows.Forms.Label();
            this.outputPathButton = new System.Windows.Forms.Button();
            this.fiatRatesPathTextBox = new System.Windows.Forms.TextBox();
            this.fiatRatesPathLabel = new System.Windows.Forms.Label();
            this.fiatRatesPathButton = new System.Windows.Forms.Button();
            this.transactionsPathLabel = new System.Windows.Forms.Label();
            this.transactionsPathButton = new System.Windows.Forms.Button();
            this.pathsGroup = new System.Windows.Forms.GroupBox();
            this.cryptoToFiatRatesPathTextBox = new System.Windows.Forms.TextBox();
            this.transactionsPathTextBox = new System.Windows.Forms.TextBox();
            this.cryptoToFiatRatesPathLabel = new System.Windows.Forms.Label();
            this.cryptoToFiatRatesPathButton = new System.Windows.Forms.Button();
            this.pathsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(404, 209);
            this.executeButton.Margin = new System.Windows.Forms.Padding(2);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(56, 25);
            this.executeButton.TabIndex = 26;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteClick);
            // 
            // outputPathTextBox
            // 
            this.outputPathTextBox.Location = new System.Drawing.Point(7, 155);
            this.outputPathTextBox.Name = "outputPathTextBox";
            this.outputPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.outputPathTextBox.TabIndex = 6;
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
            this.pathsGroup.Location = new System.Drawing.Point(11, 11);
            this.pathsGroup.Margin = new System.Windows.Forms.Padding(2);
            this.pathsGroup.Name = "pathsGroup";
            this.pathsGroup.Padding = new System.Windows.Forms.Padding(2);
            this.pathsGroup.Size = new System.Drawing.Size(449, 194);
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
            // 
            // transactionsPathTextBox
            // 
            this.transactionsPathTextBox.Location = new System.Drawing.Point(7, 35);
            this.transactionsPathTextBox.Name = "transactionsPathTextBox";
            this.transactionsPathTextBox.Size = new System.Drawing.Size(376, 20);
            this.transactionsPathTextBox.TabIndex = 0;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(471, 242);
            this.Controls.Add(this.pathsGroup);
            this.Controls.Add(this.executeButton);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Cryptaxation";
            this.Closed += new System.EventHandler(this.SaveSettings);
            this.pathsGroup.ResumeLayout(false);
            this.pathsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.TextBox outputPathTextBox;
        private System.Windows.Forms.Label outputPathLabel;
        private System.Windows.Forms.Button outputPathButton;
        private System.Windows.Forms.TextBox fiatRatesPathTextBox;
        private System.Windows.Forms.Label fiatRatesPathLabel;
        private System.Windows.Forms.Button fiatRatesPathButton;
        private System.Windows.Forms.Label transactionsPathLabel;
        private System.Windows.Forms.Button transactionsPathButton;
        private System.Windows.Forms.GroupBox pathsGroup;
        private System.Windows.Forms.Label cryptoToFiatRatesPathLabel;
        private System.Windows.Forms.Button cryptoToFiatRatesPathButton;
        private System.Windows.Forms.TextBox transactionsPathTextBox;
        private System.Windows.Forms.TextBox cryptoToFiatRatesPathTextBox;
    }
}

