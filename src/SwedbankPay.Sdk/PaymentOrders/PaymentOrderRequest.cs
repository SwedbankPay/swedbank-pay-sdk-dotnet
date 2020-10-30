using SwedbankPay.Sdk.Common;
using System.Collections.Generic;

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
            PaymentOrder = new PaymentOrderRequestObject(operation, currency, amount, vatAmount, description, userAgent, language,
                                                         generateRecurrenceToken, urls, payeeInfo, payer, orderItems, riskIndicator,
                                                         metadata, items, disablePaymentMenu);
        }


        public PaymentOrderRequestObject PaymentOrder { get; }
    }
}