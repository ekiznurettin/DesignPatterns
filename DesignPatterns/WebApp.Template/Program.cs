using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using WebApp.Template.Models;

namespace WebApp.Template
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var identityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            identityDbContext.Database.Migrate();
            if (!userManager.Users.Any())
            {
                userManager.CreateAsync(new AppUser() { UserName = "user1", Email = "user1@gmail.com", PictureUrl = "/UserPictures/user2.jpg", Description = "This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer." }, "Password123.").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "user2", Email = "user2@gmail.com", PictureUrl = "/UserPictures/user2.jpg", Description = "This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer." }, "Password123.").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "user3", Email = "user3@gmail.com", PictureUrl = "/UserPictures/user2.jpg", Description = "This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer." }, "Password123.").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "user4", Email = "user4@gmail.com", PictureUrl = "/UserPictures/user2.jpg", Description = "This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer." }, "Password123.").Wait();
                userManager.CreateAsync(new AppUser() { UserName = "user5", Email = "user5@gmail.com", PictureUrl = "/UserPictures/user2.jpg", Description = "This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer." }, "Password123.").Wait();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
