using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// API resource to access order items on a payment order.
/// </summary>
public class OrderItemListResponse : Identifiable
{
    /// <summary>
    /// Instantiates a <see cref="OrderItemListResponse"/> with the provided parameters.
    /// </summary>
    /// <param name="id">Unique ID for this resource.</param>
    public OrderItemListResponse(Uri id): base(id)
    {
    }

    /// <summary>
    ///     The orderItems property of the paymentOrder is an array containing the items being purchased with the order. Used
    ///     to print on invoices if
    ///     the payer chooses to pay with invoice, among other things. Order items can be specified on both payment order
    ///     creation as well as on Capture.
    /// </summary>
    public IEnumerable<IOrderItem> OrderItemList { get; set; }
}