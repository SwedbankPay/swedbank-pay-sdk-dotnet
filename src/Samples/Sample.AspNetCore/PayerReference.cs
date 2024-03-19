using System;

namespace Sample.AspNetCore;

public class PayerReference
{
    public PayerReference()
    {
        Id = Guid.NewGuid().ToString().Replace("-", "");
    }
    
    public string Id { get; }
    
}