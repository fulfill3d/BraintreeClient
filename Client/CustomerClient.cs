using AutoMapper;
using Braintree;
using Client.Exceptions;
using Client.Interface;
using Client.Model.Customer;
using Client.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Client
{
    internal class CustomerClient(IOptions<BraintreeClientOptions> options, IMapper mapper, ILogger<CustomerClient> logger) : BaseClient(options), ICustomerClient
	{
        public async Task<CustomerResult> CreateCustomer(CreateCustomerRequest request)
		{
			Result<Customer> result = await Gateway.Customer.CreateAsync(mapper.Map<CustomerRequest>(request));

            if (result.IsSuccess())
            {
                logger.LogInformation($"Braintree customer successfully created with id:{result.Target.Id}");
                return mapper.Map<CustomerResult>(result.Target);
            }
            else
            {
                logger.LogError($"An error occured while creating payment method: {result.Message}");
                throw new BraintreeException(nameof(CreateCustomer), result.Message);
            }
		}

		public async Task<GenerateClientTokenResult> GenerateClientToken(string customerId)
		{
			var clientToken = await Gateway.ClientToken.GenerateAsync(new Braintree.ClientTokenRequest
			{
				CustomerId = customerId
			});

			return new GenerateClientTokenResult
			{
				ClientToken = clientToken
			};

        }
	}
}

