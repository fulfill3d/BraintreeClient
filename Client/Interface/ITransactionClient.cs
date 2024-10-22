using Client.Model.Transaction;

namespace Client.Interface
{
    public interface ITransactionClient
    {
        Task<TransactionResult> CreateTransaction(decimal amount, string nonce, string deviceData, string currency);
    }
}