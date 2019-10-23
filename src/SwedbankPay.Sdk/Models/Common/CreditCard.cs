namespace SwedbankPay.Sdk.Models.Common
{
    public class CreditCard
    {
        /// <summary>
        /// true if the payment should not require a 3D-secure authentication; otherwise  false.
        /// </summary>
        public bool No3DSecure { get; set; }

        /// <summary>
        /// true if this is a MOTO payment; otherwise false. Default value is set on the contract.
        /// </summary>
        public bool MailOrderTelephoneOrder { get; set; }

        /// <summary>
        /// true if cards not enrolled with 3D-secure should be declined; otherwise false. Default value is set on the contract.
        /// </summary>
        public bool RejectCardNot3DSecureEnrolled { get; set; }

        /// <summary>
        /// true if debit cards should be declined; otherwise false. Default value is set on the contract.
        /// </summary>
        public bool RejectDebitCards { get; set; }

        /// <summary>
        /// true if credit cards should be declined; otherwise false. Default value is set on the contract.
        /// </summary>
        public bool RejectCreditCards { get; set; }

        /// <summary>
        /// true if consumer cards should be declined; otherwise false. Default value is set on the contract.
        /// </summary>
        public bool RejectConsumerCards { get; set; }

        /// <summary>
        /// true if corporate cards should be declined; otherwise false. Default value is set on the contract.
        /// </summary>
        public bool RejectCorporateCards { get; set; }

        /// <summary>
        /// true if response code U from issuer bank should be declined; otherwise  false. Default value is set on the contract. Response code U means that it couldn't be determined if card was 3DSecure enrolled or not. 
        /// </summary>
        public bool RejectAuthenticationStatusU { get; set; }

        /// <summary>
        ///  true if response code A from issuer bank should be declined; otherwise  false. Default value is set on the contract.Response code A means that the 3DSecure service is unavailable and therefore a 3DSecure verification is not made.
        /// </summary>
        public bool RejectAuthenticationStatusA { get; set; }


    }
}
