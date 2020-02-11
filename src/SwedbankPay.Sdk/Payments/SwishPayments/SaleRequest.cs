namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SaleRequest
    {
        public SaleRequest(Msisdn msisdn)
        {
            Transaction = new SaleTransaction(msisdn);
        }


        public SaleTransaction Transaction { get; }
    }
}
