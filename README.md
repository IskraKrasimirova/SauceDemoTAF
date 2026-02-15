# SauceDemo BDD Test Automation Framework  

This repository contains a **UI automation framework** built in C# using **Selenium WebDriver** and **Reqnroll**.  
The framework automates the public demo application **SauceDemo**: https://www.saucedemo.com/

---

# 🧪 System Under Test (SUT): SauceDemo

SauceDemo is a public web application designed specifically for UI automation training.  
It provides functionality for:

- User login  
- Product listing  
- Sorting  
- Shopping cart  
- Checkout flow  

The application is intentionally simple but covers all essential UI automation patterns.

---

# 🎯 Test Assignment Requirements 

This framework implements the following tasks – Web UI Automation Assignment**.

## Version 1 — Functional Scenarios

### **Scenario 1 — End-to-End Purchase Flow**
- Log in using the **standard user**  
  *(credentials must be obtained dynamically from the login page — they may change)*  
- Add the **first** and **last** product to the cart  
- Verify the correct items are added  
- Remove the **first** product  
- Add the **previous-to-last** product  
- Verify the cart content again  
- Proceed to checkout  
- Complete the order  
- Verify the order is placed  
- Verify the cart is empty  
- Log out  

### **Scenario 2 — Sorting Verification**
- Log in with the standard user  
- Select sorting option **“Price (high to low)”**  
- Verify that products are sorted correctly  
- Log out  

---

# Version 2 — Framework Enhancements

The framework additionally supports:

### ✔ Test Filtering  
Run tests by tags (e.g., `@smoke`, `@regression`, `@sorting`).

### ✔ Custom HTML Reporting  
Integrated HTML report for each test execution.

### ✔ Multi-Environment Support  
Configurable environments (dev, test, staging) via `appsettings.*.json`.

### ✔ Multi-Browser Support  
- Chrome  
- Firefox  

### ✔ Bonus Features  
Optional enhancements such as:
- Different browser resolutions  
- Additional logging  
- Screenshot capture on failure  

---

# 🏗️ Framework Architecture
/Features        -> Gherkin feature files
/Steps           -> Step definitions (BDD glue)
/Pages           -> Page Object Model (POM)
/Hooks           -> Test lifecycle hooks (DI, cleanup, screenshots)
/Models          -> Test data models & factories
/Utilities       -> WebDriver helpers, waits, retry logic, config


---

# 🛠️ Technology Stack

| Area | Technology |
|------|------------|
| Language | C# (.NET 8) |
| UI Automation | Selenium WebDriver |
| BDD | ReqNroll |
| DI | .NET Dependency Injection |
| Reporting | HTML report provider |
| Test Data | Bogus (random data generation) |
| Patterns | Page Object Model, Factory, Builder |

---

# 🚀 Running the Tests

### 1. Install dependencies  
Restore NuGet packages via Visual Studio or:
```
dotnet restore
```
### 2. Run tests with default browser  
```
dotnet test
```
### 3. Run tests with tags  
```
dotnet test --filter TestCategory=Smoke
```
### 4. Run tests with a specific browser 
```
set browser=firefox
dotnet test
```


---

# 🔐 Credentials Handling

SauceDemo credentials **must NOT be hardcoded**.

The framework dynamically extracts:

- **standard_user**
- **secret_sauce**

directly from the login page, as required by the assignment.

