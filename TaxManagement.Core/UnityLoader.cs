using Microsoft.Practices.Unity;
using TaxManagement.Data;
using TaxManagement.Data.Contracts;
using TaxManagement.Service;
using TaxManagement.Service.Contracts;

namespace TaxManagement.Core
{
    public static class UnityLoader
    {
        public static void Init(IUnityContainer container)
        {
            container.RegisterType<ITransactionService, TransactionService>();
            container.RegisterType<ITransactionRepository, TransactionRepository>();
        }
    }
}
