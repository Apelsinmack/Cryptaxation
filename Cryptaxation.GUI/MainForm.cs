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
                List<int> years = GetYearsList();
                Logic logic = new Logic(fullNameTextBox.Text, personalIdentificationNumberTextBox.Text, years, bitstampTransactionsPathTextBox.Text, riksbankenRatesPathTextBox.Text, bitstampRatesPathTextBox.Text, outputPathTextBox.Text, processNameTextBox.Text);
                logic.Execute();
                MessageBox.Show("Execution complete.", "Status");
            /*}
            catch (Exception exception)
            {
                MessageBox.Show(exception.StackTrace, exception.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
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

        private void BitstampTransactionsPathButtonClick(object sender, EventArgs e)
        {
            _browseBitstampTransactionsDialog = new OpenFileDialog();
            if (_browseBitstampTransactionsDialog.ShowDialog() == DialogResult.OK)
            {
                bitstampTransactionsPathTextBox.Text = _browseBitstampTransactionsDialog.FileName;
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
            Properties.Settings.Default.BitstampTransactionsPath = bitstampTransactionsPathTextBox.Text;
            Properties.Settings.Default.RiksbankenRatesPath = riksbankenRatesPathTextBox.Text;
            Properties.Settings.Default.BitstampRatesPath = bitstampRatesPathTextBox.Text;
            Properties.Settings.Default.OutputPath = outputPathTextBox.Text;
            Properties.Settings.Default.Save();
        }
    }
}
