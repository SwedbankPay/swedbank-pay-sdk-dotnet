using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Metadata;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Urls;
using SwedbankPay.Sdk.PaymentOrder;
using SwedbankPay.Sdk.PaymentOrder.Urls;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record PaymentOrderDto
{
    internal PaymentOrderDto(PaymentOrderRequest paymentOrderRequest)
    {
        Operation = paymentOrderRequest.Operation.Value;
        Currency = paymentOrderRequest.Currency.ToString();
        Amount = paymentOrderRequest.Amount.InLowestMonetaryUnit;
        VatAmount = paymentOrderRequest.VatAmount.InLowestMonetaryUnit;
        Description = paymentOrderRequest.Description;
        UserAgent = paymentOrderRequest.UserAgent;
        Language = paymentOrderRequest.Language.ToString();
        Instrument = paymentOrderRequest.Instrument;
        Implementation = paymentOrderRequest.Implementation;
        Urls = new UrlsRequestDto(paymentOrderRequest.Urls);
        OrderItems = paymentOrderRequest.OrderItems?.Select(x => new OrderItemRequestDto(x)).ToArray();
        PayeeInfo = new PayeeInfoDto(paymentOrderRequest.PayeeInfo);

        if (paymentOrderRequest.Metadata != null)
        {
            Metadata = new MetadataDto(paymentOrderRequest.Metadata);
        }
    }

    public string Operation { get; }
    public string Currency { get; }
    public long Amount { get; }
    public long VatAmount { get; }
    public string Description { get; }
    public string UserAgent { get; }
    public string Language { get; }
    public string? Instrument { get; }
    public string? Implementation { get; }
    public UrlsRequestDto Urls { get; set; }
    public OrderItemRequestDto[]? OrderItems { get; }
    public PayeeInfoDto PayeeInfo { get; }
    public MetadataDto? Metadata { get; }
}