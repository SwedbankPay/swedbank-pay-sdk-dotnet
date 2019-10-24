namespace SwedbankPay.Sdk.Exceptions
{
    using System;
    using SwedbankPay.Sdk.Models;
    using SwedbankPay.Sdk.PaymentOrders;

    public class CouldNotUpdatePaymentOrderException : Exception
    {
        public ProblemsContainer Problems { get; }
        public PaymentOrderRequestContainer Payment { get; }

        public CouldNotUpdatePaymentOrderException(PaymentOrderRequestContainer payment, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            Payment = payment;
        }
    }
}
