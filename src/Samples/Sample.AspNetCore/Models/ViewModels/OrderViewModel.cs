using SwedbankPay.Sdk;
using System.Collections;
using System.Collections.Generic;

namespace Sample.AspNetCore.Models.ViewModels
{
    public class OrderViewModel
    {
        public List<HttpOperation> OperationList { get; set; }

        public Order Order { get; set; }
    }
}