using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Consumers
{
    internal class ConsumersRequestDto
    {
        public ConsumersRequestDto()
        {
        }

        public ConsumersRequestDto(ConsumersRequest consumersRequest)
        {
            if(consumersRequest == null)
            {
                return;
            }

            if (consumersRequest.NationalIdentifier != null)
            {
                NationalIdentifier = new NationalIdentifierDto(consumersRequest.NationalIdentifier);
            }

            Email = consumersRequest.Email?.ToString();
            Language = consumersRequest.Language?.ToString();
            Msisdn = consumersRequest.Msisdn?.ToString();
            Operation = consumersRequest.Operation.Value;
            ShippingAddressRestrictedToCountryCodes = new List<string>();
            foreach (var item in consumersRequest.ShippingAddressRestrictedToCountryCodes)
            {
                ShippingAddressRestrictedToCountryCodes.Add(item.Name);
            }
        }

        public string Email { get; set; }

        public string Language { get; set; }

        public string Msisdn { get; }

        public NationalIdentifierDto NationalIdentifier { get; set; }

        public string Operation { get; }

        public List<string> ShippingAddressRestrictedToCountryCodes { get; set; }
    }
}