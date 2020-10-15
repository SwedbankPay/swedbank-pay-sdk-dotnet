using SwedbankPay.Sdk.Common;

namespace SwedbankPay.Sdk.PaymentInstruments
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