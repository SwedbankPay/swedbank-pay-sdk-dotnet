namespace SwedbankPay.Client.Resources
{
    using SwedbankPay.Client.Exceptions;
    using SwedbankPay.Client.Models;
    using SwedbankPay.Client.Models.Request;
    using SwedbankPay.Client.Models.Request.Transaction;
    using SwedbankPay.Client.Models.Response;
    using SwedbankPay.Client.Models.Vipps.TransactionAPI.Response;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class PaymentOrdersResource : ResourceBase, IPaymentOrdersResource
    {
        public PaymentOrdersResource(SwedbankPayOptions swedbankPayOptions, ILogPayExHttpResponse logger = null) : base(swedbankPayOptions, logger)
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
        public async Task<PaymentOrderResponseContainer> CreatePaymentOrder(PaymentOrderRequestContainer paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            var url = $"/psp/paymentorders{Utils.GetExpandQueryString(paymentOrderExpand)}";

            paymentOrderRequest.Paymentorder.Operation = "Purchase";

            Func<ProblemsContainer, Exception> onError = m => new CouldNotPlacePaymentOrderException(paymentOrderRequest, m);
            var res = await CreateInternalClient().HttpPost<PaymentOrderRequestContainer, PaymentOrderResponseContainer>(url, onError, paymentOrderRequest);
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

            var url = $"{id}{Utils.GetExpandQueryString(paymentOrderExpand)}";

            Func<ProblemsContainer, Exception> onError = m => new CouldNotFindPaymentException(id, m);
            var res = await CreateInternalClient().HttpGet<PaymentOrderResponseContainer>(url, onError);
            return res;
        }

        /// <summary>
        /// Updates an existing payment.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderRequest"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotUpdatePaymentOrderException"></exception>
        /// <returns></returns>
        public async Task<PaymentOrderResponseContainer> UpdatePaymentOrder(string id, PaymentOrderRequestContainer paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "update-paymentorder-updateorder");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new PaymentNotYetAuthorizedException(id, $"This payment cannot be updated. Available operations: {availableOps}"); //TODO: throw correct ecxception
                }
                throw new NoOperationsLeftException();
            }
            var url = $"{httpOperation.Href}{Utils.GetExpandQueryString(paymentOrderExpand)}";

            paymentOrderRequest.Paymentorder.Operation = "UpdateOrder";

            Func<ProblemsContainer, Exception> onError = m => new CouldNotUpdatePaymentOrderException(paymentOrderRequest, m);
            var res = await CreateInternalClient().HttpPatch<PaymentOrderRequestContainer, PaymentOrderResponseContainer>(url, onError, paymentOrderRequest);
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

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "update-paymentorder-abort");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new PaymentNotYetAuthorizedException(id, $"This payment cannot be aborted. Available operations: {availableOps}"); //TODO: throw correct ecxception
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;
            var paymentOrderRequest = new PaymentAbortRequestContainer();

            Func<ProblemsContainer, Exception> onError = m => new CouldNotPostTransactionException(id, m);
            var res = await CreateInternalClient().HttpPatch<PaymentAbortRequestContainer, PaymentOrderResponseContainer>(url, onError, paymentOrderRequest);
            return res;
        }

        /// <summary>
        /// Captures a payment
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="requestObject"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotPostTransactionException"></exception>
        /// <returns></returns>
        public async Task<TransactionResponse> Capture(string id, TransactionRequestContainer requestObject)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "create-paymentorder-capture");
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
            Func<ProblemsContainer, Exception> onError = m => new CouldNotPostTransactionException(url, m);
            var res = await CreateInternalClient().HttpPost<TransactionRequestContainer, CaptureTransactionResponseContainer>(url, onError, requestObject);
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
        public async Task<TransactionResponse> Reversal(string id, TransactionRequestContainer requestObject)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "create-paymentorder-reversal");
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
            var res = await CreateInternalClient().HttpPost<TransactionRequestContainer, ReversalTransactionResponseContainer>(url, onError, requestObject);
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
        public async Task<TransactionResponse> CancelPaymentOrder(string id, TransactionRequestContainer requestObject)
        {
            var payment = await GetPaymentOrder(id);

            var httpOperation = payment.Operations.FirstOrDefault(o => o.Rel == "create-paymentorder-cancel");
            if (httpOperation == null)
            {
                if (payment.Operations.Any())
                {
                    var availableOps = payment.Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
                    throw new PaymentNotYetAuthorizedException(id, $"This payment cannot be canceled. Available operations: {availableOps}"); //TODO: throw correct ecxception
                }
                throw new NoOperationsLeftException();
            }

            var url = httpOperation.Href;

            Func<ProblemsContainer, Exception> onError = m => new CouldNotPostTransactionException(id, m);
            var payload = new PaymentAbortRequestContainer();
            var res = await CreateInternalClient().HttpPost<TransactionRequestContainer, CancellationTransactionResponseContainer>(url, onError, requestObject);
            return res.Cancellation.Transaction;
        }
    }
}
