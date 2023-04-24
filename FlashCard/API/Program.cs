using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Services;

var MyAllowOrigins = "*";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options => {

    options.AddPolicy(name: MyAllowOrigins, policy => {
    policy.WithOrigins(MyAllowOrigins).AllowAnyHeader().AllowAnyMethod();
});

});

builder.Services.AddScoped<FlashCardServices>();
builder.Services.AddDbContext<FlashCardDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CardDB")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowOrigins);
app.Run();
