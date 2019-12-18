using System.Net.Http;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Exceptions
{
    public class CouldNotUpdatePaymentOrderException : SdkException
    {
        public CouldNotUpdatePaymentOrderException(HttpResponseMessage httpResponseMessage,
                                                   string id, 
                                                   ProblemsContainer problems)
            : base(httpResponseMessage, problems.ToString())
        {
            Problems = problems;
            Id = id;
        }


        public CouldNotUpdatePaymentOrderException(HttpResponseMessage httpResponseMessage,
                                                   PaymentOrderRequestContainer paymentOrderRequestContainer,
                                                   ProblemsContainer problems)
            : base(httpResponseMessage, problems.ToString())
        {
            Problems = problems;
            PaymentOrderRequestContainer = paymentOrderRequestContainer;
        }


        public string Id { get; }
        public PaymentOrderRequestContainer PaymentOrderRequestContainer { get; }
        public ProblemsContainer Problems { get; }
    }
}