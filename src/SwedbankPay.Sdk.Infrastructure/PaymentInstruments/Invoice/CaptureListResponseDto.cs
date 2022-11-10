using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

internal class CaptureListResponseDto
{
    public string Id { get; set; }
    public List<TransactionDto> CaptureList { get; set; } = new List<TransactionDto>();

    internal ICaptureListResponse Map()
    {
        var transactionList = new List<ITransaction>();
        foreach (var t in CaptureList)
        {
            transactionList.Add(t.Map());
        }
        var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
        return new CaptureListResponse(uri, transactionList);
    }
}