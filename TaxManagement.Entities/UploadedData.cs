using System;
using System.Collections.Generic;
using System.Data;

namespace TaxManagement.Entities
{
    public class UploadedData
    {
        public UploadedData()
        {
            InsertData = new List<TransactionDto>();
            FailedData = new List<TransactionDto>();
        }
        public IList<TransactionDto> InsertData { get; set; }
        public IList<TransactionDto> FailedData { get; set; }
    }
}
