using Microsoft.AspNetCore.Mvc.ViewFeatures;

using Sample.AspNetCore.Models;

using SwedbankPay.Sdk;

using System;
using System.Linq;
using System.Threading.Tasks;

using SwedbankPay.Sdk.Payments;

namespace Sample.AspNetCore
{
    public static class PaymentHelper
    {
        public static async Task CancelCreditCardPayment(string paymentId,
                                                         ISwedbankPayClient swedbankPayClient,
                                                         ITempDataDictionary tempData,
                                                         Cart cartService)
        {
            var payment = await swedbankPayClient.Payments.CardPayments.Get(new Uri(paymentId, UriKind.RelativeOrAbsolute));   

            if (payment.Operations.Cancel != null)
            {
                var cancelRequest = new SwedbankPay.Sdk.Payments.CardPayments.CardPaymentCancelRequest(DateTime.Now.Ticks.ToString(), "Cancelling parts of the total amount");
                var response = await payment.Operations.Cancel(cancelRequest);
                tempData["CancelMessage"] = $"Payment has been cancelled: {response.Cancellation.Transaction.Id}";
                cartService.PaymentOrderLink = null;
            }
            else
            {
                tempData["ErrorMessage"] = "Operation not available";
            }
        }

        public static async Task CancelTrustlyPayment(string paymentId, 
                                                                            ISwedbankPayClient swedbankPayClient, 
                                                                            ITempDataDictionary tempData,
                                                                            Cart cartService)
        {
            var payment = await swedbankPayClient.Payments.TrustlyPayments.Get(new Uri(paymentId, UriKind.RelativeOrAbsolute));

            if (payment.Operations.Cancel != null)
            {
                var cancelRequest = new SwedbankPay.Sdk.Payments.TrustlyPayments.TrustlyPaymentCancelRequest(DateTime.Now.Ticks.ToString(), "Cancelling parts of the total amount");
                var response = await payment.Operations.Cancel(cancelRequest);
                tempData["CancelMessage"] = $"Payment has been cancelled: {response.Cancellation.Transaction.Id}";
                cartService.PaymentOrderLink = null;
            }
            else
            {
                tempData["ErrorMessage"] = "Operation not available";
            }
        }


        public static async Task<ReversalResponse> ReverseSwishPayment(string paymentId, Order order, string description, ISwedbankPayClient swedbankPayClient)
        {
            var swishPayment = await swedbankPayClient.Payments.SwishPayments.Get(new Uri(paymentId, UriKind.RelativeOrAbsolute));
            var swishReversal = new SwedbankPay.Sdk.Payments.SwishPayments.SwishPaymentReversalRequest(
                Amount.FromDecimal(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
                Amount.FromDecimal(0), description, DateTime.Now.Ticks.ToString());
            return await swishPayment.Operations.Reverse.Invoke(swishReversal);
        }


        public static async Task<ReversalResponse> ReverseCreditCardPayment(string paymentId, Order order, string description, ISwedbankPayClient swedbankPayClient)
        {
            var cardPayment = await swedbankPayClient.Payments.CardPayments.Get(new Uri(paymentId, UriKind.RelativeOrAbsolute));
            var cardReversal = new SwedbankPay.Sdk.Payments.CardPayments.CardPaymentReversalRequest(
                Amount.FromDecimal(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
                Amount.FromDecimal(0), description, DateTime.Now.Ticks.ToString());
            return await cardPayment.Operations.Reverse.Invoke(cardReversal);
        }


        public static async Task<ReversalResponse> ReverseTrustlyPayment(string paymentId, Order order, string description, ISwedbankPayClient swedbankPayClient)
        {
            var trustlyPayment = await swedbankPayClient.Payments.TrustlyPayments.Get(new Uri(paymentId, UriKind.RelativeOrAbsolute));
            var trustlyReversal = new SwedbankPay.Sdk.Payments.TrustlyPayments.TrustlyPaymentReversalRequest(
                Operation.Sale, Amount.FromDecimal(order.Lines.Sum(e => e.Quantity * e.Product.Price)),
                Amount.FromDecimal(0), DateTime.Now.Ticks.ToString(), "receipt reference", description);
            return await trustlyPayment.Operations.Reverse.Invoke(trustlyReversal);
        }
    }
}
