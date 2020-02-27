using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderRequest
    {
        public PaymentOrderRequest(Operation operation,
                                   CurrencyCode currency,
                                   Amount amount,
                                   Amount vatAmount,
                                   string description,
                                   string userAgent,
                                   CultureInfo language,
                                   bool generateRecurrenceToken,
                                   Urls urls,
                                   PayeeInfo payeeInfo,
                                   Payer payer = null,
                                   List<OrderItem> orderItems = null,
                                   RiskIndicator riskIndicator = null,
                                   Dictionary<string, object> metadata = null,
                                   List<Item> items = null,
                                   bool? disablePaymentMenu = null)
        {
            PaymentOrder = new PaymentOrderRequestObject(operation, currency, amount, vatAmount, description, userAgent, language,
                                                         generateRecurrenceToken, urls, payeeInfo, payer, orderItems, riskIndicator,
                                                         metadata, items, disablePaymentMenu);
        }


        public PaymentOrderRequestObject PaymentOrder { get; }
    }
}