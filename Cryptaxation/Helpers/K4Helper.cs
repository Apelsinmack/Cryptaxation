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
        private readonly string _personalIdentificationNumber;
        private List<K4Transaction> _cryptoTransactions;
        private List<K4Transaction> _fiatTransactions;
        private PdfHelper _pdfHelper;
        private int fiatTransactionIndex;
        private int cryptoTransactionIndex;

        public K4Helper(string name, string personalIdentificationNumber, string originalk4Path, string outputPath, string processName, List<K4Transaction> fiatTransactions, List<K4Transaction> cryptoTransactions)
        {
            _name = name;
            _personalIdentificationNumber = personalIdentificationNumber;
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
            _pdfHelper.SaveAndClose();
        }

        private void FillForm()
        {
            _pdfHelper.CreateNewPdf();
            _pdfHelper.OpenPdf();
            FillDate();
            FillNumbering();
            FillName();
            FillPersonalIdentificationNumber();
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

        private void FillPersonalIdentificationNumber()
        {
            _pdfHelper.GotoField(TAB_INDEX_PERSON_NUMBER);
            _pdfHelper.WriteText(_personalIdentificationNumber);
        }

        private void FillCurrencies()
        {
            bool fillSum = false;
            decimal salesPriceSum = 0;
            decimal taxBasisSum = 0;
            int gainSum = 0;
            int lossSum = 0;

            _pdfHelper.GotoField(TAB_INDEX_FIRST_CURRENCY_FIELD);
            for (int i = 0; i < 7 && fiatTransactionIndex < _fiatTransactions.Count; i++)
            {
                _pdfHelper.WriteText(_fiatTransactions[fiatTransactionIndex].Amount);
                _pdfHelper.WriteText(_fiatTransactions[fiatTransactionIndex].Currency);
                _pdfHelper.WriteText(decimal.Round(_fiatTransactions[fiatTransactionIndex].SalesPrice));
                _pdfHelper.WriteText(decimal.Round(_fiatTransactions[fiatTransactionIndex].TaxBasis));
                _pdfHelper.WriteText(((int)_fiatTransactions[fiatTransactionIndex].Gain == 0 ? string.Empty : ((int)_fiatTransactions[fiatTransactionIndex].Gain).ToString()));
                _pdfHelper.WriteText(((int)_fiatTransactions[fiatTransactionIndex].Loss == 0 ? string.Empty : ((int)_fiatTransactions[fiatTransactionIndex].Loss).ToString()));

                salesPriceSum += decimal.Round(_fiatTransactions[fiatTransactionIndex].SalesPrice);
                taxBasisSum += decimal.Round(_fiatTransactions[fiatTransactionIndex].TaxBasis);
                gainSum += (int)_fiatTransactions[fiatTransactionIndex].Gain;
                lossSum += (int)_fiatTransactions[fiatTransactionIndex].Loss;

                fiatTransactionIndex++;
                fillSum = true;
            }

            if (fillSum)
            {
                _pdfHelper.GotoField(TAB_INDEX_FIRST_SUM_CURRENCY_FIELD);
                _pdfHelper.WriteText(decimal.Round(salesPriceSum));
                _pdfHelper.WriteText(decimal.Round(taxBasisSum));
                _pdfHelper.WriteText(gainSum == 0 ? string.Empty : gainSum.ToString());
                _pdfHelper.WriteText(lossSum == 0 ? string.Empty : lossSum.ToString());
            }
        }

        private void FillResources()
        {
            bool fillSum = false;
            decimal salesPriceSum = 0;
            decimal taxBasisSum = 0;
            int gainSum = 0;
            int lossSum = 0;

            _pdfHelper.GotoField(TAB_INDEX_FIRST_RESOURCE_FIELD);
            for (int i = 0; i < 7 && cryptoTransactionIndex < _cryptoTransactions.Count; i++)
            {
                _pdfHelper.WriteText(_cryptoTransactions[cryptoTransactionIndex].Amount);
                _pdfHelper.WriteText(_cryptoTransactions[cryptoTransactionIndex].Currency);
                _pdfHelper.WriteText(decimal.Round(_cryptoTransactions[cryptoTransactionIndex].SalesPrice));
                _pdfHelper.WriteText(decimal.Round(_cryptoTransactions[cryptoTransactionIndex].TaxBasis));
                _pdfHelper.WriteText(((int)_cryptoTransactions[cryptoTransactionIndex].Gain == 0 ? string.Empty : ((int)_cryptoTransactions[cryptoTransactionIndex].Gain).ToString()));
                _pdfHelper.WriteText(((int)_cryptoTransactions[cryptoTransactionIndex].Loss == 0 ? string.Empty : ((int)_cryptoTransactions[cryptoTransactionIndex].Loss).ToString()));

                salesPriceSum += _cryptoTransactions[cryptoTransactionIndex].SalesPrice;
                taxBasisSum += _cryptoTransactions[cryptoTransactionIndex].TaxBasis;
                gainSum += (int)_cryptoTransactions[cryptoTransactionIndex].Gain;
                lossSum += (int)_cryptoTransactions[cryptoTransactionIndex].Loss;

                cryptoTransactionIndex++;

                fillSum = true;
            }

            if (fillSum)
            {
                _pdfHelper.GotoField(TAB_INDEX_FIRST_SUM_RESOURCE_FIELD);
                _pdfHelper.WriteText(decimal.Round(salesPriceSum));
                _pdfHelper.WriteText(decimal.Round(taxBasisSum));
                _pdfHelper.WriteText(gainSum == 0 ? string.Empty : gainSum.ToString());
                _pdfHelper.WriteText(lossSum == 0 ? string.Empty : lossSum.ToString());
            }
        }
    }
}
