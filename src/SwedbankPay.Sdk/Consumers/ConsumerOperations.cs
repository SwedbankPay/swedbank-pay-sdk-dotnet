using System.Runtime.Serialization;

namespace SwedbankPay.Sdk.Consumers
{
    /// <summary>
    /// Holds all currently available operations for a consumer.
    /// </summary>
    public class ConsumerOperations : OperationsBase
    {
        /// <summary>
        /// Consturcts a <see cref="ConsumerOperations"/> holding all currently available operations for a consumer.
        /// </summary>
        /// <param name="operations">A list of available operations.</param>
        public ConsumerOperations(IOperationList operations)
        {
            foreach (var httpOperation in operations)
            {
                switch (httpOperation.Rel.Value)
                {
                    case ConsumerResourceOperations.RedirectConsumerIdentification:
                        RedirectConsumerIdentification = httpOperation;
                        break;
                    case ConsumerResourceOperations.ViewConsumerIdentification:
                        ViewConsumerIdentification = httpOperation;
                        break;
                }
                Add(httpOperation.Rel, httpOperation);
            }
        }

        /// <summary>
        /// Constructs a <see cref="ConsumerOperations"/> using data from <seealso cref="SerializationInfo"/>.
        /// </summary>
        /// <param name="info">A <seealso cref="SerializationInfo"/> containging the needed operations.</param>
        protected ConsumerOperations(SerializationInfo info)
            : base()
        {
            RedirectConsumerIdentification = (HttpOperation)info.GetValue(nameof(RedirectConsumerIdentification), typeof(HttpOperation));
            ViewConsumerIdentification = (HttpOperation)info.GetValue(nameof(ViewConsumerIdentification), typeof(HttpOperation));
        }

        /// <summary>
        /// The <seealso cref="HttpOperation"/> for redirecting the consumer to the
        /// identification page
        /// </summary>
        public HttpOperation RedirectConsumerIdentification { get; }

        /// <summary>
        /// The <seealso cref="HttpOperation"/> for viewing/opening
        /// the identifiaction frame
        /// </summary>
        public HttpOperation ViewConsumerIdentification { get; }
    }
}