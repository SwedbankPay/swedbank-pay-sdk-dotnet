using System;
using System.Collections.Generic;
using System.Linq;

using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments
{
    internal static class RequestExtensions
    {
        internal static void SetRequiredMerchantInfo(this PaymentOrderRequest paymentOrder, SwedbankPayOptions options)
        {
            paymentOrder.Urls.CallbackUrl ??= options.CallBackUrl;
            paymentOrder.Urls.CancelUrl ??= options.CancelPageUrl;
            paymentOrder.Urls.CompleteUrl ??= options.CompletePageUrl ?? throw new InvalidConfigurationSettingsException(
                                                  $"Variable {nameof(options.CompletePageUrl)} is required. Check config or provide a value in the request payload.");
            paymentOrder.Urls.PaymentUrl ??= options.PaymentUrl;
            paymentOrder.Urls.TermsOfServiceUrl ??= options.TermsOfServiceUrl
                                                    ?? throw new InvalidConfigurationSettingsException(
                                                        $"Variable {nameof(options.TermsOfServiceUrl)} is required. Check config or provide a value in the request payload.");
            paymentOrder.Urls.HostUrls ??= options.HostUrls ?? throw new InvalidConfigurationSettingsException(
                                               $"At least one {nameof(options.HostUrls)} is required. Check config or provide a value in the request payload.");
        }


        internal static void SetRequiredMerchantInfo(this PaymentRequest payment, SwedbankPayOptions options)
        {
            payment.Urls.CallbackUrl ??= options.CallBackUrl;
            payment.Urls.CancelUrl ??= options.CancelPageUrl;
            payment.Urls.CompleteUrl ??= options.CompletePageUrl;
            payment.Urls.PaymentUrl ??= options.PaymentUrl;
            payment.Urls.TermsOfServiceUrl ??= options.TermsOfServiceUrl;
            payment.Urls.HostUrls ??= new List<Uri>(options.HostUrls.Any()
                                                        ? options.HostUrls
                                                        : throw new InvalidConfigurationSettingsException(
                                                            "At least one Host url must be provided."));
        }
    }
}