using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class VerificationListResponseDto
    {
        public Uri Id { get; set; }
        public IList<VerificationDto> VerificationList { get; set; } = new List<VerificationDto>();

        internal IVerificationListResponse Map()
        {
            return new VerificationListResponse(Id, VerificationList);
        }
    }
}