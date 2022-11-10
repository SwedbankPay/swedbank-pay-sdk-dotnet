using Atata;

namespace Sample.AspNetCore.SystemTests.PageObjectModels.Payment;

using _ = IdentificationFramePage;

public class IdentificationFramePage : Page<_>
{
    [FindById("email")] public EmailInput<_> Email { get; private set; }

    [FindById("px-submit")] public Button<_> Next { get; private set; }

    [FindById("msisdn")] public TelInput<_> PhoneNumber { get; private set; }

    [FindById("ssn")] public TextInput<_> PersonalNumber { get; private set; }
    
    [FindByClass("px-button custom-button")] public Button<_> SaveMyInformation { get; private set; }

    [FindById("firstName")] public TextInput<_> FirstName { get; private set; }
    [FindById("lastName")] public TextInput<_> LastName { get; private set; }
    [FindById("streetAddress")] public TextInput<_> Address { get; private set; }
    [FindById("zipCode")] public TextInput<_> ZipCode { get; private set; }
    [FindById("city")] public TextInput<_> City { get; private set; }
}