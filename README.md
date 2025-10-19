# SauceDemo Playwright Test Automation Framework

[![Playwright](https://img.shields.io/badge/Playwright-1.48-green)](https://playwright.dev/)
[![.NET](https://img.shields.io/badge/.NET-10.0-blue)](https://dotnet.microsoft.com/)
[![Tests](https://img.shields.io/badge/tests-6%2F6%20passing-brightgreen)](https://github.com/pothugantivijay/SauceDemo-Playwright-NUnit)

## 🎯 Overview

A modern **async test automation framework** built with **Microsoft Playwright**, **NUnit**, and **C#** to test the SauceDemo e-commerce application. This framework demonstrates modern async/await patterns, Playwright's auto-waiting capabilities, and comprehensive HTML reporting with ExtentReports.

**Live Application:** [https://www.saucedemo.com](https://www.saucedemo.com)

## 🚀 Technologies & Tools

- **Language:** C# (.NET 10.0)
- **Test Framework:** NUnit 3.14
- **Automation Tool:** Microsoft Playwright 1.48
- **Design Pattern:** Page Object Model (POM)
- **Reporting:** ExtentReports 5.0 with automatic screenshots
- **Async/Await:** Full asynchronous test execution
- **Browsers:** Chromium, Firefox, WebKit

## 📁 Project Structure
```
PlaywrightTests/
├── Pages/                   # Page Object Model classes
│   ├── LoginPage.cs
│   ├── ProductsPage.cs
│   └── CartPage.cs
├── Tests/                   # Test classes
│   ├── LoginTests.cs
│   └── ShoppingCartTests.cs
├── Support/                 # Base test class and utilities
│   └── TestBase.cs
├── Utilities/               # ExtentReports manager
│   └── ExtentManager.cs
└── Reports/                 # Generated test reports
    ├── PlaywrightTestReport.html
    └── Screenshots/
```

## ⚙️ Prerequisites

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Playwright Browsers](https://playwright.dev/dotnet/docs/browsers) (installed automatically)
- IDE: [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

## 🔧 Setup Instructions

### 1. Clone the Repository
```bash
git clone https://github.com/pothugantivijay/SauceDemo-Playwright-NUnit.git
cd SauceDemo-Playwright-NUnit
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Install Playwright Browsers
```bash
# Build the project first
dotnet build

# Install browsers (Chromium, Firefox, WebKit)
playwright install
```

### 4. Run Tests
```bash
# Run all tests
dotnet test

# Run with detailed output
dotnet test --logger "console;verbosity=detailed"

# Run by category
dotnet test --filter "TestCategory=Smoke"
dotnet test --filter "TestCategory=Cart"
```

## 🎭 Test Scenarios Covered

### Login Tests (3 scenarios)
- ✅ Successful login with valid credentials
- ✅ Failed login with invalid credentials  
- ✅ Failed login with locked out user

### Shopping Cart Tests (3 scenarios)
- ✅ Add single item to cart
- ✅ Add multiple items to cart
- ✅ Verify cart contains added items

**Test Results: 6/6 Passing (100%)** ✅

## 🏷️ Running Tests by Category
```bash
# Smoke tests
dotnet test --filter "TestCategory=Smoke"

# Cart tests
dotnet test --filter "TestCategory=Cart"

# Negative tests
dotnet test --filter "TestCategory=Negative"
```

## 📊 Test Reports

After test execution, comprehensive HTML reports are auto-generated with ExtentReports.

**Report Location:** `bin/Debug/net10.0/Reports/PlaywrightTestReport.html`

### Report Features:
- 📊 Interactive dashboard with pass/fail statistics
- 📈 Pie charts showing test distribution
- ✅ Detailed step-by-step execution logs
- 📷 Automatic screenshots on test failures
- 🏷️ Test categorization (Smoke, Cart, Negative)
- ⏱️ Individual test execution times
- 🖥️ System and environment information

### Sample Test Results:
```
✅ Test Summary: 6/6 Passing (100%)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
📋 Login Tests:          3/3 passed
🛒 Shopping Cart Tests:  3/3 passed
⏱️  Total Time:          ~39 seconds
🌐 Browser:              Chromium
```

## 🎨 Key Features

### ✨ Framework Highlights

- **Modern Async/Await:** Full asynchronous test execution using C# async patterns
- **Playwright Auto-Waiting:** Built-in smart waits for elements (no explicit waits needed)
- **Page Object Model:** Clean separation of test logic and page interactions
- **ExtentReports Integration:** Beautiful HTML reports with screenshots
- **Multi-Browser Support:** Run tests on Chromium, Firefox, or WebKit
- **Category-based Execution:** Organize and run tests by categories
- **Automatic Screenshots:** Captured on failures and embedded in reports
- **Detailed Logging:** Step-by-step test execution logs

### 🔍 Playwright Advantages Over Selenium

1. **Auto-Waiting:** No need for explicit waits - Playwright waits automatically
2. **Faster Execution:** Direct browser control via CDP
3. **Better Reliability:** Built-in retry mechanisms
4. **Modern API:** Clean async/await patterns
5. **Multi-Browser:** Single API for Chromium, Firefox, and WebKit
6. **Network Interception:** Built-in request/response mocking

## 🛠️ Browser Configuration

The framework uses Playwright's PageTest base class for automatic browser management:
```csharp
public class TestBase : PageTest
{
    // Automatic browser lifecycle management
    // Page object available via this.Page
}
```

To run in **headless mode**, modify browser launch options in `TestBase.cs` if needed.

## 📝 Sample Test Code
```csharp
[Test]
[Category("Smoke")]
public async Task SuccessfulLogin_WithValidCredentials()
{
    Test?.Info("Navigating to SauceDemo login page");
    var loginPage = new LoginPage(Page);
    await loginPage.NavigateAsync();

    Test?.Info("Logging in with valid credentials");
    await loginPage.LoginAsync("standard_user", "secret_sauce");

    Test?.Info("Verifying products page is displayed");
    var productsPage = new ProductsPage(Page);
    Assert.That(await productsPage.IsDisplayedAsync(), Is.True);
}
```

## 🐛 Troubleshooting

### Playwright Browsers Not Installed
```bash
# Install browsers
playwright install

# Or install specific browser
playwright install chromium
```

### Tests Timing Out

Playwright has generous timeouts by default. If needed, adjust in `TestBase.cs`:
```csharp
public override BrowserNewContextOptions ContextOptions => new()
{
    ViewportSize = ViewportSize.NoViewport,
    Timeout = 30000  // 30 seconds
};
```

## 📚 Learning Resources

- [Playwright Documentation](https://playwright.dev/dotnet/)
- [Playwright Best Practices](https://playwright.dev/dotnet/docs/best-practices)
- [NUnit Documentation](https://docs.nunit.org/)
- [Async/Await in C#](https://docs.microsoft.com/en-us/dotnet/csharp/async)

## 👨‍💻 Author

**Vijay**
- 🎓 MS Information Systems @ Northeastern University (May 2025)
- 💼 Software Engineering Trainee @ Wipro
- 🔧 Skills: C#, Java, Playwright, Selenium, Python, Spring Boot
- 🔗 [LinkedIn](https://linkedin.com/in/vijayramaraopothuganti)
- 📧 Email: vijaypothuganti1@gmail.com

## 🤝 Related Projects

- [SauceDemo Selenium + SpecFlow Framework](https://github.com/pothugantivijay/Saucedemo-Selenium-SpecFlow) - BDD approach with Gherkin

## 📝 License

This project is created for educational and portfolio purposes.

---

⭐ **If you found this helpful, please give it a star!**

## 🎯 Why This Framework?

This framework demonstrates:
- ✅ Modern async/await patterns in C#
- ✅ Playwright's powerful auto-waiting capabilities
- ✅ Clean Page Object Model implementation
- ✅ Professional reporting with screenshots
- ✅ Industry-standard test organization
- ✅ Production-ready code quality
```
