namespace SwedbankPay.Sdk.PaymentOrder;

public record PaymentOrderRequest(Operation Operation, Currency Currency, Amount Amount, Amount VatAmount, string Description,
    string UserAgent, Language Language, Urls Urls, Sdk.PayeeInfo PayeeInfo)
{
    public IList<OrderItem>? OrderItems { get; set; }

    public Metadata.Metadata? Metadata { get; set; }
    public Operation Operation { get; } = Operation;
    public Currency Currency { get; } = Currency;
    public Amount Amount { get; } = Amount;
    public Amount VatAmount { get; } = VatAmount;
    public string Description { get; } = Description;
    public string UserAgent { get; } = UserAgent;
    public Language Language { get; } = Language;
    public string? Instrument { get; set; }
    public string? Implementation { get; set; }
    public Urls Urls { get; } = Urls;
    public Sdk.PayeeInfo PayeeInfo { get; } = PayeeInfo;
}