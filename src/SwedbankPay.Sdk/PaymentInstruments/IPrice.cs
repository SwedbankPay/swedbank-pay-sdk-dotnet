namespace SwedbankPay.Sdk.PaymentInstruments
{
    public interface IPrice
    {
        /// <summary>
        /// The amount (including VAT, if any) to charge the payer,
        /// entered in the lowest monetary unit of the selected currency
        /// </summary>
        Amount Amount { get; }

        /// <summary>
        /// The type of the price object.
        /// </summary>
        PriceType Type { get; }

        /// <summary>
        /// The payment’s VAT (Value Added Tax) amount, entered in the lowest monetary unit of the selected currency.
        /// The vatAmount entered will not affect the amount shown on the payment page, which only shows the total amount.
        /// This field is used to specify how much ofthe total amount the VAT will be.
        /// Set to 0 (zero) if there is no VAT amount charged.
        /// </summary>
        Amount VatAmount { get; }
    }
}