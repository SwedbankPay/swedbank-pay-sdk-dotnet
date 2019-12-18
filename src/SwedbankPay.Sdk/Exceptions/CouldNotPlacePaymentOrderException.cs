using System;
using System.Net.Http;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotPlacePaymentOrderException : SdkException
    {
        public CouldNotPlacePaymentOrderException(HttpResponseMessage httpResponseMessage, PaymentOrderRequestContainer payment, ProblemsContainer problems)
            : base(httpResponseMessage,problems.ToString())
        {
            Problems = problems;
            Payment = payment;
        }


        public PaymentOrderRequestContainer Payment { get; }
        public ProblemsContainer Problems { get; }
    }
}