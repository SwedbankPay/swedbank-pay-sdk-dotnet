using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.PaymentInstruments;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Consumers
{
    public class ConsumersResponseDto
    {
        public OperationListDto Operations { get; set; }

        public string Token { get; set; }
    }
}