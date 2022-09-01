using Microsoft.EntityFrameworkCore;
using Product.Microservice.Implementation.Repository;
using Product.Microservice.Implementation.Services;
using Product.Microservice.Intefaces.IRepository;
using Product.Microservice.Intefaces.IService;
using Product.Microservice.MyContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionstring = builder.Configuration.GetConnectionString("ApplicationContext");
builder.Services.AddDbContext<AppContx>(options => options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IProductsRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSwaggerGen();

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
