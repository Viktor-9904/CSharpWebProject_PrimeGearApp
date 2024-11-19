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

builder.Services.AddScoped<IProductService, ProductService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

static void IdentityConfiguration(WebApplicationBuilder builder, IdentityOptions cfg)
{
    cfg.Password.RequireDigit = builder.Configuration.GetValue<bool>("Idenity:Password:RequireDigits");

    cfg.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Idenity:Password:RequireLowerCase");

    cfg.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Idenity:Password:RequireUpperCase");

    cfg.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Idenity:Password:RequireNonAlphanumerical");

    cfg.Password.RequiredLength = builder.Configuration.GetValue<int>("Idenity:Password:RequiredLength");

    cfg.Password.RequiredUniqueChars = builder.Configuration.GetValue<int>("Idenity:Password:RequiredUniqueCharacters");


    cfg.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Idenity:SignIn:RequireConfirmedAccound");

    cfg.SignIn.RequireConfirmedEmail = builder.Configuration.GetValue<bool>("Idenity:SignIn:RequireConfirmedEmail");

    cfg.SignIn.RequireConfirmedPhoneNumber = builder.Configuration.GetValue<bool>("Idenity:SignIn:RequireConfirmedPhoneNumber");


    cfg.User.RequireUniqueEmail = builder.Configuration.GetValue<bool>("Idenity:User:RequireUniqueEmail");
}