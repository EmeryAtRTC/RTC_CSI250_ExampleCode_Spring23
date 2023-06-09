
INSERT INTO Customers (FirstName, LastName, Phone, Active)
VALUES
    ('John', 'Doe', '123-456-7890', 1),
    ('Jane', 'Smith', '987-654-3210', 1),
    ('Alice', 'Johnson', '555-123-4567', 0),
    ('David', 'Brown', '555-987-6543', 1),
    ('Sarah', 'Wilson', '111-222-3333', 1),
    ('Michael', 'Anderson', '444-555-6666', 0),
    ('Emily', 'Taylor', '777-888-9999', 1),
    ('Robert', 'Clark', '123-456-7890', 0),
    ('Olivia', 'Walker', '555-123-4567', 1),
    ('Daniel', 'Lee', '987-654-3210', 1),
    ('Sophia', 'Lewis', '555-987-6543', 0),
    ('Matthew', 'Thomas', '111-222-3333', 1),
    ('Isabella', 'Harris', '444-555-6666', 0),
    ('Andrew', 'Martin', '777-888-9999', 1),
    ('Emma', 'White', '123-456-7890', 0),
    ('James', 'Johnson', '555-123-4567', 1),
    ('Ava', 'Smith', '987-654-3210', 1),
    ('William', 'Davis', '555-987-6543', 0),
    ('Mia', 'Wilson', '111-222-3333', 1),
    ('Alexander', 'Miller', '444-555-6666', 0);
INSERT INTO TechnicianStatuses ([Status]) VALUES ('Full-Time'),('Part-Time'),('Terminated'); 
--This seeds the technician table
INSERT INTO Technicians (FirstName, LastName, EmployeeNumber, TechnicianStatusId)
VALUES
    ('Mark', 'Johnson', '123456789', 1),
    ('Emily', 'Williams', '987654321', 2),
    ('Christopher', 'Brown', '555888777', 3),
    ('Laura', 'Thompson', '111222333', 2),
    ('Benjamin', 'Anderson', '444555666', 1),
    ('Victoria', 'Harris', '777888999', 3),
    ('Jonathan', 'Taylor', '222333444', 3),
    ('Sophia', 'Lewis', '555444333', 2),
    ('Alexander', 'Walker', '999888777', 2),
    ('Olivia', 'Martin', '666555444', 1);

INSERT INTO ServiceStatuses([Status])
VALUES ('New'),
       ('In-Progress'),
       ('Pending Customer'),
       ('Completed');