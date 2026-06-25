using CatalogModel.Models;
using CatalogModel.ServiceContract;
using CatalogRepository;
using CatalogService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Added the BrandService with the dependency injection container (IOC)
builder.Services.Add(new ServiceDescriptor(
    typeof(IBrandService),
    typeof(BrandService),
    ServiceLifetime.Transient
    ));

builder.Services.Add(new ServiceDescriptor(
    typeof(ITypeService),
    typeof(TypeService),
    ServiceLifetime.Transient
    ));

builder.Services.Add(new ServiceDescriptor(
    typeof(IProductService),
    typeof(ProductService),
    ServiceLifetime.Transient
    ));

// Add controller service to the controller
builder.Services.AddControllersWithViews();

// read the connection string from the config file (appsettings.json) and store it variable
string? _conn = builder.Configuration.GetConnectionString("EStoreAdminDb");

// Register the BrandRepository with the dependency injection container
// and configure it to use sql server with the connection string
builder.Services.AddDbContext<BrandRepository>(option =>
{
    option.UseSqlServer(_conn);
});

builder.Services.AddDbContext<TypeRepository>(option =>
{
    option.UseSqlServer(_conn);
});

builder.Services.AddDbContext<ProductRepository>(option =>
{
    option.UseSqlServer(_conn);
});

builder.Services.AddDbContext<ApplicationRepository>(option =>
{
    option.UseSqlServer(_conn);
});

//builder.Services.AddIdentityCore<ApplicationUserModel>(option =>
//{
//    option.Password.RequireDigit = true;
//    option.Password.RequiredLength = 8;
//})
//    .AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationRepository>();

builder.Services.AddIdentity<ApplicationUserModel, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<ApplicationRepository>()
.AddDefaultTokenProviders();

var app = builder.Build();

// To serve static files such as CSS, JavaScript and Images from the wwwroot folder.
app.UseStaticFiles();

// Configure the HTTP request pipeline with the Routing
app.UseRouting();

// configure the authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Map Controller Endpoints
app.MapControllers();


app.Run();
