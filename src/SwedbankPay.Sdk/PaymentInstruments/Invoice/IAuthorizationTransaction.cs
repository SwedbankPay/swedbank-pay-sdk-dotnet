namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IAuthorizationTransaction
    {
        /// <summary>
        /// The full (first and last) name of the consumer.
        /// </summary>
        string Addressee { get; }
        /// <summary>
        /// The city to the consumer.
        /// </summary>
        string City { get; }
        /// <summary>
        /// The CO-address (if used)
        /// </summary>
        string CoAddress { get; }
        /// <summary>
        /// SE, NO, or FI. The country code of the consumer.
        /// </summary>
        string CountryCode { get; }
        /// <summary>
        /// The customer number in the merchant system.
        /// </summary>
        int? CustomerNumber { get; }
        /// <summary>
        /// The e-mail address of the consumer.
        /// </summary>
        EmailAddress Email { get; }
        /// <summary>
        /// The IP address of the consumer.
        /// </summary>
        string Ip { get; }
        /// <summary>
        /// The mobile phone number of the consumer. Format Sweden: +46707777777. Format Norway: +4799999999. 
        /// Format Finland: +358501234567
        /// </summary>
        string Msisdn { get; }
        /// <summary>
        /// The social security number (national identity number) of the consumer. Format Sweden: YYMMDD-NNNN. 
        /// Format Norway: DDMMYYNNNNN. Format Finland: DDMMYYNNNNN
        /// </summary>
        int SocialSecurityNumber { get; }
        /// <summary>
        /// The street address of the consumer.
        /// </summary>
        string StreetAddress { get; }
        /// <summary>
        /// FinancingConsumer
        /// </summary>
        Operation TransactionActivity { get; }
        /// <summary>
        /// The postal code (ZIP code) of the consumer.
        /// </summary>
        string ZipCode { get; }
    }
}