using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = IdentificationFramePage;

    public class IdentificationFramePage : Page<_>
    {
        [FindById("email")] public EmailInput<_> Email { get; private set; }

        [FindById("px-submit")] public Button<_> Next { get; private set; }

        [FindById("msisdn")] public TelInput<_> PhoneNumber { get; private set; }
    }
}