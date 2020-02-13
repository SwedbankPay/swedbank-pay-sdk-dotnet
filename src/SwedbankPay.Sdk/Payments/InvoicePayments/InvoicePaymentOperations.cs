using System;
using System.Threading.Tasks;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments.InvoicePayments;
using SwedbankPay.Sdk.Payments;
using System.Collections.Generic;

namespace Swedbankpay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentOperations : Dictionary<LinkRelation, HttpOperation>
    {
        public Func<InvoicePaymentCancelRequest, Task<CancellationResponse>> Cancel { get; internal set; }
        public Func<InvoicePaymentCaptureRequest, Task<CaptureResponse>> Capture { get; internal set; }
        public Func<InvoicePaymentAuthorizationRequest, Task<InvoicePaymentAuthorizationResponse>> DirectAuthorization { get; internal set; }
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        public HttpOperation RedirectAuthorization { get; internal set; }
        public Func<InvoicePaymentReversalRequest, Task<ReversalResponse>> Reversal { get; internal set; }
        public HttpOperation Update { get; internal set; }
        public HttpOperation ViewAuthorization { get; internal set; }
        public HttpOperation ApprovedLegalAddress { get; internal set; }

    }
}