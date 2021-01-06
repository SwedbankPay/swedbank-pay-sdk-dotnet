﻿using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    internal class MobilePayPaymentDetailsDto
    {
        public MobilePayPaymentDetailsDto(IMobilePayPaymentDetails payment)
        {
            Currency = payment.Currency.ToString();
            Description = payment.Description;
            Intent = payment.Intent.ToString();
            Language = payment.Language.ToString();
            Operation = payment.Operation.Value;
            PayeeInfo = new PayeeInfoDto(payment.PayeeInfo);
            PayerReference = payment.PayerReference;
            PrefillInfo = new PrefillInfoDto(payment.PrefillInfo);
            Prices = new List<PriceDto>();
            foreach (var item in payment.Prices)
            {
                Prices.Add(new PriceDto(item));
            }
            Urls = new UrlsDto(payment.Urls);
            UserAgent = payment.UserAgent;
            Metadata = payment.Metadata;
        }

        public string Currency { get; set; }

        public string Description { get; set; }

        public string Intent { get; set; }

        public string Language { get; set; }

        public string Operation { get; set; }

        public PayeeInfoDto PayeeInfo { get; }

        public string PayerReference { get; set; }

        public PrefillInfoDto PrefillInfo { get; set; }

        public List<PriceDto> Prices { get; set; }

        public UrlsDto Urls { get; }

        public string UserAgent { get; set; }

        public Dictionary<string, object> Metadata { get; }
    }
}