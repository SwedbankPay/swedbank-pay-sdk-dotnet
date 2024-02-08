using SwedbankPay.Sdk.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.PaymentOrder.Paid;

namespace SwedbankPay.Sdk.PaymentOrder;

public record PaymentOrderRequest(
    Operation Operation,
    Currency Currency,
    Amount Amount,
    Amount VatAmount,
    string Description,
    string UserAgent,
    Language Language,
    Urls.Urls Urls,
    Sdk.PayeeInfo PayeeInfo)
{
    public IList<OrderItem>? OrderItems { get; set; }
    public Metadata.Metadata? Metadata { get; set; }
    public Operation Operation { get; } = Operation;
    public string? RecurrenceToken { get; set; }
    public string? UnscheduledToken { get; set; }
    public Currency Currency { get; } = Currency;
    public Amount Amount { get; } = Amount;
    public Amount VatAmount { get; } = VatAmount;
    public string Description { get; } = Description;
    public string UserAgent { get; } = UserAgent;
    public bool GeneratePaymentToken { get; set; }
    public string? PaymentToken { get; set; }
    public Language Language { get; } = Language;
    public bool GenerateRecurrenceToken { get; set; }
    public bool GenerateUnscheduledToken { get; set; }
    public bool DisableStoredPaymentDetails { get; set; }
    public bool EnablePaymentDetailsConsentCheckbox { get; set; }
    public PaymentInstrument? Instrument { get; set; }
    public string? Implementation { get; set; }
    public Urls.Urls Urls { get; } = Urls;
    public Sdk.PayeeInfo PayeeInfo { get; } = PayeeInfo;
    public RiskIndicator.RiskIndicator? RiskIndicator { get; set; }
    public Payer.Payer? Payer { get; set; }
}