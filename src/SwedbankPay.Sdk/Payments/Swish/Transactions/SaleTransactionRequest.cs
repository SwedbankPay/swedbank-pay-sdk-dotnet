using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.Swish.Transactions
{
    public class SaleTransactionRequest
    {
        public SaleTransactionRequest(Msisdn msisdn)
        {
            Msisdn = msisdn;
        }

        public Msisdn Msisdn { get; }
    }
}
