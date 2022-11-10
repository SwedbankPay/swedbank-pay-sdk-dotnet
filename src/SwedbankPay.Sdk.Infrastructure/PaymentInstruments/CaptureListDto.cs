using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments;

internal class CaptureListDto
{
    public string Id { get; set; }

    public List<TransactionDto> CaptureList { get; set; } = new List<TransactionDto>();

    internal ICaptureListResponse Map()
    {
        var list = new List<ITransaction>();
        foreach (var c in CaptureList)
        {
            list.Add(c.Map());
        }
        var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
        return new CaptureListResponse(uri, list);
    }
}