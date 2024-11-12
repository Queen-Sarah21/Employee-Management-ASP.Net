# Employee-Management ASP.NET-Web-Form
This Employee Management is an ASP.NET Web Forms application for managing employee records within a company. Developed in Visual Studio 2022 using C# and SQL Server, this application allows for CRUD operations and includes input validation to ensure data integrity.

## Features
**Add Employee**: Save new employee records to the database with essential details like Employee Number, First Name, Last Name, and Job Title.

**Search Employee**: Retrieve employee records based on Employee Number or Name.

**Update Employee**: Modify existing employee records, with confirmation prompts to prevent accidental changes.

**Delete Employee**: Remove employee records from the database, with confirmation.

**List All Employees**: Display all employees stored in the database.

## Technologies Used
- ASP.NET Web Forms: Used for building the user interface and handling form submissions.
- ADO.NET: Provides database connectivity and data manipulation with SQL Server.
- SQL Server: Database system used to store employee information.
- C#: Programming language for backend logic and database operations.

## Project Structure
- **DAL (Data Access Layer)**: Contains classes for database connection and CRUD operations (UtilityDB.cs, EmployeeDB.cs).
- **BLL (Business Logic Layer)**: Includes the Employee.cs class representing the employee entity.
- **GUI (Graphical User Interface)**: Contains Web Forms for interacting with the application, such as WebFormEmployee.aspx.
- Validation: Holds methods for input validation to enforce data accuracy (e.g., numeric and text-only fields).

## Data Validation Rules
- Employee Number: Must be a unique, 4-digit number.
- First and Last Name: Only letters are allowed, with an optional space for compound names.


## Installation and Setup
**Database Setup**:

- Create a new database in SQL Server named EmployeeDB.
- Execute the SQL scripts provided to create the Employees table and insert sample data.

**Configure Connection String**:
- Update the connection string in UtilityDB.cs to match your SQL Server instance.
- Also ensure to update the Web.config file with your SQL Server connection details.

**Run the Application**:
- Open the project in Visual Studio.
- Set WebFormEmployee.aspx as the start page and run the application to manage employee data.

## Usage
- Add and Manage Employees: Use the web form to add new employees, search by ID or name, update records, and delete them as needed.
- Database Connection Test: Verify the database connection using WebFormTest.aspx before performing operations.
