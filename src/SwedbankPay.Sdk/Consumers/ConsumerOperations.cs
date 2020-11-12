using System.Runtime.Serialization;

namespace SwedbankPay.Sdk.Consumers
{
    public class ConsumerOperations : OperationsBase
    {
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


        protected ConsumerOperations(
            SerializationInfo info)
            : base()
        {
            RedirectConsumerIdentification = (HttpOperation)info.GetValue("RedirectConsumerIdentification", typeof(HttpOperation));
            ViewConsumerIdentification = (HttpOperation)info.GetValue("ViewConsumerIdentification", typeof(HttpOperation));
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