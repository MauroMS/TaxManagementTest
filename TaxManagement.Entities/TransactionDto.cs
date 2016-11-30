using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManagement.Entities
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
        public string Message { get; set; }

        public bool IsSuccess
        {
            get { return String.IsNullOrEmpty(Message); }
        }
    }
}
