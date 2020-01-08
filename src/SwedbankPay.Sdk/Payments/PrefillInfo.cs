using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments
{
    public class PrefillInfo
    {
        public PrefillInfo(Msisdn msisdn)
        {
            Msisdn = msisdn;
        }

        /// <summary>
        ///     "+47xxxxxxxx"
        /// </summary>
        public Msisdn Msisdn { get; }
    }
}