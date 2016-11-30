using AutoMapper;
using TaxManagement.Data.Entities;
using TaxManagement.Entities;

namespace TaxManagement.Core
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<TransactionMapProfile>();
            });
        }
    }

    public class TransactionMapProfile : Profile
    {
        public TransactionMapProfile()
        {
            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}