using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk;

internal class OperationList : List<HttpOperation>, IOperationList
{
    
}

public interface IOperationList : IList<HttpOperation>
{
    
}