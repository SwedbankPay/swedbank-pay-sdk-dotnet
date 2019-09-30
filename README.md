## Build status

| Build server                | Platform     | Status                                            |
|-----------------------------|--------------|---------------------------------------------------|
| AppVeyor                    | Windows      | [![Build status][appveyor-badge]][appveyor-build] |
| Travis                      | Linux        | [![Build Status][travis-badge]][travis-build]     |
| Azure DevOps                | Linux        | [![Build Status][azdo-badge]][azdo-build]         |

## About

`PayEx.Client` is a `netstandard2` library to talk to PayEx direct REST APIs.

Download it from NuGet: [![NuGet][nuget-badge]][nuget-pkg]

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


  [appveyor-badge]: https://ci.appveyor.com/api/projects/status/jqpkvy5fe523hsja/branch/master?svg=true
  [appveyor-build]: https://ci.appveyor.com/project/ice/payex-client/branch/master
  [travis-badge]: https://travis-ci.org/icenorge/PayEx.Client.svg?branch=master
  [travis-build]: https://travis-ci.org/icenorge/PayEx.Client
  [azdo-badge]: https://dev.azure.com/icenorge/PayEx.Client/_apis/build/status/icenorge.PayEx.Client
  [azdo-build]: https://dev.azure.com/icenorge/PayEx.Client/_build/latest?definitionId=2
  [nuget-badge]: https://img.shields.io/nuget/dt/payex.client.svg
  [nuget-pkg]: https://www.nuget.org/packages/payex.client/