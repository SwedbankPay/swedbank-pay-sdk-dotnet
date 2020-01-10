namespace SwedbankPay.Sdk.Payments.Swish
{
    public class SaleRequest
    {
        public SaleRequest(Msisdn msisdn)
        {
            Transaction = new SaleTransaction(msisdn);
        }


        public SaleTransaction Transaction { get; }

        public class SaleTransaction
        {
            protected internal SaleTransaction(Msisdn msisdn)
            {
                Msisdn = msisdn;
            }


            public Msisdn Msisdn { get; }
        }
    }
}