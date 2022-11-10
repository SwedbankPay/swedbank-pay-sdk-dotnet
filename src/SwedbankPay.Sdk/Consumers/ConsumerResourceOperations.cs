#region License

// --------------------------------------------------
// Copyright © Swedbank Pay. All Rights Reserved.
// 
// This software is proprietary information of Swedbank Pay.
// USE IS SUBJECT TO LICENSE TERMS.
// --------------------------------------------------

#endregion


namespace SwedbankPay.Sdk.Consumers;

/// <summary>
/// Currently mapped operations available for consumers.
/// </summary>
public static class ConsumerResourceOperations
{
    /// <summary>
    /// The Operation used to open a iframe to view consumer identification.
    /// </summary>
    public const string ViewConsumerIdentification = "view-consumer-identification";

    /// <summary>
    /// The operation used to redirect a consumer for identification.
    /// </summary>
    public const string RedirectConsumerIdentification = "redirect-consumer-identification";
}