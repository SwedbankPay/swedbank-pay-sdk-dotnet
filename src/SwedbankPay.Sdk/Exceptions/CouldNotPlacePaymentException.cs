using System;

using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotPlacePaymentException : Exception
    {
        public CouldNotPlacePaymentException(PaymentRequest payment, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Payment = payment;
        }


        public PaymentRequest Payment { get; }
        public ProblemsContainer Problems { get; }
    }
}