namespace MVCBank.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Services;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCBank.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MVCBank.Models.ApplicationDbContext";
        }

        protected override void Seed(MVCBank.Models.ApplicationDbContext context)
        {
            //var userStore = new UserStore<ApplicationUser>(context);
            //var userManager = new UserManager<ApplicationUser>(userStore);

            //var currentAdmin = context.Users.Where(user => user.UserName == "admin@mvcbank.com").FirstOrDefault();

            ////var isAdminExisting = context.Users.Any(user => user.UserName == "admin@mvcbank.com");

            //if (currentAdmin == null)
            //{
            //    var adminUser = new ApplicationUser { UserName = "admin@mvcbank.com", Email = "admin@mvcbank.com", UserRole = "Admin" };
            //    userManager.Create(adminUser, "12345Ut.");

            //    var service = new CheckAccountServices(context);
            //    service.CreateCheckAccount("admin", "user", adminUser.Id, 1000);

            //    context.Roles.AddOrUpdate(res => res.Name, new IdentityRole { Name = "Admin" });
            //    context.SaveChanges();

            //    userManager.AddToRole(adminUser.Id, "Admin");
            //}

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var currentAdmin = context.Users.Where(user => user.UserName == "admin@mvcbank.com").FirstOrDefault();

            if (currentAdmin == null)
            {
                var adminUser = new ApplicationUser { UserName = "admin@mvcbank.com", Email = "admin@mvcbank.com", UserRole = "Admin" };
                userManager.Create(adminUser, "12345Ut.");

                var service = new CheckAccountServices(context);
                service.CreateCheckAccount("admin", "user", adminUser.Id, 1000);

                context.SaveChanges();

            }
            else if (context.Users.Any(user => user.UserName == "admin@mvcbank.com" && user.UserRole == null))
            {
                currentAdmin.UserRole = "Admin";
                context.Entry(currentAdmin).State = EntityState.Modified;
                context.SaveChanges();
            }



            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
