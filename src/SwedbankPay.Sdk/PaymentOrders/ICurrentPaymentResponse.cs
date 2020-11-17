using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface ICurrentPaymentResponse
    {
        /// <summary>
        /// Unique <seealso cref="Uri"/> to access this payment.
        /// </summary>
        public Uri PaymentOrder { get; }

        /// <summary>
        /// The name of the selected menu element.
        /// </summary>
        public string MenuElementName { get; }

        /// <summary>
        /// Current payment object, contains detailed information.
        /// </summary>
        public ICurrentPayment Payment { get; }
    }
}