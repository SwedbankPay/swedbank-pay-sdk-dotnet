﻿using SwedbankPay.Sdk.PaymentInstruments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders;

internal class TransactionListResponseDto
{
    public string Id { get; set; }
    public List<TransactionDto> TransactionList { get; set; }

    internal ITransactionListResponse Map()
    {
        var list = new List<ITransaction>();

        foreach (var c in TransactionList)
        {
            list.Add(c.Map());
        }

        return new TransactionListResponse(new Uri(Id, UriKind.RelativeOrAbsolute), list);
    }
}