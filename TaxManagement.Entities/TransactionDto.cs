using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxManagement.Entities
{
    public class TransactionDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide an Account.")]
        public string Account { get; set; }
        [Required(ErrorMessage = "Please provide a Description.")]
        public string Description { get; set; }
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        [Required(ErrorMessage = "Please provide a Currency Code.")]
        public string CurrencyCode { get; set; }
        [Required(ErrorMessage = "Please provide an Amount.")]
        public decimal Amount { get; set; }
        public string Message { get; set; }

        public bool IsSuccess
        {
            get { return String.IsNullOrEmpty(Message); }
        }
    }
}
