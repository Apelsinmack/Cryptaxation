using System;
using System.Collections.Generic;
using Cryptaxation.Pdf.Logic;

namespace Cryptaxation.Helpers
{
    public class K4Helper
    {
        private const int TAB_INDEX_DATE = 1;
        private const int TAB_INDEX_NUMBERING = 2;
        private const int TAB_INDEX_NAME = 3;
        private const int TAB_INDEX_PERSON_NUMBER = 4;
        private const int TAB_INDEX_FIRST_CURRENCY_FIELD = 66;
        private const int TAB_INDEX_FIRST_SUM_CURRENCY_FIELD = 108;
        private const int TAB_INDEX_FIRST_RESOURCE_FIELD = 112;
        private const int TAB_INDEX_FIRST_SUM_RESOURCE_FIELD = 154;

        private readonly string _name;
        private readonly string _personalIdentificationNumber;
        private List<K4Transaction> _cryptoTransactions;
        private List<K4Transaction> _fiatTransactions;
        private PdfLogic _pdfLogic;
        private int fiatTransactionIndex;
        private int cryptoTransactionIndex;

        public K4Helper(string name, string personalIdentificationNumber, string originalk4Path, string outputPath, string processName, List<K4Transaction> fiatTransactions, List<K4Transaction> cryptoTransactions)
        {
            _name = name;
            _personalIdentificationNumber = personalIdentificationNumber;
            _cryptoTransactions = cryptoTransactions;
            _fiatTransactions = fiatTransactions;
            _pdfLogic = new PdfLogic(originalk4Path, outputPath, processName);
            fiatTransactionIndex = 0;
            cryptoTransactionIndex = 0;
        }

        public void FillForms() 
        {
            while (fiatTransactionIndex < _fiatTransactions.Count || cryptoTransactionIndex < _cryptoTransactions.Count)
            {
                FillForm();
            }
            //_pdfLogic.SaveAndClose();
        }

        private void FillForm()
        {
            _pdfLogic.CopyPdf();
            _pdfLogic.OpenPdf();
            FillDate();
            FillNumbering();
            FillName();
            FillPersonalIdentificationNumber();
            FillCurrencies();
            FillResources();
        }

        private void FillDate()
        {
            _pdfLogic.GotoField(TAB_INDEX_DATE);
            _pdfLogic.FillField(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        private void FillNumbering()
        {
            _pdfLogic.GotoField(TAB_INDEX_NUMBERING);
            _pdfLogic.FillField(_pdfLogic.GetNumberOfCopies().ToString());
        }

        private void FillName()
        {
            _pdfLogic.GotoField(TAB_INDEX_NAME);
            _pdfLogic.FillField(_name);
        }

        private void FillPersonalIdentificationNumber()
        {
            _pdfLogic.GotoField(TAB_INDEX_PERSON_NUMBER);
            _pdfLogic.FillField(_personalIdentificationNumber);
        }

        private void FillCurrencies()
        {
            bool fillSum = false;
            decimal salesPriceSum = 0;
            decimal taxBasisSum = 0;
            int gainSum = 0;
            int lossSum = 0;

            _pdfLogic.GotoField(TAB_INDEX_FIRST_CURRENCY_FIELD);
            for (int i = 0; i < 7 && fiatTransactionIndex < _fiatTransactions.Count; i++)
            {
                _pdfLogic.FillField(_fiatTransactions[fiatTransactionIndex].Amount);
                _pdfLogic.FillField(_fiatTransactions[fiatTransactionIndex].Currency);
                _pdfLogic.FillField(decimal.Round(_fiatTransactions[fiatTransactionIndex].SalesPrice));
                _pdfLogic.FillField(decimal.Round(_fiatTransactions[fiatTransactionIndex].TaxBasis));
                _pdfLogic.FillField(((int)_fiatTransactions[fiatTransactionIndex].Gain == 0 ? string.Empty : ((int)_fiatTransactions[fiatTransactionIndex].Gain).ToString()));
                _pdfLogic.FillField(((int)_fiatTransactions[fiatTransactionIndex].Loss == 0 ? string.Empty : ((int)_fiatTransactions[fiatTransactionIndex].Loss).ToString()));

                salesPriceSum += decimal.Round(_fiatTransactions[fiatTransactionIndex].SalesPrice);
                taxBasisSum += decimal.Round(_fiatTransactions[fiatTransactionIndex].TaxBasis);
                gainSum += (int)_fiatTransactions[fiatTransactionIndex].Gain;
                lossSum += (int)_fiatTransactions[fiatTransactionIndex].Loss;

                fiatTransactionIndex++;
                fillSum = true;
            }

            if (fillSum)
            {
                _pdfLogic.GotoField(TAB_INDEX_FIRST_SUM_CURRENCY_FIELD);
                _pdfLogic.FillField(decimal.Round(salesPriceSum));
                _pdfLogic.FillField(decimal.Round(taxBasisSum));
                _pdfLogic.FillField(gainSum == 0 ? string.Empty : gainSum.ToString());
                _pdfLogic.FillField(lossSum == 0 ? string.Empty : lossSum.ToString());
            }
        }

        private void FillResources()
        {
            bool fillSum = false;
            decimal salesPriceSum = 0;
            decimal taxBasisSum = 0;
            int gainSum = 0;
            int lossSum = 0;

            _pdfLogic.GotoField(TAB_INDEX_FIRST_RESOURCE_FIELD);
            for (int i = 0; i < 7 && cryptoTransactionIndex < _cryptoTransactions.Count; i++)
            {
                _pdfLogic.FillField(_cryptoTransactions[cryptoTransactionIndex].Amount);
                _pdfLogic.FillField(_cryptoTransactions[cryptoTransactionIndex].Currency);
                _pdfLogic.FillField(decimal.Round(_cryptoTransactions[cryptoTransactionIndex].SalesPrice));
                _pdfLogic.FillField(decimal.Round(_cryptoTransactions[cryptoTransactionIndex].TaxBasis));
                _pdfLogic.FillField(((int)_cryptoTransactions[cryptoTransactionIndex].Gain == 0 ? string.Empty : ((int)_cryptoTransactions[cryptoTransactionIndex].Gain).ToString()));
                _pdfLogic.FillField(((int)_cryptoTransactions[cryptoTransactionIndex].Loss == 0 ? string.Empty : ((int)_cryptoTransactions[cryptoTransactionIndex].Loss).ToString()));

                salesPriceSum += _cryptoTransactions[cryptoTransactionIndex].SalesPrice;
                taxBasisSum += _cryptoTransactions[cryptoTransactionIndex].TaxBasis;
                gainSum += (int)_cryptoTransactions[cryptoTransactionIndex].Gain;
                lossSum += (int)_cryptoTransactions[cryptoTransactionIndex].Loss;

                cryptoTransactionIndex++;

                fillSum = true;
            }

            if (fillSum)
            {
                _pdfLogic.GotoField(TAB_INDEX_FIRST_SUM_RESOURCE_FIELD);
                _pdfLogic.FillField(decimal.Round(salesPriceSum));
                _pdfLogic.FillField(decimal.Round(taxBasisSum));
                _pdfLogic.FillField(gainSum == 0 ? string.Empty : gainSum.ToString());
                _pdfLogic.FillField(lossSum == 0 ? string.Empty : lossSum.ToString());
            }
        }
    }
}
