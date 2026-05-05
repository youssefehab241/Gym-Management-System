# Gym Management System

A desktop database application for managing a gym system using C# Windows Forms, ADO.NET, and SQL Server.

## Features

- Manage gym members
- View members from SQL Server database
- Add new members using ADO.NET
- Navigate between multiple forms:
  - Members
  - Trainers
  - Subscriptions
  - Machines
  - Sports

## Technologies Used

- C#
- Windows Forms
- ADO.NET
- SQL Server
- SQL Server Management Studio

## Project Structure

```text
Gym-Management-System/
├── database/
│   ├── 01_create_database_and_tables.sql
│   ├── 02_insert_sample_data.sql
│   └── 03_test_queries.sql
│
└── src/
    └── GymManagementSystem/
    Database Setup

Run the SQL scripts in this order:

database/01_create_database_and_tables.sql
database/02_insert_sample_data.sql
database/03_test_queries.sql
Current Status

Completed:

Database schema
Sample data
Main navigation form
Members form
View members
Add member

In progress:

Update member
Delete member
CRUD operations for other forms