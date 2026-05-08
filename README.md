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

The current default connection string in the project is:

```csharp
string connectionString =
    @"Data Source=X\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
```

This means the project is currently configured to connect to a SQL Server instance named:

```text
X\SQLEXPRESS
```

If your SQL Server instance has a different name, you must update the connection string before running the project.

For example, if your SQL Server in SSMS appears as:

```text
localhost
```

then change the connection string to:

```csharp
string connectionString =
    @"Data Source=localhost;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
```

If your SQL Server in SSMS appears as:

```text
DESKTOP-ABC\SQLEXPRESS
```

then change the connection string to:

```csharp
string connectionString =
    @"Data Source=DESKTOP-ABC\SQLEXPRESS;Initial Catalog=GymDB;Integrated Security=True;TrustServerCertificate=True";
```

You can find your SQL Server name at the top of **Object Explorer** in SSMS.

To update it in Visual Studio:

1. Press `Ctrl + Shift + F`.
2. Search for:

```text
Data Source
```

3. Replace the existing server name with your own SQL Server name.
4. Save all files.

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

Before starting new work, always pull the latest version:

```bash
git pull origin main
```

After making changes:

```bash
git add .
git commit -m "Describe your changes"
git push
```