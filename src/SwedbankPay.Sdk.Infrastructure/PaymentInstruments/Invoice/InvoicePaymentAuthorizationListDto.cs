using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentAuthorizationListDto
    {
        public Uri Id { get; set; }
        public List<InvoicePaymentAuthorizationDto> AuthorizationList { get; set; }

        public IInvoicePaymentAuthorizationListResponse Map()
        {
            var list = new List<IInvoicePaymentAuthorization>();
            foreach (var item in AuthorizationList)
            {
                list.Add(new InvoicePaymentAuthorization(Id, item));
            }
            return new InvoicePaymentAuthorizationListResponse(Id, list);
        }
    }
}