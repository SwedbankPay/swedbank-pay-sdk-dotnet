namespace SwedbankPay.Sdk.Exceptions
{
    using System;
    using SwedbankPay.Sdk.Models;
    using SwedbankPay.Sdk.Models.Vipps.PaymentAPI.Request;

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