using SwedbankPay.Sdk.PaymentOrders;

using System.Collections.Generic;
using System.Text.Json;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public static class JsonSerialization
    {
        public static readonly JsonSerializerOptions Settings = new JsonSerializerOptions
        {
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }
}