using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace SwedbankPay.Client.Models.Common
{
    public class OrderItems : IdLink
    {
        public List<OrderItem> OrderItemList { get; set; }
    }
}