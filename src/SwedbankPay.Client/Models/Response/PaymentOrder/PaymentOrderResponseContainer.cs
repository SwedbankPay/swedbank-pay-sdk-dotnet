namespace SwedbankPay.Client.Models.Response
{
    using SwedbankPay.Client.Exceptions;
    using SwedbankPay.Client.Models.Vipps.PaymentAPI.Response;

    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public List<HttpOperation> Operations { get; set; } = new List<HttpOperation>();


        public string GetUpdatePaymentOrderUrl()
        {
            var httpOperation = Operations.FirstOrDefault(o => o.Rel == "update-paymentorder-updateorder");
            if (httpOperation == null)
            {
                if (Operations.Any())
                {
                    var availableOps = Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
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
                    var availableOps = Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
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
                    var availableOps = Operations.Select(o => o.Rel).Aggregate((x, y) => x + "," + y);
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
