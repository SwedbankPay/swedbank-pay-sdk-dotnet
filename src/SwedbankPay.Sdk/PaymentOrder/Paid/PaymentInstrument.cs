namespace SwedbankPay.Sdk.PaymentOrder.Paid;

/// <summary>
/// Payment instrument of the Order.
/// </summary>
public class PaymentInstrument : TypeSafeEnum<PaymentInstrument>
	{
        /// <summary>
        /// The order item will be limited to credit card.
        /// </summary>
        public static readonly PaymentInstrument CreditCard = new PaymentInstrument(nameof(CreditCard), "CreditCard");

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
        
        /// <summary>
        /// The order item will be limited to credit account No.
        /// </summary>
        public static readonly PaymentInstrument CreditAccountCreditAccountNo = new PaymentInstrument(nameof(CreditAccountCreditAccountNo), "CreditAccount-CreditAccountNo");
        
        /// <summary>
        /// The order item will be limited to credit account Se.
        /// </summary>
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
        
        /// <summary>
        /// The order item will be limited to ApplePay.
        /// </summary>
        public static readonly PaymentInstrument ApplePay = new PaymentInstrument(nameof(ApplePay), "ApplePay");
        
        /// <summary>
        /// The order item will be limited to GooglePay.
        /// </summary>
        public static readonly PaymentInstrument GooglePay = new PaymentInstrument(nameof(GooglePay), "GooglePay");
        
        /// <summary>
        /// The order item will be limited to SamsungPay.
        /// </summary>
        public static readonly PaymentInstrument SamsungPay = new PaymentInstrument(nameof(SamsungPay), "SamsungPay");
        
        /// <summary>
        /// The order item will be limited to MobilePay.
        /// </summary>
        public static readonly PaymentInstrument MobilePay = new PaymentInstrument(nameof(MobilePay), "MobilePay");
        
        /// <summary>
        /// The order item will be limited to ClickToPay.
        /// </summary>
        public static readonly PaymentInstrument ClickToPay = new PaymentInstrument(nameof(ClickToPay), "ClickToPay");
        
        /// <summary>
        /// The order item will be limited to CarPay.
        /// </summary>
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