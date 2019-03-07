using System;
using System.Collections.Generic;
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
        private readonly string _originalPath;
        private readonly string _outputPath;
        private readonly string _processName;
        private int _tabIndex;
        private int _numberOfTotalCopies;
        private Dictionary<int, int> _numberOfCopies;
        private Process _currentPdf;

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(IntPtr hWnd);

        public PdfLogic(string outputPath, string processName)
        {
            _originalPath = AppDomain.CurrentDomain.BaseDirectory + @"Resources\\K4 original";
            _outputPath = outputPath.TrimEnd('\\');
            _processName = processName;
            _tabIndex = 0;
            _numberOfTotalCopies = 0;
            _numberOfCopies = new Dictionary<int, int>();
        }

        public void CopyPdf(int year)
        {
            if (!_numberOfCopies.ContainsKey(year))
            {
                _numberOfCopies.Add(year, 0);
            }
            _numberOfCopies[year]++;
            string newPdfPath = GetPdfPath(year, _numberOfCopies[year]);
            if (!Directory.Exists(_outputPath + "\\" + year))
            {
                Directory.CreateDirectory(_outputPath + "\\" + year);
            }
            File.Copy(_originalPath + "\\" + year + ".pdf", newPdfPath, true);
            _numberOfTotalCopies++;
        }

        public int GetNumberOfCopies(int? year)
        {
            if (year.HasValue)
            {
                return _numberOfCopies[year.Value];
                
            }
            return _numberOfTotalCopies;
        }

        public string GetPdfPath(int year, int number)
        {
            return _outputPath + "\\" + year + "\\" + year + "_" + number + ".pdf";
        }

        public void OpenPdf(int year, int number)
        {
            _tabIndex = 0;
            _currentPdf = Process.Start(GetPdfPath(year, number));
            Thread.Sleep(10000);
        }

        public void SaveAndClose()
        {
            Thread.Sleep(3000);
            SendKeys.SendWait("%{F4}");
            for (var i = 0; i < _numberOfTotalCopies; i++)
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
    }
}
