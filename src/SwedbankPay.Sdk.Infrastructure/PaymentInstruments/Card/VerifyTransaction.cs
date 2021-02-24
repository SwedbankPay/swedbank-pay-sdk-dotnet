using System;
using SwedbankPay.Sdk.Extensions;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class VerifyTransaction : Identifiable, IVerifyTransaction
    {
        public VerifyTransaction(VerifyTransactionDto dto)
            : base(dto.Id)
        {
            Amount = dto.Amount;
            VatAmount = dto.VatAmount;
            FailedReason = dto.FailedReason;
            FailedActivityName = dto.FailedActivityName;
            FailedErrorCode = dto.FailedErrorCode;
            FailedErrorDescription = dto.FailedErrorDescription;
            Activities = dto.Activities;
            Created = dto.Created;
            Updated = dto.Updated;
            Activity = dto.Activity;
            Description = dto.Description;
            IsOperational = dto.IsOperational;
            Number = dto.Number;
            PayeeReference = dto.PayeeReference;
            State = dto.State;

            Type = string.IsNullOrEmpty(dto.Type) ? TransactionType.Unknown : dto.Type.ParseTo<TransactionType>();
            Problem = dto.Problem?.Map();
            IOperationList operations = new OperationList();
            foreach (var item in dto.Operations)
            {
                var rel = new LinkRelation(item.Rel);
                operations.Add(new HttpOperation(item.Href, rel, item.Method, item.ContentType));
            }
            Operations = operations;
        }

        public string FailedReason { get; }

        public string FailedActivityName { get; }

        public string FailedErrorCode { get; }

        public string FailedErrorDescription { get; }

        public Uri Activities { get; }

        public DateTime Created { get; }

        public DateTime Updated { get; }

        public string Activity { get; }

        public Amount Amount { get; }

        public string Description { get; }

        public bool IsOperational { get; }

        public long Number { get; }

        public IOperationList Operations { get; }

        public string PayeeReference { get; }

        public State State { get; }

        public TransactionType Type { get; }

        public Amount VatAmount { get; }

        public IProblem Problem { get; }
    }
}
