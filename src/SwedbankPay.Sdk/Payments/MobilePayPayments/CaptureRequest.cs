using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.MobilePayPayments
{
    public class CaptureRequest
    {
        public CaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new CaptureTransaction(amount, vatAmount, description, payeeReference);
        }


        public CaptureTransaction Transaction { get; }

        public class CaptureTransaction
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
            public string Description { get; }
            public string PayeeReference { get; }
            public Amount VatAmount { get; }
        }
    }
}