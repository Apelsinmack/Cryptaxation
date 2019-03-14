using System;
using System.Collections.Generic;
using System.IO;
using Cryptaxation.Csv.Contract;
using Cryptaxation.Entities;

namespace Cryptaxation.Csv.Logic
{
    public class DetailedTransactionCsvLogic<TDetailedTransaction> : IDetailedTransactionCsvLogic<TDetailedTransaction> where TDetailedTransaction : DetailedTransaction, new()
    {
        private readonly string _path;

        public DetailedTransactionCsvLogic(string path)
        {
            _path = path;
        }

        public void CreateDetailedTransactionsCsv(List<TDetailedTransaction> detailedTransactions)
        {
            string delimter = ";";
            using (TextWriter writer = File.CreateText(_path))
            {
                List<string> headers = new List<string>();
                foreach (var property in typeof(TDetailedTransaction).GetProperties())
                {
                    headers.Add(property.Name);
                }
                writer.WriteLine(string.Join(delimter, headers));
                foreach (var detailedTransaction in detailedTransactions)
                {
                    List<string> columns = new List<string>();
                    foreach (var property in typeof(TDetailedTransaction).GetProperties())
                    {
                        var csvProperty = detailedTransaction.GetType().GetProperty(property.Name);
                        if (csvProperty != null)
                        {
                            var csvPropertyValue = csvProperty.GetValue(detailedTransaction, null);
                            columns.Add((csvPropertyValue.ToString().Equals("Undefined") ? string.Empty : csvPropertyValue.ToString()));
                        }
                    }
                    writer.WriteLine(string.Join(delimter, columns));
                }
            }
        }
    }
}
