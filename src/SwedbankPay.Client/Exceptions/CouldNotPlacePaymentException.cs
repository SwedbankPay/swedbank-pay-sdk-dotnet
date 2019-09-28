namespace SwedbankPay.Client.Exceptions
{
    using SwedbankPay.Client.Models;
    using SwedbankPay.Client.Models.Vipps.PaymentAPI.Request;

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