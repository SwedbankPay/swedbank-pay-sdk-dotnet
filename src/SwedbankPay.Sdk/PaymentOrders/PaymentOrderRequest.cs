using System.Collections.Generic;

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
        /// <param name="userAgent">The payers UserAgent string.</param>
        /// <param name="language">The payers prefered languae.</param>
        /// <param name="generateRecurrenceToken">Set if you want a recurrence token for recur payments.</param>
        /// <param name="urls">Object with URLs relevant for the payment.</param>
        /// <param name="payeeInfo">Object with information about the Merchant.</param>
        /// <param name="payer">Detail information about the payer of the payment.</param>
        /// <param name="orderItems">List of items involved in the payment.</param>
        /// <param name="riskIndicator">Detailed information about the risk involved in this payment.</param>
        /// <param name="metadata">MetaData to be stored on the payment.</param>
        /// <param name="items">List of payment instrument details.</param>
        /// <param name="disablePaymentMenu">Set if you want the payment menu to be disabled.</param>
        public PaymentOrderRequest(Operation operation,
                                   Currency currency,
                                   Amount amount,
                                   Amount vatAmount,
                                   string description,
                                   string userAgent,
                                   Language language,
                                   bool generateRecurrenceToken,
                                   IUrls urls,
                                   PayeeInfo payeeInfo,
                                   Payer payer = null,
                                   List<OrderItem> orderItems = null,
                                   IRiskIndicator riskIndicator = null,
                                   Dictionary<string, object> metadata = null,
                                   List<Item> items = null,
                                   bool? disablePaymentMenu = null)
        {
            PaymentOrder = new PaymentOrderRequestDetails(operation, currency, amount, vatAmount, description, userAgent, language,
                                                         generateRecurrenceToken, urls, payeeInfo, payer, orderItems, riskIndicator,
                                                         metadata, items, disablePaymentMenu);
        }

        /// <summary>
        /// Transactional details about the payment order.
        /// </summary>
        public PaymentOrderRequestDetails PaymentOrder { get; }
    }
}