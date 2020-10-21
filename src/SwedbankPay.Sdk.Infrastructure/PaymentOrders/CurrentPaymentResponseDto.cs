using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class CurrentPaymentResponseDto
    {
        public string Id { get; set; }
        public string MenuElementName { get; set; }
        public PaymentResponseDto Payment { get; set; }
        public List<HttpOperationDto> Operations { get; set; }

        internal ICurrentPaymentResponse Map()
        {
            var payment = new CurrentPaymentResponseObject(Payment.Number,
                                                            Enum.Parse<PaymentInstrument>(Payment.Instrument),
                                                            Payment.Created,
                                                            Payment.Updated,
                                                            Payment.Amount,
                                                            Payment.Authorizations.Map(),
                                                            Payment.Cancellations.Map(),
                                                            Payment.Captures.Map(),
                                                            new CurrencyCode(Payment.Currency),
                                                            Payment.Description,
                                                            Enum.Parse<PaymentIntent>(Payment.Intent),
                                                            new Language(Payment.Language),
                                                            Payment.Operation,
                                                            Payment.PayeeInfo.Map(),
                                                            Payment.PayerReference,
                                                            Payment.PaymentToken,
                                                            Payment.Prices.Map(),
                                                            Payment.Reversals.Map(),
                                                            Payment.State,
                                                            Payment.Transactions.Map(),
                                                            Payment.Urls,
                                                            Payment.UserAgent,
                                                            Payment.Sales.Map());
            return new CurrentPaymentResponse(new Uri(Id, UriKind.RelativeOrAbsolute), MenuElementName, payment);
        }
    }
}