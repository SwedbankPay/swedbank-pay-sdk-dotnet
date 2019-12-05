namespace SwedbankPay.Sdk.Payments
{
    using Newtonsoft.Json;

    using SwedbankPay.Sdk.Exceptions;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PaymentResponseContainer
    {
        public PaymentResponseContainer()
        {
        }

        [JsonConstructor]
        public PaymentResponseContainer(PaymentResponse payment)
        {
            Payment = payment;
        }

        public PaymentResponse Payment { get; set; }

        public OperationList Operations { get; set; } = new OperationList();

        public string GetPaymentUrl()
        {
            var httpOperation = Operations.FirstOrDefault(o => o.Rel.Value == "redirect-authorization");
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