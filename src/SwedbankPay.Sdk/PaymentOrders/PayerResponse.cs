﻿using System;

namespace SwedbankPay.Sdk.PaymentOrders;

/// <summary>
/// Resource to access the Payer information on a payment order.
/// </summary>
public class PayerResponse : Identifiable
{
    /// <summary>
    /// Instantiates a <see cref="PayerResponse"/> with the provided <paramref name="id"/>.
    /// </summary>
    /// <param name="id"></param>
    public PayerResponse(Uri id) : base(id)
    {
    }

    /// <summary>
    /// Account information about the payer if such is known by the merchant system.
    /// </summary>
    public AccountInfo AccountInfo { get; set; }

    /// <summary>
    /// Payers billing address for this payment order.
    /// </summary>
    public Address BillingAddress { get; set; }

    /// <summary>
    ///     The consumer profile reference as obtained through the Consumers API.
    /// </summary>
    public string ConsumerProfileRef { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>

    public EmailAddress Email { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set) If buyer is a company, use only firstName for
    ///     companyName.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>
    public string HomePhoneNumber { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set) If buyer is a company, use only firstName for
    ///     companyName.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>
    public Msisdn Msisdn { get; set; }

    /// <summary>
    ///     Required when merchant onboards consumer.
    /// </summary>
    public NationalIdentifier NationalIdentifier { get; set; }

    /// <summary>
    /// Payers shipping address for this payment order.
    /// </summary>
    public Address ShippingAddress { get; set; }

    /// <summary>
    ///     Optional (increases chance for challenge flow if not set)
    /// </summary>
    public string WorkPhoneNumber { get; set; }
}
