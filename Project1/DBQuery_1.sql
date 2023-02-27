DROP table EmployeeTickets
create table EmployeeTable (
    EmployeeName NVARCHAR(50),
    Username NVARCHAR(50),
    userID NVARCHAR(50) PRIMARY KEY,
    empPassword NVARCHAR(50),
    EmployeeType NVARCHAR(50),
)

create table EmployeeTickets(
    TicketID int,
    userID NVARCHAR(50) FOREIGN KEY REFERENCES EmployeeTable(userID),
    ExpenseType NVARCHAR(50),
    ExpenseDescription NVARCHAR(50),
    ExpenseAmount float,
    TicketStatus NVARCHAR(50)
)

INSERT INTO EmployeeTable(
    EmployeeName,
    Username,
    userID,
    empPassword,
    EmployeeType
)
VALUES(
    'John Riley',
    'jriley',
    'john203',
    '12345',
    'Employee'
)

INSERT INTO EmployeeTable(
    EmployeeName,
    Username,
    userID,
    empPassword,
    EmployeeType
)
VALUES(
    'Michael Scott',
    'mscott123',
    'mikeyScott',
    '12345',
    'Manager'
)

INSERT INTO EmployeeTickets(
    TicketID,
    userID,
    ExpenseType,
    ExpenseDescription,
    ExpenseAmount,
    TicketStatus
)
VALUES(
    '1234',
    'john203',
    'Plane Ticket',
    'Help me',
    350,
    'Pending'
)

INSERT INTO EmployeeTickets(
    TicketID,
    userID,
    ExpenseType,
    ExpenseDescription,
    ExpenseAmount,
    TicketStatus
)
VALUES(
    '1234',
    'john203',
    'Commute',
    'Cab Fare',
    70.00,
    'Pending'
)

SELECT * from EmployeeTable
SELECT * from EmployeeTickets