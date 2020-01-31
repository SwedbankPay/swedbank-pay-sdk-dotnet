namespace SwedbankPay.Sdk.Payments.Swish
{
    public class SaleTransaction
    {
        protected internal SaleTransaction(Msisdn msisdn)
        {
            Msisdn = msisdn;
        }


        public Msisdn Msisdn { get; }
    }
}
