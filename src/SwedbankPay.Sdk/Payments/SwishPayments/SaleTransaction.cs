namespace SwedbankPay.Sdk.Payments.SwishPayments
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
