using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment;

using _ = TrustlyPaymentPage;

public class TrustlyPaymentPage : Page<_>
{
    public ControlList<TrustlyBankItem<_>, _> Banks { get; set; }

    [FindByName("loginid")]
    public TextInput<_> PersonalNumber { get; private set; }

    [FindByContent("Säkerhetskod")]
    public Clickable<_> SecurityCodeOption { get; private set; }

    [FindByContent("Mobilt BankID")]
    public Clickable<_> BankIdOption { get; private set; }

    [FindByName("challenge_response")]
    public PasswordInput<_> Code { get; private set; }

    [FindByClass("message_value")]
    public Text<_> MessageCode { get; private set; }

    [FindByClass("options")]
    public Control<_> AccountOptions { get; private set; }

    [WaitSeconds(1, TriggerEvents.BeforeClick)]
    [FindByClass("button_next")]
    public Link<_> Next { get; private set; }
}
