Turkey Geo Data Console Application
This console application is designed to import Turkey's province, district, and neighborhood data into a PostgreSQL database. It reads a JSON file containing geographical information and stores it in the database using Entity Framework Core.

Key Features
JSON Parsing: The application reads and deserializes a JSON file containing province, district, and neighborhood details.
Entity Framework Core: Utilizes Entity Framework Core for efficient database operations.
Batch Insert: Implements batch insert to optimize data insertion performance.
Exception Handling: Includes error handling for robust execution and to ensure proper logging of any failures during the data insertion process.
Modular Design: The code is structured in a modular way, separating JSON deserialization and database operations into different methods for clarity and maintainability.
Prerequisites
.NET Core SDK
PostgreSQL Database
Entity Framework Core
Getting Started
Clone the repository, configure the connection string for your PostgreSQL instance, and run the application to load the data.
