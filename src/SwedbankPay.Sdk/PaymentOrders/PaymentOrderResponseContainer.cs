using System;
using System.Linq;

using SwedbankPay.Sdk.Exceptions;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderResponseContainer
    {
        public PaymentOrderResponseContainer()
        {
        }


        public PaymentOrderResponseContainer(PaymentOrderResponse paymentOrder)
        {
            PaymentOrder = paymentOrder;
        }


        public OperationList Operations { get; set; } = new OperationList();

        public PaymentOrderResponse PaymentOrder { get; set; }


        public string GetPaymentUrl()
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


        public string GetRedirectVerificationUrl()
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


        public string GetUpdatePaymentOrderUrl()
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


        public bool TryGetPaymentUrl(out string paymentUrl)
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