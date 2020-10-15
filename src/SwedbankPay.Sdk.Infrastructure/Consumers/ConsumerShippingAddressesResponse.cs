using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.Models.Shared.Consumers;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Models.Responses.Consumers
{
    public class ConsumerShippingAddressesResponse
    {
        public IEnumerable<AddressOperationModel> Addresses { get; set; }

        public IEnumerable<Operation> Operations { get; set; }

        public IEnumerable<Action> Actions { get; set; }
    }

    public class AddressOperationModel
    {
        public string Addressee { get; set; }

        public string CoAddress { get; set; }

        public string StreetAddress { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public IEnumerable<Operation> Operations { get; set; }
    }
}
