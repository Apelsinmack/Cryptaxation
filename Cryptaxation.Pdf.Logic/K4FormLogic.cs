using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cryptaxation.Pdf.Contract;
using Cryptaxation.Pdf.Models;

namespace Cryptaxation.Pdf.Logic
{
    public class K4FormLogic<TK4FillModel, TK4TabIndexModel> : IK4FormLogic<TK4FillModel, TK4TabIndexModel> where TK4FillModel : K4FillModel, new() where TK4TabIndexModel : K4TabIndexModel, new()
    {
        private readonly K4FormModel _k4Form;

        public K4FormLogic(K4FormModel k4Form)
        {
            _k4Form = k4Form;
        }

        public List<TK4FillModel> GetK4FillModelList()
        {
            var k4FillModelList = new List<TK4FillModel>();
            var yearsWithTransactions = _k4Form.CryptoTransactions.Keys.Union(_k4Form.FiatTransactions.Keys).OrderBy(t => t).ToList();

            yearsWithTransactions.ForEach(year =>
            {
                if (_k4Form.Years.Contains(year))
                {
                    k4FillModelList.Add(new TK4FillModel
                    {
                        Year = year,
                        TabIndexes = GetTabIndexesByYear(year),
                        FullName = _k4Form.FullName,
                        PersonalIdentificatonNumber = _k4Form.PersonalIdentificatonNumber,
                        CryptoTransactions = _k4Form.CryptoTransactions[year],
                        FiatTransactions = _k4Form.FiatTransactions[year]
                    });
                }
            });

            return k4FillModelList;
        }

        public TK4TabIndexModel GetTabIndexesByYear(int year)
        {
            switch (year)
            {
                case 2013:
                case 2014:
                case 2015:
                case 2016:
                case 2017:
                    return new TK4TabIndexModel
                    {
                        Date = 1,
                        Numbering = 2,
                        Name = 3,
                        PersonalIdentificationNumber = 4,
                        FirstCurrencyField = 65,
                        FirstSumCurrencyField = 107,
                        FirstResourceField = 111,
                        FirstSumResourceField = 153
                    };
                case 2018:
                    return new TK4TabIndexModel
                    {
                        Date = 1,
                        Numbering = 2,
                        Name = 3,
                        PersonalIdentificationNumber = 4,
                        FirstCurrencyField = 66,
                        FirstSumCurrencyField = 108,
                        FirstResourceField = 112,
                        FirstSumResourceField = 154
                    };
                case 2019:
                    return new TK4TabIndexModel
                    {
                        Date = 1,
                        Numbering = 2,
                        Name = 3,
                        PersonalIdentificationNumber = 4,
                        FirstCurrencyField = 66,
                        FirstSumCurrencyField = 108,
                        FirstResourceField = 112,
                        FirstSumResourceField = 154
                    };
                default: throw new NotImplementedException();
            }
        }
    }
}
