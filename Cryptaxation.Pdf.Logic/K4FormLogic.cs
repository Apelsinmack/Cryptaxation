using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Pdf.Contract;
using Cryptaxation.Pdf.Models;

namespace Cryptaxation.Pdf.Logic
{
    public class K4FormLogic : IK4FormLogic
    {
        private readonly IPdfLogic _pdfLogic;
        private readonly K4Form _k4Form;
        private int _fiatTransactionIndex;
        private int _cryptoTransactionIndex;

        public K4FormLogic(IPdfLogic pdfLogic, K4Form k4Form)
        {
            _pdfLogic = pdfLogic;
            _k4Form = k4Form;
            _fiatTransactionIndex = 0;
            _cryptoTransactionIndex = 0;
        }
        
        public void FillForms(int year)
        {
            while (_fiatTransactionIndex < _k4Form.FiatTransactions.Count || _cryptoTransactionIndex < _k4Form.CryptoTransactions.Count)
            {
                FillForm(year);
            }
        }

        public void FillForm(int year)
        {
            _pdfLogic.CopyPdf(year);
            _pdfLogic.OpenPdf(year, _pdfLogic.GetNumberOfCopies(year));
            FillDate();
            FillNumbering(year);
            FillName();
            FillPersonalIdentificationNumber();
            FillCurrencies();
            FillResources();
        }

        public void FillDate()
        {
            _pdfLogic.GotoField(_k4Form.TabIndexes.TabIndexDate);
            _pdfLogic.FillField(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        public void FillNumbering(int year)
        {
            _pdfLogic.GotoField(_k4Form.TabIndexes.TabIndexNumbering);
            _pdfLogic.FillField(_pdfLogic.GetNumberOfCopies(year).ToString());
        }

        public void FillName()
        {
            _pdfLogic.GotoField(_k4Form.TabIndexes.TabIndexName);
            _pdfLogic.FillField(_k4Form.Name);
        }

        public void FillPersonalIdentificationNumber()
        {
            _pdfLogic.GotoField(_k4Form.TabIndexes.TabIndexPersonalIdentificationNumber);
            _pdfLogic.FillField(_k4Form.PersonalIdentificatonNumber);
        }

        public void FillCurrencies()
        {
            bool fillSum = false;
            decimal salesPriceSum = 0;
            decimal taxBasisSum = 0;
            int gainSum = 0;
            int lossSum = 0;

            _pdfLogic.GotoField(_k4Form.TabIndexes.TabIndexFirstCurrencyField);
            for (int i = 0; i < 7 && _fiatTransactionIndex < _k4Form.FiatTransactions.Count; i++)
            {
                _pdfLogic.FillField(_k4Form.FiatTransactions[_fiatTransactionIndex].Amount);
                _pdfLogic.FillField(_k4Form.FiatTransactions[_fiatTransactionIndex].Currency);
                _pdfLogic.FillField(decimal.Round(_k4Form.FiatTransactions[_fiatTransactionIndex].SalesPrice));
                _pdfLogic.FillField(decimal.Round(_k4Form.FiatTransactions[_fiatTransactionIndex].TaxBasis));
                _pdfLogic.FillField(_k4Form.FiatTransactions[_fiatTransactionIndex].Gain == 0 ? string.Empty : _k4Form.FiatTransactions[_fiatTransactionIndex].Gain.ToString());
                _pdfLogic.FillField(_k4Form.FiatTransactions[_fiatTransactionIndex].Loss == 0 ? string.Empty : _k4Form.FiatTransactions[_fiatTransactionIndex].Loss.ToString());

                salesPriceSum += decimal.Round(_k4Form.FiatTransactions[_fiatTransactionIndex].SalesPrice);
                taxBasisSum += decimal.Round(_k4Form.FiatTransactions[_fiatTransactionIndex].TaxBasis);
                gainSum += _k4Form.FiatTransactions[_fiatTransactionIndex].Gain;
                lossSum += _k4Form.FiatTransactions[_fiatTransactionIndex].Loss;

                _fiatTransactionIndex++;
                fillSum = true;
            }

            if (fillSum)
            {
                _pdfLogic.GotoField(_k4Form.TabIndexes.TabIndexFirstSumCurrencyField);
                _pdfLogic.FillField(decimal.Round(salesPriceSum));
                _pdfLogic.FillField(decimal.Round(taxBasisSum));
                _pdfLogic.FillField(gainSum == 0 ? string.Empty : gainSum.ToString());
                _pdfLogic.FillField(lossSum == 0 ? string.Empty : lossSum.ToString());
            }
        }

        public void FillResources()
        {
            bool fillSum = false;
            decimal salesPriceSum = 0;
            decimal taxBasisSum = 0;
            int gainSum = 0;
            int lossSum = 0;

            _pdfLogic.GotoField(_k4Form.TabIndexes.TabIndexFirstResourceField);
            for (int i = 0; i < 7 && _cryptoTransactionIndex < _k4Form.CryptoTransactions.Count; i++)
            {
                _pdfLogic.FillField(_k4Form.CryptoTransactions[_cryptoTransactionIndex].Amount);
                _pdfLogic.FillField(_k4Form.CryptoTransactions[_cryptoTransactionIndex].Currency);
                _pdfLogic.FillField(decimal.Round(_k4Form.CryptoTransactions[_cryptoTransactionIndex].SalesPrice));
                _pdfLogic.FillField(decimal.Round(_k4Form.CryptoTransactions[_cryptoTransactionIndex].TaxBasis));
                _pdfLogic.FillField((_k4Form.CryptoTransactions[_cryptoTransactionIndex].Gain == 0 ? string.Empty : (_k4Form.CryptoTransactions[_cryptoTransactionIndex].Gain).ToString()));
                _pdfLogic.FillField((_k4Form.CryptoTransactions[_cryptoTransactionIndex].Loss == 0 ? string.Empty : (_k4Form.CryptoTransactions[_cryptoTransactionIndex].Loss).ToString()));

                salesPriceSum += _k4Form.CryptoTransactions[_cryptoTransactionIndex].SalesPrice;
                taxBasisSum += _k4Form.CryptoTransactions[_cryptoTransactionIndex].TaxBasis;
                gainSum += _k4Form.CryptoTransactions[_cryptoTransactionIndex].Gain;
                lossSum += _k4Form.CryptoTransactions[_cryptoTransactionIndex].Loss;

                _cryptoTransactionIndex++;

                fillSum = true;
            }

            if (fillSum)
            {
                _pdfLogic.GotoField(_k4Form.TabIndexes.TabIndexFirstSumResourceField);
                _pdfLogic.FillField(decimal.Round(salesPriceSum));
                _pdfLogic.FillField(decimal.Round(taxBasisSum));
                _pdfLogic.FillField(gainSum == 0 ? string.Empty : gainSum.ToString());
                _pdfLogic.FillField(lossSum == 0 ? string.Empty : lossSum.ToString());
            }
        }
    }
}
