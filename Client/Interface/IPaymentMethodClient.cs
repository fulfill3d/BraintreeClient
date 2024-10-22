using Client.Model.PaymentMethod;

namespace Client.Interface
{
    public interface IPaymentMethodClient
    {
        Task<PaymentMethodResult> CreatePaymentMethod(string sellerId, string nonce);
    }
}