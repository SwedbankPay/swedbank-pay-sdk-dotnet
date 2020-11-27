using System.Collections.Generic;

namespace SwedbankPay.Sdk
{
    /// <summary>
    /// Contains the MetaData for a Payment/PaymentOrder.
    /// </summary>
    public class MetadataResponse : Dictionary<string, object>
    {
        /// <summary>
        /// Instantiates a new empty <seealso cref="MetadataResponse"/>.
        /// </summary>
        public MetadataResponse()
        {
        }

        /// <summary>
        /// Instantiates a new <seealso cref="MetadataResponse"/> using the provided <seealso cref="Dictionary{TKey, TValue}"/>.
        /// </summary>
        /// <param name="dictionary">A <seealso cref="Dictionary{TKey, TValue}"/> with values to be added.</param>
        public MetadataResponse(Dictionary<string, object> dictionary)
            : base(dictionary)
        {
            Id = dictionary["id"]?.ToString();
        }

        /// <summary>
        /// Unique ID that references this resource, available if set.
        /// </summary>
        public string Id { get; set; }
    }
}