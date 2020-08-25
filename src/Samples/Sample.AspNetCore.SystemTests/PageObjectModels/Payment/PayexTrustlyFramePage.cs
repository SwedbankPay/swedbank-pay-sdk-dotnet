using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment
{
    using _ = PayexTrustlyFramePage;

    public class PayexTrustlyFramePage : Page<_>
    {
        [FindById("first-name-input")]
        public TextInput<_> FirstName { get; private set; }

        [FindById("last-name-input")]
        public TextInput<_> LastName { get; private set; }

        [FindById("px-submit")]
        public Button<_> Next { get; private set; }
    }
}