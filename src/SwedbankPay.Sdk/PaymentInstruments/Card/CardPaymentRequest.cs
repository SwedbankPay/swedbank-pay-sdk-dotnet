using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentRequest
    {
        public CardPaymentRequest(Operation operation,
                              PaymentIntent intent,
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
                              IRiskIndicator riskIndicator = null,
                              Cardholder cardholder = null,
                              CreditCard creditCard = null,
                              MetadataResponse metadata = null,
                              string paymentToken = null)
        {
            this.Payment = new CardPaymentRequestObject(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateReccurenceToken, userAgent, language, urls, payeeInfo, riskIndicator, cardholder,
                                               creditCard, metadata, paymentToken);
        }


        public CardPaymentRequestObject Payment;
    }
}