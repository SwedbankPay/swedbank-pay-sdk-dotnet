namespace SwedbankPay.Sdk.PaymentOrder;

internal class PaymentOrderDto
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
        OrderItems = paymentOrderRequest.OrderItems.Select(x => new OrderItemDto(x)).ToArray();
        PayeeInfo = new PayeeInfoDto(paymentOrderRequest.PayeeInfo);

        if (paymentOrderRequest.Metadata != null)
        {
            Metadata = new MetadataDto(paymentOrderRequest.Metadata);
        }
    }

    public string Operation { get; set; }
    public string Currency { get; set; }
    public long Amount { get; set; }
    public long VatAmount { get; set; }
    public string Description { get; set; }
    public string UserAgent { get; set; }
    public string Language { get; set; }
    public string? Instrument { get; set; }
    public string? Implementation { get; set; }
    public UrlsDto Urls { get; set; }
    public OrderItemDto[] OrderItems { get; set; }
    public PayeeInfoDto PayeeInfo { get; set; }
    public MetadataDto? Metadata { get; set; }
}