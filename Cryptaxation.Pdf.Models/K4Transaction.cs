namespace Cryptaxation.Pdf.Models
{
    public class K4Transaction
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int SalesPrice { get; set; }
        public int TaxBasis { get; set; }
        public int Gain { get; set; }
        public int Loss { get; set; }
    }
}
