using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TaxManagement.Data.Entities;
using TaxManagement.Entities;


namespace TaxManagement.Data
{
    public class TaxManagementContext : DbContext
    {
        public TaxManagementContext()
            : base("name=TaxManagement")
        {
            Database.SetInitializer<TaxManagementContext>(null);
            var _providers = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Transaction>().ToTable("Transaction").HasKey(t => t.Id);
        }
    }
}

