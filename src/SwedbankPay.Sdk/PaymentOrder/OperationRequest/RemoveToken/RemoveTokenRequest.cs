using System.Text.RegularExpressions;

namespace SwedbankPay.Sdk.PaymentOrder.OperationRequest.RemoveToken;

public record RemoveTokenRequest
{
    public TokenState State { get; }
    public string Comment { get; }

    private static readonly Regex ValidAbortReasonRegex = new Regex(@"^[a-zA-Z0-9]+$");

    public RemoveTokenRequest(TokenState state, string comment)
    {
        ValidateCommentReason(comment);

        State = state;
        Comment = comment;
    }
    
    private void ValidateCommentReason(string comment)
    {
        if (!ValidAbortReasonRegex.IsMatch(comment))
        {
            throw new ArgumentException(@"Comment must match the regular expression '\w*'");
        }
    }
    
}