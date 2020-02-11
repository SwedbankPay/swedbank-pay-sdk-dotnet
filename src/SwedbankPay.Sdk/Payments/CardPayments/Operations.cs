using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class Operations : Dictionary<LinkRelation, HttpOperation>
    {
        public Func<CardPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; internal set; }
        public Func<CardPaymentCaptureRequest, Task<CaptureResponse>> Capture { get; internal set; }
        public Func<CardPaymentAuthorizationRequest, Task<CardPaymentAuthorizationResponse>> DirectAuthorization { get; internal set; }
        public HttpOperation DirectVerification { get; internal set; }
        public new HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        public HttpOperation PaidPayment { get; internal set; }
        public HttpOperation RedirectAuthorization { get; internal set; }
        public HttpOperation RedirectVerification { get; internal set; }
        public Func<CardPaymentReversalRequest, Task<ReversalResponse>> Reversal { get; internal set; }

        public HttpOperation Update { get; internal set; }
        public HttpOperation ViewAuthorization { get; internal set; }
        public HttpOperation ViewVerification { get; internal set; }
    }
}