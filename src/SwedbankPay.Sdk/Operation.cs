namespace SwedbankPay.Sdk;

 /// <summary>
    /// A enum-like class that holds <seealso cref="Operation"/>.
    /// </summary>
    public sealed class Operation : TypeSafeEnum<Operation>
    {
        /// <summary>
        /// The <seealso cref="Operation"/> for Purchase.
        /// </summary>
        public static readonly Operation Purchase = new Operation(nameof(Purchase), "Purchase");

        /// <summary>
        /// The <seealso cref="Operation"/> for UpdateOrder.
        /// </summary>
        public static readonly Operation UpdateOrder = new Operation(nameof(UpdateOrder), "UpdateOrder");

        /// <summary>
        /// The <seealso cref="Operation"/> for Verify.
        /// </summary>
        public static readonly Operation Verify = new Operation(nameof(Verify), "Verify");

        /// <summary>
        /// The <seealso cref="Operation"/> for initiate-consumer-session.
        /// </summary>
        public static readonly Operation Initiate = new Operation(nameof(Initiate), "initiate-consumer-session");

        /// <summary>
        /// The <seealso cref="Operation"/> for Recur.
        /// </summary>
        public static readonly Operation Recur = new Operation(nameof(Recur), "Recur");

        /// <summary>
        /// The <seealso cref="Operation"/> for FinancingConsumer.
        /// </summary>
        public static readonly Operation FinancingConsumer = new Operation(nameof(FinancingConsumer), "FinancingConsumer");

        /// <summary>
        /// The <seealso cref="Operation"/> for Sale.
        /// </summary>
        public static readonly Operation Sale = new Operation(nameof(Sale), "Sale");

        /// <summary>
        /// Instantiates a new <seealso cref="Operation"/> with the provided parameters.
        /// </summary>
        /// <param name="name">The name of the operation.</param>
        /// <param name="value">The API value for the operation.</param>
        public Operation(string name, string value)
            : base(name, value)
        {
        }

        /// <summary>
        /// Implicitly converts a string to a <seealso cref="Operation"/>.
        /// </summary>
        /// <param name="operation">The name/value of the <seealso cref="Operation"/>.</param>
        public static implicit operator Operation(string operation)
        {
            return operation switch
            {
                "Purchase" => Purchase,
                "UpdateOrder" => UpdateOrder,
                "Verify" => Verify,
                "initiate-consumer-session" => Initiate,
                "Recur" => Recur,
                "FinancingConsumer" => FinancingConsumer,
                "Sale" => Sale,
                _ => new Operation(operation, operation),
            };
        }
    }