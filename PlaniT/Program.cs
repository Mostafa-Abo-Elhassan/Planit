using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlaniT.Data;
using PlaniT.Models;

namespace PlaniT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //database
            builder.Services.AddDbContext<ApplicationDbContext>(
                          options => options.UseSqlServer(builder.Configuration.GetConnectionString("todoapp")));





            builder.Services.AddIdentity<User, IdentityRole>(options =>
            options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
       .AddEntityFrameworkStores<ApplicationDbContext>();


            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;


            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
