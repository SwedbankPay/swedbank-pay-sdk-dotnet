using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentRequest
    {
        public CardPaymentRequest(Operation operation,
                              PaymentIntent intent,
                              Currency currency,
                              List<IPrice> prices,
                              string description,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              bool generatePaymentToken = false,
                              bool generateRecurrenceToken = false,
                              string payerReference = null,
                              IRiskIndicator riskIndicator = null,
                              Cardholder cardholder = null,
                              CreditCard creditCard = null,
                              MetadataResponse metadata = null,
                              string paymentToken = null)
        {
            Payment = new CardPaymentDetails(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateRecurrenceToken, userAgent, language, urls, payeeInfo, riskIndicator, cardholder,
                                               creditCard, metadata, paymentToken);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public CardPaymentDetails Payment { get; }
    }
}