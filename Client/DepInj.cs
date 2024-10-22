using Client.Interface;
using Client.Options;
using Client.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Client
{
    public static class DepInj
    {
        public static void AddBraintreeSetupPaymentClients(
            this IServiceCollection services,
            Action<BraintreeClientOptions> configureBraintreeClientOptions)
        {
            services.ConfigureServiceOptions<BraintreeClientOptions>((_, options) => configureBraintreeClientOptions(options));
            services.AddAutoMapper(typeof(SetupPaymentProfile));
            services.AddTransient<ICustomerClient, CustomerClient>();
            services.AddTransient<IPaymentMethodClient, PaymentMethodClient>();
        }
        
        public static void AddBraintreeTransactionClients(
            this IServiceCollection services,
            Action<BraintreeClientOptions> configureBraintreeClientOptions)
        {
            services.ConfigureServiceOptions<BraintreeClientOptions>((_, options) => configureBraintreeClientOptions(options));
            services.AddAutoMapper(typeof(TransactionProfile));
            services.AddTransient<ITransactionClient, TransactionClient>();
        }

        private static void ConfigureServiceOptions<TOptions>(
            this IServiceCollection services,
            Action<IServiceProvider, TOptions> configure)
            where TOptions : class
        {
            services
                .AddOptions<TOptions>()
                .Configure<IServiceProvider>((options, resolver) => configure(resolver, options));
        }
    }
}