using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders;

internal class ReversalListResponseDto
{
    public string Id { get; set; }
    public List<TransactionDto> Reversals { get; set; } = new List<TransactionDto>();

    internal IReversalListResponse Map()
    {
        var list = new List<ITransactionResponse>();
        var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
        foreach (var item in Reversals)
        {
            list.Add(new TransactionResponse(uri, item));
        }

        return new ReversalListResponse(uri, list);
    }
}