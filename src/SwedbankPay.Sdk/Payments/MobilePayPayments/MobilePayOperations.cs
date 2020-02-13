using System;
using System.Threading.Tasks;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using SwedbankPay.Sdk.Payments;
using System.Collections.Generic;

namespace swedbankpay.sdk.Payments.MobilePayPayments
{
    public class MobilePayOperations : Dictionary<LinkRelation, HttpOperation>
    {
        public Func<MobilePayCancelRequest, Task<CancellationResponse>> Cancel { get; internal set; }
        public Func<MobilePayCaptureRequest, Task<CaptureResponse>> Capture { get; internal set; }
        public HttpOperation this[LinkRelation rel] => ContainsKey(rel) ? base[rel] : null;
        public HttpOperation RedirectAuthorization { get; internal set; }
        public Func<MobilePayReversalRequest, Task<ReversalResponse>> Reversal { get; internal set; }
        public HttpOperation Update { get; internal set; }
        public HttpOperation ViewAuthorization { get; internal set; }
    }
}