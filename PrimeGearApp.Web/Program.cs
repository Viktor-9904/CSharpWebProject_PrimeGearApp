using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using PrimeGearApp.Data.Models;
using PrimeGearApp.Data.Repository;
using PrimeGearApp.Data.Repository.Interfaces;
using PrimeGearApp.Services.Data;
using PrimeGearApp.Services.Data.Interfaces;
using PrimeGearApp.Web.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ConnectionString")!;

// Add services to the container.
builder.Services.AddDbContext<PrimeGearDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services
    .AddIdentity<ApplicationUser, IdentityRole<Guid>>(cfg =>
    {
        IdentityConfiguration(builder, cfg);
    })
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddRoles<IdentityRole<Guid>>()
    .AddSignInManager<SignInManager<ApplicationUser>>()
    .AddUserManager<UserManager<ApplicationUser>>()
    .AddEntityFrameworkStores<PrimeGearDbContext>();

builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Identity/Account/Login";
});

builder.Services.AddScoped<IRepository<Product, int>, BaseRepositery<Product, int>>();
builder.Services.AddScoped<IRepository<ProductType, int>, BaseRepositery<ProductType, int>>();
builder.Services.AddScoped<IRepository<ProductDetail, int>, BaseRepositery<ProductDetail, int>>();
builder.Services.AddScoped<IRepository<ProductTypeProperty, int>, BaseRepositery<ProductTypeProperty, int>>();
builder.Services.AddScoped<IRepository<PropertyValueType, int>, BaseRepositery<PropertyValueType, int>>();
builder.Services.AddScoped<IRepository<Manager, Guid>, BaseRepositery<Manager, Guid>>();
builder.Services.AddScoped<IRepository<ShoppingCart, int>, BaseRepositery<ShoppingCart, int>>();
builder.Services.AddScoped<IRepository<ShoppingCartItem, int>, BaseRepositery<ShoppingCartItem, int>>();
builder.Services.AddScoped<IRepository<Order, Guid>, BaseRepositery<Order, Guid>>();
builder.Services.AddScoped<IRepository<ApplicationUser, Guid>, BaseRepositery<ApplicationUser, Guid>>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IManagerService, ManagerService>();
builder.Services.AddScoped<IUserCartSerivce, UserCartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter(); //?

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");

app.MapControllerRoute(
    name: "Errors",
    pattern: "{controller=Home}/{action=Index}/{statusCode?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

static void IdentityConfiguration(WebApplicationBuilder builder, IdentityOptions cfg)
{
    cfg.Password.RequireDigit = builder.Configuration.GetValue<bool>("Identity:Password:RequireDigits");

    cfg.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowerCase");

    cfg.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUpperCase");

    cfg.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumerical");

    cfg.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");

    cfg.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("Identity:Password:RequiredUniqueCharacters");


    cfg.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccound");

    cfg.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedEmail");

    cfg.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedPhoneNumber");


    cfg.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Identity:User:RequireUniqueEmail");
}