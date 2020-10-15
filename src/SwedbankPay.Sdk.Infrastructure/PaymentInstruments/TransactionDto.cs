using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class TransactionDto
    {
        public int Amount { get; }
        public DateTime Created { get; }
        public string Description { get; }
        public Uri Id { get; }
        public bool IsOperational { get; }
        public string Number { get; }
        public OperationList Operations { get; }
        public string PayeeReference { get; }
        public string State { get; }
        public string Type { get; }
        public DateTime Updated { get; }
        public int VatAmount { get; }
        public string Activity { get; }
    }
}