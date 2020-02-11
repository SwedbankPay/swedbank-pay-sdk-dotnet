namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishPaymentSaleTransaction
    {
        protected internal SwishPaymentSaleTransaction(Msisdn msisdn)
        {
            Msisdn = msisdn;
        }


        public Msisdn Msisdn { get; }
    }
}
