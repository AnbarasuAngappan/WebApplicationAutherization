namespace WebApplicationAutherization.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplicationAutherization.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplicationAutherization.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WebApplicationAutherization.Models.ApplicationDbContext";
        }

        protected override void Seed(WebApplicationAutherization.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);
            context.Contacts.AddOrUpdate(p => p.Name,
                new Contact
                {
                    Name = "Anbu",
                    Address = "No.47 Jubliee Hills",
                    City = "Hyderabad",
                    State = "Telengana",
                    Zip = "500003",
                    Email = "anbu@gmail.com",

                },
                new Contact
                {
                    Name = "Balaji",
                    Address = "4 S.N.V.S layout",
                    City = "Tirupur",
                    State = "Tamilnadhu",
                    Zip = "500403",
                    Email = "balaji@gmail.com",

                },
                new Contact
                {
                    Name = "Shiva",
                    Address = "No.47 Jubliee Hills",
                    City = "Bangalore",
                    State = "Karnataka",
                    Zip = "641607",
                    Email = "shiva@gmail.com",

                },
                new Contact
                {
                    Name = "Indhu",
                    Address = "No.47 Jubliee Hills",
                    City = "Kochin",
                    State = "Kerala",
                    Zip = "466059",
                    Email = "indhu@gmail.com",

                }
                
            );


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

        bool AddUserAndRole(WebApplicationAutherization.Models.ApplicationDbContext context)
        {
            IdentityResult ir;

            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canCreate"));

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "indhu@gmail.com",

            };
            ir = um.Create(user, "sai");

            if (ir.Succeeded == false)
                return ir.Succeeded;

            ir = um.AddToRoles(user.Id, "canCreate");
                return ir.Succeeded;            
            
        }

    }
}
