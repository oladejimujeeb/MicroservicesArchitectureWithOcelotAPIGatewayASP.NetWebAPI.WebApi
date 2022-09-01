using Customer.Microservice.Context;
using Customer.Microservice.Implementation.Repositories;
using Customer.Microservice.Implementation.Services;
using Customer.Microservice.Interface.IRepository;
using Customer.Microservice.Interface.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ApplicationContext");
builder.Services.AddControllers();
// Learn more about configuring Sger/OpenAPIwag at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ICustomersRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerServices, CustomerService>();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyAppContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
