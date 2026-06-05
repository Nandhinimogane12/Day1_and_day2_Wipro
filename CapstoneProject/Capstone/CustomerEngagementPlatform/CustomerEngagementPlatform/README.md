# Customer Engagement Platform

## Project Overview

Customer Engagement Platform is an ASP.NET Core MVC application developed to manage customers and service tickets efficiently. The application helps organizations track customer interactions, create support tickets, monitor ticket status, and improve service management.

---

## Technologies Used

* ASP.NET Core MVC (.NET 8)
* C#
* Entity Framework Core
* ADO.NET
* SQL Server
* Razor Views
* AJAX
* Swagger/OpenAPI
* JWT Authentication
* Role-Based Authorization
* xUnit Unit Testing
* Docker
* GitHub Actions CI/CD

---

## Features

### Customer Management

* Add Customer
* Edit Customer
* Delete Customer
* View Customer Details
* Customer Listing

### Ticket Management

* Create Ticket
* Edit Ticket
* Delete Ticket
* View Ticket Details
* Track Ticket Status

### Security

* JWT Authentication
* Role-Based Authorization
* Protected API Endpoints

### API Support

* RESTful APIs
* Swagger Documentation
* Customer API Endpoints

### Validation

* Server-side Validation
* Client-side Validation

### AJAX Integration

* AJAX Ticket Search

### Testing

* Unit Testing using xUnit
* Repository Testing

### Exception Handling

* Try-Catch implementation in Controllers
* User-friendly error handling

### AI Concept

* Ticket Summary Service
* AI Ticket Summary Endpoint (Conceptual)

### Cloud & DevOps

* Dockerfile for containerization
* GitHub Actions CI/CD workflow
* Azure App Service deployment concept

---

## Database

Database Name:

CustomerEngagementDB

Tables:

1. Customers
2. Tickets
3. Users

Database features implemented:

* Primary Keys
* Foreign Keys
* Joins
* Trigger
* Stored Procedures
* Entity Framework Core Migrations

---

## API Endpoints

### Authentication

POST

/api/Auth/login

### Customers

GET

/api/CustomerApi

POST

/api/CustomerApi

PUT

/api/CustomerApi/{id}

DELETE

/api/CustomerApi/{id}

---

## Running the Project

1. Open solution in Visual Studio 2022.
2. Configure SQL Server connection string in appsettings.json.
3. Run Entity Framework migrations.
4. Build the solution.
5. Run the application.
6. Open Swagger to test APIs.

---

## Project Architecture

Presentation Layer

* ASP.NET Core MVC
* Razor Views

Business Layer

* Controllers
* Services

Data Access Layer

* Repository Pattern
* EF Core
* ADO.NET

Database Layer

* SQL Server

---

## Developed By

Nandhini Mogane

Customer Engagement Platform – Capstone Project
