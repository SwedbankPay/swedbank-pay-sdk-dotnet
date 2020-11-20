using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentSaleResponse : ISwishPaymentSaleResponse
    {
        public SwishPaymentSaleResponse(Uri payment, SwishPaymentSale sale)
        {
            Payment = payment;
            Sale = sale;
        }

        /// <summary>
        /// The <seealso cref="Uri"/> to access details on this sales payment.
        /// </summary>
        public Uri Payment { get; }

        /// <summary>
        /// Detailed information about this sales payment.
        /// </summary>
        public ISwishPaymentSale Sale { get; }
    }
}