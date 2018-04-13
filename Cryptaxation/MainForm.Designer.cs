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
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.FullNameLabel = new System.Windows.Forms.Label();
            this.PersonNumberLabel = new System.Windows.Forms.Label();
            this.PersonNumberTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Location = new System.Drawing.Point(358, 101);
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.Size = new System.Drawing.Size(100, 22);
            this.FullNameTextBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(611, 338);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FullNameLabel
            // 
            this.FullNameLabel.AutoSize = true;
            this.FullNameLabel.Location = new System.Drawing.Point(358, 78);
            this.FullNameLabel.Name = "FullNameLabel";
            this.FullNameLabel.Size = new System.Drawing.Size(46, 17);
            this.FullNameLabel.TabIndex = 2;
            this.FullNameLabel.Text = "FullNameLabel";
            // 
            // PersonNumberLabel
            // 
            this.PersonNumberLabel.AutoSize = true;
            this.PersonNumberLabel.Location = new System.Drawing.Point(381, 229);
            this.PersonNumberLabel.Name = "PersonNumberLabel";
            this.PersonNumberLabel.Size = new System.Drawing.Size(46, 17);
            this.PersonNumberLabel.TabIndex = 4;
            this.PersonNumberLabel.Text = "PersonNumberLabel";
            // 
            // PersonNumberTextBox
            // 
            this.PersonNumberTextBox.Location = new System.Drawing.Point(381, 252);
            this.PersonNumberTextBox.Name = "PersonNumberTextBox";
            this.PersonNumberTextBox.Size = new System.Drawing.Size(100, 22);
            this.PersonNumberTextBox.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 503);
            this.Controls.Add(this.PersonNumberLabel);
            this.Controls.Add(this.PersonNumberTextBox);
            this.Controls.Add(this.FullNameLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FullNameTextBox);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label FullNameLabel;
        private System.Windows.Forms.Label PersonNumberLabel;
        private System.Windows.Forms.TextBox PersonNumberTextBox;
    }
}

