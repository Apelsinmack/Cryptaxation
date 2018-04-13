using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cryptaxation
{
    public class PdfHelper
    {
        private string _processName;
        private int _tabIndex;

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        public PdfHelper(string processName)
        {
            _processName = processName;
            _tabIndex = 0;
        }

        public void CreateNewPdf()
        {
        }

        public void AddText(string text, bool nextField = true)
        {
            SendKeys.SendWait(text);
            if (nextField)
            {
                NextField();
            }
        }

        public void NextField()
        {
            _tabIndex++;
            SendKeys.SendWait("{TAB}");
        }

        public void GotoField(int field)
        {
            for (int i = 0; i < field; i++)
            {
                NextField();
            }
        }

        public void FocusAdobeReader()
        {
            Process[] processes = Process.GetProcessesByName(_processName);

            foreach (Process proc in processes)
            {
                SetForegroundWindow(proc.MainWindowHandle);
                Thread.Sleep(5000);
            }
        }
    }
}
