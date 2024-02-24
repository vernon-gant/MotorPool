using System.Globalization;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;

using MotorPool.Auth;
using MotorPool.Persistence;
using MotorPool.Services.Drivers;
using MotorPool.Services.Enterprise;
using MotorPool.Services.VehicleBrand;
using MotorPool.Services.Vehicles;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddPersistenceServices(connectionString);
builder.Services.AddVehicleServices();
builder.Services.AddVehicleBrandServices();
builder.Services.AddEnterpriseServices();
builder.Services.AddDriverServices();
builder.Services.AddAuthServices(connectionString);

builder.Services
       .AddAuthentication(options =>
       {
           options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
           options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
       })
       .AddCookie(options =>
       {
           options.LoginPath = "/Identity/Account/Login";
           options.AccessDeniedPath = "/Identity/Account/AccessDenied";
       });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("IsManager", policy => policy.RequireClaim("ManagerId"));
    options.AddPolicy("IsManagerAccessible", policy => policy.Requirements.Add(new IsManagerAccessibleRequirement()));

    options.DefaultPolicy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .RequireClaim("ManagerId")
                            .Build();
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var mvcBuilder = builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Brands");
    options.Conventions.AuthorizeFolder("/Drivers");
    options.Conventions.AuthorizeFolder("/Enterprises");
    options.Conventions.AuthorizeFolder("/Vehicles");
});

if (builder.Environment.IsDevelopment()) mvcBuilder.AddRazorRuntimeCompilation();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("de-de"),
    SupportedCultures = new List<CultureInfo> { new ("en-US") },
    SupportedUICultures = new List<CultureInfo> { new ("en-US") }
});
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

await app.SetupDatabaseAsync();

app.Run();