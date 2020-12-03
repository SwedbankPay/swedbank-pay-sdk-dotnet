using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.PaymentInstruments.Card;
using SwedbankPay.Sdk.PaymentOrders;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentOperations : OperationsBase, IInvoicePaymentOperations
    {
        public InvoicePaymentOperations(IOperationList operations, HttpClient client)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        Abort = async payload => {
                            var dto = await client.SendAsJsonAsync<InvoicePaymentResponseDto>(httpOperation.Method, httpOperation.Href, payload);
                            return new InvoicePaymentResponse(dto, client);
                        };
                        break;

                    case PaymentResourceOperations.RedirectAuthorization:
                        RedirectAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewAuthorization:
                        ViewAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.CreateCapture:
                        Capture = async payload => {
                            var dto = await client.SendAsJsonAsync<CaptureResponseDto>(httpOperation.Method, httpOperation.Href, payload);
                            return new CaptureResponse(dto.Payment, dto.Capture.Map());
                        };
                        break;

                    case PaymentResourceOperations.CreateCancellation:
                        Cancel = async payload => {
                            var dto = await client.SendAsJsonAsync<CancellationResponseDto>(httpOperation.Method, httpOperation.Href, payload);
                            return new CancellationResponse(dto.Payment, dto.Cancellation.Map());
                        };
                        break;

                    case PaymentResourceOperations.CreateReversal:
                        Reversal = async payload => {
                            var dto = await client.SendAsJsonAsync<ReversalResponseDto>(httpOperation.Method, httpOperation.Href, payload);
                            return new ReversalResponse(dto.Payment, dto.Reversal.Map());
                        };
                        break;

                    case PaymentResourceOperations.CreateApprovedLegalAddress:
                        ApprovedLegalAddress = async payload => {
                            var dto = await client.SendAsJsonAsync<ApprovedLegalAddressResponseDto>(httpOperation.Method, httpOperation.Href, payload);
                            return new ApprovedLegalAddressResponse(dto.Payment, dto.ApprovedLegalAddress.Map());
                        };
                        break;

                    case PaymentResourceOperations.DirectAuthorization:
                        DirectAuthorization = async payload => {
                            var dto = await client.SendAsJsonAsync<InvoicePaymentAuthorizationResponseDto>(httpOperation.Method, httpOperation.Href, payload);
                            return new InvoicePaymentAuthorizationResponse(dto.Payment, dto.Map());
                        };
                        break;
                }
                Add(httpOperation.Rel, httpOperation);
            }
        }

        public Func<InvoiceApprovedLegalAddressRequest, Task<ApprovedLegalAddressResponse>> ApprovedLegalAddress { get; }
        public Func<PaymentAbortRequest, Task<IInvoicePaymentResponse>> Abort { get; }
        public Func<InvoicePaymentCancelRequest, Task<ICancellationResponse>> Cancel { get; }
        public Func<InvoicePaymentCaptureRequest, Task<ICaptureResponse>> Capture { get; }
        public Func<InvoicePaymentAuthorizationRequest, Task<IInvoicePaymentAuthorizationResponse>> DirectAuthorization { get; }
        public Func<InvoicePaymentReversalRequest, Task<IReversalResponse>> Reversal { get; }
        public HttpOperation RedirectAuthorization { get; }
        public HttpOperation ViewAuthorization { get; }

    }
}