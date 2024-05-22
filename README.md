# Swedbank Pay SDK for .NET

![Swedbank Pay SDK for .NET][opengraph-image]

[![Latest stable NuGet package][nuget-stable-badge]][nuget]
[![Latest prerelease NuGet package][nuget-pre-badge]][nuget]
[![NuGet downloads][nuget-downloads-badge]][nuget]
[![CLA assistant][cla-badge]][cla]
[![License][license-badge]][license]
[![Contributor Covenant][coc-badge]][coc]

[`SwedbankPay.Sdk`][nuget] is a library that allows you to interact with
[Swedbank Pay's API Platform][dev-portal] in a statically typed client targeting
[.NET Standard 2.0][netstandard]. For information about which runtimes (.NET
Framework, .NET Core, Mono, Xamarin, etc.) support .NET Standard 2.0, [see
Microsoft's documentation][netstandard-impl].

## About

**UNSUPPORTED**: This SDK is at an early stage of development and is not
supported as of yet by Swedbank Pay. It is provided as a convenience to speed
up your development, so please feel free to play around. However, if you need
support, please wait for a future, stable release.

## Supported APIs Version 3.1

- **Payment Order**
  - Create PaymentOrder
  - GET PaymentOrder
  - UpdateOrder
  - Capture
  - Cancel
  - Reversal
  - Abort
- **Tokens**
  - Network Tokenization
  - Get stored details
  - Delete stored details

## Use Cases

  - Subscriptions
  - Verify
    - Collect and store payment details for future usage.
    - Collect and replace current payment details (Subscriptions)
  - Instrument Mode (Build your own menu)
  - Customise payment selection & favorite method
    
## Sample App

Check the [the samples folder][samples].
To run the sample site. Make sure to add your PayeeId and ApiBaseUrl from SwedbankPay in appsettings.json

You will also need to add the token from SwedbankPay in secrets.json by running the following command in the project root folder.
`dotnet user-secrets set "Token" "{Your token}" --project src/Samples/Sample.AspNetCore`

## Getting started

Install the [`SwedbankPay.Sdk` NuGet][nuget] in your project:

```shell
dotnet add package SwedbankPay.Sdk
```

To configure the SDK in one line using `Microsoft.Extensions.DependencyInjection`,
you need to install `SwedbankPay.Sdk.Extensions`. The SDK can then be configured
as such:
(This requires that you have added `SwedbankPay.Sdk.Extensions`)

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddSwedbankPayClient(ApiUrl, AuthenticationToken);
    ...
}
```

This will add the `ISwedbankPayClient` to the system, as well as interfaces for
all api's in case you want to have more control over what is injected.
See the [samples][samples] for inspiration and usage.
Using this to configure the `SwedbankPay.Sdk` will set up a
`LoggingDelegatingHandler` that aids in logging error responses from the api.

## Contributing

Bug reports and pull requests are welcome on [GitHub][github]. This project is
intended to be a safe, welcoming space for collaboration, and contributors are
expected to adhere to the [code of conduct][coc] and sign the
[contributor's license agreement][cla].

## License

The code within this repository is available as open source under the terms of
the [Apache 2.0 License][license] and the [contributor's license
agreement][cla].

  [azdo-mac-badge]:         https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_apis/build/status/sdk-dotnet-macOS-Dev-CI?branchName=develop
  [azdo-mac-link]:          https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_build/latest?definitionId=5&branchName=develop
  [azdo-ubuntu-badge]:      https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_apis/build/status/sdk-dotnet-ubuntu-Dev-CI?branchName=develop
  [azdo-ubuntu-link]:       https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_build/latest?definitionId=3&branchName=develop
  [azdo-win-badge]:         https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_apis/build/status/sdk-dotnet-Dev-CI?branchName=develop
  [azdo-win-link]:          https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_build/latest?definitionId=1&branchName=develop
  [cla-badge]:              https://cla-assistant.io/readme/badge/SwedbankPay/swedbank-pay-sdk-dotnet
  [cla]:                    https://cla-assistant.io/SwedbankPay/swedbank-pay-sdk-dotnet
  [coc-badge]:              https://img.shields.io/badge/Contributor%20Covenant-v2.0%20adopted-ff69b4.svg
  [coc]:                    ./CODE_OF_CONDUCT.md
  [dependabot-badge]:       https://api.dependabot.com/badges/status?host=github&repo=SwedbankPay/swedbank-pay-sdk-dotnet
  [dependabot]:             https://dependabot.com
  [dev-portal]:             https://developer.swedbankpay.com/
  [github]:                 https://github.com/SwedbankPay/swedbank-pay-sdk-dotnet
  [license-badge]:          https://img.shields.io/github/license/SwedbankPay/swedbank-pay-sdk-dotnet
  [license]:                https://opensource.org/licenses/Apache-2.0
  [netstandard-impl]:       https://docs.microsoft.com/en-us/dotnet/standard/net-standard#net-implementation-support
  [netstandard]:            https://docs.microsoft.com/en-us/dotnet/standard/net-standard
  [nuget-downloads-badge]:  https://img.shields.io/nuget/dt/SwedbankPay.Sdk
  [nuget-pre-badge]:        https://img.shields.io/nuget/vpre/SwedbankPay.Sdk
  [nuget-stable-badge]:     https://img.shields.io/nuget/v/SwedbankPay.Sdk
  [nuget]:                  https://www.nuget.org/packages/SwedbankPay.Sdk
  [opengraph-image]:        https://repository-images.githubusercontent.com/211096861/84938580-53e8-11ea-8062-53a4f9ad981c
  [samples]:                https://github.com/SwedbankPay/swedbank-pay-sdk-dotnet/tree/master/src/Samples
