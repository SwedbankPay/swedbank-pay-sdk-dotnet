using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrder;

namespace Sample.AspNetCore.Models.ViewModels;

public class TokenViewModel
{
    public string Id { get;set; }
    public string PayerReference { get;set; }

    public IUserTokenOperations OperationList { get; set; }

    public List<IUserToken> Tokens { get; set; }
}