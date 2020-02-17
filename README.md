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
To run the sample site. Make sure to add your PayeeId and ApiBaseUrl from SwedbankPay in appsettings.json

You will also need to add the token from SwedbankPay in secrets.json by running the following command in the project root folder.  
`dotnet user-secrets set "Token" "{Your token}" --project src/Samples/Sample.AspNetCore`


  [azdo-badge]: https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_apis/build/status/swedbank-pay-sdk-dotnet-CI?branchName=master
  [azdo-build]: https://dev.azure.com/SwedbankPay/swedbank-pay-sdk-dotnet/_build/latest?definitionId=1&branchName=master
  [samples]: https://github.com/SwedbankPay/swedbank-pay-sdk-dotnet/tree/master/src/Samples
