using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentAuthorizationTransactionDto
    {
        public int Amount { get; }
        public DateTime Created { get; }
        public string Description { get; }
        public string FailedActivityName { get; }
        public string FailedErrorCode { get; }
        public string FailedErrorDescription { get; }
        public string FailedReason { get; }
        public bool IsOperational { get; }
        public string Number { get; }
        public OperationListDto Operations { get; }
        public string PayeeReference { get; }
        public string State { get; }
        public string Type { get; }
        public DateTime Updated { get; }
        public int VatAmount { get; }

        internal AuthorizationTransaction Map()
        {
            return new AuthorizationTransaction(Created,
                                                Updated,
                                                Type,
                                                State,
                                                Number,
                                                Amount,
                                                VatAmount,
                                                Description,
                                                PayeeReference,
                                                FailedReason,
                                                FailedActivityName,
                                                FailedErrorCode,
                                                FailedErrorDescription,
                                                IsOperational,
                                                Operations.Map());
        }
    }
}