using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class VerifyTransactionDto
    {
        public long Amount { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public bool IsOperational { get; set; }
        public long Number { get; set; }
        public OperationListDto Operations { get; set; } = new OperationListDto();
        public string PayeeReference { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public DateTime Updated { get; set; }
        public long VatAmount { get; set; }
        public string Activity { get; set; }
        public ProblemDto Problem { get; set; }
        public string FailedReason { get; set; }
        public string FailedActivityName { get; set; }
        public string FailedErrorCode { get; set; }
        public string FailedErrorDescription { get; set; }
        public Uri Activities { get; set; }
    }
}