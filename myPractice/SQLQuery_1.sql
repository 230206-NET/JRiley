

create table employee(
    fullName varchar(50),
    username varchar(20)

);

create table reimbursement(
    ticketId int,
    expenseDate DATETIME,
    expenseAmount float,
    expenseDescription varchar(100)
);

insert into employee(fullName, username) values ('John Riley', 'john203', '123456$');

insert into employee(fullName, username) values ('Joe Swanson', 'joe444', 'helloWorld');


select * from employee;



