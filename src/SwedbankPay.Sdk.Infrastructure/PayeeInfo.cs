using System;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public class PayeeInfo : IPayeeInfo
    {
        /// <summary>
        /// Constructs a fully qualified <seealso cref="PayeeInfo"/>
        /// </summary>
        /// <param name="payeeId"></param>
        /// <param name="payeeReference"></param>
        public PayeeInfo(string payeeId,
                         string payeeReference)
        {
            PayeeId = payeeId;
            PayeeReference = payeeReference;
        }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string OrderReference { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string PayeeId { get; set; }


        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string PayeeName { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string PayeeReference { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string ProductCategory { get; set; }
        
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public string Subsite { get; set; }
    }
}