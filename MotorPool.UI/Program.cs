using System.Globalization;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;

using MotorPool.Persistence;
using MotorPool.Services.VehicleBrand;
using MotorPool.Services.Vehicles;
using MotorPool.UI.Areas.Identity.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<UserIdentityContext>(options => options.UseSqlServer(connectionString));

builder.Services
       .AddDefaultIdentity<IdentityUser>(options =>
       {
           options.SignIn.RequireConfirmedAccount = true;

           options.Password.RequireDigit = true;
           options.Password.RequireLowercase = true;
           options.Password.RequireNonAlphanumeric = true;
           options.Password.RequireUppercase = true;
           options.Password.RequiredLength = 8;
           options.Password.RequiredUniqueChars = 1;
       })
       .AddEntityFrameworkStores<UserIdentityContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddRazorPages();

builder.Services.AddPersistence(connectionString);
builder.Services.AddVehicleServices();
builder.Services.AddVehicleBrandServices();

IMvcBuilder mvcBuilder = builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment()) mvcBuilder.AddRazorRuntimeCompilation();

WebApplication app = builder.Build();

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