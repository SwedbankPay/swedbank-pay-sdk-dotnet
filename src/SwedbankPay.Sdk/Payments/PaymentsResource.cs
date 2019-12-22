using System;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Exceptions;

namespace SwedbankPay.Sdk.Payments
{
    internal class PaymentsResource : ResourceBase, IPaymentsResource
    {
        //private readonly Uri PspVippsPaymentsBaseUrl = new Uri("/psp/vipps/payments/", UriKind.Relative);
        //private readonly Uri PspCreditCardPaymentsBaseUrl = new Uri("/psp/creditcard/payments/", UriKind.Relative);
        //private readonly Uri PspSwishPaymentsBaseUrl = new Uri("/psp/swish/payments/", UriKind.Relative);
        //private readonly Uri PspDirectDebitPaymentsBaseUrl = new Uri("/psp/directdebit/payments", UriKind.Relative);


        public PaymentsResource(SwedbankPayHttpClient swedbankPayHttpClient)
            : base(swedbankPayHttpClient)
        {
        }


        public async Task<Payment> Create(PaymentType paymentType,
                                          PaymentRequest paymentRequest,
                                          PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Payment.Create(paymentType, paymentRequest, this.swedbankPayHttpClient, GetExpandQueryString(paymentExpand));
        }


        public async Task<Payment> CreateCreditCardPayment(PaymentRequest paymentRequest, PaymentExpand paymentExpand = PaymentExpand.None)
        {
            return await Payment.Create(PaymentType.CreditCard, paymentRequest, this.swedbankPayHttpClient,
                                        GetExpandQueryString(paymentExpand));
        }


        public Task<Payment> Get(Uri id, PaymentExpand paymentExpand)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            return GetInternalAsync(id, paymentExpand);
        }


        ///// <summary>
        /////     Creates a new Vipps payment
        ///// </summary>
        ///// <param name="payment"></param>
        ///// <returns></returns>
        //public async Task<PaymentResponseContainer> PostVippsPayment(PaymentRequest payment)
        //{
        //    return await CreatePayment(PspVippsPaymentsBaseUrl, payment);
        //}

        ///// <summary>
        /////     Creates a new CreditCard payment
        ///// </summary>
        ///// <param name="payment"></param>
        ///// <returns></returns>
        //public async Task<PaymentResponseContainer> PostCreditCardPayment(PaymentRequest payment)
        //{
        //    return await CreatePayment(PspCreditCardPaymentsBaseUrl, payment);
        //}

        ///// <summary>
        /////     Gets an existing payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public Task<PaymentResponseContainer> GetPayment(Uri id, PaymentExpand paymentExpand = PaymentExpand.All)
        //{
        //    if (id == null)
        //        throw new ArgumentNullException(nameof(id));

        //    return GetPaymentInternalAsync(id, paymentExpand);
        //}

        ///// <summary>
        /////     Gets an existing payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<PaymentResponseContainer> GetPaymentInternalAsync(Uri id, PaymentExpand paymentExpand = PaymentExpand.All)
        //{
        //    var paymentOrderExpand = GetExpandQueryString(paymentExpand);
        //    var url = !string.IsNullOrWhiteSpace(paymentOrderExpand) ? new UriBuilder(id) { Query = paymentOrderExpand }.Uri : id;

        //    var res = await this.swedbankPayHttpClient.HttpGet<PaymentResponseContainer>(url);
        //    return res;
        //}

        ///// <summary>
        /////     Gets all sales for a payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<SaleResponse>> GetSales(Uri id)
        //{
        //    var res = await this.swedbankPayHttpClient.HttpGet<SaleResponseContainer>(id);
        //    return res.Sales.SaleList;
        //}

        ///// <summary>
        /////     Gets all transactions for a payment.
        ///// </summary>
        ///// <param name="id"></param>
        ///// <param name="paymentExpand"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<TransactionResponse>> GetTransactions(Uri id, PaymentExpand paymentExpand = PaymentExpand.All)
        //{
        //    var paymentOrderExpand = GetExpandQueryString(paymentExpand);
        //    var url = !string.IsNullOrWhiteSpace(paymentOrderExpand) ? new UriBuilder(id) { Query = paymentOrderExpand }.Uri : id;

        //    var res = await this.swedbankPayHttpClient.HttpGet<AllTransactionResponseContainer>(url);
        //    return res.Transactions.TransactionList;
        //}

        ///// <summary>
        /////     Captures a payment a.k.a POSTs a transaction.
        ///// </summary>
        //public async Task<TransactionResponse> PostCapture(Uri id, TransactionRequest transaction)
        //{
        //    var payment = await GetPayment(id);

        //    var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == "create-capture");
        //    if (httpOperation == null)
        //    {
        //        if (payment.Operations.Any())
        //        {
        //            var availableOps = payment.Operations.ToString();
        //            throw new PaymentNotYetAuthorizedException(
        //                id, $"This payment cannot be captured. Available operations: {availableOps}");
        //        }

        //        throw new NoOperationsLeftException();
        //    }

        //    var url = httpOperation.Href;

        //    var payload = new TransactionRequestContainer(transaction);
        //    var res = await this.swedbankPayHttpClient.SendHttpRequestAndProcessHttpResponse<CaptureTransactionResponseContainer>(httpOperation.Method, url, payload);
        //    return res.Capture.Transaction;
        //}

        ///// <summary>
        /////     Reverses a payment a.k.a POSTs a transaction.
        ///// </summary>
        //public async Task<TransactionResponse> PostReversal(Uri id, TransactionRequest transaction)
        //{
        //    var payment = await GetPayment(id);

        //    var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == "create-reversal");
        //    if (httpOperation == null)
        //    {
        //        if (payment.Operations.Any())
        //        {
        //            var availableOps = payment.Operations.ToString();
        //            throw new CouldNotReversePaymentException(id, $"This payment cannot be reversed. Available operations: {availableOps}");
        //        }

        //        throw new NoOperationsLeftException();
        //    }

        //    var url = httpOperation.Href;

        //    var payload = new TransactionRequestContainer(transaction);
        //    var res = await this.swedbankPayHttpClient.SendHttpRequestAndProcessHttpResponse<ReversalTransactionResponseContainer>(httpOperation.Method, url, payload);
        //    return res.Reversal.Transaction;
        //}

        ///// <summary>
        /////     Cancels a payment a.k.a POSTs a transaction.
        ///// </summary>
        //public async Task<TransactionResponse> PostCancellation(Uri id, TransactionRequest transaction)
        //{
        //    var payment = await GetPayment(id);

        //    var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == "create-cancellation");
        //    if (httpOperation == null)
        //    {
        //        if (payment.Operations.Any())
        //        {
        //            var availableOps = payment.Operations.ToString();
        //            throw new CouldNotCancelPaymentException(id, $"This payment cannot be cancelled. Available operations: {availableOps}");
        //        }

        //        throw new NoOperationsLeftException();
        //    }

        //    var url = httpOperation.Href;

        //    var payload = new TransactionRequestContainer(transaction);
        //    var res = await this.swedbankPayHttpClient.SendHttpRequestAndProcessHttpResponse<CancellationTransactionResponseContainer>(
        //        httpOperation.Method, url, payload);
        //    return res.Cancellation.Transaction;
        //}


        ///// <summary>
        /////     Cancels an unauthorized creditcard payment a.k.a PATCH with a static abort object.
        ///// </summary>
        //public async Task<PaymentResponseContainer> PatchAbortPayment(Uri id)
        //{
        //    var payment = await GetPayment(id);

        //    var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == "update-payment-abort");
        //    if (httpOperation == null)
        //    {
        //        if (payment.Operations.Any())
        //        {
        //            var availableOps = payment.Operations.ToString();
        //            throw new CouldNotCancelPaymentException(id, $"This payment cannot be aborted. Available operations: {availableOps}");
        //        }

        //        throw new NoOperationsLeftException();
        //    }

        //    var url = httpOperation.Href;

        //    var payload = new PaymentAbortRequestContainer();
        //    var res =
        //        await this.swedbankPayHttpClient.SendHttpRequestAndProcessHttpResponse<PaymentResponseContainer>(
        //            httpOperation.Method, url, payload);
        //    return res;
        //}


        //private async Task<PaymentResponseContainer> CreatePayment(Uri baseUrl, PaymentRequest payment)
        //{
        //    var payload = new PaymentRequestContainer(payment);

        //    var paymentOrderExpand = GetExpandQueryString(PaymentExpand.All);
        //    var url = !string.IsNullOrWhiteSpace(paymentOrderExpand)
        //        ? new Uri(baseUrl.OriginalString + paymentOrderExpand, UriKind.RelativeOrAbsolute)
        //        : baseUrl;

        //    var res =
        //        await this.swedbankPayHttpClient.SendHttpRequestAndProcessHttpResponse<PaymentResponseContainer>(
        //            HttpMethod.Post, url, payload);
        //    return res;
        //}


        private async Task<Payment> GetInternalAsync(Uri id, PaymentExpand paymentExpand)
        {
            return await Payment.Get(id, this.swedbankPayHttpClient, GetExpandQueryString(paymentExpand));
        }
    }
}