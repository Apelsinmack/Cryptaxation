namespace Cryptaxation.Pdf.Contract
{
    public interface IPdfLogic
    {
        void CopyPdf(int year);
        int GetNumberOfCopies(int? year);
        string GetPdfPath(int year, int number);
        void OpenPdf(int year, int number);
        void SaveAndClose();
        void FillField(string text);
        void FillField(decimal value);
        void NextField();
        void PreviousField();
        void GotoField(int tabIndex);
        void FocusAdobeReader();
    }
}
