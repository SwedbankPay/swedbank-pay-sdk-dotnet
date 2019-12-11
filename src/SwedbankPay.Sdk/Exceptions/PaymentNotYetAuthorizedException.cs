using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class PaymentNotYetAuthorizedException : Exception
    {
        public PaymentNotYetAuthorizedException(string id, string message)
            : base(message)
        {
            Id = id;
        }


        public string Id { get; }
    }
}