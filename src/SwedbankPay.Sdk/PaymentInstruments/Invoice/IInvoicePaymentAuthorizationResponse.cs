using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentAuthorizationResponse
    {
        /// <summary>
        /// A <seealso cref="Uri"/> to this authorization response.
        /// </summary>
        Uri Payment { get; }
        IInvoicePaymentAuthorization Authorization { get; }
    }
}