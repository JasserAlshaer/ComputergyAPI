# 🛒 Computergy E-Commerce API

Manage your computer store with a robust and scalable API.

![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![Code Coverage](https://img.shields.io/badge/coverage-ComingSoon-yellow)
![API Version](https://img.shields.io/badge/API%20Version-v1-informational)
![License](https://img.shields.io/badge/license-MIT-blue.svg)

---

## ✨ Overview

Welcome to the Computergy API project repository! This API serves as the backend for an E-Commerce platform specializing in computer-related resources for the Computergy store. It provides essential endpoints for managing core E-commerce functionalities, including:

*   📦 Products
*   📝 Orders
*   👤 Customers
*   🔢 Inventory (Implicitly managed through products and orders)
*   🛒 Shopping Carts
*   💰 Discounts
*   💳 Payments
*   ❤️ Wishlists
*   ⭐ Ratings

Designed with scalability, security, and ease of integration in mind, this API is built to power a seamless online shopping experience.

## 🚀 Features

*   **Product Catalog Management:** Add, update, delete, and retrieve product information.
*   **Order Processing:** Create, view, and manage customer orders.
*   **Customer Accounts:** Handle user registration, login, and profile management.
*   **Shopping Cart Functionality:** Manage items in a user's shopping cart.
*   **Discount Application:** Apply and manage various types of discounts.
*   **Payment Handling:** Integrate with payment gateways (implementation details dependent).
*   **Wishlist Management:** Allow users to save products for later.
*   **Product Ratings:** Enable customers to rate products.
*   **Authentication & Authorization:** Secure API endpoints.

## 🛠️ Technologies Used

*   **C#** ⚛️
*   **.NET Core / ASP.NET Core** 🚀
*   **Entity Framework Core** 💾 (For data access and migrations)
*   **Swagger / OpenAPI** ✨ (For API documentation and testing)
*   **RESTful API Design** 🌐
*   **Dependency Injection** 💉
*   **Layered Architecture**

## 🗺️ Codebase Map (Project Structure)

This project follows a structured approach to organize code logically. Here's a simplified overview of the key directories based on the Solution Explorer:

```
Computergy.API/
├── Models/               # 📁 Domain Entities / Data Models
│   ├── CartItem.cs       # Represents an item in a shopping cart
│   ├── Discount.cs       # Defines discount structures
│   ├── MainEntity.cs     # Base entity class (likely)
│   ├── Order.cs          # Represents a customer order
│   ├── PaymentCard.cs    # Payment card details (handle securely!)
│   ├── Person.cs         # Base class for users/customers (likely)
│   ├── Product.cs        # Represents a product in the catalog
│   ├── Rate.cs           # Product rating information
│   └── Wishlist.cs       # Represents a user's wishlist
├── Helpers/              # 🛠️ Utility Classes & Helper Functions
│   └── ...               # Generic helper classes
├── Interfaces/           # 🧩 Service Contracts (Abstractions)
│   ├── IAuthanication.cs # Authentication service interface (Likely IAuthentication.cs)
│   ├── ICart.cs          # Cart service interface
│   ├── IDiscount.cs      # Discount service interface
│   ├── IOrder.cs         # Order service interface
│   ├── IPayment.cs       # Payment service interface
│   ├── IProducts.cs      # Products service interface (Likely IProductService.cs)
│   └── IRate.cs          # Rating service interface
├── Migrations/           # 📊 Entity Framework Database Migrations
│   └── ...               # Database schema evolution scripts
├── Services/             # ⚙️ Business Logic Implementations
│   ├── AuthanicationService.cs # Authentication service implementation (Likely AuthenticationService.cs)
│   ├── CartService.cs    # Cart service implementation
│   ├── DiscountService.cs # Discount service implementation
│   ├── OrderService.cs   # Order service implementation
│   ├── PaymentService.cs # Payment service implementation
│   ├── ProductsService.cs # Products service implementation (Likely ProductService.cs)
│   └── RateService.cs    # Rating service implementation
├── Controllers/          # 🌐 API Endpoints (MVC/API Controllers - Implicit)
│   └── ...               # Controllers exposing API functionality
├── Data/                 # 💾 Database Context & Configuration (Implicit)
│   └── ...               # DbContext class, data seeding, etc.
└── ...                   # Other project files (Startup.cs, Program.cs, appsettings.json, etc.)
```
*Note: Some file names like `IAuthanication.cs`, `AuthanicationService.cs`, `IProducts.cs`, `ProductsService.cs` might contain typos in the original source and are listed as seen in the screenshot, but the likely intended names are Authentication and Product/Products Service.*

## 🚦 Getting Started

### Prerequisites

*   [.NET 6 SDK](https://dotnet.microsoft.com/download) or later
*   A database server (e.g., SQL Server, PostgreSQL, MySQL)
*   A code editor (e.g., Visual Studio, VS Code)

### Installation

1.  Clone the repository:
    ```bash
    git clone <repository-url>
    ```
2.  Navigate to the project directory:
    ```bash
    cd Computergy.API
    ```
3.  Restore dependencies:
    ```bash
    dotnet restore
    ```

## ⚙️ Configuration

Update the database connection string and other application settings in `appsettings.json` or `appsettings.{EnvironmentName}.json`.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your_Database_Connection_String_Here"
  },
  // Other settings like JWT configuration, external service keys, etc.
}
```
**Important:** Do not commit sensitive credentials to version control. Use environment variables or secret management tools.

## 💾 Database Setup

This project uses Entity Framework Core Migrations. To set up your database:

1.  Ensure your connection string in `appsettings.json` is correct.
2.  Apply the migrations to create the database schema:
    ```bash
    dotnet ef database update
    ```

## ▶️ Running the API

You can run the API from the project directory:

```bash
dotnet run
```

The API will typically start on `https://localhost:5001` and `http://localhost:5000` by default.

## 📚 API Documentation (Swagger)

Interactive API documentation is available via Swagger UI. Once the application is running, navigate to:

[https://localhost:5001/swagger](https://localhost:5001/swagger) (Adjust host and port if necessary)

This interface allows you to explore the available endpoints, understand request/response models, and test API calls directly from your browser.

## 🤝 Contributing

Contributions are welcome! Please follow the standard GitHub flow: fork the repository, create a feature branch, make your changes, and open a pull request.

## 📄 License

This project is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for details.

## 📬 Contact

If you have any questions or need support, please reach out to the Support Team:

*   **Email:** [support@computergy.com](mailto:support@computergy.com)
*   **Website:** [https://computergy.com/contact](https://computergy.com/contact)
*   **Terms of Service:** [https://Computergy.com/terms](https://Computergy.com/terms)
