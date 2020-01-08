using System;

using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponseContainer : PaymentResponseContainer<CurrentPaymentResponse>
    {
        public CurrentPaymentResponseContainer(Uri id, string menuElementName,
                                               OperationList operations,
                                               CurrentPaymentResponse paymentResponse) : base(operations, paymentResponse)
        {
            Id = id;
            MenuElementName = menuElementName;
        }

        /// <summary>
        ///     The relative URI to the payment.
        /// </summary>
        public Uri Id { get; }

        /// <summary>
        ///     creditcard, invoice, etc. The name of the selected menu element.
        /// </summary>
        public string MenuElementName { get; }
    }
}