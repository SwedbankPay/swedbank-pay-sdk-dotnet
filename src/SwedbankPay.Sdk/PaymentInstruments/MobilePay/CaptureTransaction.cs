namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
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