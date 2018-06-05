using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Blog.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<Blog.Models.AccountViewModels>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Blog.Models.AccountViewModels context)
        {
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "StevenUnderwood@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "StevenUnderwood@Mailinator.com",
                    Email = "StevenUnderwood@Mailinator.com",
                    FirstName = "Steven",
                    LastName = "Underwood",
                    DisplayName = "SUnderwood"
                }, "Abc123!");
            }

            if (!context.Users.Any(u => u.Email == "Moderator@Mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "Moderator@Mailinator.com",
                    Email = "Moderator@Mailinator.com",
                    FirstName = "Modi",
                    LastName = "Rator",
                    DisplayName = "TheBoss"
                }, "Password!!");
            }

            var userId = userManager.FindByEmail("StevenUnderwood@Mailinator.com").Id;
            userManager.AddToRole(userId, "Admin");

            userId = userManager.FindByEmail("Moderator@Mailinator.com").Id;
            userManager.AddToRole(userId, "Moderator");
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

        }
    }
}






