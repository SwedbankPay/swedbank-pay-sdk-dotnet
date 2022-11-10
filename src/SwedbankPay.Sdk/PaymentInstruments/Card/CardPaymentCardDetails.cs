﻿namespace SwedbankPay.Sdk.PaymentInstruments.Card;

/// <summary>
/// Object to hold details about a payments card details.
/// </summary>
public class CardPaymentCardDetails : ICardPaymentCardDetails
{
    /// <summary>
    /// Instantiates a new <see cref="CardPaymentCardDetails"/> with the provided parameters.
    /// </summary>
    /// <param name="cardNumber">The card number.</param>
    /// <param name="cardExpiryMonth">The card expiry month.</param>
    /// <param name="cardExpiryYear">The card expiry year.</param>
    protected internal CardPaymentCardDetails(string cardNumber,
                                                int cardExpiryMonth,
                                                int cardExpiryYear)
    {
        CardNumber = cardNumber;
        CardExpiryMonth = cardExpiryMonth;
        CardExpiryYear = cardExpiryYear;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public int CardExpiryMonth { get; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public int CardExpiryYear { get; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string CardHolderName { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string CardNumber { get; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public string CardVerificationCode { get; set; }
}