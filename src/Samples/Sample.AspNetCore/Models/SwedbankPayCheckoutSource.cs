using SwedbankPay.Sdk;

using System;
using System.Globalization;

namespace Sample.AspNetCore.Models;

public class SwedbankPayCheckoutSource
{
    public Uri AbortOperationLink { get; set; }
    public CultureInfo Culture { get; set; }
    public Uri JavascriptSource { get; set; }
    public HttpOperation UpdateOperation { get; set; }
    public bool UseAnonymousCheckout { get; set; }
    public Uri ConsumerUiScriptSource { get; set; }
    public Uri PaymentOrderLink { get; set; }
}