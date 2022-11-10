using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

internal class InvoicePaymentAuthorizationListDto
{
    public string Id { get; set; }
    public List<InvoicePaymentAuthorizationDto> AuthorizationList { get; set; }

    public IInvoicePaymentAuthorizationListResponse Map()
    {
        var list = new List<IInvoicePaymentAuthorization>();
        var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
        foreach (var item in AuthorizationList)
        {
            list.Add(new InvoicePaymentAuthorization(uri, item));
        }
        return new InvoicePaymentAuthorizationListResponse(uri, list);
    }
}