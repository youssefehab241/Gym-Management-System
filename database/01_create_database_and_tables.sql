CREATE DATABASE GymDB;
GO

USE GymDB;
GO

CREATE TABLE Employee (
    Employee_ID INT IDENTITY(1,1) PRIMARY KEY,
    F_Name VARCHAR(50) NOT NULL,
    L_Name VARCHAR(50) NOT NULL,
    Job_Title VARCHAR(50),
    Salary DECIMAL(10,2),
    Password VARCHAR(50) NOT NULL DEFAULT '1234'
);

CREATE TABLE Trainer (
    Trainer_ID INT IDENTITY(1,1) PRIMARY KEY,
    F_Name VARCHAR(50) NOT NULL,
    L_Name VARCHAR(50) NOT NULL,
    Salary DECIMAL(10,2),
    Experience INT,
    Start_Date DATE
);

CREATE TABLE Member (
    Member_ID INT IDENTITY(1,1) PRIMARY KEY,
    F_Name VARCHAR(50) NOT NULL,
    L_Name VARCHAR(50) NOT NULL,
    Age INT,
    Join_Date DATE,
    Trainer_ID INT,
    Session_Time VARCHAR(50),
    Goal VARCHAR(100),
    FOREIGN KEY (Trainer_ID) REFERENCES Trainer(Trainer_ID)
);

CREATE TABLE Subscription (
    Subscription_ID INT IDENTITY(1,1) PRIMARY KEY,
    Cost DECIMAL(10,2),
    Start_Date DATE,
    End_Date DATE,
    Employee_ID INT NULL,
    Member_ID INT NULL,
    FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID),
    FOREIGN KEY (Member_ID) REFERENCES Member(Member_ID)
);

CREATE TABLE Member_Phones (
    Member_ID INT,
    Phone_Number VARCHAR(20),
    PRIMARY KEY (Member_ID, Phone_Number),
    FOREIGN KEY (Member_ID) REFERENCES Member(Member_ID)
);

CREATE TABLE Sport (
    Sport_ID INT IDENTITY(1,1) PRIMARY KEY,
    Sport_Name VARCHAR(50) NOT NULL
);

CREATE TABLE Machine (
    Machine_ID INT IDENTITY(1,1) PRIMARY KEY,
    Machine_Name VARCHAR(50) NOT NULL,
    Usage VARCHAR(100),
    Purchase_Date DATE,
    Employee_ID INT,
    FOREIGN KEY (Employee_ID) REFERENCES Employee(Employee_ID)
);

CREATE TABLE Maintenance (
    Machine_ID INT,
    Start_Date DATE,
    End_Date DATE,
    Cost DECIMAL(10,2),
    PRIMARY KEY (Machine_ID, Start_Date, End_Date),
    FOREIGN KEY (Machine_ID) REFERENCES Machine(Machine_ID)
);

CREATE TABLE Practices (
    Member_ID INT,
    Sport_ID INT,
    Skill_Level VARCHAR(50),
    PRIMARY KEY (Member_ID, Sport_ID),
    FOREIGN KEY (Member_ID) REFERENCES Member(Member_ID),
    FOREIGN KEY (Sport_ID) REFERENCES Sport(Sport_ID)
);

CREATE TABLE Trains (
    Trainer_ID INT,
    Sport_ID INT,
    PRIMARY KEY (Trainer_ID, Sport_ID),
    FOREIGN KEY (Trainer_ID) REFERENCES Trainer(Trainer_ID),
    FOREIGN KEY (Sport_ID) REFERENCES Sport(Sport_ID)
);

CREATE TABLE Requires (
    Machine_ID INT,
    Sport_ID INT,
    Priority_Level VARCHAR(50),
    PRIMARY KEY (Machine_ID, Sport_ID),
    FOREIGN KEY (Machine_ID) REFERENCES Machine(Machine_ID),
    FOREIGN KEY (Sport_ID) REFERENCES Sport(Sport_ID)
);
GO
