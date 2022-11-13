using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.Tests.TestBuilders;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests;

public class CardPaymentTests : ResourceTestsBase
{
    private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();


    [Fact]
    public async Task GetPayment()
    {
        var creditCardPayment = await this.Sut.Payments.CardPayments.Get(
            new Uri("/psp/creditcard/payments/08bb7e22-167b-43e5-94f6-08dabd8f424e", UriKind.Relative), PaymentExpand.All);

        Assert.NotNull(creditCardPayment);
    }


    [Fact]
    public async Task CreateVerifyPayment_ShouldReturnPayment()
    {
        var paymentRequest = this.paymentRequestBuilder.WithCreditcardTestValues(this.payeeId, Operation.Verify).BuildCreditCardPaymentRequest();
        var creditCardPayment = await this.Sut.Payments.CardPayments.Create(paymentRequest, PaymentExpand.All);
        Assert.Equal(UserAgent.Default, creditCardPayment.Payment.InitiatingSystemUserAgent);
        Assert.NotNull(creditCardPayment);
    }

    [Fact]
    public async Task CreateVerifyRecurringPayment_ShouldReturnPayment()
    {
        var paymentRequest = this.paymentRequestBuilder.WithCreditcardTestValues(this.payeeId, Operation.Verify, generateRecurrenceToken: true).BuildCreditCardVerifyPaymentRequest();
        var cardPayment = await this.Sut.Payments.CardPayments.Create(paymentRequest, PaymentExpand.All);
        Assert.NotNull(cardPayment);
    }

    [Fact]
    public async Task CreateRecurringPayment_ShouldReturnPayment()
    {
        var recurPaymentRequest = this.paymentRequestBuilder.WithCreditcardTestValues(this.payeeId, Operation.Verify, recurrenceToken: "fb813868-1491-4854-a71d-e3b9878b342d").BuildCreditCardRecurPaymentRequest();
        var cardPayment = await this.Sut.Payments.CardPayments.Create(recurPaymentRequest, PaymentExpand.All);
        Assert.NotNull(cardPayment);
    }


    [Fact]
    public async Task CreatePayment_ShouldReturnPayment()
    {
        var paymentRequest = this.paymentRequestBuilder.WithCreditcardTestValues(this.payeeId).BuildCreditCardPaymentRequest();
        var creditCardPayment = await this.Sut.Payments.CardPayments.Create(paymentRequest, PaymentExpand.All);

        Assert.NotNull(creditCardPayment);
        Assert.Equal(UserAgent.Default, creditCardPayment.Payment.InitiatingSystemUserAgent);
        Assert.Equal(paymentRequest.Payment.Metadata["key1"], creditCardPayment.Payment.Metadata["key1"]);
    }
}
