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
            this.fullNameTextBox = new System.Windows.Forms.TextBox();
            this.fullNameLabel = new System.Windows.Forms.Label();
            this.personNumberLabel = new System.Windows.Forms.Label();
            this.personNumberTextBox = new System.Windows.Forms.TextBox();
            this.executeButton = new System.Windows.Forms.Button();
            this.processNameTextBox = new System.Windows.Forms.TextBox();
            this.processNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fullNameTextBox
            // 
            this.fullNameTextBox.Location = new System.Drawing.Point(358, 101);
            this.fullNameTextBox.Name = "fullNameTextBox";
            this.fullNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.fullNameTextBox.TabIndex = 0;
            // 
            // fullNameLabel
            // 
            this.fullNameLabel.AutoSize = true;
            this.fullNameLabel.Location = new System.Drawing.Point(358, 78);
            this.fullNameLabel.Name = "fullNameLabel";
            this.fullNameLabel.Size = new System.Drawing.Size(69, 17);
            this.fullNameLabel.TabIndex = 2;
            this.fullNameLabel.Text = "Full name";
            // 
            // personNumberLabel
            // 
            this.personNumberLabel.AutoSize = true;
            this.personNumberLabel.Location = new System.Drawing.Point(381, 229);
            this.personNumberLabel.Name = "personNumberLabel";
            this.personNumberLabel.Size = new System.Drawing.Size(105, 17);
            this.personNumberLabel.TabIndex = 4;
            this.personNumberLabel.Text = "Person number";
            // 
            // personNumberTextBox
            // 
            this.personNumberTextBox.Location = new System.Drawing.Point(381, 252);
            this.personNumberTextBox.Name = "personNumberTextBox";
            this.personNumberTextBox.Size = new System.Drawing.Size(100, 22);
            this.personNumberTextBox.TabIndex = 3;
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(611, 338);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(75, 23);
            this.executeButton.TabIndex = 1;
            this.executeButton.Text = "button1";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.execute_Click);
            // 
            // processNameTextBox
            // 
            this.processNameTextBox.Location = new System.Drawing.Point(611, 252);
            this.processNameTextBox.Name = "processNameTextBox";
            this.processNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.processNameTextBox.TabIndex = 7;
            // 
            // processNameLabel
            // 
            this.processNameLabel.AutoSize = true;
            this.processNameLabel.Location = new System.Drawing.Point(611, 229);
            this.processNameLabel.Name = "processNameLabel";
            this.processNameLabel.Size = new System.Drawing.Size(98, 17);
            this.processNameLabel.TabIndex = 8;
            this.processNameLabel.Text = "Process name";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 503);
            this.Controls.Add(this.processNameLabel);
            this.Controls.Add(this.processNameTextBox);
            this.Controls.Add(this.personNumberLabel);
            this.Controls.Add(this.personNumberTextBox);
            this.Controls.Add(this.fullNameLabel);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.fullNameTextBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox fullNameTextBox;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Label fullNameLabel;
        private System.Windows.Forms.Label personNumberLabel;
        private System.Windows.Forms.TextBox personNumberTextBox;
        private System.Windows.Forms.TextBox processNameTextBox;
        private System.Windows.Forms.Label processNameLabel;
    }
}

