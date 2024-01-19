using Microsoft.EntityFrameworkCore;
using OrderService.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderServiceContext")
    ?? throw new InvalidOperationException("Connection string 'OrderServiceContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
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
