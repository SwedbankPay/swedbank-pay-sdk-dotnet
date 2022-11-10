namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

internal class ItemDescriptionDto
{
    public ItemDescriptionDto(ItemDescription item)
    {
        Amount = item.Amount.InLowestMonetaryUnit;
        Description = item.Description;
    }

    public long Amount { get; }

    public string Description { get; }
}