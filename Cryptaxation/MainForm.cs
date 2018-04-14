using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptaxation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void execute_Click(object sender, EventArgs e)
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory;
            Logic logic = new Logic(fullNameTextBox.Text, personNumberTextBox.Text, @"C:\Test\Bitstamp transactions to 20180119.csv", @"C:\Test\", @"C:\Test\2017.pdf", @"C:\Test\output", processNameTextBox.Text);
            logic.Execute();
        }
    }
}
