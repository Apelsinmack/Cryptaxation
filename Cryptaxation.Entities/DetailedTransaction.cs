using System;
using Cryptaxation.Entities.Types.Enums;

namespace Cryptaxation.Entities
{
    public class DetailedTransaction
    {
        public DateTime DateTime { get; set; }
        public CurrencyCode CurrencyCodeTaxation { get; set; }
        public CurrencyCode CurrencyCodeSold { get; set; }
        public decimal AmountSold { get; set; }
        public decimal ValueTaxationCurrencySold { get; set; }
        public decimal TaxBasisValueSold { get; set; }
        public decimal Gain { get; set; }
        public decimal Loss { get; set; }
        public decimal TaxBasisRateSold { get; set; }
        public decimal TaxBasisAmountAfterSold { get; set; }
        public decimal TaxBasisAmountBeforeSold { get; set; }
        public CurrencyCode CurrencyCodeBought { get; set; }
        public decimal AmountBought { get; set; }
        public decimal TaxBasisRateAfterBought { get; set; }
        public decimal TaxBasisRateBeforeBought { get; set; }
        public decimal TaxBasisAmountAfterBought { get; set; }
        public decimal TaxBasisAmountBeforeBought { get; set; }
        public CurrencyCode CurrencyCodeFee { get; set; }
        public decimal AmountFee { get; set; }
        public decimal ValueTaxationCurrencyFee { get; set; }
    }
}
