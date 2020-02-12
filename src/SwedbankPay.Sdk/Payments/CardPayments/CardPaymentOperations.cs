using System;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentOperations : OperationsBase
    {
        public Func<CardPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; internal set; }
        public Func<CardPaymentCaptureRequest, Task<CaptureResponse>> Capture { get; internal set; }
        public Func<CardPaymentAuthorizationRequest, Task<CardPaymentAuthorizationResponse>> DirectAuthorization { get; internal set; }
        public Func<CardPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; internal set; }
        public HttpOperation DirectVerification { get; internal set; }
        public HttpOperation PaidPayment { get; internal set; }
        public HttpOperation RedirectAuthorization { get; internal set; }
        public HttpOperation RedirectVerification { get; internal set; }
        public HttpOperation Update { get; internal set; }
        public HttpOperation ViewAuthorization { get; internal set; }
        public HttpOperation ViewVerification { get; internal set; }
    }
}