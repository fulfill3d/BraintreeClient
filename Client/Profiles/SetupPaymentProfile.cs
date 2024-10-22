using AutoMapper;
using Client.Model.Customer;
using Client.Model.PaymentMethod;

namespace Client.Profiles
{
    public class SetupPaymentProfile : Profile
    {
        public SetupPaymentProfile()
        {
            CreateMap<CreateCustomerRequest, Braintree.CustomerRequest>();
            CreateMap<Braintree.Customer, CustomerResult>();
            CreateMap<Braintree.PaymentMethod, PaymentMethodResult>();
        }
    }
}