## Build status

| Build server | Platform | Status                                    |
| ------------ | -------- | ----------------------------------------- |
| Azure DevOps | Windows  | [![Build Status][azdo-badge]][azdo-build] |

## About

`SwedbankPay.Sdk` is a `netstandard2` library that allows you to interact with Swedbank Pay's API Platform in a statically typed client.

## Supported APIs

* **Payment Order**
  * create payment order
  * get payment order
  * capture
  * cancel
  * reversal
  * abort
* **Swish Payments**
  * create swish payment
  * get swish payment
  * abort
  * reversal
* **Card Payments**
  * create card payment
  * get card payment
  * capture
  * cancel
  * reversal

# Sample apps

Check the [the samples folder][samples].

## Getting started

Install the `SwedbankPay.Sdk` NuGet in your project:

```
dotnet add package SwedbankPay.Sdk
```

Configure the SDK in one line.

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


  [azdo-badge]: https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_apis/build/status/swedbank-pay-sdk-dotnet-CI?branchName=master
  [azdo-build]: https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_build/latest?definitionId=1&branchName=master
  [samples]: https://github.com/SwedbankPay/swedbank-pay-sdk-dotnet/tree/master/src/Samples
