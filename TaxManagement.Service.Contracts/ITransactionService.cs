using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManagement.Entities;


namespace TaxManagement.Service.Contracts
{
    public interface ITransactionService
    {
        IList<TransactionDto> GetTransactions();
        TransactionDto GetTransaction(int id);
        UploadedData UploadTransactions(Stream fileStream);
        bool UpdateTransaction(TransactionDto transaction);
        bool DeleteTransaction(int id);
    }
}
