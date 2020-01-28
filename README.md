## Build status

| Build server                | Platform     | Status                                            |
|-----------------------------|--------------|---------------------------------------------------|
| Azure DevOps                | Windows      | [![Build Status][azdo-badge]][azdo-build]         |

## About

`SwedbankPay.Sdk` is a `netstandard2` library to talk to SwedbankPay direct REST APIs.

## Supported APIs

* PaymentOrder
  * create payment order
  * get payment order
  * capture
  * cancel
  * reversal
  * abort
* Swish
  * create swish payment
  * get swish payment
  * abort
  * reversal
* CreditCard
  * create card payment
  * get card payment
  * capture
  * cancel
  * reversal

# Sample apps

Check the [the samples folder][samples].

  [azdo-badge]: https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_apis/build/status/swedbank-pay-sdk-dotnet-CI?branchName=master
  [azdo-build]: https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_build/latest?definitionId=1&branchName=master
  [samples]: https://github.com/SwedbankPay/swedbank-pay-sdk-dotnet/tree/master/src/Samples
