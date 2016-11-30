using System;
using System.ComponentModel.DataAnnotations;

namespace TaxManagement.Data.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public string Account { get; set; }
        public string Description { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
    }
}
