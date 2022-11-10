﻿namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardPaymentReversalTransactionDto
{
    public CardPaymentReversalTransactionDto(CardPaymentReversalTransaction transaction)
    {
        Amount = transaction.Amount.InLowestMonetaryUnit;
        Description = transaction.Description;
        PayeeReference = transaction.PayeeReference;
        VatAmount = transaction.VatAmount.InLowestMonetaryUnit;
    }

    public long Amount { get; }

    public string Description { get; }

    public string PayeeReference { get; }

    public long VatAmount { get; }
}