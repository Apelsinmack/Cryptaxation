using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Models;
using Microsoft.VisualBasic.FileIO;

namespace Cryptaxation
{
    public class CSVHelper
    {
        public List<BitstampTransaction> CreateBitstampTransactions(string path)
        {
            List<BitstampTransaction> bitstampTransactions = new List<BitstampTransaction>();
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields != null)
                    {
                        BitstampTransaction bitstampTransaction = new BitstampTransaction();
                        for (int i = 0; i < fields.Length; i++)
                        {
                            switch (i)
                            {
                                default:
                                    throw new Exception("Invalid field");
                            }
                        }
                        bitstampTransactions.Add(bitstampTransaction);
                    }
                    else
                    {
                        throw new Exception("Now rows found.");
                    }
                }
            }
            return bitstampTransactions;
        }

        /*public List<Rate> CreateRate(string path)
        {
            List<Rate> rates = new List<Rate>();
            return rates;
        }*/

        private enum BitstampTransactionFields
        {
            
        };
    }
}
