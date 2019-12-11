using SwedbankPay.Sdk;

namespace Sample.AspNetCore.Models.ViewModels
{
    public class OrderViewModel
    {
        public OperationList OperationList { get; set; }

        public Order Order { get; set; }
    }
}