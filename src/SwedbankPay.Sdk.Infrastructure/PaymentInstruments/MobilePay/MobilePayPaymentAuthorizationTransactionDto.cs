using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentAuthorizationTransactionDto
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

        internal IMobilePayPaymentAuthorization Map()
        {
            return new MobilePayPaymentAuthorizationTransaction(this);
        }
    }
}