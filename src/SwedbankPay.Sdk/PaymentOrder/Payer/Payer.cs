namespace SwedbankPay.Sdk.PaymentOrder.Payer;

/// <summary>
/// Detailed information about a payer for a payment order.
/// </summary>
public record Payer
{
    
    /// <summary>
    ///     Optional (increases chance for challenge flow if not set) If buyer is a company, use only firstName for
    ///     companyName.
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set) If buyer is a company, use only firstName for
    ///     companyName.
    /// </summary>
    public string? LastName { get; set; }
    
    /// <summary>
    /// This will enable Swedbank Pay to render a unique payment menu experience for each payer. It will also increase the chance for a frictionless payment.
    /// </summary>
    public string? PayerReference { get; set; }
    
    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>
    public EmailAddress? Email { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>
    public Msisdn? Msisdn { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>
    public Msisdn? WorkPhoneNumber { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>
    public Msisdn? HomePhoneNumber { get; set; }

    /// <summary>
    /// Payers billing address for this payment order.
    /// </summary>
    public Address? BillingAddress { get; set; }

    /// <summary>
    /// Payers shipping address for this payment order.
    /// </summary>
    public Address? ShippingAddress { get; set; }
    
    /// <summary>
    /// Account information about the payer if such is known by the merchant system.
    /// </summary>
    public AccountInfo? AccountInfo { get; set; }
}