using Swedbankpay.Sdk.Payments;
using SwedbankPay.Sdk.Extensions;
using SwedbankPay.Sdk.Payments.MobilePayPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class MobilePayPayment : IMobilePayPayment
    {
        public IMobilePayPaymentOperations Operations { get; }

        public IMobilePayPaymentResponse PaymentResponse { get; }
    }
}