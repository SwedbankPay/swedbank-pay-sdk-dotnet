using System.Collections.Generic;
using SwedbankPay.Sdk;

namespace Sample.AspNetCore3.Models.ViewModels
{
    public class OrderViewModel
    {
      
        public Order Order { get; set; }
        public List<HttpOperation> Operations { get; set; }
    }
    
}