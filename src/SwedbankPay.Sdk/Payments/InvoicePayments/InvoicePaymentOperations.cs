using System;
using SwedbankPay.Sdk.Extensions;
using System.Threading.Tasks;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments.InvoicePayments;
using SwedbankPay.Sdk.Payments;
using System.Net.Http;
using System.Collections.Generic;

namespace Swedbankpay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentOperations : OperationsBase
    {
        public InvoicePaymentOperations(OperationList operations, HttpClient client)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        Abort = async payload =>
                            await client.SendAsJsonAsync<InvoicePaymentResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.RedirectAuthorization:
                        RedirectAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewAuthorization:
                        ViewAuthorization = httpOperation;
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
                        Reversal = async payload =>
                            await client.SendAsJsonAsync<ReversalResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.CreateApprovedLegalAddress:
                        ApprovedLegalAddress = httpOperation;
                        break;

                }
                this.Add(httpOperation.Rel, httpOperation);
            }
        }
        public Func<PaymentAbortRequest, Task<InvoicePaymentResponse>> Abort { get; }
        public Func<InvoicePaymentCancelRequest, Task<CancellationResponse>> Cancel { get; internal set; }
        public Func<InvoicePaymentCaptureRequest, Task<CaptureResponse>> Capture { get; internal set; }
        public Func<InvoicePaymentAuthorizationRequest, Task<InvoicePaymentAuthorizationResponse>> DirectAuthorization { get; internal set; }
        public HttpOperation RedirectAuthorization { get; internal set; }
        public Func<InvoicePaymentReversalRequest, Task<ReversalResponse>> Reversal { get; internal set; }
        public HttpOperation Update { get; internal set; }
        public HttpOperation ViewAuthorization { get; internal set; }
        public HttpOperation ApprovedLegalAddress { get; internal set; }

    }
}