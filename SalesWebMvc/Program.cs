using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Data;
using SalesWebMvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Access configuration from appsettings.json
var configuration = builder.Configuration;

// Configure the DbContext with MySQL
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
    options.UseMySql(configuration.GetConnectionString("SalesWebMvcContext"), new MySqlServerVersion(new Version(8, 0, 21))));

builder.Services.AddTransient<SeedingService>();
builder.Services.AddTransient<SellerService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<SeedingService>();
    await seeder.SeedAsync(); // Make sure to await this async method

}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
