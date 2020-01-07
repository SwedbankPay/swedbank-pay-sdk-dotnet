using System;
using System.Linq;

using Newtonsoft.Json;

using SwedbankPay.Sdk.Exceptions;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResponseContainer
    { 
        public PaymentOrderResponseContainer(OperationList operations, PaymentOrderResponse paymentOrderResponse)
        {
            Operations = operations;
            PaymentOrderResponse = paymentOrderResponse;
        }


        public OperationList Operations { get; }

        [JsonProperty("paymentorder")]
        public PaymentOrderResponse PaymentOrderResponse { get; }


        public Uri GetPaymentUrl()
        {
            var httpOperation = Operations.FirstOrDefault(o => o.Rel.Value == LinkRelation.RedirectPaymentOrder.Value);
            if (httpOperation == null)
            {
                if (Operations.Any())
                {
                    var availableOps = Operations.ToString();
                    throw new BadRequestException($"Cannot get PaymentUrl from this payment. Available operations: {availableOps}");
                }

                throw new NoOperationsLeftException();
            }

            return httpOperation.Href;
        }


        public Uri GetRedirectVerificationUrl()
        {
            var httpOperation = Operations.FirstOrDefault(o => o.Rel.Value == "redirect-verification");
            if (httpOperation == null)
            {
                if (Operations.Any())
                {
                    var availableOps = Operations.ToString();
                    throw new BadRequestException(
                        $"Cannot get RedirectVerificationUrl from this payment. Available operations: {availableOps}");
                }

                throw new NoOperationsLeftException();
            }

            return httpOperation.Href;
        }


        public Uri GetUpdatePaymentOrderUrl()
        {
            var httpOperation = Operations.FirstOrDefault(o => o.Rel.Value == LinkRelation.UpdatePaymentOrderUpdateOrder.Value);
            if (httpOperation == null)
            {
                if (Operations.Any())
                {
                    var availableOps = Operations.ToString();
                    throw new BadRequestException($"Cannot get PaymentUrl from this payment. Available operations: {availableOps}");
                }

                throw new NoOperationsLeftException();
            }

            return httpOperation.Href;
        }


        public bool TryGetPaymentUrl(out Uri paymentUrl)
        {
            try
            {
                paymentUrl = GetPaymentUrl();
                return true;
            }
            catch (Exception)
            {
                paymentUrl = null;
            }

            return false;
        }
    }
}