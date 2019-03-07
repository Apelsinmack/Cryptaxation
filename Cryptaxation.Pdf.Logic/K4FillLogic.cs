using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Pdf.Contract;
using Cryptaxation.Pdf.Models;

namespace Cryptaxation.Pdf.Logic
{
    public class K4FillLogic : IK4FillLogic
    {
        private readonly IPdfLogic _pdfLogic;
        private readonly K4FillModel _k4Fill;
        private int _fiatTransactionIndex;
        private int _cryptoTransactionIndex;
        
        public K4FillLogic(IPdfLogic pdfLogic, K4FillModel k4Fill)
        {
            _pdfLogic = pdfLogic;
            _k4Fill = k4Fill;
            _fiatTransactionIndex = 0;
            _cryptoTransactionIndex = 0;
        }
        
        public void FillForms()
        {
            while (_fiatTransactionIndex < _k4Fill.FiatTransactions.Count || _cryptoTransactionIndex < _k4Fill.CryptoTransactions.Count)
            {
                FillForm();
            }
        }

        public void FillForm()
        {
            _pdfLogic.CopyPdf(_k4Fill.Year);
            _pdfLogic.OpenPdf(_k4Fill.Year, _pdfLogic.GetNumberOfCopies(_k4Fill.Year));
            FillDate();
            FillNumbering();
            FillName();
            FillPersonalIdentificationNumber();
            FillCurrencies();
            FillResources();
        }

        public void FillDate()
        {
            _pdfLogic.GotoField(_k4Fill.TabIndexes.Date);
            _pdfLogic.FillField(DateTime.Now.ToString("yyyy-MM-dd"));
        }

        public void FillNumbering()
        {
            _pdfLogic.GotoField(_k4Fill.TabIndexes.Numbering);
            _pdfLogic.FillField(_pdfLogic.GetNumberOfCopies(_k4Fill.Year).ToString());
        }

        public void FillName()
        {
            _pdfLogic.GotoField(_k4Fill.TabIndexes.Name);
            _pdfLogic.FillField(_k4Fill.FullName);
        }

        public void FillPersonalIdentificationNumber()
        {
            _pdfLogic.GotoField(_k4Fill.TabIndexes.PersonalIdentificationNumber);
            _pdfLogic.FillField(_k4Fill.PersonalIdentificatonNumber);
        }

        public void FillCurrencies()
        {
            bool fillSum = false;
            decimal salesPriceSum = 0;
            decimal taxBasisSum = 0;
            int gainSum = 0;
            int lossSum = 0;

            _pdfLogic.GotoField(_k4Fill.TabIndexes.FirstCurrencyField);
            for (int i = 0; i < 7 && _fiatTransactionIndex < _k4Fill.FiatTransactions.Count; i++)
            {
                _pdfLogic.FillField(_k4Fill.FiatTransactions[_fiatTransactionIndex].Amount);
                _pdfLogic.FillField(_k4Fill.FiatTransactions[_fiatTransactionIndex].Currency);
                _pdfLogic.FillField(decimal.Round(_k4Fill.FiatTransactions[_fiatTransactionIndex].SalesPrice));
                _pdfLogic.FillField(decimal.Round(_k4Fill.FiatTransactions[_fiatTransactionIndex].TaxBasis));
                _pdfLogic.FillField(_k4Fill.FiatTransactions[_fiatTransactionIndex].Gain == 0 ? string.Empty : _k4Fill.FiatTransactions[_fiatTransactionIndex].Gain.ToString());
                _pdfLogic.FillField(_k4Fill.FiatTransactions[_fiatTransactionIndex].Loss == 0 ? string.Empty : _k4Fill.FiatTransactions[_fiatTransactionIndex].Loss.ToString());

                salesPriceSum += decimal.Round(_k4Fill.FiatTransactions[_fiatTransactionIndex].SalesPrice);
                taxBasisSum += decimal.Round(_k4Fill.FiatTransactions[_fiatTransactionIndex].TaxBasis);
                gainSum += _k4Fill.FiatTransactions[_fiatTransactionIndex].Gain;
                lossSum += _k4Fill.FiatTransactions[_fiatTransactionIndex].Loss;

                _fiatTransactionIndex++;
                fillSum = true;
            }

            if (fillSum)
            {
                _pdfLogic.GotoField(_k4Fill.TabIndexes.FirstSumCurrencyField);
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

            _pdfLogic.GotoField(_k4Fill.TabIndexes.FirstResourceField);
            for (int i = 0; i < 7 && _cryptoTransactionIndex < _k4Fill.CryptoTransactions.Count; i++)
            {
                _pdfLogic.FillField(_k4Fill.CryptoTransactions[_cryptoTransactionIndex].Amount);
                _pdfLogic.FillField(_k4Fill.CryptoTransactions[_cryptoTransactionIndex].Currency);
                _pdfLogic.FillField(decimal.Round(_k4Fill.CryptoTransactions[_cryptoTransactionIndex].SalesPrice));
                _pdfLogic.FillField(decimal.Round(_k4Fill.CryptoTransactions[_cryptoTransactionIndex].TaxBasis));
                _pdfLogic.FillField((_k4Fill.CryptoTransactions[_cryptoTransactionIndex].Gain == 0 ? string.Empty : (_k4Fill.CryptoTransactions[_cryptoTransactionIndex].Gain).ToString()));
                _pdfLogic.FillField((_k4Fill.CryptoTransactions[_cryptoTransactionIndex].Loss == 0 ? string.Empty : (_k4Fill.CryptoTransactions[_cryptoTransactionIndex].Loss).ToString()));

                salesPriceSum += _k4Fill.CryptoTransactions[_cryptoTransactionIndex].SalesPrice;
                taxBasisSum += _k4Fill.CryptoTransactions[_cryptoTransactionIndex].TaxBasis;
                gainSum += _k4Fill.CryptoTransactions[_cryptoTransactionIndex].Gain;
                lossSum += _k4Fill.CryptoTransactions[_cryptoTransactionIndex].Loss;

                _cryptoTransactionIndex++;

                fillSum = true;
            }

            if (fillSum)
            {
                _pdfLogic.GotoField(_k4Fill.TabIndexes.FirstSumResourceField);
                _pdfLogic.FillField(decimal.Round(salesPriceSum));
                _pdfLogic.FillField(decimal.Round(taxBasisSum));
                _pdfLogic.FillField(gainSum == 0 ? string.Empty : gainSum.ToString());
                _pdfLogic.FillField(lossSum == 0 ? string.Empty : lossSum.ToString());
            }
        }
    }
}
