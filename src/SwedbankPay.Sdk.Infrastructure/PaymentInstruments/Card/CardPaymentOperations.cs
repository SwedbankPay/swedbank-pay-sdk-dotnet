using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments.CardPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class CardPaymentOperations : OperationsBase, ICardPaymentOperations
    {
        internal CardPaymentOperations(CardPaymentOperationsDto operations, HttpClient client)
        {
            foreach (var httpOperation in operations.Operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        Abort = async payload =>
                            await client.SendAsJsonAsync<CardPayments.CardPaymentResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.RedirectAuthorization:
                        RedirectAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewAuthorization:
                        ViewAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.DirectAuthorization:
                        DirectAuthorization = async payload =>
                            await client.SendAsJsonAsync<CardPaymentAuthorizationResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.CreateCapture:
                        Capture = async payload =>
                            await client.SendAsJsonAsync<CaptureResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.CreateCancellation:
                        Cancel = async payload =>
                            await client.SendAsJsonAsync<CancellationResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.CreateReversal:
                        Reverse = async payload =>
                            await client.SendAsJsonAsync<ReversalResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.RedirectVerification:
                        RedirectVerification = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewVerification:
                        ViewVerification = httpOperation;
                        break;

                    case PaymentResourceOperations.DirectVerification:
                        DirectVerification = httpOperation;
                        break;

                    case PaymentResourceOperations.PaidPayment:
                        PaidPayment = httpOperation;
                        break;
                }
                this.Add(httpOperation.Rel, httpOperation);
            }
        }

        public Func<CardPaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        public Func<CardPaymentCaptureRequest, Task<CaptureResponse>> Capture { get; }
        public Func<CardPaymentAuthorizationRequest, Task<CardPaymentAuthorizationResponse>> DirectAuthorization { get; }
        public Func<CardPaymentReversalRequest, Task<ReversalResponse>> Reverse { get; }
        public Func<CardPaymentAbortRequest, Task<CardPayments.CardPaymentResponse>> Abort { get; }
        public HttpOperation DirectVerification { get; internal set; }
        public HttpOperation PaidPayment { get; internal set; }
        public HttpOperation RedirectAuthorization { get; internal set; }
        public HttpOperation RedirectVerification { get; internal set; }
        public HttpOperation ViewAuthorization { get; internal set; }
        public HttpOperation ViewVerification { get; internal set; }
    }
}