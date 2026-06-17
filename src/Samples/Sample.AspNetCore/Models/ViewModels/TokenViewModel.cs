using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrder;

namespace Sample.AspNetCore.Models.ViewModels;

public class TokenViewModel
{
    public string? Id { get;set; }
    public string? PayerReference { get;set; }

    public Cart Cart { get; set; } = null!;
    public IUserTokenOperations OperationList { get; set; } = null!;
    public List<IUserToken> Tokens { get; set; } = [];
    
}