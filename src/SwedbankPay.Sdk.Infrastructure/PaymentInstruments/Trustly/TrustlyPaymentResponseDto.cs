using System.Net.Http;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPaymentResponseDto
    {
        public TrustlyPaymentDto Payment { get; set; }
        public OperationListDto Operations { get; set; }
    }
}