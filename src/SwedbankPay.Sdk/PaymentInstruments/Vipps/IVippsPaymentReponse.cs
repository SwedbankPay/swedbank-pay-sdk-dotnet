namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public interface IVippsPaymentReponse
    {
        public IVippsPaymentOperations Operations { get; set; }
        public IVippsPayment Payment { get; set; }
    }
}