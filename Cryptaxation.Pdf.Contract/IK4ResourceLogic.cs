using Cryptaxation.Pdf.Models;

namespace Cryptaxation.Pdf.Contract
{
    public interface IK4ResourceLogic
    {
         K4TabIndexes GetTabIndexesByYear(int year);
    }
}
