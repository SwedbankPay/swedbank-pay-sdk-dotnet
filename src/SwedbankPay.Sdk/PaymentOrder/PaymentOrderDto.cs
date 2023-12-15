using SwedbankPay.Sdk.PaymentOrder.Metadata;

namespace SwedbankPay.Sdk.PaymentOrder;

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
        Urls = new UrlsDto(paymentOrderRequest.Urls);
        OrderItems = paymentOrderRequest.OrderItems?.Select(x => new OrderItemDto(x)).ToArray();
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
    public UrlsDto Urls { get; set; }
    public OrderItemDto[]? OrderItems { get; }
    public PayeeInfoDto PayeeInfo { get; }
    public MetadataDto? Metadata { get; }
}