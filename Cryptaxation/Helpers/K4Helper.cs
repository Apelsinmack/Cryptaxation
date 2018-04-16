using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cryptaxation.Helpers
{
    public class K4Helper
    {
        private const int TAB_INDEX_DATE = 1;
        private const int TAB_INDEX_NUMBERING = 2;
        private const int TAB_INDEX_NAME = 3;
        private const int TAB_INDEX_PERSON_NUMBER = 4;
        private const int TAB_INDEX_FIRST_CURRENCY_FIELD = 65;
        private const int TAB_INDEX_FIRST_SUM_CURRENCY_FIELD = 107;
        private const int TAB_INDEX_FIRST_RESOURCE_FIELD = 111;
        private const int TAB_INDEX_FIRST_SUM_RESOURCE_FIELD = 153;

        private readonly string _name;
        private readonly string _personNumber;
        private List<K4Transaction> _cryptoTransactions;
        private List<K4Transaction> _fiatTransactions;
        private PdfHelper _pdfHelper;
        private int fiatTransactionIndex;
        private int cryptoTransactionIndex;

        public K4Helper(string name, string personNumber, string originalk4Path, string outputPath, string processName, List<K4Transaction> fiatTransactions, List<K4Transaction> cryptoTransactions)
        {
            _name = name;
            _personNumber = personNumber;
            _cryptoTransactions = cryptoTransactions;
            _fiatTransactions = fiatTransactions;
            _pdfHelper = new PdfHelper(originalk4Path, outputPath, processName);
            fiatTransactionIndex = 0;
            cryptoTransactionIndex = 0;
        }

        public void FillForms()
        {
            while (fiatTransactionIndex < _fiatTransactions.Count || cryptoTransactionIndex < _cryptoTransactions.Count)
            {
                FillForm();
            }
        }

        private void FillForm()
        {
            _pdfHelper.CreateNewPdf();
            _pdfHelper.OpenPdf();
            FillDate();
            FillNumbering();
            FillName();
            FillPersonNumber();
            FillCurrencies();
            FillResources();
        }

        private void FillDate()
        {
            _pdfHelper.GotoField(TAB_INDEX_DATE);
            _pdfHelper.WriteText(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private void FillNumbering()
        {
            _pdfHelper.GotoField(TAB_INDEX_NUMBERING);
            _pdfHelper.WriteText(_pdfHelper.GetNumberOfCreatedPdfs().ToString());
        }

        private void FillName()
        {
            _pdfHelper.GotoField(TAB_INDEX_NAME);
            _pdfHelper.WriteText(_name);
        }

        private void FillPersonNumber()
        {
            _pdfHelper.GotoField(TAB_INDEX_PERSON_NUMBER);
            _pdfHelper.WriteText(_personNumber);
        }

        private void FillCurrencies()
        {
            bool fillSum = false;
            decimal salesPriceSum = 0;
            decimal taxBasisSum = 0;
            decimal gainSum = 0;
            decimal lossSum = 0;

            _pdfHelper.GotoField(TAB_INDEX_FIRST_CURRENCY_FIELD);
            for (int i = 0; i < 7 && fiatTransactionIndex < _fiatTransactions.Count; i++)
            {
                _pdfHelper.WriteText(_fiatTransactions[fiatTransactionIndex].Amount);
                _pdfHelper.WriteText(_fiatTransactions[fiatTransactionIndex].Currency);
                _pdfHelper.WriteText(_fiatTransactions[fiatTransactionIndex].SalesPrice);
                _pdfHelper.WriteText(_fiatTransactions[fiatTransactionIndex].TaxBasis);
                _pdfHelper.WriteText(_fiatTransactions[fiatTransactionIndex].Gain);
                _pdfHelper.WriteText(_fiatTransactions[fiatTransactionIndex].Loss);

                salesPriceSum += _fiatTransactions[fiatTransactionIndex].SalesPrice;
                taxBasisSum += _fiatTransactions[fiatTransactionIndex].TaxBasis;
                gainSum += _fiatTransactions[fiatTransactionIndex].Gain;
                lossSum += _fiatTransactions[fiatTransactionIndex].Loss;

                fiatTransactionIndex++;
                fillSum = true;
            }

            if (fillSum)
            {
                _pdfHelper.GotoField(TAB_INDEX_FIRST_SUM_CURRENCY_FIELD);
                _pdfHelper.WriteText(salesPriceSum);
                _pdfHelper.WriteText(taxBasisSum);
                _pdfHelper.WriteText(gainSum);
                _pdfHelper.WriteText(lossSum);
            }
        }

        private void FillResources()
        {
            bool fillSum = false;
            decimal salesPriceSum = 0;
            decimal taxBasisSum = 0;
            decimal gainSum = 0;
            decimal lossSum = 0;

            _pdfHelper.GotoField(TAB_INDEX_FIRST_RESOURCE_FIELD);
            for (int i = 0; i < 7 && cryptoTransactionIndex < _cryptoTransactions.Count; i++)
            {
                _pdfHelper.WriteText(_cryptoTransactions[cryptoTransactionIndex].Amount);
                _pdfHelper.WriteText(_cryptoTransactions[cryptoTransactionIndex].Currency);
                _pdfHelper.WriteText(_cryptoTransactions[cryptoTransactionIndex].SalesPrice);
                _pdfHelper.WriteText(_cryptoTransactions[cryptoTransactionIndex].TaxBasis);
                _pdfHelper.WriteText(_cryptoTransactions[cryptoTransactionIndex].Gain);
                _pdfHelper.WriteText(_cryptoTransactions[cryptoTransactionIndex].Loss);

                salesPriceSum += _cryptoTransactions[cryptoTransactionIndex].SalesPrice;
                taxBasisSum += _cryptoTransactions[cryptoTransactionIndex].TaxBasis;
                gainSum += _cryptoTransactions[cryptoTransactionIndex].Gain;
                lossSum += _cryptoTransactions[cryptoTransactionIndex].Loss;

                cryptoTransactionIndex++;

                fillSum = true;
            }

            if (fillSum)
            {
                _pdfHelper.GotoField(TAB_INDEX_FIRST_SUM_RESOURCE_FIELD);
                _pdfHelper.WriteText(salesPriceSum);
                _pdfHelper.WriteText(taxBasisSum);
                _pdfHelper.WriteText(gainSum);
                _pdfHelper.WriteText(lossSum);
            }
        }
    }
}
