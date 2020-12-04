using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CreditCardDto
    {
        public CreditCardDto(CreditCard creditCard)
        {
            if(creditCard == null)
            {
                return;
            }

            MailOrderTelephoneOrder = creditCard.MailOrderTelephoneOrder;
            RejectAuthenticationStatusA = creditCard.RejectAuthenticationStatusA;
            RejectAuthenticationStatusU = creditCard.RejectAuthenticationStatusU;
            RejectCardNot3DSecureEnrolled = creditCard.RejectCardNot3DSecureEnrolled;
            RejectConsumerCards = creditCard.RejectConsumerCards;
            RejectCorporateCards = creditCard.RejectCorporateCards;
            RejectCreditCards = creditCard.RejectCreditCards;
            RejectDebitCards = creditCard.RejectDebitCards;
        }

        public bool MailOrderTelephoneOrder { get; set; }

        public bool RejectAuthenticationStatusA { get; set; }

        public bool RejectAuthenticationStatusU { get; set; }

        public bool RejectCardNot3DSecureEnrolled { get; set; }

        public bool RejectConsumerCards { get; set; }

        public bool RejectCorporateCards { get; set; }

        public bool RejectCreditCards { get; set; }

        public bool RejectDebitCards { get; set; }
    }
}