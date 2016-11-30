using System;
using System.Collections.Generic;
using System.IO;
using TaxManagement.Data;
using TaxManagement.Data.Contracts;
using TaxManagement.Entities;
using TaxManagement.Service.Contracts;
using TaxManagement.Util;

namespace TaxManagement.Service
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public IList<TransactionDto> GetTransactions()
        {
            return _transactionRepository.GetTransactions();
        }

        public TransactionDto GetTransaction(int id)
        {
            return _transactionRepository.GetTransaction(id);
        }

        public UploadedData UploadTransactions(Stream fileStream)
        {
            var uploadedData = FileHelper.CSVtoEntities(fileStream);
            _transactionRepository.SaveTransactions(uploadedData.InsertData);
            return uploadedData;
        }

        public bool UpdateTransaction(TransactionDto transaction)
        {
            return _transactionRepository.UpdateTransaction(transaction);
        }

        public bool DeleteTransaction(int id)
        {
            return _transactionRepository.DeleteTransaction(id);
        }
    }
}
