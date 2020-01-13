using System;

namespace Sample.AspNetCore.Models
{
    public class PayeeInfoConfig
    {
        public Guid PayeeId { get; set; }

        public string PayeeReference { get; set; }
    }
}