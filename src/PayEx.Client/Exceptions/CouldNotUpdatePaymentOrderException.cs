namespace SwedbankPay.Client.Exceptions
{
    using SwedbankPay.Client.Models.Request;
    using SwedbankPay.Client.Models.Vipps;

    using System;
    using SwedbankPay.Client.Models;

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
