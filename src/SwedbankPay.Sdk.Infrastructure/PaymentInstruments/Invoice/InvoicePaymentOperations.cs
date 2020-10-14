using System;
using SwedbankPay.Sdk.Extensions;
using System.Threading.Tasks;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.Payments.InvoicePayments;
using SwedbankPay.Sdk.Payments;
using System.Net.Http;

namespace Swedbankpay.Sdk.Payments
{
    public class InvoicePaymentOperations : OperationsBase, IInvoicePaymentOperations
    {
        public InvoicePaymentOperations(PaymentOperationsDto operations, HttpClient client)
        {
            foreach (var httpOperation in operations.Operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        Abort = async payload =>
                            await client.SendAsJsonAsync<SwedbankPay.Sdk.Payments.InvoicePayments.InvoicePaymentResponse>(httpOperation.Method, httpOperation.Href, payload);
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
                        ApprovedLegalAddress = async payload =>
                            await client.SendAsJsonAsync<ApprovedLegalAddressResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;

                    case PaymentResourceOperations.DirectAuthorization:
                        DirectAuthorization = async payload =>
                            await client.SendAsJsonAsync<InvoicePaymentAuthorizationResponse>(httpOperation.Method, httpOperation.Href, payload);
                        break;
                }
                this.Add(httpOperation.Rel, httpOperation);
            }
        }

        public Func<InvoiceApprovedLegalAddressRequest, Task<ApprovedLegalAddressResponse>> ApprovedLegalAddress { get; }
        public Func<PaymentAbortRequest, Task<SwedbankPay.Sdk.Payments.InvoicePayments.InvoicePaymentResponse>> Abort { get; }
        public Func<InvoicePaymentCancelRequest, Task<CancellationResponse>> Cancel { get; }
        public Func<InvoicePaymentCaptureRequest, Task<CaptureResponse>> Capture { get; }
        public Func<InvoicePaymentAuthorizationRequest, Task<InvoicePaymentAuthorizationResponse>> DirectAuthorization { get; }
        public Func<InvoicePaymentReversalRequest, Task<ReversalResponse>> Reversal { get; }
        public HttpOperation RedirectAuthorization { get; }
        public HttpOperation ViewAuthorization { get; }

    }
}