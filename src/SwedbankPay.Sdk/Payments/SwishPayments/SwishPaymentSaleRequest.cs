namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishPaymentSaleRequest
    {
        public SwishPaymentSaleRequest(Msisdn msisdn)
        {
            transaction = new SwishPaymentSaleTransaction(msisdn);
        }


        private SwishPaymentSaleTransaction transaction;

        public Msisdn Msisdn => this.transaction.Msisdn;

        private class SwishPaymentSaleTransaction
        {
            protected internal SwishPaymentSaleTransaction(Msisdn msisdn)
            {
                Msisdn = msisdn;
            }


            public Msisdn Msisdn { get; }
        }
    }
}
