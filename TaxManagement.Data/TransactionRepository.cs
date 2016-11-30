using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TaxManagement.Data.Contracts;
using TaxManagement.Data.Entities;
using TaxManagement.Entities;

namespace TaxManagement.Data
{
    public class TransactionRepository : ITransactionRepository
    {
        public IList<TransactionDto> GetTransactions()
        {
            using (var context = new TaxManagementContext())
            {
                return context.Transactions.Select(Mapper.Map<TransactionDto>).ToList();
            }
        }

        public TransactionDto GetTransaction(int id)
        {
            using (var context = new TaxManagementContext())
            {
                return Mapper.Map<TransactionDto>(context.Transactions.FirstOrDefault(t => t.Id == id));
            }
        }

        public bool SaveTransactions(IList<TransactionDto> uploadTransactions)
        {
            using (var context = new TaxManagementContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                context.Transactions.AddRange(uploadTransactions.Select(Mapper.Map<Transaction>));
                context.SaveChanges();
            }
            return true;
        }

        public bool UpdateTransaction(TransactionDto transaction)
        {
            using (var context = new TaxManagementContext())
            {
                var trans = context.Transactions.FirstOrDefault(t => t.Id == transaction.Id);
                Mapper.Map(transaction, trans);
                context.SaveChanges();
            }
            return true;
        }

        public bool DeleteTransaction(int id)
        {
            using (var context = new TaxManagementContext())
            {
                var trans = context.Transactions.FirstOrDefault(t => t.Id == id);
                context.Transactions.Remove(trans);
                context.SaveChanges();
            }
            return true;
        }
    }
}
