namespace SwedbankPay.Sdk.Payments
{
    using System;

    using System.Collections.Generic;

    using SwedbankPay.Sdk.PaymentOrders;

    internal static class PaymentRequestExtensions
    {

        internal static void SetRequiredMerchantInfo(this PaymentOrderRequest paymentOrder, SwedbankPayOptions options)
        {
            paymentOrder.Urls.CallbackUrl = options.CallBackUrl.ToString();
            paymentOrder.Urls.CancelUrl = CallbackUrl(options.CancelPageUrl, "?status=cancel");
            paymentOrder.Urls.CompleteUrl = CallbackUrl(options.CompletePageUrl, "?status=complete");
            paymentOrder.Urls.PaymentUrl = options.PaymentUrl.ToString();
            paymentOrder.Urls.TermsOfServiceUrl = options.TermsOfServiceUrl.ToString();
            paymentOrder.Urls.HostUrls = new List<string> { options.TermsOfServiceUrl.ToString() };
        }

        internal static void SetRequiredMerchantInfo(this PaymentRequest payment, SwedbankPayOptions options)
        {
            payment.PayeeInfo.PayeeId = options.MerchantId;
            payment.PayeeInfo.PayeeName = options.MerchantName;
            payment.Urls.CallbackUrl = options.CallBackUrl.ToString();
            payment.Urls.CancelUrl = CallbackUrl(options.CancelPageUrl, "?status=cancel");
            payment.Urls.CompleteUrl = CallbackUrl(options.CompletePageUrl, "?status=complete");
            payment.Urls.PaymentUrl = options.PaymentUrl.ToString();
            payment.Urls.TermsOfServiceUrl = options.TermsOfServiceUrl.ToString();
        }

        private static string CallbackUrl(Uri callbackBaseUrl, string relativePath)
        {
            return new Uri(callbackBaseUrl, relativePath).ToString();
        }
    }
}