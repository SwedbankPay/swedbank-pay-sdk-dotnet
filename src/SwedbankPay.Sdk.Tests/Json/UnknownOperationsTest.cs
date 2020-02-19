using Newtonsoft.Json.Linq;
using SwedbankPay.Sdk.Payments.CardPayments;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SwedbankPay.Sdk.Tests.Json
{
    public class UnknownOperationsTest
    {
        [Fact]
        public void CanDeserializeUnknownOperation()
        {

        }

        public static Uri LocalHost = new Uri("localhost:4040");
        public static CardPaymentResponse TestResponse = new CardPaymentResponse(
            new PaymentResponseObject(
                    LocalHost,
                    "number",
                    PaymentInstrument.CreditCard,
                    DateTime.UtcNow,
                    DateTime.UtcNow,
                    State.Initialized,
                    Operation.Initiate,
                    Payments.Intent.Authorization,
                    new CurrencyCode("sek"),
                    Amount.FromInt(1337),
                    Amount.FromInt(0),
                    Amount.FromInt(0),
                    Amount.FromInt(0),
                    "description",
                    "payerReference",
                    "initiatingSystemUserAgent",
                    "userAgent",
                    System.Globalization.CultureInfo.InvariantCulture,
                    new Payments.PricesListResponse(new List<Payments.Price>()),
                    new Payments.TransactionListResponse(, new List<Payments.Transaction>()),
                    new CardPaymentAuthorizationListResponse(LocalHost, new List<CardPaymentAuthorization>()),
                    new Payments.CapturesListResponse(LocalHost, new List<Payments.TransactionResponse>()),
                    new Payments.ReversalsListResponse(LocalHost, new List<Payments.TransactionResponse>()),
                    new Payments.CancellationsListResponse(LocalHost, new List<Payments.TransactionResponse>()),
                    new Urls(LocalHost ,new List<Uri>()),
                    new PayeeInfo(Guid.Empty, "payeeReference"),
                    new PaymentOrders.MetaDataResponse(new Dictionary<string, object>())
                ),
            new OperationList(new List<HttpOperation>
            {
                new HttpOperation(LocalHost, new LinkRelation("test", "test-unknown"), "GET", "text/test")
            }));
    }
}
