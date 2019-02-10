using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Cryptaxation.Pdf.Contract;

namespace Cryptaxation.Pdf.Logic
{
    public class PdfLogic : IPdfLogic
    {
        private readonly string _originalPdfPath;
        private readonly string _outputPath;
        private readonly string _processName;
        private int _tabIndex;
        private int _numberOfCopies;
        private Process _currentPdf;

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        public PdfLogic(string originalPdfPath, string outputPath, string processName)
        {
            _originalPdfPath = originalPdfPath;
            _outputPath = outputPath;
            _processName = processName;
            _tabIndex = 0;
            _numberOfCopies = 0;
        }

        public void CopyPdf()
        {
            _tabIndex = 0;
            _numberOfCopies++;
            string newPdfPath = GetPdfPath(_numberOfCopies);
            File.Copy(_originalPdfPath, newPdfPath, true);
        }

        public int GetNumberOfCopies()
        {
            return _numberOfCopies;
        }

        public string GetPdfPath(int number)
        {
            return _outputPath + "\\" + Path.GetFileNameWithoutExtension(_originalPdfPath) + "_" + number + Path.GetExtension(_originalPdfPath);
        }

        public void OpenPdf()
        {
            _currentPdf = Process.Start(GetPdfPath(_numberOfCopies));
            Thread.Sleep(10000);
        }

        public void SaveAndClose()
        {
            SendKeys.SendWait("%{F4}");
            for (int i = 0; i < _numberOfCopies; i++)
            {
                Thread.Sleep(1000);
                SendKeys.SendWait("{ENTER}");
                Thread.Sleep(1000);
                SendKeys.SendWait("{ENTER}");
                Thread.Sleep(1000);
                SendKeys.SendWait("{ENTER}");
                Thread.Sleep(1000);
                SendKeys.SendWait("y");
            }
        }

        public void FillField(string text)
        {
            SendKeys.SendWait(text);
            NextField();
        }

        public void FillField(decimal value)
        {
            SendKeys.SendWait(value.ToString());
            NextField();
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
