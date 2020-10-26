namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class CancelTransaction
        {
            public CancelTransaction(string payeeReference, string description)
            {
                PayeeReference = payeeReference;
                Description = description;
            }


            public string Description { get; }
            public string PayeeReference { get; }
        }
    }
