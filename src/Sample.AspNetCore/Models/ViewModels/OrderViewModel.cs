namespace Sample.AspNetCore.Models.ViewModels
{
    using System.Collections.Generic;
    using SwedbankPay.Sdk;

    public class OrderViewModel
    {
      
        public Order Order { get; set; }
        public Operations Operations { get; set; }
    }
    
}