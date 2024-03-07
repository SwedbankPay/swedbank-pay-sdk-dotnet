using System.Collections.Generic;

using Sample.AspNetCore.Models;
using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentOrder.OrderItems;

namespace Sample.AspNetCore.Extensions;

public static class CartLineExtensions
{
    public static IEnumerable<OrderItem> ToOrderItems(this IEnumerable<CartLine> lines)
    {
        foreach (var line in lines)
        {
            yield return new OrderItem(line.Product.Reference, line.Product.Name, OrderItemType.FromValue(line.Product.Type),
                line.Product.Class,
                line.Quantity, "pcs", new Amount(line.Product.Price), 0,
                new Amount(line.CalculateTotal()),
                new Amount(line.Product.VatPercentage == 0
                    ? 0
                    : line.CalculateTotal() * line.Product.VatPercentage
                      / 100));
        }
    }
}