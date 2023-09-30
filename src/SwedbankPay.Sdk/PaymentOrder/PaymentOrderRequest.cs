namespace SwedbankPay.Sdk.PaymentOrder;

public record PaymentOrderRequest(Operation Operation, Currency Currency, Amount Amount, Amount VatAmount, string Description,
    string UserAgent, Language Language, string ProductName, Urls Urls,
    PayeeInfo PayeeInfo)
{
    public string? Instrument { get; set; }
    public string? Implementation { get; set; }
    public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public Metadata? Metadata { get; set; }
}