namespace HumanResource.Migrations
{
    using HumanResource.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HumanResource.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HumanResource.Models.ApplicationDbContext";
        }

        protected override void Seed(HumanResource.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //initialized Admin user
            if (!context.Users.Any(u => u.UserName == "herreraingrid@outlook.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "32321321",
                    Email = "herreraingrid@outlook.com"
                    //.......
                };
                manager.Create(user, "rUidE=pH1");
                manager.AddToRole(user.Id, "Administrator");
            }
        }
    }
    
}
