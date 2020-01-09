namespace SwedbankPay.Sdk.Transactions
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
