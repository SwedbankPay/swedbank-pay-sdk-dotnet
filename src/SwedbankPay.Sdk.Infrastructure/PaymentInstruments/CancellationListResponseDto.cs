using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments;

internal class CancellationListResponseDto
{
    public List<TransactionDto> CancellationList { get; set; }
    public string Id { get; set; }

    internal ICancellationListResponse Map()
    {
        var transactionList = new List<ITransaction>();
        foreach (var t in CancellationList)
        {
            transactionList.Add(t.Map());
        }
        var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
        return new CancellationListResponse(uri, transactionList);
    }
}