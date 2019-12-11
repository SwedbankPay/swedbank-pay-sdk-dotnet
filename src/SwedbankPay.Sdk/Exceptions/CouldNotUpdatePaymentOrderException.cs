using System;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotUpdatePaymentOrderException : Exception
    {
        public CouldNotUpdatePaymentOrderException(string id, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public CouldNotUpdatePaymentOrderException(PaymentOrderRequestContainer paymentOrderRequestContainer, ProblemsContainer problems)
            : base(problems.ToString())
        {
            Problems = problems;
            PaymentOrderRequestContainer = paymentOrderRequestContainer;
        }


        public string Id { get; }
        public PaymentOrderRequestContainer PaymentOrderRequestContainer { get; }
        public ProblemsContainer Problems { get; }
    }
}