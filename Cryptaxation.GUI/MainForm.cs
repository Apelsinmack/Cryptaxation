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
        }

        private void ExecuteClick(object sender, EventArgs e)
        {
            Thread thread = new Thread(Execute);
            thread.Start();
        }

        private void Execute()
        {
#if RELEASE
            try
            {
#endif
                List<int> years = GetYearsList();
                Logic logic = new Logic(fullNameTextBox.Text, personalIdentificationNumberTextBox.Text, years, transactionsPathTextBox.Text, fiatRatesPathTextBox.Text, cryptoToFiatRatesPathTextBox.Text, outputPathTextBox.Text, processNameTextBox.Text);
                logic.Execute();
                MessageBox.Show("Execution complete.", "Status");
#if RELEASE
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.StackTrace, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
#endif
        }

        private List<int> GetYearsList()
        {
            List<int> returnYears = new List<int>();
            foreach (Control year in years.Controls)
            {
                if(year is CheckBox) {
                    if (((CheckBox) year).Checked)
                    {
                        try
                        {
                            returnYears.Add(Convert.ToInt32(year.Name.Substring(4)));
                        }
                        catch
                        {
                            throw new Exception("Invalid year ChecBox name. Must have format yearYYYY");
                        }
                    }
                }
            }
            return returnYears.OrderBy(y => y).ToList();
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
            Properties.Settings.Default.FullName = fullNameTextBox.Text;
            Properties.Settings.Default.PersonalIdentificationNumber = personalIdentificationNumberTextBox.Text;
            Properties.Settings.Default.ProcessName = processNameTextBox.Text;
            Properties.Settings.Default.TransactionsPath = transactionsPathTextBox.Text;
            Properties.Settings.Default.FiatRatesPath = fiatRatesPathTextBox.Text;
            Properties.Settings.Default.CryptoToFiatRatesPath = cryptoToFiatRatesPathTextBox.Text;
            Properties.Settings.Default.OutputPath = outputPathTextBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
