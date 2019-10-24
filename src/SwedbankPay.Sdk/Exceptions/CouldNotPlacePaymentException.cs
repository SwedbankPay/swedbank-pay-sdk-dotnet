namespace SwedbankPay.Sdk.Exceptions
{
    using SwedbankPay.Sdk.Payments;

    using System;

    public class CouldNotPlacePaymentException : Exception
    {
        public ProblemsContainer Problems { get; }
        public PaymentRequest Payment { get; }

        public CouldNotPlacePaymentException(PaymentRequest payment, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            Payment = payment;
        }
    }
}