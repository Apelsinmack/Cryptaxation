namespace Cryptaxation.Pdf.Contract
{
    public interface IPdfLogic
    {
        void CopyPdf();
        int GetNumberOfCopies();
        string GetPdfPath(int number);
        void OpenPdf();
        void SaveAndClose();
        void FillField(string text);
        void FillField(decimal value);
        void NextField();
        void PreviousField();
        void GotoField(int tabIndex);
        void FocusAdobeReader();
    }
}
