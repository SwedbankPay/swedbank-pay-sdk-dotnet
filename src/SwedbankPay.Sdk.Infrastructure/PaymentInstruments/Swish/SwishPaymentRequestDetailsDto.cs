﻿using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

internal class SwishPaymentRequestDetailsDto
{
    public SwishPaymentRequestDetailsDto(SwishPaymentRequestDetails payment)
    {
        Currency = payment.Currency.ToString();
        Description = payment.Description;
        Intent = payment.Intent.ToString();
        Language = payment.Language.ToString();
        Operation = payment.Operation.Value;
        PayeeInfo = new PayeeInfoResponseDto(payment.PayeeInfo);
        PayerReference = payment.PayerReference;
        PrefillInfo = new PrefillInfoDto(payment.PrefillInfo);
        Prices = new List<PriceDto>();
        foreach (var item in payment.Prices)
        {
            Prices.Add(new PriceDto(item));
        }
        Swish = new SwishPaymentOptionsDto(payment.Swish);
        Urls = new UrlsDto(payment.Urls);
        UserAgent = payment.UserAgent;

        if(payment.Metadata != null)
        {
            Metadata = new MetadataDto(payment.Metadata);
        }
    }

    public string Currency { get; set; }

    public string Description { get; set; }

    public string Intent { get; set; }

    public string Language { get; set; }

    public string Operation { get; set; }

    public PayeeInfoResponseDto PayeeInfo { get; set; }

    public string PayerReference { get; set; }

    public PrefillInfoDto PrefillInfo { get; set; }

    public List<PriceDto> Prices { get; set; }

    public SwishPaymentOptionsDto Swish { get; set; }

    public UrlsDto Urls { get; set; }

    public string UserAgent { get; set; }

    public MetadataDto Metadata { get; set; }
}