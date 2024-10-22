using Braintree;
using Client.Options;
using Microsoft.Extensions.Options;

namespace Client
{
    internal abstract class BaseClient(IOptions<BraintreeClientOptions> options)
    {
        protected BraintreeGateway Gateway { get; } = new(
            options.Value.UseSandbox ? Braintree.Environment.SANDBOX : Braintree.Environment.PRODUCTION,
            options.Value.MerchantId,
            options.Value.PublicKey,
            options.Value.PrivateKey
        );
    }
}