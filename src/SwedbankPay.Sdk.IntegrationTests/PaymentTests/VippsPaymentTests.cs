using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.Tests.TestBuilders;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace SwedbankPay.Sdk.Tests.PaymentTests;


public class VippsPaymentTests : ResourceTestsBase
{
    private readonly PaymentRequestBuilder paymentRequestBuilder = new PaymentRequestBuilder();

    [Fact]
    public async Task CreateVippsPayment_ShouldReturnWithExpectedValues()
    {
        var vippsPaymentRequest = this.paymentRequestBuilder.WithVippsTestValues(this.payeeId, Operation.Purchase).BuildVippsRequest();
        var vippsPayment = await this.Sut.Payments.VippsPayments.Create(vippsPaymentRequest, PaymentExpand.All);

        Assert.NotNull(vippsPayment);
        Assert.Equal(vippsPaymentRequest.Payment.Metadata["key1"], vippsPayment.Payment.Metadata["key1"]);
        Assert.Equal(vippsPaymentRequest.Payment.Language.ToString(), vippsPayment.Payment.Language.ToString());
        Assert.True(vippsPaymentRequest.Payment.Operation.Equals(Operation.Purchase));
        Assert.True(vippsPaymentRequest.Payment.Currency.ToString().Equals(vippsPayment.Payment.Currency.ToString()));
        Assert.True(vippsPaymentRequest.Payment.Description.Length.Equals(vippsPayment.Payment.Description.Length));
        Assert.True(vippsPaymentRequest.Payment.UserAgent.Length.Equals(vippsPayment.Payment.UserAgent.Length));
        Assert.Equal(UserAgent.Default, vippsPayment.Payment.InitiatingSystemUserAgent);
        Assert.True(vippsPaymentRequest.Payment.PayeeInfo.PayeeId.Equals(vippsPayment.Payment.PayeeInfo.PayeeId));
    }

    [Fact]
    public async Task CreateAndGetVippsPayment_ShouldReturnPaymentId()
    {
        var vippsPaymentRequest = this.paymentRequestBuilder.WithVippsTestValues(this.payeeId, Operation.Purchase).BuildVippsRequest();
        var vippsPayment = await this.Sut.Payments.VippsPayments.Create(vippsPaymentRequest, PaymentExpand.All);
        var vippsPaymentId = vippsPayment.Payment.Id;
        var getVippsPayment = await this.Sut.Payments.VippsPayments.Get(vippsPaymentId);

        Assert.NotNull(getVippsPayment);

        var priceList = vippsPayment.Payment.Prices.PriceList;

        Assert.NotEmpty(priceList);
        var price = priceList.First();
        Assert.Equal(vippsPaymentRequest.Payment.Prices.First().Amount.InLowestMonetaryUnit, price.Amount.InLowestMonetaryUnit);
        Assert.Equal(vippsPaymentRequest.Payment.Prices.First().VatAmount.InLowestMonetaryUnit, price.VatAmount.InLowestMonetaryUnit);
    }
}
