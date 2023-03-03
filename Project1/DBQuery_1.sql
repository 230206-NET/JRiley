

create table EmployeeTable (
    EmployeeName NVARCHAR(50),
    Username NVARCHAR(50),
    userID NVARCHAR(50) PRIMARY KEY,
    empPassword NVARCHAR(50),
    EmployeeType NVARCHAR(50),
)

create table EmployeeTickets(
    TicketDate DATETIME,
    TicketID int,
    userID NVARCHAR(50) FOREIGN KEY REFERENCES EmployeeTable(userID),
    ExpenseType NVARCHAR(50),
    ExpenseDescription NVARCHAR(50),
    ExpenseAmount float,
    TicketStatus NVARCHAR(50),
    ManagedBy NVARCHAR(50)
)


SELECT * from EmployeeTable
SELECT * from EmployeeTickets

Delete from EmployeeTickets where TicketID = 
