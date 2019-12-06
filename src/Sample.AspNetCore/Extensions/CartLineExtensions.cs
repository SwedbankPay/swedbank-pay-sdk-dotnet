

using System.Collections;
using System.Collections.Generic;

using SwedbankPay.Sdk;
using SwedbankPay.Sdk.PaymentOrders;

namespace Sample.AspNetCore.Extensions
{
    using Newtonsoft.Json;

    using Sample.AspNetCore.Models;

    public static class CartLineExtensions
    {
        public static IEnumerable<OrderItem> ToOrderItems(this IEnumerable<CartLine> lines)
        {
            foreach (var line in lines)
            {
                yield return new OrderItem(line.Product.Reference, line.Product.Name, OrderItemType.FromValue(line.Product.Type), line.Product.Class,
                                    line.Quantity, "pcs", Amount.FromDecimal(line.Product.Price), 0,
                                    amount : Amount.FromDecimal(line.CalculateTotal()),
                                    Amount.FromDecimal(line.Product.VatPercentage == 0 ? 0 : line.CalculateTotal() * (decimal)line.Product.VatPercentage / 100)); //TODO provide correct VAT amount
            }
        }
    }
}