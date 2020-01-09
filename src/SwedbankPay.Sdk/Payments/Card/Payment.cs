using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.Payments.Card
{
    public class Payment
    {
        private Payment(PaymentResponseContainer<PaymentResponse> paymentResponseContainer, SwedbankPayHttpClient client)
        {
            PaymentResponse = paymentResponseContainer.PaymentResponse;
            var operations = new Operations();

            foreach (var httpOperation in paymentResponseContainer.Operations)
            {
                operations.Add(httpOperation.Rel, httpOperation);

                switch (httpOperation.Rel.Value)
                {
                    case PaymentResourceOperations.UpdatePaymentAbort:
                        operations.Update = httpOperation;
                        break;
                        
                    case PaymentResourceOperations.RedirectAuthorization:
                        operations.RedirectAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewAuthorization:
                        operations.ViewAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.DirectAuthorization:
                        operations.DirectAuthorization = httpOperation;
                        break;

                    case PaymentResourceOperations.CreateCapture:
                        operations.Capture = new ExecuteRequestWrapper<TransactionRequestContainer<TransactionRequest>, CaptureTransactionResponseContainer>(httpOperation.Request, client);
                        break;

                    case PaymentResourceOperations.CreateCancellation:
                        operations.Cancel = new ExecuteRequestWrapper<TransactionRequestContainer<CancelTransactionRequest>, CancellationTransactionResponseContainer>(httpOperation.Request, client);
                        break;

                    case PaymentResourceOperations.CreateReversal:
                        operations.Reversal = new ExecuteRequestWrapper<TransactionRequestContainer<ReversalTransactionRequest>, ReversalTransactionResponseContainer>(httpOperation.Request, client);
                        break;

                    case PaymentResourceOperations.RedirectVerification:
                        operations.RedirectVerification = httpOperation;
                        break;

                    case PaymentResourceOperations.ViewVerification:
                        operations.ViewVerification = httpOperation;
                        break;

                    case PaymentResourceOperations.DirectVerification:
                        operations.DirectVerification = httpOperation;
                        break;

                    case PaymentResourceOperations.PaidPayment:
                        operations.PaidPayment = httpOperation;
                        break;
                }
            }

            Operations = operations;
        }


        public Operations Operations { get; }

        public PaymentResponse PaymentResponse { get; }


        internal static async Task<Payment> Create(PaymentRequest paymentRequest,
                                                   SwedbankPayHttpClient client,
                                                   string paymentExpand)
        {
            var url = new Uri($"/psp/creditcard/payments{paymentExpand}", UriKind.Relative);

            var payload = new PaymentRequestContainer(paymentRequest);

            var paymentResponseContainer = await client.HttpPost<PaymentResponseContainer<PaymentResponse>>(url, payload);
            return new Payment(paymentResponseContainer, client);
        }




        internal static async Task<Payment> Get(Uri id, SwedbankPayHttpClient client, string paymentExpand)
        {
            var url = !string.IsNullOrWhiteSpace(paymentExpand)
                ? new Uri(id.OriginalString + paymentExpand, UriKind.RelativeOrAbsolute)
                : id;

            var paymentResponseContainer = await client.HttpGet<PaymentResponseContainer<PaymentResponse>>(url);
            return new Payment(paymentResponseContainer, client); 
        }
    }
}