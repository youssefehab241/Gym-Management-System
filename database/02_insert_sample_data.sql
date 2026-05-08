USE GymDB;
GO

-- IDs removed, column names explicitly listed
INSERT INTO Employee (F_Name, L_Name, Job_Title, Salary) VALUES
('Ahmed', 'Hassan', 'Receptionist', 6000),
('Mariam', 'Ali', 'Manager', 9000),
('Omar', 'Samy', 'Maintenance Staff', 5500);

INSERT INTO Trainer (F_Name, L_Name, Salary, Experience, Start_Date) VALUES
('Khaled', 'Mahmoud', 10000, 6, '2020-01-10'),
('Sara', 'Nabil', 9500, 5, '2021-03-15'),
('Youssef', 'Adel', 8500, 3, '2022-07-01');

INSERT INTO Sport (Sport_Name) VALUES
('Bodybuilding'),
('Cardio'),
('Boxing');

INSERT INTO Member (F_Name, L_Name, Age, Join_Date, Trainer_ID, Session_Time, Goal) VALUES
('Ali', 'Mostafa', 22, '2025-01-01', 1, '10:00 AM', 'Build muscle'),
('Nada', 'Hany', 24, '2025-01-05', 2, '6:00 PM', 'Lose weight'),
('Mina', 'George', 21, '2025-02-01', 3, '8:00 PM', 'Improve fitness');

INSERT INTO Subscription (Cost, Start_Date, End_Date, Employee_ID, Member_ID) VALUES
(500, '2025-01-01', '2025-02-01', 1, 1),
(1200, '2025-01-05', '2025-04-05', 2, 2),
(2200, '2025-02-01', '2025-08-01', 1, 3);

-- Linking tables (No IDENTITY, so we keep the IDs, but add column names for safety)
INSERT INTO Member_Phones (Member_ID, Phone_Number) VALUES
(1, '01011111111'),
(2, '01022222222'),
(3, '01033333333');

INSERT INTO Machine (Machine_Name, Usage, Purchase_Date, Employee_ID) VALUES
('Treadmill', 'Running and cardio', '2023-01-10', 3),
('Bench Press', 'Chest training', '2022-05-20', 3),
('Leg Press', 'Leg training', '2021-09-15', 2);

INSERT INTO Maintenance (Machine_ID, Start_Date, End_Date, Cost) VALUES
(1, '2025-01-10', '2025-01-11', 300),
(2, '2025-01-15', '2025-01-16', 450),
(3, '2025-02-01', '2025-02-02', 500);

INSERT INTO Practices (Member_ID, Sport_ID, Skill_Level) VALUES
(1, 1, 'Intermediate'),
(2, 2, 'Beginner'),
(3, 3, 'Advanced');

INSERT INTO Trains (Trainer_ID, Sport_ID) VALUES
(1, 1),
(2, 2),
(3, 3);

INSERT INTO Requires (Machine_ID, Sport_ID, Priority_Level) VALUES
(1, 2, 'High'),
(2, 1, 'Medium'),
(3, 1, 'High');
GO