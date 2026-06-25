using Catalog.Application;
using Catalog.Core;
using Catalog.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// adding swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string conn = builder.Configuration.GetConnectionString("EStoreAdminDb");

builder.Services.AddDbContext<BrandRepository>(option=>
{
    option.UseSqlServer(conn);
});

builder.Services.Add(new ServiceDescriptor(
    typeof(IBrandService), 
    typeof(BrandService), 
    ServiceLifetime.Transient));

var app = builder.Build();

//enable swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.MapControllers();

app.Run();
