﻿using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

public class InvoicePaymentsResource : ResourceBase, IInvoiceResource
{
    public InvoicePaymentsResource(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<IInvoicePaymentResponse> Get(Uri id, PaymentExpand paymentExpand = PaymentExpand.None)
    {
        if (id == null)
        {
            throw new ArgumentNullException(nameof(id));
        }

        var url = id.GetUrlWithQueryString(paymentExpand);

        var paymentResponse = await HttpClient.GetAsJsonAsync<InvoicePaymentResponseDto>(url);
        return new InvoicePaymentResponse(paymentResponse, HttpClient);
    }

    public async Task<IInvoicePaymentResponse> Create(InvoicePaymentRequest paymentRequest,
                                       PaymentExpand paymentExpand = PaymentExpand.None)
    {
        var url = new Uri("/psp/invoice/payments", UriKind.Relative).GetUrlWithQueryString(paymentExpand);

        var requestDto = new InvoicePaymentRequestDto(paymentRequest);

        var paymentResponse = await HttpClient.PostAsJsonAsync<InvoicePaymentResponseDto>(url, requestDto);
        return new InvoicePaymentResponse(paymentResponse, HttpClient);
    }
}
