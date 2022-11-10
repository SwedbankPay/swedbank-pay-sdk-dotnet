using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay;

/// <summary>
/// Object detailing a authorized Mobile Pay payment.
/// </summary>
public interface IMobilePayPaymentAuthorization
{
    /// <summary>
    /// The System Trace Audit Number assigned by the acquirer to uniquely identify the transaction.
    /// </summary>
    string AcquirerStan { get; }

    /// <summary>
    /// The ID of the acquirer terminal.
    /// </summary>
    string AcquirerTerminalId { get; }

    /// <summary>
    /// The ISO-8601 date and time of the acquirer transaction.
    /// </summary>
    DateTime AcquirerTransactionTime { get; }

    /// <summary>
    /// 3DSECURE or SSL. Indicates the transaction type of the acquirer.
    /// </summary>
    string AcquirerTransactionType { get; }

    /// <summary>
    /// Visa, MC, etc. The brand of the card that authorized this transaction.
    /// </summary>
    string CardBrand { get; }

    /// <summary>
    /// Credit Card or Debit Card. Indicates the type of card used for the authorization.
    /// </summary>
    string CardType { get; }

    /// <summary>
    /// The country the card is issued in.
    /// </summary>
    string CountryCode { get; }

    /// <summary>
    /// The ExpiryDate for the card used.
    /// Format MM/YY
    /// </summary>
    string ExpiryDate { get; }

    /// <summary>
    /// The masked PAN number of the card.
    /// </summary>
    string MaskedPan { get; }

    /// <summary>
    /// Tokenized version of the primary account number.
    /// </summary>
    string PanToken { get; }

    /// <summary>
    /// Available information about the payment card that authorized this transaction.
    /// </summary>
    IAuthorizationTransaction Transaction { get; }
}