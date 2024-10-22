using Client.Model.Customer;

namespace Client.Interface
{
    public interface ICustomerClient
    {
        Task<CustomerResult> CreateCustomer(CreateCustomerRequest request);
        Task<GenerateClientTokenResult> GenerateClientToken(string customerId);
    }
}