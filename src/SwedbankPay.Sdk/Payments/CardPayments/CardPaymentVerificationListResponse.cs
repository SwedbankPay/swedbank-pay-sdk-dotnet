using System;
using System.Collections.Generic;
using System.Text;

namespace SwedbankPay.Sdk.Payments.CardPayments
{
    public class CardPaymentVerificationListResponse : IdLink
    {
        public CardPaymentVerificationListResponse(Uri id, List<CardPaymentVerification> verificationList)
        {
            Id = id;
            VerificationList = verificationList;
        }

        public List<CardPaymentVerification> VerificationList { get; }
    }
}
