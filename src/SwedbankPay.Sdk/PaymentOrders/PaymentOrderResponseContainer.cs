namespace SwedbankPay.Sdk.PaymentOrders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SwedbankPay.Sdk.Exceptions;

    public class PaymentOrderResponseContainer
    {
        public PaymentOrderResponseContainer()
        {
        }

        public PaymentOrderResponseContainer(PaymentOrderResponse paymentOrder)
        {
            PaymentOrder = paymentOrder;
        }

        public PaymentOrderResponse PaymentOrder { get; set; }

        public Operations Operations { get; set; } = new Operations();


        public string GetUpdatePaymentOrderUrl()
        {
            var httpOperation = Operations.FirstOrDefault(o => o.Rel == "update-paymentorder-updateorder");
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

        public string GetPaymentUrl()
        {
            var httpOperation = Operations.FirstOrDefault(o => o.Rel == "redirect-paymentorder");
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
            var httpOperation = Operations.FirstOrDefault(o => o.Rel == "redirect-verification");
            if (httpOperation == null)
            {
                if (Operations.Any())
                {
                    var availableOps = Operations.ToString();
                    throw new BadRequestException($"Cannot get RedirectVerificationUrl from this payment. Available operations: {availableOps}");
                }
                throw new NoOperationsLeftException();
            }
            return httpOperation.Href;
        }

        public string TryGetPaymentUrl()
        {
            try
            {
                return GetPaymentUrl();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
