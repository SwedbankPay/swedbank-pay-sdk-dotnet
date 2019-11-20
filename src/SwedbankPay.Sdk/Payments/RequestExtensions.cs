namespace SwedbankPay.Sdk.Payments
{
    using SwedbankPay.Sdk.PaymentOrders;
    using System.Linq;

    internal static class RequestExtensions
    {

        internal static void SetRequiredMerchantInfo(this PaymentOrderRequest paymentOrder, SwedbankPayOptions options)
        {
            paymentOrder.Urls.CallbackUrl = options.CallBackUrl.ToString();
            paymentOrder.Urls.CancelUrl = options.CancelPageUrl.ToString();
            paymentOrder.Urls.CompleteUrl = options.CompletePageUrl.ToString();
            paymentOrder.Urls.PaymentUrl = options.PaymentUrl.ToString();
            paymentOrder.Urls.TermsOfServiceUrl = options.TermsOfServiceUrl.ToString();
            paymentOrder.Urls.HostUrls = options.HostUrls.Select(x => x.ToString()).ToList();
        }

        internal static void SetRequiredMerchantInfo(this PaymentRequest payment, SwedbankPayOptions options)
        {
            payment.PayeeInfo.PayeeId = options.MerchantId;
            payment.PayeeInfo.PayeeName = options.MerchantName;
            payment.Urls.CallbackUrl = options.CallBackUrl.ToString();
            payment.Urls.CancelUrl = options.CancelPageUrl.ToString();
            payment.Urls.CompleteUrl = options.CompletePageUrl.ToString();
            payment.Urls.PaymentUrl = options.PaymentUrl.ToString();
            payment.Urls.TermsOfServiceUrl = options.TermsOfServiceUrl.ToString();
            payment.Urls.HostUrls = options.HostUrls.Select(x => x.ToString()).ToList();
        }

       
    }
}