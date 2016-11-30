using System;
using System.IO;
using TaxManagement.Entities;

namespace TaxManagement.Util
{
    public static class FileHelper
    {
        public static UploadedData CSVtoEntities(Stream fileStream)
        {
            int rowNumber = 0;
            UploadedData uploadedData = new UploadedData();
            TransactionDto transaction;
            using (StreamReader sr = new StreamReader(fileStream))
            {
                decimal amount = 0;
                //skip header
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    rowNumber++;
                    transaction = new TransactionDto();
                    try
                    {
                        string[] rows = sr.ReadLine().Split(',');
                        if (rows.Length == 4)
                        {
                            if (String.IsNullOrEmpty(rows[0]))
                                transaction.Message = "No Account provided. ";
                            else
                                transaction.Account = rows[0].Trim();

                            if (String.IsNullOrEmpty(rows[1]))
                                transaction.Message += "No Description provided. ";
                            else
                                transaction.Description = rows[1].Trim();

                            if (String.IsNullOrEmpty(rows[2]))
                                transaction.Message += "No Currency Code provided. ";
                            else
                                transaction.CurrencyCode = rows[2].Trim();

                            if (!CurrencyHelper.ValidateCurrency(rows[2]))
                                transaction.Message += "Non existing Currency Code provided. ";

                            if (String.IsNullOrEmpty(rows[3]) || !Decimal.TryParse(rows[3], out amount))
                                transaction.Message += "No Amount provided. ";
                            else
                                transaction.Amount = amount;

                            if (!transaction.IsSuccess)
                            {
                                transaction.Message += " at row: " + rowNumber;
                                uploadedData.FailedData.Add(transaction);
                            }
                            else
                            {
                                uploadedData.InsertData.Add(transaction);
                            }
                        }
                        else if (rows.Length < 4)
                        {
                            transaction.Message = "Missing data at row " + rowNumber;
                            uploadedData.FailedData.Add(transaction);
                        }
                        else
                        {
                            transaction.Message = "Invalid chars at row " + rowNumber;
                            uploadedData.FailedData.Add(transaction);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Message = ex.InnerException.Message + " At row " + rowNumber;
                        uploadedData.FailedData.Add(transaction);
                    }
                }
            }

            return uploadedData;
        }
    }
}
