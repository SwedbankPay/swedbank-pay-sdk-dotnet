using System;

namespace SwedbankPay.Sdk.Exceptions
{
    public class OperationNotAvailableException : Exception
    {
        public OperationNotAvailableException(string id, string message)
            : base(message)
        {
            Id = id;
        }


        public string Id { get; }
    }
}