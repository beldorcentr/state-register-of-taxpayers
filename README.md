StateRegisterOfTaxpayers
=

.NET client library for Ministry of Taxes and Duties of the Republic of Belarus UNP (Payer’s Account Number) service

## Installation

[![Bdc.StateRegisterOfTaxpayers](https://img.shields.io/nuget/v/Bdc.StateRegisterOfTaxpayers.svg)](https://www.nuget.org/packages/Bdc.StateRegisterOfTaxpayers/)

```cmd
Install-Package Bdc.StateRegisterOfTaxpayers
```

Require .NET Standard 2.0 (.NET Core 2.0+, .NET Framework 4.6.1+)

## Usage

```csharp
var stateRegisterOfTaxpayerService = new StateRegisterOfTaxpayerService();
var taxpayer = stateRegisterOfTaxpayerService.GetTaxpayer(190638734);
Console.WriteLine(taxpayer.Name);
```
