using System;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
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