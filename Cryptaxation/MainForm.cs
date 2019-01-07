using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptaxation
{
    public partial class MainForm : Form
    {
        private OpenFileDialog _browseK4Dialog;
        private OpenFileDialog _browseRiksbankenRatesDialog;
        private OpenFileDialog _browseBitstampRatesDialog;
        private OpenFileDialog _browseBitstampTransactionsDialog;
        private FolderBrowserDialog _browseOutputDialog;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ExecuteClick(object sender, EventArgs e)
        {
            Thread thread = new Thread(Execute);
            thread.Start();
        }

        private void Execute()
        {
            /*try
            {*/
                Logic logic = new Logic(fullNameTextBox.Text, personalIdentificationNumberTextBox.Text, BitstampTransactionsPathTextBox.Text, riksbankenRatesPathTextBox.Text, bitstampRatesPathTextBox.Text, k4PathTextBox.Text, outputPathTextBox.Text, processNameTextBox.Text);
                logic.Execute(useTestDataCheckBox.Checked);
                MessageBox.Show("Execution complete.", "Status");
            /*}
            catch (Exception exception)
            {
                MessageBox.Show(exception.StackTrace, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

        }

        private void BitstampTransactionsPathButtonClick(object sender, EventArgs e)
        {
            _browseBitstampTransactionsDialog = new OpenFileDialog();
            if (_browseBitstampTransactionsDialog.ShowDialog() == DialogResult.OK)
            {
                BitstampTransactionsPathTextBox.Text = _browseBitstampTransactionsDialog.FileName;
            }
        }

        private void RiksbankenRatesPathButtonClick(object sender, EventArgs e)
        {
            _browseRiksbankenRatesDialog = new OpenFileDialog();
            if (_browseRiksbankenRatesDialog.ShowDialog() == DialogResult.OK)
            {
                riksbankenRatesPathTextBox.Text = _browseRiksbankenRatesDialog.FileName;
            }
        }

        private void bitstampRatesPathButton_Click(object sender, EventArgs e)
        {
            _browseBitstampRatesDialog = new OpenFileDialog();
            if (_browseBitstampRatesDialog.ShowDialog() == DialogResult.OK)
            {
                bitstampRatesPathTextBox.Text = _browseBitstampRatesDialog.FileName;
            }
        }

        private void BrowseK4ButtonClick(object sender, EventArgs e)
        {
            _browseK4Dialog = new OpenFileDialog();
            if (_browseK4Dialog.ShowDialog() == DialogResult.OK)
            {
                k4PathTextBox.Text = _browseK4Dialog.FileName;
            }
        }

        private void OutputPathButtonClick(object sender, EventArgs e)
        {
            _browseOutputDialog = new FolderBrowserDialog();
            if (_browseOutputDialog.ShowDialog() == DialogResult.OK)
            {
                outputPathTextBox.Text = _browseOutputDialog.SelectedPath;
            }
        }

        private void SaveSettings(object sender, EventArgs e)
        {
            Properties.Settings.Default.FullName = fullNameTextBox.Text;
            Properties.Settings.Default.PersonalIdentificationNumber = personalIdentificationNumberTextBox.Text;
            Properties.Settings.Default.ProcessName = processNameTextBox.Text;
            Properties.Settings.Default.BitstampTransactionsPath = BitstampTransactionsPathTextBox.Text;
            Properties.Settings.Default.RiksbankenRatesPath = riksbankenRatesPathTextBox.Text;
            Properties.Settings.Default.BitstampRatesPath = bitstampRatesPathTextBox.Text;
            Properties.Settings.Default.OutputPath = outputPathTextBox.Text;
            Properties.Settings.Default.K4Path = k4PathTextBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
