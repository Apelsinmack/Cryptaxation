using System.Collections.Generic;
using Cryptaxation.Pdf.Models;

namespace Cryptaxation.Pdf.Contract
{
    public interface IK4FormLogic<TK4FillModel, TK4TabIndexModel>
    {
        List<TK4FillModel> GetK4FillModelList();
         TK4TabIndexModel GetTabIndexesByYear(int year);
    }
}
