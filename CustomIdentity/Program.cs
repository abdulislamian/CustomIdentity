using CustomIdentity.Data;
using CustomIdentity.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CustomIdentity.Models;
using CustomIdentity.Models.PermissionModel;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using CustomIdentity.Utilities;
using Microsoft.AspNetCore.Mvc;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var emailConfig = builder.Configuration
                .GetSection("EmailSettings")
                .Get<EmailConfiguration>();
        builder.Services.AddSingleton(emailConfig);


        // Add services to the container.
        builder.Services.AddControllersWithViews();
        //builder.Services.AddMvc(options =>
        //{
        //    options.CacheProfiles.Add("NoCache", new CacheProfile { NoStore = true, Duration = 0 });
        //});

        builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
        builder.Services.AddScoped<IPolicyService, PolicyService>();
        builder.Services.AddScoped<IEmailSender, SmtpEmailService>();

        builder.Services.AddDbContext<ApplicationDbContext>
            (Options => Options.UseSqlServer
            (builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddAuthorization(AuthorizationPolicies.ConfigurePolicies);

        builder.Services.AddNotyf(config => { config.DurationInSeconds = 5; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });
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
        //app.UseMiddleware<PermissionMiddleware>();
        app.UseAuthorization();
        app.UseNotyf();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}