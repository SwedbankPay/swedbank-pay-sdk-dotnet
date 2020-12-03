using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentAuthorizationTransactionDto
    {
        public Uri Id { get; set; }
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string FailedActivityName { get; set; }
        public string FailedErrorCode { get; set; }
        public string FailedErrorDescription { get; set; }
        public string FailedReason { get; set; }
        public bool IsOperational { get; set; }
        public long Number { get; set; }
        public OperationListDto Operations { get; set; }
        public string PayeeReference { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public DateTime Updated { get; set; }
        public int VatAmount { get; set; }

        internal AuthorizationTransaction Map()
        {
            return new AuthorizationTransaction(Id,
                                                Created,
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