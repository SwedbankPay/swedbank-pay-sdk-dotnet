## Build status

| Build server                | Platform     | Status                                            |
|-----------------------------|--------------|---------------------------------------------------|
| AppVeyor                    | Windows      | [![Build status][appveyor-badge]][appveyor-build] |
| Travis                      | Linux        | [![Build Status][travis-badge]][travis-build]     |
| Azure DevOps                | Linux        | [![Build Status][azdo-badge]][azdo-build]         |

## About

`PayEx.Client` is a `netstandard2` library to talk to PayEx direct REST APIs.

## Supported APIs:

* Vipps 
  * create payment
  * Vipps authorize
  * capture
  * cancel
  * reversal
* CreditCard 
  * create payment
  * create recurring payment with initial payment
  * create recurring payment without initial payment
  * capture
  * cancel
  * reversal

# Sample apps
Check the [the samples folder](https://github.com/icenorge/PayEx.Client/tree/master/src/Samples)


  [appveyor-badge]: https://ci.appveyor.com/api/projects/status/l7mqg1ygmkwf9m9n/branch/master?svg=true
  [appveyor-build]: https://ci.appveyor.com/project/SwedbankPay/swedbank-pay-sdk-dotnet/branch/master
  [travis-badge]: https://travis-ci.org/SwedbankPay/swedbank-pay-sdk-dotnet.svg?branch=master
  [travis-build]: https://travis-ci.org/SwedbankPay/swedbank-pay-sdk-dotnet
  [azdo-badge]: https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_apis/build/status/swedbank-pay-sdk-dotnet-CI?branchName=master
  [azdo-build]: https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_build/latest?definitionId=1&branchName=master