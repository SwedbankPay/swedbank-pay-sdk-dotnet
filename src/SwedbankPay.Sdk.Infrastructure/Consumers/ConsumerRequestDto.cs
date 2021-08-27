using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Consumers
{
    internal class ConsumerRequestDto
    {
        public ConsumerRequestDto()
        {
        }

        public ConsumerRequestDto(ConsumerRequest consumerRequest)
        {
            if(consumerRequest == null)
            {
                return;
            }

            if (consumerRequest.NationalIdentifier != null)
            {
                NationalIdentifier = new NationalIdentifierDto(consumerRequest.NationalIdentifier);
            }

            Email = consumerRequest.Email?.ToString();
            Language = consumerRequest.Language?.ToString();
            Msisdn = consumerRequest.Msisdn?.ToString();
            Operation = consumerRequest.Operation.Value;
            RequireShippingAddress = consumerRequest.RequireShippingAddress;
            ShippingAddressRestrictedToCountryCodes = new List<string>();
            foreach (var item in consumerRequest.ShippingAddressRestrictedToCountryCodes)
            {
                ShippingAddressRestrictedToCountryCodes.Add(item);
            }
        }

        public string Email { get; set; }

        public string Language { get; set; }

        public string Msisdn { get; }

        public NationalIdentifierDto NationalIdentifier { get; set; }

        public string Operation { get; }

        public List<string> ShippingAddressRestrictedToCountryCodes { get; set; }

        public bool RequireShippingAddress { get; set; }
    }
}