using SwedbankPay.Sdk.Infrastructure.PaymentOrder.OrderItems;
using SwedbankPay.Sdk.PaymentOrder.OperationRequest;

namespace SwedbankPay.Sdk.Infrastructure.PaymentOrder.OperationRequest;

internal record TransactionRequestDto
{
    public TransactionRequestDto(TransactionRequest payload)
    {
        Description = payload.Description;
        Amount = payload.Amount.InLowestMonetaryUnit;
        VatAmount = payload.VatAmount.InLowestMonetaryUnit;
        PayeeReference = payload.PayeeReference;
        ReceiptReference = payload.ReceiptReference;
        OrderItems = payload.OrderItems.Select(x => new OrderItemRequestDto(x)).ToList();
    }
    
    public string Description { get; }
    public long Amount { get; }
    public long VatAmount { get; }
    public string PayeeReference { get; }
    public string? ReceiptReference { get; }
    public IList<OrderItemRequestDto> OrderItems { get; }
}