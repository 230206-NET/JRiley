using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DataAccess;
using Services;
using Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRepository, DBRepository>(ctx => new DBRepository(builder.Configuration.GetConnectionString("expenseDB")));
builder.Services.AddScoped<UserService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


//Retrieves a list of employees in the database
app.MapGet("/users", (UserService service) =>{
    return service.getEmployees();
} );

//Retrieves a list of Expense Tickets in the database
app.MapGet("/tickets", (UserService service) =>{
    return service.getAllTickets();
} );

//Displays each ticket made by each employee
app.MapGet("/user/tickets", ([FromQuery]string uID, UserService service ) =>{
    
    foreach(Employee emp in service.getEmployees()){
        if (emp.userID.Equals(uID) && emp.employeeType.Equals("Manager")){
            return Results.BadRequest("Error! Invalid ID");
        }
        else if(service.showUserTickets(uID).Count > 0){
            return Results.Ok(service.showUserTickets(uID));
        }
        else{
            return Results.BadRequest("User ID Does not exist");
        }
    }
    return Results.BadRequest("Something went wrong");
    


} );

//Displays Pending Tickets for Employee
app.MapGet("/user/tickets/pending", ([FromQuery]string uID, UserService service ) =>{
    
    foreach(Employee emp in service.getEmployees()){
        if (emp.userID.Equals(uID) && emp.employeeType.Equals("Manager")){
            return Results.BadRequest("Error! Invalid ID");
        }
        else if(service.showPendingTickets(uID).Count > 0){
            return Results.Ok(service.showPendingTickets(uID));
        }
        else if (service.showPendingTickets(uID).Count < 1 && emp.userID.Equals(uID)){
            return Results.BadRequest("No Pending Tickets for " + emp.empName);
        }
    }
    return Results.BadRequest("Error! userID Does Not Exist");
    


} );

//Displays Login Functionality
app.MapGet("/login", ([FromQuery]string? username, [FromQuery]string? password, UserService service) => {
    if(string.IsNullOrEmpty(username)){return Results.BadRequest("username must not be empty or whitespaces");}


    else if(string.IsNullOrWhiteSpace(password)){return Results.BadRequest("Password must not be empty or whitespace");}

    Employee emp = new();
    emp = service.VerifyUser(username, password);

    if (emp != null){
        if (emp.employeeType.Equals("Employee")){
            return Results.Ok("Welcome to the Employee Portal!");
        }
        else if (emp.employeeType.Equals("Manager")){
            return Results.Ok("Welcome to the Manager Portal");
        }
    }
    return Results.BadRequest("Account does not exist...");


});

//Manager can accept Reimbursement requests
app.MapPut("/users/manager/acceptTickets", ([FromQuery] int ticketID, [FromQuery] string managerID, [FromQuery] string manPwd, UserService service)  => {
    return Results.Ok(service.AcceptTickets(ticketID, managerID));
});

//Manager can deny Reimbursement requests
app.MapPut("/users/manager/denyTickets", ([FromQuery] int ticketID, [FromQuery] string managerID, [FromQuery] string manPwd, UserService service)  => {
    return Results.Ok(service.DenyTickets(ticketID, managerID));
});


//Manager can promote an Employee
app.MapPut("/users/manager/promoteEmp", ([FromQuery] string empId, [FromQuery] string managerID, [FromQuery] string manPwd, UserService service)  => {
    for(int i = 0; i < service.getEmployees().Count; i++){
        if(service.getEmployees()[i].userID.Equals(empId) && service.getEmployees()[i].employeeType.Equals("Manager")){
            return Results.BadRequest("Error! " + service.getEmployees()[i].empName + " is already a Manager");
        }
        if(service.getEmployees()[i].userID.Equals(empId) && service.getEmployees()[i].employeeType.Equals("Employee")){
            return Results.Ok(service.PromoteEmployee(empId));
        }
    }
    return Results.BadRequest("User does not exist");

});

//Manager can demote a Manager
app.MapPut("/users/manager/demoteEmp", ([FromQuery] string empId, [FromQuery] string managerID, [FromQuery] string manPwd, UserService service)  => {

    for(int i = 0; i < service.getEmployees().Count; i++){
        if(service.getEmployees()[i].userID.Equals(empId) && service.getEmployees()[i].employeeType.Equals("Employee")){
            return Results.BadRequest("Error! " + service.getEmployees()[i].empName + " is already an Employee");
        }
        if(service.getEmployees()[i].userID.Equals(empId) && service.getEmployees()[i].employeeType.Equals("Manager")){
            return Results.Ok(service.DemoteEmployee(empId));
        }
    }
        return Results.BadRequest("User does not exist");
});

//allows user to create an account
app.MapPost("/users/createEmployee", ([FromBody] Employee emp, UserService service) => {
    return "User Created: " + Results.Created("/users", service.CreateAccount(emp));
});


//allows manager to create an account
app.MapPost("/users/createManager", ([FromBody] Employee emp, [FromQuery]string managerKey, UserService service) => {
    if(managerKey.Equals(Key.getManagerKey())){
        return Results.Ok("User Created: " + Results.Created("/users", service.CreateAccount(emp)));
    }
    else {
        return Results.BadRequest("Invalid manager key");
    }
});

//allows user to create an expense reimbursement ticket
app.MapPost("/tickets/create", ([FromBody] ExpenseTicket tick, UserService service) => {

    tick.ticketID = service.generateTicketID();
    tick.tickStat = "Pending";
    
    return "User Created: " + Results.Created("/tickets", service.CreateExpense(tick));
});


//displays "Hello World"
app.MapGet("/", () => "Hello World!");

app.Run();
