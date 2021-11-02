namespace SwedbankPay.Sdk
{
	/// <summary>
	/// Payment instrument the order item will be limited to.
	/// </summary>
	public class OrderItemInstrument : TypeSafeEnum<OrderItemInstrument>
	{
        /// <summary>
        /// The order item will be limited to credit card.
        /// </summary>
        public static readonly OrderItemInstrument CreditCard = new OrderItemInstrument(nameof(CreditCard), "CreditCard");

        /// <summary>
        /// The order item will be limited to invoice.
        /// </summary>
        public static readonly OrderItemInstrument Invoice = new OrderItemInstrument(nameof(Invoice), "Invoice");

        /// <summary>
        /// The order item will be limited to Vipps.
        /// </summary>
        public static readonly OrderItemInstrument Vipps = new OrderItemInstrument(nameof(Vipps), "Vipps");

        /// <summary>
        /// The order item will be limited to Swish.
        /// </summary>
        public static readonly OrderItemInstrument Swish = new OrderItemInstrument(nameof(Swish), "Swish");

        /// <summary>
        /// The order item will be limited to Trustly.
        /// </summary>
        public static readonly OrderItemInstrument Trustly = new OrderItemInstrument(nameof(Trustly), "Trustly");

        /// <summary>
        /// The order item will be limited to credit account.
        /// </summary>
        public static readonly OrderItemInstrument CreditAccount = new OrderItemInstrument(nameof(CreditAccount), "CreditAccount");

        /// <summary>
        /// The order item will be limited to invoice subtype PayExFinancingNo.
        /// </summary>
        public static readonly OrderItemInstrument InvoicePayExFinancingNo = new OrderItemInstrument(nameof(InvoicePayExFinancingNo), "Invoice-PayExFinancingNo");

        /// <summary>
        /// The order item will be limited to invoice subtype PayExFinancingSe.
        /// </summary>
        public static readonly OrderItemInstrument InvoicePayExFinancingSe = new OrderItemInstrument(nameof(InvoicePayExFinancingSe), "Invoice-PayExFinancingSe");

        /// <summary>
        /// The order item will be limited to invoice subtype PayMonthlyInvoiceSe.
        /// </summary>
        public static readonly OrderItemInstrument InvoicePayMonthlyInvoiceSe = new OrderItemInstrument(nameof(InvoicePayMonthlyInvoiceSe), "Invoice-PayMonthlyInvoiceSe");

        /// <summary>
        /// Instantiates a <see cref="OrderItemInstrument"/> with the provided parameters.
        /// </summary>
        /// <param name="name">The human readable name of the type.</param>
        /// <param name="value">The API value of the type.</param>
        public OrderItemInstrument(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Converts a <see cref="string"/> to a <see cref="OrderItemInstrument"/>.
        /// </summary>
        /// <param name="type">The API value to convert.</param>
        public static implicit operator OrderItemInstrument(string instrument)
        {
            return instrument switch
            {
                "CreditCard" => CreditCard,
                "Invoice" => Invoice,
                "Vipps" => Vipps,
                "Swish" => Swish,
                "Trustly" => Trustly,
                "CreditAccount" => CreditAccount,
                "InvoicePayExFinancingNo" => InvoicePayExFinancingNo,
                "InvoicePayExFinancingSe" => InvoicePayExFinancingSe,
                "InvoicePayMonthlyInvoiceSe" => InvoicePayMonthlyInvoiceSe,
                _ => new OrderItemInstrument(instrument, instrument),
            };
        }
    }
}
