namespace SwedbankPay.Sdk.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SwedbankPay.Sdk.Exceptions;
    using SwedbankPay.Sdk.Models;
    using SwedbankPay.Sdk.Models.Request;
    using SwedbankPay.Sdk.Models.Request.Transaction;
    using SwedbankPay.Sdk.Models.Response.Payment;
    using SwedbankPay.Sdk.Models.Vipps.PaymentAPI.Request;
    using SwedbankPay.Sdk.Models.Vipps.TransactionAPI.Response;

    public class PaymentResource : ResourceBase, IPaymentResource
    {
        private const string PspVippsPaymentsBaseUrl = "/psp/vipps/payments/";
        private const string PspCreditCardPaymentsBaseUrl = "/psp/creditcard/payments/";
        private const string PspSwishPaymentsBaseUrl = "/psp/swish/payments/";
        private const string PspDirectDebitPaymentsBaseUrl = "/psp/directdebit/payments";

        public PaymentResource(SwedbankPayOptions swedbankPayOptions, ILogPayExHttpResponse logger) : base(swedbankPayOptions, logger)
        {
        }

        /// <summary>
        /// Creates a new Vipps payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public async Task<PaymentResponseContainer> PostVippsPayment(PaymentRequest payment)
        {
            return await CreatePayment(PspVippsPaymentsBaseUrl, payment);
        }

        /// <summary>
        /// Creates a new CreditCard payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public async Task<PaymentResponseContainer> PostCreditCardPayment(PaymentRequest payment)
        {
            return await CreatePayment(PspCreditCardPaymentsBaseUrl, payment);
        }


        /// <summary>
        /// Gets an existing payment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<PaymentResponseContainer> GetPayment(string id, PaymentExpand paymentExpand = PaymentExpand.All)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new CouldNotFindPaymentException(id);
            }
            var url = $"{id}{GetExpandQueryString(paymentExpand)}";
            Func<ProblemsContainer, Exception> onError = m => new CouldNotFindPaymentException(id, m);
            var res = await CreateInternalClient().HttpGet<PaymentResponseContainer>(url, onError);
            return res;
        }

        /// <summary>
        /// Gets all sales for a payment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SaleResponse>> GetSales(string id)
        {
            Func<ProblemsContainer, Exception> onError = m => new CouldNotFindTransactionException(id, m);
            var res = await CreateInternalClient().HttpGet<SaleResponseContainer>(id, onError);
            return res.Sales.SaleList;
        }

        /// <summary>
        /// Gets all transactions for a payment.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TransactionResponse>> GetTransactions(string id, PaymentExpand paymentExpand = PaymentExpand.All)
        {
            var url = $"{id}{GetExpandQueryString(paymentExpand)}";
            Func<ProblemsContainer, Exception> onError = m => new CouldNotFindTransactionException(id, m);
            var res = await CreateInternalClient().HttpGet<AllTransactionResponseContainer>(url, onError);
            return res.Transactions.TransactionList;
        }

        /// <summary>
        /// Captures a payment a.k.a POSTs a transaction.
        /// </summary>
        public async Task<TransactionResponse> PostCapture(string id, TransactionRequest transaction)
        {
            var payment = await GetPayment(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "create-capture");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new PaymentNotYetAuthorizedException(id, $"This payment cannot be captured. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;
            Func<ProblemsContainer, Exception> onError = m => new CouldNotPostTransactionException(id, m);
            var payload = new TransactionRequestContainer(transaction);
            var res = await CreateInternalClient().HttpPost<TransactionRequestContainer, CaptureTransactionResponseContainer>(url, onError, payload);
            return res.Capture.Transaction;
        }

        /// <summary>
        /// Reverses a payment a.k.a POSTs a transaction.
        /// </summary>
        public async Task<TransactionResponse> PostReversal(string id, TransactionRequest transaction)
        {
            var payment = await GetPayment(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "create-reversal");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new CouldNotReversePaymentException(id, $"This payment cannot be reversed. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;
            Func<ProblemsContainer, Exception> onError = m => new CouldNotPostTransactionException(id, m);
            var payload = new TransactionRequestContainer(transaction);
            var res = await CreateInternalClient().HttpPost<TransactionRequestContainer, ReversalTransactionResponseContainer>(url, onError, payload);
            return res.Reversal.Transaction;
        }

        /// <summary>
        /// Cancels a payment a.k.a POSTs a transaction.
        /// </summary>
        public async Task<TransactionResponse> PostCancellation(string id, TransactionRequest transaction)
        {
            var payment = await GetPayment(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "create-cancellation");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new CouldNotCancelPaymentException(id, $"This payment cannot be cancelled. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;
            Func<ProblemsContainer, Exception> onError = m => new CouldNotPostTransactionException(id, m);
            var payload = new TransactionRequestContainer(transaction);
            var res = await CreateInternalClient().HttpPost<TransactionRequestContainer, CancellationTransactionResponseContainer>(url, onError, payload);
            return res.Cancellation.Transaction;
        }


        /// <summary>
        /// Cancels an unauthorized creditcard payment a.k.a PATCH with a static abort object.
        /// </summary>
        public async Task<PaymentResponseContainer> PatchAbortPayment(string id)
        {
            var payment = await GetPayment(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "update-payment-abort");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new CouldNotCancelPaymentException(id, $"This payment cannot be aborted. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;
            Func<ProblemsContainer, Exception> onError = m => new CouldNotPostTransactionException(id, m);
            var payload = new PaymentAbortRequestContainer();
            var res = await CreateInternalClient().HttpPatch<PaymentAbortRequestContainer, PaymentResponseContainer>(url, onError, payload);
            return res;
        }



        private async Task<PaymentResponseContainer> CreatePayment(string baseUrl, PaymentRequest payment)
        {
            payment.SetRequiredMerchantInfo(SwedbankPayOptions);

            var payload = new PaymentRequestContainer(payment);
            Func<ProblemsContainer, Exception> onError = m => new CouldNotPlacePaymentException(payment, m); 
            var url = $"{baseUrl}{GetExpandQueryString(PaymentExpand.All)}";
            var res = await CreateInternalClient().HttpPost<PaymentRequestContainer, PaymentResponseContainer>(url, onError, payload);
            return res;
        }
    }
}
