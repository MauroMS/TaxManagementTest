using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxManagement.Data.Entities;
using TaxManagement.Entities;

namespace TaxManagement.Data.Contracts
{
    public interface ITransactionRepository
    {
        IList<TransactionDto> GetTransactions();
        TransactionDto GetTransaction(int id);
        bool SaveTransactions(IList<TransactionDto> uploadTransactions);
        bool UpdateTransaction(TransactionDto transaction);
        bool DeleteTransaction(int id);
    }
}
