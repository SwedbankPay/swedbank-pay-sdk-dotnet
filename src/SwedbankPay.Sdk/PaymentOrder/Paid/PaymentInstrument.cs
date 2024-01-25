namespace SwedbankPay.Sdk.PaymentOrder.Paid;

public class PaymentInstrument : TypeSafeEnum<PaymentInstrument>
	{
        /// <summary>
        /// The order item will be limited to credit card.
        /// </summary>
        public static readonly PaymentInstrument CreditCard = new PaymentInstrument(nameof(CreditCard), "CreditCard");

        // /// <summary>
        // /// The order item will be limited to invoice.
        // /// </summary>
        // public static readonly PaymentInstrument Invoice = new PaymentInstrument(nameof(Invoice), "Invoice");

        /// <summary>
        /// The order item will be limited to Vipps.
        /// </summary>
        public static readonly PaymentInstrument Vipps = new PaymentInstrument(nameof(Vipps), "Vipps");

        /// <summary>
        /// The order item will be limited to Swish.
        /// </summary>
        public static readonly PaymentInstrument Swish = new PaymentInstrument(nameof(Swish), "Swish");

        /// <summary>
        /// The order item will be limited to Trustly.
        /// </summary>
        public static readonly PaymentInstrument Trustly = new PaymentInstrument(nameof(Trustly), "Trustly");

        /// <summary>
        /// The order item will be limited to credit account.
        /// </summary>
        public static readonly PaymentInstrument CreditAccount = new PaymentInstrument(nameof(CreditAccount), "CreditAccount");
        
        public static readonly PaymentInstrument CreditAccountCreditAccountNo = new PaymentInstrument(nameof(CreditAccountCreditAccountNo), "CreditAccount-CreditAccountNo");
        public static readonly PaymentInstrument CreditAccountCreditAccountSe = new PaymentInstrument(nameof(CreditAccountCreditAccountSe), "CreditAccount-CreditAccountSe");

        /// <summary>
        /// The order item will be limited to invoice subtype PayExFinancingNo.
        /// </summary>
        public static readonly PaymentInstrument InvoicePayExFinancingNo = new PaymentInstrument(nameof(InvoicePayExFinancingNo), "Invoice-PayExFinancingNo");

        /// <summary>
        /// The order item will be limited to invoice subtype PayExFinancingSe.
        /// </summary>
        public static readonly PaymentInstrument InvoicePayExFinancingSe = new PaymentInstrument(nameof(InvoicePayExFinancingSe), "Invoice-PayExFinancingSe");

        /// <summary>
        /// The order item will be limited to invoice subtype PayMonthlyInvoiceSe.
        /// </summary>
        public static readonly PaymentInstrument InvoicePayMonthlyInvoiceSe = new PaymentInstrument(nameof(InvoicePayMonthlyInvoiceSe), "Invoice-PayMonthlyInvoiceSe");

        
        public static readonly PaymentInstrument ApplePay = new PaymentInstrument(nameof(ApplePay), "ApplePay");
        public static readonly PaymentInstrument GooglePay = new PaymentInstrument(nameof(GooglePay), "GooglePay");
        public static readonly PaymentInstrument SamsungPay = new PaymentInstrument(nameof(SamsungPay), "SamsungPay");
        public static readonly PaymentInstrument MobilePay = new PaymentInstrument(nameof(MobilePay), "MobilePay");
        public static readonly PaymentInstrument ClickToPay = new PaymentInstrument(nameof(ClickToPay), "ClickToPay");
        public static readonly PaymentInstrument CarPay = new PaymentInstrument(nameof(CarPay), "CarPay");


        
        /// <summary>
        /// Instantiates a <see cref="OrderItemInstrument"/> with the provided parameters.
        /// </summary>
        /// <param name="name">The human readable name of the type.</param>
        /// <param name="value">The API value of the type.</param>
        public PaymentInstrument(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Converts a <see cref="string"/> to a <see cref="OrderItemInstrument"/>.
        /// </summary>
        /// <param name="instrument">The API value to convert.</param>
        public static implicit operator PaymentInstrument?(string? instrument)
        {
            if (string.IsNullOrWhiteSpace(instrument))
            {
                return null;
            }
            
            return instrument switch
            {
                "CreditCard" => CreditCard,
                // "Invoice" => Invoice,
                "Vipps" => Vipps,
                "Swish" => Swish,
                "Trustly" => Trustly,
                "CreditAccount" => CreditAccount,
                "InvoicePayExFinancingNo" => InvoicePayExFinancingNo,
                "InvoicePayExFinancingSe" => InvoicePayExFinancingSe,
                "InvoicePayMonthlyInvoiceSe" => InvoicePayMonthlyInvoiceSe,
                "CreditAccountCreditAccountNo" => CreditAccountCreditAccountNo,
                "CreditAccountCreditAccountSe" => CreditAccountCreditAccountSe,
                "ApplePay" => ApplePay,
                "GooglePay" => GooglePay,
                "SamsungPay" => SamsungPay,
                "MobilePay" => MobilePay,
                "ClickToPay" => ClickToPay,
                "CarPay" => CarPay,
                
                _ => new PaymentInstrument(instrument!, instrument!),
            };
        }
    }