﻿using SwedbankPay.Sdk.PaymentOrders;
using System;

namespace SwedbankPay.Sdk
{
    internal class PayeeInfoResponse : Identifiable, IPayeeInfo
    {
        public PayeeInfoResponse(Uri id) : base(id)
        {
        }

        public PayeeInfoResponse(PayeeInfoResponseDto dto)
            :base(dto.Id)
        {
            OrderReference = dto.OrderReference;
            PayeeId = dto.PayeeId;
            PayeeName = dto.PayeeName;
            PayeeReference = dto.PayeeReference;
            ProductCategory = dto.ProductCategory;
            Subsite = dto.Subsite;
        }

        public PayeeInfoResponse(PaymentOrderPayeeInfoDto dto)
            : base(dto.Id)
        {
            if (string.IsNullOrEmpty(dto.PayeeId))
            {
                return;
            }

            OrderReference = dto.OrderReference;
            PayeeId = dto.PayeeId;
            PayeeName = dto.PayeeName;
            PayeeReference = dto.PayeeReference;
            ProductCategory = dto.ProductCategory;
            Subsite = dto.Subsite;
        }

        public string OrderReference { get; }
        public string PayeeId { get; }
        public string PayeeName { get; }
        public string PayeeReference { get; }
        public string ProductCategory { get; }
        public string Subsite { get; }
    }
}
