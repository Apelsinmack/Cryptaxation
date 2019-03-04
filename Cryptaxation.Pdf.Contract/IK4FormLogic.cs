namespace Cryptaxation.Pdf.Contract
{
    public interface IK4FormLogic
    {
        void FillForms(int year);
        void FillForm(int year);
        void FillDate();
        void FillNumbering(int year);
        void FillName();
        void FillPersonalIdentificationNumber();
        void FillCurrencies();
        void FillResources();
    }
}