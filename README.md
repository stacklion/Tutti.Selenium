# 🚀 Tutti Selenium Automation

Automate interactions with Tutti.ch using Selenium in C#!

## 🌟 Features

- 🔐 User Authentication
- 📝 Listing Management
- 👤 Account Operations

## 🚀 Quick Start

```csharp
using OpenQA.Selenium.Chrome;
using Tutti.Selenium;

// Create a WebDriver instance
var driver = new ChromeDriver();

// Initialize Tutti automation
var tutti = new Tutti(driver);

// Login
tutti.Auth.Login("email@example.com", "password");

// Create a listing
tutti.Account.Listings.CreateListing(
    category: "Electronics",
    subcategory: "Smartphones",
    type: "Offer",
    picturePaths: new[] { "path/to/image1.jpg", "path/to/image2.jpg" },
    zipCode: 8001,
    canton: "Zürich",
    price: 500,
    subject: "iPhone X for sale",
    description: "Excellent condition, barely used",
    isPrivateNumber: true,
    phoneNumber: "+41123456789",
    hidePhoneNumber: false
);

// Get active listings
var activeListings = tutti.Account.Listings.GetActiveListings();
foreach (var listing in activeListings)
{
    Console.WriteLine($"Title: {listing.Title}, Price: {listing.Price}");
}
```

## 📚 Main Components

- `Tutti`: Main entry point for the library
- `Auth`: Handles authentication
- `Account`: Manages account-related operations
- `Listings`: Handles listing creation and management

## 🔑 Key Classes

- `Tutti`: Initializes the automation and provides access to other components
- `Auth`: Provides methods for login, registration, and checking login status
- `Listings`: Offers methods to create listings and retrieve active listings
- `Listing`: Represents a single listing with properties like title, price, and description

## 📝 Note

Use responsibly and in accordance with Tutti.ch's terms of service! 🙏
