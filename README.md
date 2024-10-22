
# BraintreeClient

BraintreeClient is a .NET library that integrates with Braintree's payment gateway, providing support for setting up customer payments, managing payment methods, and handling transactions. It leverages the official Braintree .NET SDK and includes support for AutoMapper profiles to map models between the Braintree SDK and your application's domain.

## Table of Contents

1. [Introduction](#introduction)
2. [Features](#features)
3. [Tech Stack](#tech-stack)
4. [Usage](#usage)
5. [Configuration](#configuration)

## Introduction

BraintreeClient simplifies payment integration by providing dedicated clients for setting up customers and payment methods, as well as processing transactions. It supports both sandbox and production environments, with built-in configuration options to manage API credentials securely.

## Features

- **Payment Setup Clients:** Provides clients to handle customer creation, payment method setup, and management.
- **Transaction Clients:** Allows processing of transactions, including sales and refunds.
- **AutoMapper Support:** Integrates AutoMapper for mapping data between your application and Braintree's models.
- **Sandbox/Production Toggle:** Easily switch between Braintree's sandbox and production environments.

## Tech Stack

- **Backend:** .NET 8
- **Payment Gateway:** Braintree .NET SDK
- **Mapping:** AutoMapper
- **Dependency Injection:** Used for service registrations and configurations

## Usage

1. **Register the BraintreeClient:** Use the provided extension methods such as `AddBraintreeSetupPaymentClients` or `AddBraintreeTransactionClients` to register the necessary clients in the dependency injection container.
2. **Configure Authentication:** Use the `BraintreeClientOptions` class to set up authentication details such as `MerchantId`, `PublicKey`, and `PrivateKey`.
3. **Invoke Services:** Use the respective service clients (e.g., `ICustomerClient`, `ITransactionClient`) to interact with the Braintree API.

## Configuration

### BraintreeClientOptions

- **UseSandbox:** A boolean to specify whether to use Braintree's sandbox environment.
- **MerchantId:** The merchant ID for your Braintree account.
- **PublicKey:** The public key for Braintree API authentication.
- **PrivateKey:** The private key for Braintree API authentication.

```csharp
public class BraintreeClientOptions
{
    public bool UseSandbox { get; set; }
    public string MerchantId { get; set; }
    public string PublicKey { get; set; }
    public string PrivateKey { get; set; }
}
```

### Dependency Injection Example

Registering Braintree clients and configuring options in the `Startup.cs` or `Program.cs`:

```csharp
services.AddBraintreeSetupPaymentClients(options =>
{
    options.UseSandbox = true;
    options.MerchantId = "your-merchant-id";
    options.PublicKey = "your-public-key";
    options.PrivateKey = "your-private-key";
});

services.AddBraintreeTransactionClients(options =>
{
    options.UseSandbox = true;
    options.MerchantId = "your-merchant-id";
    options.PublicKey = "your-public-key";
    options.PrivateKey = "your-private-key";
});
```
