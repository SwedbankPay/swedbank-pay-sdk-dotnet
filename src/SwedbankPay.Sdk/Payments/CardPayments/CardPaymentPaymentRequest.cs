using System.Collections.Generic;
using System.Globalization;

using SwedbankPay.Sdk.PaymentOrders;
using SwedbankPay.Sdk.Payments.CardPayments;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentPaymentRequest
    {
        public CardPaymentPaymentRequest(Operation operation,
                              Intent intent,
                              CurrencyCode currency,
                              List<Price> prices,
                              string description,
                              string userAgent,
                              CultureInfo language,
                              Urls urls,
                              PayeeInfo payeeInfo,
                              bool generatePaymentToken = false,
                              bool generateReccurenceToken = false,
                              string payerReference = null,
                              RiskIndicator riskIndicator = null,
                              Cardholder cardholder = null,
                              CreditCard creditCard = null,
                              Dictionary<string, object> metaData = null,
                              string paymentToken = null)
        {
            Payment = new CardPaymentPaymentRequestObject(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateReccurenceToken, userAgent, language, urls, payeeInfo, riskIndicator, cardholder,
                                               creditCard, metaData, paymentToken);
        }


        public CardPaymentPaymentRequestObject Payment { get; }
    }
}