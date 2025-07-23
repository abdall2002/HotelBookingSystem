using HotelBookingSystem;
using HotelBookingSystem.Model;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ? 1?? ≈⁄œ«œ Connection String
var connectionString = builder.Configuration.GetConnectionString("constr")
    ?? throw new InvalidOperationException("Connection string 'constr' not found.");

// ? 2??  ”ÃÌ· DbContext „⁄ SQL Server
builder.Services.AddDbContext<HotelBookingDbContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<HotelBookingDbContext>()
.AddDefaultTokenProviders()
.AddDefaultUI();

// ? 4?? ≈÷«›… «·Œœ„« 
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // ·œ⁄„ ’›Õ«  «·ÂÊÌ… «·Ã«Â“…

var app = builder.Build();

// ? 5?? ≈⁄œ«œ Œÿ «·√‰«»Ì»
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ÷—Ê—Ì · ‘€Ì·  ”ÃÌ· «·œŒÊ·
app.UseAuthorization();

// ? 6?? ≈⁄œ«œ «·„”«—« 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // ÷—Ê—Ì ·œ⁄„ ’›Õ«  Register, Login, Ê€Ì—Â«

// ? 7??  ‘€Ì· «· ÿ»Ìﬁ
app.Run();
