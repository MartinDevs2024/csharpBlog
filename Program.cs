using csharpBlog.Data;
using csharpBlog.Helpers;
using csharpBlog.Interfaces;
using csharpBlog.Services;
using csharpBlog.Utility;
using csharpBlog.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Register a preconfigured instance of the MailSettings class
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IBlogEmailSender, EmailService>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

// Register our Image Service
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IFileManager, FileManager>();

var app = builder.Build();

// Seed Admin and Guest Users
await SeedAdmin.InitializeAsync(app.Services, "admin@aol.com", "Admin123*");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=UI}/{controller=Home}/{action=Index}/{id?}");

app.Run();
