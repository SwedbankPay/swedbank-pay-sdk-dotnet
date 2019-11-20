namespace SwedbankPay.Sdk.Transactions
{
    using System.Collections.Generic;

    public class TransactionListContainer : IdLink
    {
        public List<TransactionResponse> TransactionList { get; protected set; } = new List<TransactionResponse>();
    }

    public class AuthorizationListContainer : IdLink
    {
        public List<TransactionContainerResponse> AuthorizationList { get; protected set; } = new List<TransactionContainerResponse>();
    }

    public class CapturesListContainer : IdLink
    {
        public List<TransactionContainerResponse> CaptureList { get; protected set; } = new List<TransactionContainerResponse>();
    }

    public class ReversalsListContainer : IdLink
    {
        public List<TransactionContainerResponse> ReversalList { get; protected set; } = new List<TransactionContainerResponse>();
    }

    public class CancellationsListContainer : IdLink
    {
        public List<TransactionContainerResponse> CancellationList { get; protected set; } = new List<TransactionContainerResponse>();
    }

    public class TransactionContainerResponse : IdLink
    {
        public TransactionResponse Transaction { get; protected set; }
    }
}