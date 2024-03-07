using System;
using System.Collections.Generic;

namespace Sample.AspNetCore.Models;

public class UrlsOptions
{
    /// <summary>
    ///     The URI to the API endpoint receiving  POST requests on transaction activity related to the payment order.
    /// </summary>
    public Uri CallbackUrl { get; set; }

    /// <summary>
    ///     The URI to redirect the payer to if the payment is canceled.
    /// </summary>
    public Uri CancelUrl { get; set; }

    /// <summary>
    ///     The URI to redirect the payer to once the payment is completed.
    /// </summary>
    public Uri CompleteUrl { get; set; }

    /// <summary>
    ///     The list of URIs valid for embedding of PayEx Hosted Views.
    /// </summary>
    public ICollection<Uri> HostUrls { get; set; }

    /// <summary>
    ///     The URI to the logo that will be displayed on redirect pages.
    /// </summary>
    public Uri LogoUrl { get; set; }

    /// <summary>
    ///     The URI that SwedbankPay will redirect back to when the payment menu needs to be loaded, to inspect and act on the
    ///     current status of the payment. Only used in hosted views.
    /// </summary>
    public Uri PaymentUrl { get; set; }

    /// <summary>
    ///     The URI to the terms of service document the payer must accept in order to complete the payment.
    /// </summary>
    public Uri TermsOfServiceUrl { get; set; }

    /// <summary>
    ///    PaymentUrl for Standard checkout
    /// </summary>
    public Uri StandardCheckoutPaymentUrl { get; set; }

    /// <summary>
    ///    PaymentUrl for Anonymous checkout
    /// </summary>
    public Uri AnonymousCheckoutPaymentUrl { get; set; }

    /// <summary>
    ///    PaymentUrl for Payment menu checkout
    /// </summary>
    public Uri PaymentMenuPaymentUrl { get; set; }
}