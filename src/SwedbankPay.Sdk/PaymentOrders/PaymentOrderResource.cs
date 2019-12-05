namespace SwedbankPay.Sdk.PaymentOrders
{
    using Microsoft.Extensions.Logging;

    using SwedbankPay.Sdk.Exceptions;
    using SwedbankPay.Sdk.Payments;
    using SwedbankPay.Sdk.Transactions;

    using System;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class PaymentOrderResource : ResourceBase, IPaymentOrderResource
    {
        public PaymentOrderResource(SwedbankPayOptions swedbankPayOptions,
                                     ILogger logger,
                                     HttpClient client) : base(swedbankPayOptions, logger, client)
        {
        }

        /// <summary>
        /// Creates a payment order
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="CouldNotPlacePaymentOrderException"></exception>
        /// <returns></returns>
        public async Task<PaymentOrderResponseContainer> CreatePaymentOrder(PaymentOrderRequest paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            var url = $"/psp/paymentorders{GetExpandQueryString(paymentOrderExpand)}";
            paymentOrderRequest.SetRequiredMerchantInfo(this.swedbankPayOptions);

            var payload = new PaymentOrderRequestContainer(paymentOrderRequest);
            paymentOrderRequest.Operation = Operation.Purchase;

            Exception OnError(ProblemsContainer m) => new CouldNotPlacePaymentOrderException(payload, m);
            var res = await this.swedbankPayClient.HttpRequest<PaymentOrderResponseContainer>(HttpMethod.Post, url, OnError, payload);
            return res;
        }


        /// <summary>
        /// Gets an existing payment order.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="CouldNotFindPaymentException"></exception>
        /// <returns></returns>
        public async Task<PaymentOrderResponseContainer> GetPaymentOrder(string id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new CouldNotFindPaymentException(id);
            }

            var url = $"{id}{GetExpandQueryString(paymentOrderExpand)}";

            Exception OnError(ProblemsContainer m) => new CouldNotFindPaymentException(id, m);
            var res = await this.swedbankPayClient.HttpGet<PaymentOrderResponseContainer>(url, OnError);
            return res;
        }


        /// <summary>
        /// Updates an existing payment.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderRequest"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotUpdatePaymentOrderException"></exception>
        /// <returns></returns>
        public async Task<PaymentOrderResponseContainer> UpdatePaymentOrder(string id, PaymentOrderRequest paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == PaymentOrderResourceOperations.UpdatePaymentOrderUpdateOrder);
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.ToString();
                    throw new OperationNotAvailableException(id, $"This payment cannot be updated. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }
            var url = $"{httpOperation.Href}{GetExpandQueryString(paymentOrderExpand)}";

            paymentOrderRequest.Operation = Operation.UpdateOrder;
            var payload = new PaymentOrderRequestContainer(paymentOrderRequest);

            Exception OnError(ProblemsContainer m) => new CouldNotUpdatePaymentOrderException(payload, m);
            var res = await this.swedbankPayClient.HttpRequest<PaymentOrderResponseContainer>(httpOperation.Method, url, OnError, payload);
            return res;
        }


        /// <summary>
        /// Aborts a payment
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotPostTransactionException"></exception>
        /// <returns></returns>
        public async Task<PaymentOrderResponseContainer> AbortPaymentOrder(string id)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == PaymentOrderResourceOperations.UpdatePaymentOrderAbort);
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.ToString();
                    throw new OperationNotAvailableException(id, $"This payment cannot be aborted. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;
            var paymentOrderRequest = new PaymentAbortRequestContainer();

            Exception OnError(ProblemsContainer m) => new CouldNotPostTransactionException(id, m);
            var res = await this.swedbankPayClient.HttpRequest<PaymentOrderResponseContainer>(httpOperation.Method, url, OnError, paymentOrderRequest);
            return res;
        }


        /// <summary>
        /// Captures a payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestObject"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotPostTransactionException"></exception>
        /// <returns></returns>
        public async Task<TransactionResponse> Capture(string id, TransactionRequest requestObject)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == PaymentOrderResourceOperations.CreatePaymentOrderCapture);
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.ToString();
                    throw new PaymentNotYetAuthorizedException(id, $"This payment cannot be captured. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;

            var payload = new TransactionRequestContainer(requestObject);

            Exception OnError(ProblemsContainer m) => new CouldNotPostTransactionException(url, m);
            var res = await this.swedbankPayClient.HttpRequest<CaptureTransactionResponseContainer>(httpOperation.Method, url, OnError, payload);
            return res.Capture.Transaction;
        }


        /// <summary>
        /// Reverses a payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestObject"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotPostTransactionException"></exception>
        /// <returns></returns>
        public async Task<TransactionResponse> Reversal(string id, TransactionRequest requestObject)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == PaymentOrderResourceOperations.CreatePaymentOrderReversal);
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.ToString();
                    throw new PaymentNotYetAuthorizedException(id, $"This payment cannot be captured. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;
            var payload = new TransactionRequestContainer(requestObject);
            Exception OnError(ProblemsContainer m) => new CouldNotPostTransactionException(id, m);
            var res = await this.swedbankPayClient.HttpRequest<ReversalTransactionResponseContainer>(httpOperation.Method, url, OnError, payload);
            return res.Reversal.Transaction;
        }

        /// <summary>
        /// Cancels a payment
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotPostTransactionException"></exception>
        /// <param name="requestObject"></param>
        /// <returns></returns>
        public async Task<TransactionResponse> CancelPaymentOrder(string id, TransactionRequest requestObject)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel.Value == PaymentOrderResourceOperations.CreatePaymentOrderCancel);
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.ToString();
                    throw new OperationNotAvailableException(id, $"This payment cannot be canceled. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;
            var payload = new TransactionRequestContainer(requestObject);
            Exception OnError(ProblemsContainer m) => new CouldNotPostTransactionException(id, m);
            var res = await this.swedbankPayClient.HttpRequest<CancellationTransactionResponseContainer>(httpOperation.Method, url, OnError, payload);
            return res.Cancellation.Transaction;
        }


        public async Task<PaymentOrder> Create(PaymentOrderRequest paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            return await PaymentOrder.Create(paymentOrderRequest, this.swedbankPayClient, this.swedbankPayOptions, paymentOrderExpand);
        }

        public async Task<PaymentOrder> Get(string id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            return await PaymentOrder.Get(id, this.swedbankPayClient, this.swedbankPayOptions, paymentOrderExpand);
        }
    }
}
