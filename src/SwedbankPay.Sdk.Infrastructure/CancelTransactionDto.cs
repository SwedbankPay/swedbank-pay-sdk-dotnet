using SwedbankPay.Sdk.PaymentInstruments.Invoice;
using SwedbankPay.Sdk.PaymentInstruments.Trustly;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk
{
    internal class CancelTransactionDto
    {
        public CancelTransactionDto(CancelTransaction transaction)
        {
            Description = transaction.Description;
            PayeeReference = transaction.PayeeReference;
            TransactionActivity = transaction.TransactionActivity.Value;
        }

        public CancelTransactionDto(PaymentInstruments.MobilePay.CancelTransaction transaction)
        {
            Description = transaction.Description;
            PayeeReference = transaction.PayeeReference;
        }

        public CancelTransactionDto(TrustlyPaymentCancelTransaction transaction)
        {
            Description = transaction.Description;
            PayeeReference = transaction.PayeeReference;
        }

        public CancelTransactionDto(PaymentInstruments.Vipps.CancelTransaction transaction)
        {
            Description = transaction.Description;
            PayeeReference = transaction.PayeeReference;
        }

        public CancelTransactionDto(PaymentOrderCancelTransaction transaction)
        {

            Description = transaction.Description;
            PayeeReference = transaction.PayeeReference;
        }

        public string Description { get; }

        public string PayeeReference { get; }

        public string TransactionActivity { get; }
    }
}