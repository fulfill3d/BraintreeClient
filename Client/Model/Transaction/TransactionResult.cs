using System;
using Braintree;

namespace Client.Model.Transaction
{
	public class TransactionResult
	{
        public string Id { get; set; }
        public  DateTime? CreatedAt { get; set; }
    }
}

