namespace SwedbankPay.Sdk.Exceptions
{
    using System;

    public class OperationNotAvailableException : Exception
    {
        public string Id { get; }

        public OperationNotAvailableException(string id, string message) : base(message)
        {
            Id = id;
        }
    }
}
