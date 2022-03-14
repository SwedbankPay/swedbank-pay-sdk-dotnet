namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// Request details for creating a payment order.
    /// </summary>
    public class PaymentOrderRequest
    {
        /// <summary>
        /// Request details for creating a payment order.
        /// </summary>
        /// <param name="operation">Initial API operation to perform.</param>
        /// <param name="currency">The wanted currency for the payment.</param>
        /// <param name="amount">The amount to pay in the payment.</param>
        /// <param name="vatAmount">The amount to pay that is value added taxes.</param>
        /// <param name="description">Textual description of the payment order.</param>
        /// <param name="language">The payers preferred <seealso cref="Sdk.Language"/>.</param>
        /// <param name="generateRecurrenceToken">Set if you want a recurrence token for recur payments.</param>
        /// <param name="urls">Object with URLs relevant for the payment.</param>
        /// <param name="payeeInfo">Object with information about the Merchant.</param>
        public PaymentOrderRequest(Operation operation,
                                   Currency currency,
                                   Amount amount,
                                   Amount vatAmount,
                                   string description,
                                   Language language,
                                   bool generateRecurrenceToken,
                                   IUrls urls,
                                   IPayeeInfo payeeInfo) : this(operation, currency, amount, vatAmount, description, null, language, generateRecurrenceToken, urls, payeeInfo)
        {
        }


        /// <summary>
        /// Request details for creating a payment order.
        /// </summary>
        /// <param name="operation">Initial API operation to perform.</param>
        /// <param name="currency">The wanted currency for the payment.</param>
        /// <param name="amount">The amount to pay in the payment.</param>
        /// <param name="vatAmount">The amount to pay that is value added taxes.</param>
        /// <param name="description">Textual description of the payment order.</param>
        /// <param name="userAgent">The payers UserAgent string.</param>
        /// <param name="language">The payers preferred <seealso cref="Sdk.Language"/>.</param>
        /// <param name="generateRecurrenceToken">Set if you want a recurrence token for recur payments.</param>
        /// <param name="urls">Object with URLs relevant for the payment.</param>
        /// <param name="payeeInfo">Object with information about the Merchant.</param>
        public PaymentOrderRequest(Operation operation,
                                   Currency currency,
                                   Amount amount,
                                   Amount vatAmount,
                                   string description,
                                   string userAgent,
                                   Language language,
                                   bool generateRecurrenceToken,
                                   IUrls urls,
                                   IPayeeInfo payeeInfo)
        {
            PaymentOrder = new PaymentOrderRequestDetails(operation, currency, amount, vatAmount, description, userAgent, language,
                                                         generateRecurrenceToken, urls, payeeInfo);
        }

        /// <summary>
        /// Transactional details about the payment order.
        /// </summary>
        public PaymentOrderRequestDetails PaymentOrder { get; }
    }
}