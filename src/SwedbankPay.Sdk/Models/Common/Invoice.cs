namespace SwedbankPay.Sdk.Models.Common
{
    public class Invoice
    {
        /// <summary>
        /// The fee amount in the lowest monetary unit to apply if the consumer chooses to pay with invoice.
        /// </summary>
        public int? FeeAmount { get; set; }

    }
}
