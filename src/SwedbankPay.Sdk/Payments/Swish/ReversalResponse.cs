using SwedbankPay.Sdk.Transactions;

using System;

namespace SwedbankPay.Sdk.Payments.Swish
{
    public class ReversalResponse
    {
        public ReversalResponse(Uri payment, Reversal reversal)
        {
            Payment = payment;
            Reversal = reversal;
        }

        public Uri Payment { get; }
        public Reversal Reversal { get; }
    }

    public class Reversal : IdLink
    {
        public Reversal(Transaction transaction)
        {
            Transaction = transaction;
        }


        public Transaction Transaction { get; }
    }
}
