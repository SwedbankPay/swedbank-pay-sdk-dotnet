using System;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Identifies the merchant that initiated the payment.
    /// </summary>
    public class PayeeInfo : Identifiable
    {
        /// <summary>
        /// Constructs a <seealso cref="PayeeInfo"/> with only the <see cref="Identifiable.Id"/> set.
        /// </summary>
        /// <param name="id">The <seealso cref="Uri"/> used to access the resource.</param>
        public PayeeInfo(Uri id) : base(id)
        {
        }

        /// <summary>
        /// Constructs a fully qualified <seealso cref="PayeeInfo"/>, but without a <seealso cref="Identifiable.Id"/>.
        /// </summary>
        /// <param name="payeeId"></param>
        /// <param name="payeeReference"></param>
        public PayeeInfo(Guid payeeId,
                         string payeeReference)
            : base(new Uri(payeeId.ToString()))
        {
            PayeeId = payeeId;
            PayeeReference = payeeReference;
        }


        /// <summary>
        ///     The order reference should reflect the order reference found in the merchant's systems.
        /// </summary>
        public string OrderReference { get; set; }

        /// <summary>
        ///     This is the unique id that identifies this payee (like merchant) set by PayEx.
        /// </summary>
        public Guid PayeeId { get; set; }

        /// <summary>
        ///     The name of the payee, usually the name of the merchant.
        /// </summary>

        public string PayeeName { get; set; }

        /// <summary>
        ///     A unique reference, max 30 characters, set by the merchant system - this must be unique for each operation!
        ///     NOTE://PayEx may send either the transaction number OR the payeeReference as a reference to the acquirer.
        ///     This will be used in reconciliation and reporting back to PayEx and you.
        ///     If PayEx sends the transaction number to the acquirer, then the payeeReference parameter may have the format of
        ///     String(30).
        ///     If PayEx sends the payeeRef to the acquirer, the parameter is limited to the format of String(12) AND all
        ///     characters must be digits/numbers.
        /// </summary>
        public string PayeeReference { get; set; }

        /// <summary>
        ///     A product category or number sent in from the payee/merchant. This is not validated by PayEx, but will be passed
        ///     through the payment process and may be used in the settlement process.9
        /// </summary>
        public string ProductCategory { get; set; }

        /// <summary>
        ///     The subsite field can be used to perform split settlement on the payment. The subsites must be resolved with PayEx
        ///     reconciliation before being used.
        /// </summary>
        public string Subsite { get; set; }
    }
}