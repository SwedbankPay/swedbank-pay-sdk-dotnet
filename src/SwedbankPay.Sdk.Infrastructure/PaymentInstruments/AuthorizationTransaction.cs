using System;

namespace SwedbankPay.Sdk.PaymentInstruments
{
    internal class AuthorizationTransaction : Identifiable, IAuthorizationTransaction
    {
        public AuthorizationTransaction(AuthorizationTransactionDto dto)
            :base(dto.Id)
        {
            Created = dto.Created;
            Updated = dto.Updated;
            Type = dto.Type;
            State = dto.State;
            Number = dto.Number;
            Amount = dto.Amount;
            VatAmount = dto.VatAmount;
            Description = dto.Description;
            PayeeReference = dto.PayeeReference;
            FailedReason = dto.FailedReason;
            FailedActivityName = dto.FailedActivityName;
            FailedErrorCode = dto.FailedErrorCode;
            FailedErrorDescription = dto.FailedErrorDescription;
            IsOperational = dto.IsOperational;
            Operations = dto.Operations?.Map();
        }

        public Amount Amount { get; }

        public DateTime Created { get; }

        
        public string Description { get; }

        
        public string FailedActivityName { get; }

        public string FailedErrorCode { get; }

        public string FailedErrorDescription { get; }

        public string FailedReason { get; }

        public bool IsOperational { get; }

        public long Number { get; }

        public IOperationList Operations { get; }

        public string PayeeReference { get; }

        public State State { get; }

        public string Type { get; }

        public DateTime Updated { get; }

        
        public Amount VatAmount { get; }
    }
}