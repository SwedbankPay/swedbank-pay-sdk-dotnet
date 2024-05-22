using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Metadata;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Payer;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.RiskIndicator;
using SwedbankPay.Sdk.Infrastructure.PaymentOrder.Urls;
using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder;

internal record PaymentOrderDto
{
    internal PaymentOrderDto(PaymentOrderRequest paymentOrderRequest)
    {
        Operation = paymentOrderRequest.Operation.Value;
        RecurrenceToken = paymentOrderRequest.RecurrenceToken;
        UnscheduledToken = paymentOrderRequest.UnscheduledToken;
        Currency = paymentOrderRequest.Currency.ToString();
        Amount = paymentOrderRequest.Amount.InLowestMonetaryUnit;
        VatAmount = paymentOrderRequest.VatAmount.InLowestMonetaryUnit;
        Description = paymentOrderRequest.Description;
        UserAgent = paymentOrderRequest.UserAgent;
        PaymentToken = paymentOrderRequest.PaymentToken;
        GeneratePaymentToken = paymentOrderRequest.GeneratePaymentToken;
        Language = paymentOrderRequest.Language.ToString();
        ExpandFirstInstrument = paymentOrderRequest.ExpandFirstInstrument;
        RestrictedToInstruments = paymentOrderRequest.RestrictedToInstruments?.Select(x => x.Value).ToArray();
        GenerateRecurrenceToken = paymentOrderRequest.GenerateRecurrenceToken;
        GenerateUnscheduledToken = paymentOrderRequest.GenerateUnscheduledToken;
        DisableStoredPaymentDetails = paymentOrderRequest.DisableStoredPaymentDetails;
        EnablePaymentDetailsConsentCheckbox = paymentOrderRequest.EnablePaymentDetailsConsentCheckbox;
        Instrument = paymentOrderRequest.Instrument?.Value;
        Implementation = paymentOrderRequest.Implementation;
        Urls = new UrlsRequestDto(paymentOrderRequest.Urls);
        OrderItems = paymentOrderRequest.OrderItems?.Select(x => new OrderItemRequestDto(x)).ToArray();
        PayeeInfo = new PayeeInfoDto(paymentOrderRequest.PayeeInfo);

        if (paymentOrderRequest.Metadata != null)
        {
            Metadata = new MetadataDto(paymentOrderRequest.Metadata);
        }

        if (paymentOrderRequest.RiskIndicator != null)
        {
            RiskIndicator = new RiskIndicatorRequestDto(paymentOrderRequest.RiskIndicator);
        }

        if (paymentOrderRequest.Payer != null)
        {
            Payer = new PayerRequestDto(paymentOrderRequest.Payer);
        }
    }

    public string Operation { get; }
    public string? RecurrenceToken { get; }
    public string? UnscheduledToken { get; }
    public string Currency { get; }
    public long Amount { get; }
    public long VatAmount { get; }
    public string Description { get; }
    public string UserAgent { get; }
    public bool? GeneratePaymentToken { get;  }
    public string? PaymentToken { get; }
    public string Language { get; }
    public string[]? RestrictedToInstruments { get; }
    public bool? ExpandFirstInstrument { get; }
    public bool? GenerateRecurrenceToken { get; }  
    public bool? GenerateUnscheduledToken { get; }
    public bool? DisableStoredPaymentDetails { get;  }
    public bool? EnablePaymentDetailsConsentCheckbox { get; }
    public string? Instrument { get; }
    public string? Implementation { get; }
    public UrlsRequestDto Urls { get; set; }
    public OrderItemRequestDto[]? OrderItems { get; }
    public PayeeInfoDto PayeeInfo { get; }
    public MetadataDto? Metadata { get; }
    
    public RiskIndicatorRequestDto? RiskIndicator { get; }
    public PayerRequestDto? Payer { get; }

}