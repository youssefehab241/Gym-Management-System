# Gym Management System

A desktop database application for managing a gym system using **C# Windows Forms**, **ADO.NET**, and **SQL Server**.

## Overview

This project is a Windows desktop application connected to a SQL Server database.  
It allows gym employees to log in and manage different parts of the gym system through multiple forms.

The application uses **ADO.NET** to connect the C# Windows Forms interface with the SQL Server database.

---

## Features

- Employee login system
- Dashboard with basic database statistics
- Navigate between multiple management forms
- Manage gym members
- Manage trainers
- Manage subscriptions
- Manage machines
- Manage sports
- Manage employees
- View data from SQL Server database
- Add new records using ADO.NET
- Auto-increment IDs in the database

---

## Technologies Used

- C#
- Windows Forms
- ADO.NET
- SQL Server
- SQL Server Management Studio (SSMS)
- Visual Studio

---

## Project Structure

```text
Gym-Management-System/
├── database/
│   ├── 01_create_database_and_tables.sql
│   ├── 02_insert_sample_data.sql
│   └── 03_test_queries.sql
│
├── src/
│   └── GymManagementSystem/
│       └── GymManagementSystem.sln
│
├── README.md
└── .gitignore
```

---

## Requirements

Before running the project, make sure you have:

1. **Visual Studio Community 2022** or later
2. The Visual Studio workload:
   ```text
   .NET desktop development
   ```
3. **SQL Server**
4. **SQL Server Management Studio (SSMS)**

---

## Database Setup

Open **SQL Server Management Studio (SSMS)** and run the SQL files in this order:

1. `database/01_create_database_and_tables.sql`
2. `database/02_insert_sample_data.sql`
3. `database/03_test_queries.sql`

This will create a database named:

```text
GymDB
```

and insert sample data for testing.

---

## Important: SQL Server Connection String

The application connects to SQL Server using a connection string inside the C# forms.

In our local setup, the SQL Server name is:

```text
localhost
```

So the connection string looks like this:

```csharp
string connectionString =
    @"Data Source=localhost;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
```

If your SQL Server name is different, you must update the connection string.

For example, if your server name in SSMS is:

```text
DESKTOP-ABC\SQLEXPRESS
```

then change the connection string to:

```csharp
string connectionString =
    @"Data Source=DESKTOP-ABC\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
```

You can find your SQL Server name at the top of **Object Explorer** in SSMS.

Search in Visual Studio for:

```text
Data Source
```

and update all connection strings if needed.

---

## How to Run the Project

1. Clone the repository:

```bash
git clone https://github.com/youssefehab241/Gym-Management-System.git
```

2. Open the project folder.

3. Run the database scripts in SSMS:

```text
database/01_create_database_and_tables.sql
database/02_insert_sample_data.sql
database/03_test_queries.sql
```

4. Open the solution file in Visual Studio:

```text
src/GymManagementSystem/GymManagementSystem.sln
```

5. Make sure the connection string matches your SQL Server name.

6. Run the project from Visual Studio using:

```text
F5
```

or click:

```text
Start
```

---

## Login Credentials

Use one of the sample employees from the database.

Example:

```text
Employee ID: 1
Password: 1234
```

Other sample employees can be found by running:

```sql
USE GymDB;
GO

SELECT * FROM Employee;
```

---

## Current Project Status

Completed:

- Database schema
- Sample data
- SQL test queries
- Employee login form
- Main dashboard form
- Navigation between forms
- Members form
- Trainers form
- Subscriptions form
- Machines form
- Sports form
- Employees form
- ADO.NET connection to SQL Server
- View data from database
- Add data to database
- Auto-increment IDs in the database

In progress:

- Update operations
- Delete operations
- Full CRUD testing for all forms
- UI improvements
- Validation improvements

---

## Notes for Contributors

When working with Windows Forms, remember that each control has two important properties:

```text
Text = what the user sees on the screen
Name = what the code uses
```

For example:

```text
Text = Add Member
Name = btnAddMember
```

Do not randomly change control names unless you also update the related C# code.

---

## Git Workflow

After making changes:

```bash
git add .
git commit -m "Describe your changes"
git push
```

Before starting new work, always pull the latest version:

```bash
git pull origin main
```