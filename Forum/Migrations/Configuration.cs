namespace redditTakeTwo.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using redditTakeTwo.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<redditTakeTwo.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "redditTakeTwo.Models.ApplicationDbContext";
        }

        protected override void Seed(redditTakeTwo.Models.ApplicationDbContext context)
        {
            var userRole = "user";
            var adminRole = "admin";

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if (!context.Roles.Any(a => a.Name == userRole))
            {
                var role = new IdentityRole { Name = userRole };
                manager.Create(role);
            }

            if (!context.Roles.Any(a => a.Name == adminRole))
            {
                var role = new IdentityRole { Name = adminRole };
                manager.Create(role);
            }

            var defaultAdmin = "Admin@tiy.com";
            var password = "Password1!";

            if (!context.Users.Any(a => a.UserName == defaultAdmin))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = defaultAdmin };

                userManager.Create(user, password);
                userManager.AddToRole(user.Id, adminRole);
            }
        }
    }
}