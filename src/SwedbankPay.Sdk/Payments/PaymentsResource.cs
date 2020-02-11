using SwedbankPay.Sdk.Payments.CardPayments;
using SwedbankPay.Sdk.Payments.SwishPayments;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Payments
{
    public class PaymentsResource: ResourceBase, IPaymentsResource
    {
        public ICardPaymentsResource CardPayments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISwishPaymentsResource SwishPayments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PaymentsResource(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
