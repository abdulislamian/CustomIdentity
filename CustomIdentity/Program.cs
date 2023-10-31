using CustomIdentity.Data;
using CustomIdentity.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using CustomIdentity.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<ApplicationDbContext>
    (Options => Options.UseSqlServer
    (builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider); ;

//builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
//                .AddEntityFrameworkStores<ApplicationDbContext>()
//                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("FullAdminAccess", policy => policy.RequireRole("SuperAdmin"));
    options.AddPolicy("AdminAccess", policy => policy.RequireRole("Admin","SuperAdmin"));
    options.AddPolicy("UserAccess", policy => policy.RequireRole("User"));
});

builder.Services.AddAuthorization(options => {
    options.AddPolicy("SuperUserRights", policy => policy.RequireRole("User"));
});


builder.Services.AddSingleton<IEmailService, SmtpEmailService>(provider =>
{
    var smtpClient = new SmtpClient
    {
        Host = builder.Configuration["EmailSettings:SmtpServer"],
        Port = int.Parse(builder.Configuration["EmailSettings:SmtpPort"]),
        Credentials = new NetworkCredential(
            builder.Configuration["EmailSettings:SmtpUsername"],
            builder.Configuration["EmailSettings:SmtpPassword"]
        ),
        EnableSsl = true,
    };

    return new SmtpEmailService(smtpClient);
});
//builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));





builder.Services.AddSession(option => {
    option.IOTimeout = TimeSpan.FromDays(10);
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});

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

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
