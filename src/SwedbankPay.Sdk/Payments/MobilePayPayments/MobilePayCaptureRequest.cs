using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class MobilePayCaptureRequest
    {
        public MobilePayCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            transaction = new CaptureTransaction(amount, vatAmount, description, payeeReference);
        }


        private CaptureTransaction transaction;

        public Amount Amount => this.transaction.Amount;
        public Amount VatAmount => this.transaction.VatAmount;
        public string Description => this.transaction.Description;
        public string PayeeReference => this.transaction.PayeeReference;

        private class CaptureTransaction
        {
            protected internal CaptureTransaction(Amount amount,
                                                  Amount vatAmount,
                                                  string description,
                                                  string payeeReference)
            {
                Amount = amount;
                VatAmount = vatAmount;
                Description = description;
                PayeeReference = payeeReference;
            }


            public Amount Amount { get; }
            public Amount VatAmount { get; }
            public string Description { get; }
            public string PayeeReference { get; }
        }
    }
}