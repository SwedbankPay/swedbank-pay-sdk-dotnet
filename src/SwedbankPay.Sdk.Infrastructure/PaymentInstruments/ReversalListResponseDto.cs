using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments;

internal class ReversalListResponseDto
{
    public string Id { get; set; }
    public List<TransactionDto> ReversalList { get; set; } = new List<TransactionDto>();

    internal IReversalListResponse Map()
    {
        var list = new List<ITransactionResponse>();
        var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
        foreach (var item in ReversalList)
        {
            list.Add(new TransactionResponse(uri, item));
        }

        return new ReversalListResponse(uri, list);
    }
}