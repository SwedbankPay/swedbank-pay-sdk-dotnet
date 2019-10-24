namespace SwedbankPay.Sdk.PaymentOrders
{
    using System.Threading.Tasks;
    using SwedbankPay.Sdk.Exceptions;
    using SwedbankPay.Sdk.Models;
    using SwedbankPay.Sdk.Models.Request;
    using SwedbankPay.Sdk.Models.Request.Transaction;
    using SwedbankPay.Sdk.Models.Response.PaymentOrder;
    using SwedbankPay.Sdk.Models.Vipps.TransactionAPI.Response;

    public interface IPaymentOrdersResource
    {
        /// <summary>
        /// Creates a payment order
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="CouldNotPlacePaymentOrderException"></exception>
        /// <returns></returns>
        Task<PaymentOrderResponseContainer> CreatePaymentOrder(PaymentOrderRequestContainer paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);

        /// <summary>
        /// Gets an existing payment order.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paymentOrderExpand"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="CouldNotFindPaymentException"></exception>
        /// <returns></returns>
        Task<PaymentOrderResponseContainer> GetPaymentOrder(string id, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);

        /// <summary>
        /// Updates an existing payment.
        /// </summary>
        /// <param name="paymentOrderRequest"></param>
        /// <param name="id"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotUpdatePaymentOrderException"></exception>
        /// <returns></returns>
        Task<PaymentOrderResponseContainer> UpdatePaymentOrder(string id, PaymentOrderRequestContainer paymentOrderRequest, PaymentOrderExpand paymentOrderExpand = PaymentOrderExpand.None);

        /// <summary>
        /// Aborts a payment
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotPostTransactionException"></exception>
        /// <returns></returns>
        Task<PaymentOrderResponseContainer> AbortPaymentOrder(string id);

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
        Task<TransactionResponse> Capture(string id, TransactionRequestContainer requestObject);

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
        Task<TransactionResponse> Reversal(string id, TransactionRequestContainer requestObject);

        /// <summary>
        /// Cancels a payment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestObject"></param>
        /// <exception cref="InvalidConfigurationSettingsException"></exception>
        /// <exception cref="PaymentNotYetAuthorizedException"></exception>
        /// <exception cref="NoOperationsLeftException"></exception>
        /// <exception cref="CouldNotPostTransactionException"></exception>
        /// <returns></returns>
        Task<TransactionResponse> CancelPaymentOrder(string id, TransactionRequestContainer requestObject);
    }
}
