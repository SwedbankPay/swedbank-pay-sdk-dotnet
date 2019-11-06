using System;

namespace Sample.AspNetCore.SystemTests.Services
{
    public static class TestDataService
    {
        public static string FirstName => "John";

        public static string AlternativeFirstName => "Jane";

        public static string LastName => "Doe";

        public static string AlternativeLastName => "Smith";

        public static string User => "admin";

        public static string Password => "Passw0rd!.";

        public static string Street => "Streetgatan 123";

        public static string ZipCode => "12345";

        public static string City => "Stockholm";

        public static string PhoneNumber => "0706050403";

        public static string SwedishPhoneNumber => "+46706050403";

        public static string PersonalNumber => "19800101-8921";

        public static string PersonalNumberShort => "800101-8921";

        public static string Email => "john@doe.com";

        public static string CompanyName => "Authority AB";

        public static string OrganizationNumber => "SE999999999901";

        public static string CreditCardNumber => "4581097655558174";

        public static string CreditCardCVC => "210";

        public static string CreditCardExpiratioDate => DateTime.Now.AddMonths(3).ToString("MMyy");

        public static string LoremIpsum => "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent convallis facilisis neque ut scelerisque. Morbi arcu purus, gravida sed velit nec, interdum egestas ante. Pellentesque dapibus nisl ultrices dolor placerat, eu lobortis mauris elementum. Curabitur placerat ante est. Fusce et massa est. Etiam quis lacus justo. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Phasellus nulla enim, ornare in facilisis quis, ornare nec erat. Nullam sit amet mi augue. Proin dignissim risus urna, sed pulvinar turpis sollicitudin quis. Proin pretium lacinia ullamcorper.";

        public static string Description(int length = 30) => LoremIpsum.Substring(0, length);
    }
}
