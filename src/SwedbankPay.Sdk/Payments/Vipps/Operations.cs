using System;
using System.Threading.Tasks;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments.Vipps;
using SwedbankPay.Sdk.Payments;
using System.Collections.Generic;

namespace swedbankpay.sdk.Payments.Vipps
{
    public class Operations : Dictionary<LinkRelation, HttpOperation>
    {
        public Func<CancelRequest, Task<CancellationResponse>> Cancel { get; internal set; }
        public Func<CaptureRequest, Task<CaptureResponse>> Capture { get; internal set; }
        public Func<AuthorizationRequest, Task<AuthorizationResponse>> DirectAuthorization { get; internal set; }
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        public HttpOperation RedirectAuthorization { get; internal set; }
        public Func<ReversalRequest, Task<ReversalResponse>> Reversal { get; internal set; }
        public HttpOperation Update { get; internal set; }
        public HttpOperation ViewAuthorization { get; internal set; }
    }
}