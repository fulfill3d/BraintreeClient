using AutoMapper;
using Client.Model.Transaction;

namespace Client.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Braintree.Transaction, TransactionResult>();
        }
    }
}