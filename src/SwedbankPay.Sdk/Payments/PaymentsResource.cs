using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.Transactions;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentsResource : ResourceBase, IPaymentsResource
    {
        private const string PspVippsPaymentsBaseUrl = "/psp/vipps/payments/";
        private const string PspCreditCardPaymentsBaseUrl = "/psp/creditcard/payments/";
        private const string PspSwishPaymentsBaseUrl = "/psp/swish/payments/";
        private const string PspDirectDebitPaymentsBaseUrl = "/psp/directdebit/payments";


        public PaymentsResource(SwedbankPayOptions swedbankPayOptions,
                                ILogger logger,
                                HttpClient client)
            : base(swedbankPayOptions, logger, client)
        {
        }


        /// <summary>
        ///     Creates a new Vipps payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public async Task<PaymentResponseContainer> PostVippsPayment(PaymentRequest payment)
        {
            return await CreatePayment(PspVippsPaymentsBaseUrl, payment);
        }


        /// <summary>
        ///     Creates a new CreditCard payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public async Task<PaymentResponseContainer> PostCreditCardPayment(PaymentRequest payment)
        {
            return await CreatePayment(PspCreditCardPaymentsBaseUrl, payment);
        }


        /// <summary>
        ///     Gets an existing payment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PaymentResponseContainer> GetPayment(string id, PaymentExpand paymentExpand = PaymentExpand.All)
        {
            if (string.IsNullOrEmpty(id))
                throw new CouldNotFindPaymentException(id);
            var url = $"{id}{GetExpandQueryString(paymentExpand)}";

            Exception OnError(ProblemsContainer m)
            {
                return new CouldNotFindPaymentException(id, m);
            }

            var res = await this.swedbankPayClient.HttpRequest<PaymentResponseContainer>(HttpMethod.Get, url, OnError);
            return res;
        }


        /// <summary>
        ///     Gets all sales for a payment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SaleResponse>> GetSales(string id)
        {
            Func<ProblemsContainer, Exception> onError = m => new CouldNotFindTransactionException(id, m);

            var res = await this.swedbankPayClient.HttpRequest<SaleResponseContainer>(HttpMethod.Get, id, onError);
            return res.Sales.SaleList;
        }


        /// <summary>
        ///     Gets all transactions for a payment.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentExpand"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TransactionResponse>> GetTransactions(string id, PaymentExpand paymentExpand = PaymentExpand.All)
        {
            var url = $"{id}{GetExpandQueryString(paymentExpand)}";

            Exception OnError(ProblemsContainer m)
            {
                return new CouldNotFindTransactionException(id, m);
            }

            var res = await this.swedbankPayClient.HttpRequest<AllTransactionResponseContainer>(HttpMethod.Get, url, OnError);
            return res.Transactions.TransactionList;
        }


        /// <summary>
        ///     Captures a payment a.k.a POSTs a transaction.
        /// </summary>
        public async Task<TransactionResponse> PostCapture(string id, TransactionRequest transaction)
        {
            var payment = await GetPayment(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == "create-capture");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.ToString();
                    throw new PaymentNotYetAuthorizedException(
                        id, $"This payment cannot be captured. Available operations: {availableOps}");
                }

                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;

            Exception OnError(ProblemsContainer m)
            {
                return new CouldNotPostTransactionException(id, m);
            }

            var payload = new TransactionRequestContainer(transaction);
            var res = await this.swedbankPayClient.HttpRequest<CaptureTransactionResponseContainer>(HttpMethod.Post, url, OnError, payload);
            return res.Capture.Transaction;
        }


        /// <summary>
        ///     Reverses a payment a.k.a POSTs a transaction.
        /// </summary>
        public async Task<TransactionResponse> PostReversal(string id, TransactionRequest transaction)
        {
            var payment = await GetPayment(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == "create-reversal");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.ToString();
                    throw new CouldNotReversePaymentException(id, $"This payment cannot be reversed. Available operations: {availableOps}");
                }

                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;

            Exception OnError(ProblemsContainer m)
            {
                return new CouldNotPostTransactionException(id, m);
            }

            var payload = new TransactionRequestContainer(transaction);
            var res =
                await this.swedbankPayClient.HttpRequest<ReversalTransactionResponseContainer>(HttpMethod.Post, url, OnError, payload);
            return res.Reversal.Transaction;
        }


        /// <summary>
        ///     Cancels a payment a.k.a POSTs a transaction.
        /// </summary>
        public async Task<TransactionResponse> PostCancellation(string id, TransactionRequest transaction)
        {
            var payment = await GetPayment(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == "create-cancellation");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.ToString();
                    throw new CouldNotCancelPaymentException(id, $"This payment cannot be cancelled. Available operations: {availableOps}");
                }

                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;

            Exception OnError(ProblemsContainer m)
            {
                return new CouldNotPostTransactionException(id, m);
            }

            var payload = new TransactionRequestContainer(transaction);
            var res = await this.swedbankPayClient.HttpRequest<CancellationTransactionResponseContainer>(
                httpOperation.Method, url, OnError, payload);
            return res.Cancellation.Transaction;
        }


        /// <summary>
        ///     Cancels an unauthorized creditcard payment a.k.a PATCH with a static abort object.
        /// </summary>
        public async Task<PaymentResponseContainer> PatchAbortPayment(string id)
        {
            var payment = await GetPayment(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == "update-payment-abort");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.ToString();
                    throw new CouldNotCancelPaymentException(id, $"This payment cannot be aborted. Available operations: {availableOps}");
                }

                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;

            Exception OnError(ProblemsContainer m)
            {
                return new CouldNotPostTransactionException(id, m);
            }

            var payload = new PaymentAbortRequestContainer();
            var res = await this.swedbankPayClient.HttpRequest<PaymentResponseContainer>(httpOperation.Method, url, OnError, payload);
            return res;
        }


        private async Task<PaymentResponseContainer> CreatePayment(string baseUrl, PaymentRequest payment)
        {
            payment.SetRequiredMerchantInfo(this.swedbankPayOptions);

            var payload = new PaymentRequestContainer(payment);

            Exception OnError(ProblemsContainer m)
            {
                return new CouldNotPlacePaymentException(payment, m);
            }

            var url = $"{baseUrl}{GetExpandQueryString(PaymentExpand.All)}";
            var res = await this.swedbankPayClient.HttpPost<PaymentRequestContainer, PaymentResponseContainer>(url, OnError, payload);
            return res;
        }
    }
}