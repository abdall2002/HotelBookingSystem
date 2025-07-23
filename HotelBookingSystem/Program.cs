using HotelBookingSystem;
using HotelBookingSystem.Model;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ? 1?? ����� Connection String
var connectionString = builder.Configuration.GetConnectionString("constr")
    ?? throw new InvalidOperationException("Connection string 'constr' not found.");

// ? 2?? ����� DbContext �� SQL Server
builder.Services.AddDbContext<HotelBookingDbContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<HotelBookingDbContext>()
.AddDefaultTokenProviders()
.AddDefaultUI();

// ? 4?? ����� �������
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // ���� ����� ������ �������

var app = builder.Build();

// ? 5?? ����� �� ��������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // ����� ������ ����� ������
app.UseAuthorization();

// ? 6?? ����� ��������
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // ����� ���� ����� Register, Login, ������

// ? 7?? ����� �������
app.Run();
