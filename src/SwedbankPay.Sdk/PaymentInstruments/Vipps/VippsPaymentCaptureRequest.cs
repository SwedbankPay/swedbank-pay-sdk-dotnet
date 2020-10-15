namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentCaptureRequest
    {
        public VippsPaymentCaptureRequest(Amount amount, Amount vatAmount, string description, string payeeReference)
        {
            Transaction = new VippsPaymentCaptureTransaction(amount, vatAmount, description, payeeReference);
        }


        public VippsPaymentCaptureTransaction Transaction { get; }

        public class VippsPaymentCaptureTransaction
        {
            protected internal VippsPaymentCaptureTransaction(Amount amount,
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