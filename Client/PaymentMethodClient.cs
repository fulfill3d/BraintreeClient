using AutoMapper;
using Braintree;
using Client.Exceptions;
using Client.Interface;
using Client.Model.PaymentMethod;
using Client.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Client
{
    internal class PaymentMethodClient(IOptions<BraintreeClientOptions> options, IMapper mapper, ILogger<PaymentMethodClient> logger) : BaseClient(options), IPaymentMethodClient
	{
        public async Task<PaymentMethodResult> CreatePaymentMethod(string customerId, string nonce)
		{
            var request = new PaymentMethodRequest
            {
                CustomerId = customerId,
                PaymentMethodNonce = nonce
            };

            Result<PaymentMethod> result = await Gateway.PaymentMethod.CreateAsync(request);

            if (result.IsSuccess())
            {
                logger.LogInformation($"Braintree payment method successfully created for customer Id:{result.Target.CustomerId}");
                return mapper.Map<PaymentMethodResult>(result.Target);
            }
            else
            {
                logger.LogError($"An error occured while creating payment method: {result.Message}");
                throw new BraintreeException(nameof(CreatePaymentMethod), result.Message);
            }
           
        }

    }
}

