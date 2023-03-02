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


app.MapGet("/users", (UserService service) =>{
    return service.getEmployees();
} );


app.MapGet("/", () => "Hello World!");

app.Run();
