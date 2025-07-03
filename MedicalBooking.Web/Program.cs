using MedicalBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add DbContext to DI Container

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");

Console.WriteLine($"Connection String :{connectionString}");
//var app = builder.Build();

builder.Services.AddDbContext<MedicalBookingDbContext>(options =>
    options.UseSqlServer(
        connectionString
        )
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
