using SwedbankPay.Client.Models.Request;
using SwedbankPay.Client.Models.Response;
using System.Threading.Tasks;

namespace SwedbankPay.Client.Resources
{
    public interface IConsumerResource
    {
        Task<ConsumerResourceResponseContainer> InitiateSession(ConsumerResourceRequestContainer consumerResourceRequest);

    }

   
}
