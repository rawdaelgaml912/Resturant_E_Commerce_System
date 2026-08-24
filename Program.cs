using Microsoft.AspNetCore.Identity;
using Resturant_Project.Data;
using Restaurant_Project.Services;

namespace Resturant_Project
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession();

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddHttpClient<PaymobService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider
                    .GetRequiredService<RoleManager<IdentityRole>>();

                var userManager = scope.ServiceProvider
                    .GetRequiredService<UserManager<IdentityUser>>();

                // Create Admin Role
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole("Admin"));
                }

                // Create User Role
                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(
                        new IdentityRole("User"));
                }

                // Make admin2@gmail.com an Admin
                var admin = await userManager.FindByEmailAsync(
                    "admin2@gmail.com");

                if (admin != null)
                {
                    if (!await userManager.IsInRoleAsync(
                        admin,
                        "Admin"))
                    {
                        await userManager.AddToRoleAsync(
                            admin,
                            "Admin");
                    }
                }
            }

            app.UseSession();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}