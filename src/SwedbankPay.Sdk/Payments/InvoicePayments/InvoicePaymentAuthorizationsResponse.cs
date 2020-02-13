using System;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentAuthorizationsResponse
    {
        public InvoicePaymentAuthorizationsResponse(Uri payment, InvoicePaymentAuthorizationListResponse authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }


        public InvoicePaymentAuthorizationListResponse AuthorizationList { get; }

        public Uri Payment { get; }
    }
}