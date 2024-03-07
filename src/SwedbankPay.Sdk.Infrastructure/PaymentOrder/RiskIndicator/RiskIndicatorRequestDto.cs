namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.RiskIndicator;

internal record RiskIndicatorRequestDto
{
    private const string ThreeDSecureDateTimeString = "yyyyMMdd";

    public RiskIndicatorRequestDto(Sdk.PaymentOrder.RiskIndicator.RiskIndicator riskIndicator)
    {
        DeliveryEmailAddress = riskIndicator.DeliveryEmailAddress?.ToString();
        DeliveryTimeFrameIndicator = riskIndicator.DeliveryTimeFrameIndicator?.Value;
        PreOrderDate = riskIndicator.PreOrderDate.ToString(ThreeDSecureDateTimeString);
        PreOrderPurchaseIndicator = riskIndicator.PreOrderPurchaseIndicator?.Value;
        ShipIndicator = riskIndicator.ShipIndicator?.Value;
        GiftCardPurchase = riskIndicator.GiftCardPurchase;
        ReOrderPurchaseIndicator = riskIndicator.ReOrderPurchaseIndicator?.Value;
        PickUpAddress = new AddressDto(riskIndicator.PickUpAddress);
    }
    
    public string? DeliveryEmailAddress { get; }
    
    public string? DeliveryTimeFrameIndicator { get; }
    
    public string? PreOrderDate { get; }

    public string? PreOrderPurchaseIndicator { get; }
    
    public string? ShipIndicator { get; }

    public bool? GiftCardPurchase { get; }

    public string? ReOrderPurchaseIndicator { get; }

    public AddressDto? PickUpAddress { get; }
}