StateRegisterOfTaxpayers
=

.NET client library for Ministry of Taxes and Duties of the Republic of Belarus UNP (Payer’s Account Number) service

## Installation

*Warning!* nuget.org contains old version of package

[![Bdc.StateRegisterOfTaxpayers](https://img.shields.io/nuget/v/Bdc.StateRegisterOfTaxpayers.svg)](https://www.nuget.org/packages/Bdc.StateRegisterOfTaxpayers/)

```cmd
Install-Package Bdc.StateRegisterOfTaxpayers
```

Require .NET Standard 2.0 (.NET Core 2.0+, .NET Framework 4.6.1+)

## Usage

```csharp
var stateRegisterOfTaxpayerService = new StateRegisterOfTaxpayerService();
var taxpayer = await stateRegisterOfTaxpayerService.GetTaxpayerAsync("190638734");
Console.WriteLine(taxpayer.Name);
```

## Documentation

### StateRegisterOfTaxpayerService Class

#### Constructors

Name | Description
--- | ---
StateRegisterOfTaxpayerService() | Initialize with default api url (http://www.portal.nalog.gov.by/grp/getData?unp={unp})
StateRegisterOfTaxpayerService(string apiUrl) | Initialize with custom api url. "{unp}" - placehoolder for taxpayer UNP.

#### Methods

Name | Description
--- | ---
async Task&lt;Taxpayer&gt; GetTaxpayerAsync(string unp) | Return Taxpayer by unp. If taxpayer was not found, return null. Throw WebException in case of HTTP errors.

### Taxpayer Class

#### Properties

Name | Type | Description
--- | --- | ---
Unp | string |
Name | string |
FullNameWithAddress | string |
Address | string |
Status | string |
StatusCode | StatusCode |
CreateDate | DateTime? |
LiquidationDate | DateTime? | Null if organization is not liquidated
BasisForLiquidation | string | Empty string if organization is not liquidated
TaxAndDutiesMinistryInspectionCode | string |
TaxAndDutiesMinistryInspectionName | string |

### StatusCode Enum

Value |
--- |
Active |
ProcessOfLiquidationType1 |
ProcessOfLiquidationType2 |
Liquidated |
