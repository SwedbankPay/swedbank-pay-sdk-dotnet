using SwedbankPay.Sdk.PaymentOrder.Paid;

namespace SwedbankPay.Sdk.PaymentOrder;

public interface IUserToken
{
   bool? IsDeleted { get; init; }
   string? Token { get; init; }
   string? TokenType { get; init; }
   PaymentInstrument? Instrument { get; init; }
   string? InstrumentDisplayName { get; init; }
   string? CorrelationId { get; init; }
   IInstrumentParameters? InstrumentParameters { get; init; }
   IUserTokenOperations? Operations { get; set; }
}