USE GymDB;
GO

INSERT INTO Employee VALUES
(1, 'Ahmed', 'Hassan', 'Receptionist', 6000),
(2, 'Mariam', 'Ali', 'Manager', 9000),
(3, 'Omar', 'Samy', 'Maintenance Staff', 5500);

INSERT INTO Trainer VALUES
(1, 'Khaled', 'Mahmoud', 10000, 6, '2020-01-10'),
(2, 'Sara', 'Nabil', 9500, 5, '2021-03-15'),
(3, 'Youssef', 'Adel', 8500, 3, '2022-07-01');

INSERT INTO Sport VALUES
(1, 'Bodybuilding'),
(2, 'Cardio'),
(3, 'Boxing');

INSERT INTO Member VALUES
(1, 'Ali', 'Mostafa', 22, '2025-01-01', 1, '10:00 AM', 'Build muscle'),
(2, 'Nada', 'Hany', 24, '2025-01-05', 2, '6:00 PM', 'Lose weight'),
(3, 'Mina', 'George', 21, '2025-02-01', 3, '8:00 PM', 'Improve fitness');

INSERT INTO Subscription VALUES
(1, 500, '2025-01-01', '2025-02-01', 1, 1),
(2, 1200, '2025-01-05', '2025-04-05', 2, 2),
(3, 2200, '2025-02-01', '2025-08-01', 1, 3);

INSERT INTO Member_Phones VALUES
(1, '01011111111'),
(2, '01022222222'),
(3, '01033333333');

INSERT INTO Machine VALUES
(1, 'Treadmill', 'Running and cardio', '2023-01-10', 3),
(2, 'Bench Press', 'Chest training', '2022-05-20', 3),
(3, 'Leg Press', 'Leg training', '2021-09-15', 2);

INSERT INTO Maintenance VALUES
(1, '2025-01-10', '2025-01-11', 300),
(2, '2025-01-15', '2025-01-16', 450),
(3, '2025-02-01', '2025-02-02', 500);

INSERT INTO Practices VALUES
(1, 1, 'Intermediate'),
(2, 2, 'Beginner'),
(3, 3, 'Advanced');

INSERT INTO Trains VALUES
(1, 1),
(2, 2),
(3, 3);

INSERT INTO Requires VALUES
(1, 2, 'High'),
(2, 1, 'Medium'),
(3, 1, 'High');