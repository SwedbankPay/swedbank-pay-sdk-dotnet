using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentAuthorizationsResponse
    {
        public InvoicePaymentAuthorizationsResponse(Uri payment, IInvoicePaymentAuthorizationListResponse authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }


        public IInvoicePaymentAuthorizationListResponse AuthorizationList { get; }
        public Uri Payment { get; }
    }
}