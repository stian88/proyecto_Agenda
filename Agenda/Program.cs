using Agenda.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("AppDbContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDbContextConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=db_Agenda;Integrated Security=True"));

builder.Services.AddDefaultIdentity<IdentityUser>
    (Options  =>
    {
        Options.SignIn.RequireConfirmedAccount = false;
        Options.Password.RequireDigit = false;
        Options.Password.RequiredLength = 6;
        Options.Password.RequireNonAlphanumeric = false;
        Options.Password.RequireUppercase = false;
        Options.Password.RequireLowercase = false;

    })
    .AddEntityFrameworkStores<AppDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
