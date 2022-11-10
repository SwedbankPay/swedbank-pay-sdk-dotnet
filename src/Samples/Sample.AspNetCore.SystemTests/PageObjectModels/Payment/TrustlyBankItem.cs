using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment;

[ControlDefinition(ContainingClass = "core_method", ComponentTypeName = "Trustly Bank Item")]
public class TrustlyBankItem<TOwner> : Control<TOwner> where TOwner : PageObject<TOwner>
{

}
