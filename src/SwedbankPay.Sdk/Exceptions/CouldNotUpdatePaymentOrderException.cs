namespace SwedbankPay.Sdk.Exceptions
{
    using SwedbankPay.Sdk.PaymentOrders;

    using System;

    public class CouldNotUpdatePaymentOrderException : Exception
    {
        public ProblemsContainer Problems { get; }
        public string Id { get; }
        public PaymentOrderRequestContainer PaymentOrderRequestContainer { get; }


        public CouldNotUpdatePaymentOrderException(string id, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }

        public CouldNotUpdatePaymentOrderException(PaymentOrderRequestContainer paymentOrderRequestContainer, ProblemsContainer problems) : base(problems.ToString())
        {
            Problems = problems;
            PaymentOrderRequestContainer = paymentOrderRequestContainer;
        }

    }
}
