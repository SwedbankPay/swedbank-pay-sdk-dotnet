using SwedbankPay.Sdk.Common;

namespace Sample.AspNetCore.Models.ViewModels
{
    public class OrderViewModel
    {
        public IOperationList OperationList { get; set; }

        public Order Order { get; set; }
    }
}