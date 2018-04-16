using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        private readonly string _originalPdfPath;
        private readonly string _outputPath;
        private readonly string _processName;
        private int _tabIndex;
        private int _numberOfCreatedPdfs;
        private Process _currentPdf;

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        public PdfHelper(string originalPdfPath, string outputPath, string processName)
        {
            _originalPdfPath = originalPdfPath;
            _outputPath = outputPath;
            _processName = processName;
            _tabIndex = 0;
        }

        public void CreateNewPdf()
        {
            _tabIndex = 0;
            _numberOfCreatedPdfs++;
            string newPdfPath = GetPdfPath(_numberOfCreatedPdfs);
            File.Copy(_originalPdfPath, newPdfPath, true);
        }

        public int GetNumberOfCreatedPdfs()
        {
            return _numberOfCreatedPdfs;
        }

        private string GetPdfPath(int number)
        {
            return _outputPath + "\\" + Path.GetFileNameWithoutExtension(_originalPdfPath) + "_" + number + Path.GetExtension(_originalPdfPath);
        }

        public void OpenPdf()
        {
            _currentPdf = Process.Start(GetPdfPath(_numberOfCreatedPdfs));
            Thread.Sleep(5000);
        }

        public void SaveAndClosePdf()
        {
            SendKeys.SendWait("^+s");
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
            SendKeys.SendWait("{ENTER}");
            Thread.Sleep(1000);
            SendKeys.SendWait("y");
            Thread.Sleep(1000);
            SendKeys.SendWait("%{F4}");
        }

        public void WriteText(string text, bool nextField = true)
        {
            SendKeys.SendWait(text);
            if (nextField)
            {
                NextField();
            }
        }

        public void WriteText(decimal text, bool nextField = true)
        {
            SendKeys.SendWait(text.ToString());
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

        public void PreviousField()
        {
            _tabIndex--;
            SendKeys.SendWait("+{TAB}");
        }

        public void GotoField(int tabIndex)
        {
            if (tabIndex > _tabIndex)
            {
                while (_tabIndex < tabIndex)
                {
                    NextField();
                }
            }
            else if (tabIndex < _tabIndex)
            {
                while (_tabIndex > tabIndex)
                {
                    PreviousField();
                }
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
