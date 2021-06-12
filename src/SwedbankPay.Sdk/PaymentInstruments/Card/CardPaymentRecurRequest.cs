﻿namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Used to pay a credit card recurring payment.
    /// </summary>
    public class CardPaymentRecurRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="CardPaymentRecurRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="intent">The current <seealso cref="PaymentIntent"/> for this payment.</param>
        /// <param name="recurrenceToken">A previously authorized recurrence token.</param>
        /// <param name="currency">The <seealso cref="Currency"/> the payment is being paid in.</param>
        /// <param name="amount">The amount the payer pays.</param>
        /// <param name="vatAmount">The <seealso cref="Amount"/> to be paid as Value Added Tax.</param>
        /// <param name="description">A textual description of the payment.</param>
        /// <param name="userAgent">The payers User Agent.</param>
        /// <param name="language">The preferred <seealso cref="Language"/> of the payer.</param>
        /// <param name="urls">All relevant <seealso cref="IUrls"/> for this payment.</param>
        /// <param name="payeeInfo">Your payee information.</param>
        public CardPaymentRecurRequest(PaymentIntent intent,
                                       string recurrenceToken,
                                       Currency currency,
                                       Amount amount,
                                       Amount vatAmount,
                                       string description,
                                       string userAgent,
                                       Language language,
                                       IUrls urls,
                                       IPayeeInfo payeeInfo)
        {
            Payment = new CardPaymentRecurDetails(Operation.Recur,
                                                      intent,
                                                      recurrenceToken,
                                                      currency,
                                                      amount,
                                                      vatAmount,
                                                      description,
                                                      userAgent,
                                                      language,
                                                      urls,
                                                      payeeInfo);
        }

        /// <summary>
        /// Hold detailed information about this payment.
        /// </summary>
        public CardPaymentRecurDetails Payment { get; }
    }
}
