namespace SwedbankPay.Sdk.PaymentOrders
{
    using System;

    using SwedbankPay.Sdk.Payments;

    public class CurrentPaymentResponseContainer : PaymentResponseContainer
    {
        /// <summary>
        /// The relative URI to the payment.
        /// </summary>
        public Uri Id { get; set; }

        /// <summary>
        /// creditcard, invoice, etc. The name of the selected menu element.
        /// </summary>
        public string MenuElementName { get; set; }
    }
}