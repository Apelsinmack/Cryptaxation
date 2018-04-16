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
        private OpenFileDialog _browseRatesDialog;
        private OpenFileDialog _browseBitstampTransactionsDialog;
        private FolderBrowserDialog _browseOutputDialog;

        public MainForm()
        {
            InitializeComponent();
            outputPathTextBox.Text = AppDomain.CurrentDomain.BaseDirectory + "output";
        }

        private void execute_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(Execute);
            thread.Start();
        }

        private void Execute()
        {
            try
            {
                Logic logic = new Logic(fullNameTextBox.Text, personNumberTextBox.Text, BitstampTransactionsPathTextBox.Text, ratesPathTextBox.Text, k4PathTextBox.Text, outputPathTextBox.Text, processNameTextBox.Text);
                logic.Execute(useTestDataCheckBox.Checked);
                MessageBox.Show("Execution complete.", "Status");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.StackTrace, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bitstampTransactionsPathButton_Click(object sender, EventArgs e)
        {
            _browseBitstampTransactionsDialog = new OpenFileDialog();
            if (_browseBitstampTransactionsDialog.ShowDialog() == DialogResult.OK)
            {
                BitstampTransactionsPathTextBox.Text = _browseBitstampTransactionsDialog.FileName;
            }
        }

        private void ratesPathButton_Click(object sender, EventArgs e)
        {
            _browseRatesDialog = new OpenFileDialog();
            if (_browseRatesDialog.ShowDialog() == DialogResult.OK)
            {
                ratesPathTextBox.Text = _browseRatesDialog.FileName;
            }
        }

        private void browseK4Button_Click(object sender, EventArgs e)
        {
            _browseK4Dialog = new OpenFileDialog();
            if (_browseK4Dialog.ShowDialog() == DialogResult.OK)
            {
                k4PathTextBox.Text = _browseK4Dialog.FileName;
            }
        }

        private void outputPathButton_Click(object sender, EventArgs e)
        {
            _browseOutputDialog = new FolderBrowserDialog();
            if (_browseOutputDialog.ShowDialog() == DialogResult.OK)
            {
                outputPathTextBox.Text = _browseOutputDialog.SelectedPath;
            }
        }
    }
}
