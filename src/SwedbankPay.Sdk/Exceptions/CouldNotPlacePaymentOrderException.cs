using System;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotPlacePaymentOrderException : Exception
    {
        public CouldNotPlacePaymentOrderException(PaymentOrderRequestContainer payment, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Payment = payment;
        }


        public PaymentOrderRequestContainer Payment { get; }
        public ProblemsContainer Problems { get; }
    }
}