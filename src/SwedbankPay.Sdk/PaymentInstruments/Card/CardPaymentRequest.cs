using System.Collections.Generic;
using System.Globalization;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentRequest
    {
        public CardPaymentRequest(Operation operation,
                              Intent intent,
                              CurrencyCode currency,
                              List<IPrice> prices,
                              string description,
                              string userAgent,
                              CultureInfo language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              bool generatePaymentToken = false,
                              bool generateReccurenceToken = false,
                              string payerReference = null,
                              RiskIndicator riskIndicator = null,
                              Cardholder cardholder = null,
                              CreditCard creditCard = null,
                              Dictionary<string, object> metadata = null,
                              string paymentToken = null)
        {
            this.Payment = new CardPaymentRequestObject(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateReccurenceToken, userAgent, language, urls, payeeInfo, riskIndicator, cardholder,
                                               creditCard, metadata, paymentToken);
        }


        public CardPaymentRequestObject Payment;
    }
}