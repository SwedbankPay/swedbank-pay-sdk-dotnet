namespace SwedbankPay.Sdk.Exceptions
{
    using SwedbankPay.Sdk.PaymentOrders;

    using System;

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
