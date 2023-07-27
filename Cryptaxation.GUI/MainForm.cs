using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Cryptaxation.GUI
{
    public partial class MainForm : Form
    {
        private OpenFileDialog _browseFiatRatesDialog;
        private OpenFileDialog _browseCryptoToFiatRatesDialog;
        private OpenFileDialog _browseTransactionsDialog;
        private FolderBrowserDialog _browseOutputDialog;

        public MainForm()
        {
            InitializeComponent();
            SetLastUsedValues();
        }

        private void SetLastUsedValues()
        {
            transactionsPathTextBox.Text = Properties.Settings.Default.TransactionsPath;
            fiatRatesPathTextBox.Text = Properties.Settings.Default.FiatRatesPath;
            cryptoToFiatRatesPathTextBox.Text = Properties.Settings.Default.CryptoToFiatRatesPath;
            outputPathTextBox.Text= Properties.Settings.Default.OutputPath;
        }

        private void ExecuteClick(object sender, EventArgs e)
        {
            Thread thread = new Thread(Execute);
            thread.Start();
        }

        private void Execute()
        {
            Logic logic = new Logic(transactionsPathTextBox.Text, fiatRatesPathTextBox.Text, cryptoToFiatRatesPathTextBox.Text, outputPathTextBox.Text);
            logic.Execute();
            MessageBox.Show("Execution complete.", "Status");
        }

        private void TransactionsPathButtonClick(object sender, EventArgs e)
        {
            _browseTransactionsDialog = new OpenFileDialog();
            if (_browseTransactionsDialog.ShowDialog() == DialogResult.OK)
            {
                transactionsPathTextBox.Text = _browseTransactionsDialog.FileName;
            }
        }

        private void FiatRatesPathButtonClick(object sender, EventArgs e)
        {
            _browseFiatRatesDialog = new OpenFileDialog();
            if (_browseFiatRatesDialog.ShowDialog() == DialogResult.OK)
            {
                fiatRatesPathTextBox.Text = _browseFiatRatesDialog.FileName;
            }
        }

        private void cryptoToFiatRatesPathButton_Click(object sender, EventArgs e)
        {
            _browseCryptoToFiatRatesDialog = new OpenFileDialog();
            if (_browseCryptoToFiatRatesDialog.ShowDialog() == DialogResult.OK)
            {
                cryptoToFiatRatesPathTextBox.Text = _browseCryptoToFiatRatesDialog.FileName;
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
            Properties.Settings.Default.TransactionsPath = transactionsPathTextBox.Text;
            Properties.Settings.Default.FiatRatesPath = fiatRatesPathTextBox.Text;
            Properties.Settings.Default.CryptoToFiatRatesPath = cryptoToFiatRatesPathTextBox.Text;
            Properties.Settings.Default.OutputPath = outputPathTextBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
