using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class PaymentNotYetAuthorizedException : Exception
    {
        public PaymentNotYetAuthorizedException(Uri id, string message)
            : base(message)
        {
            Id = id;
        }


        public Uri Id { get; }
    }
}