using System;
using System.Collections.Generic;
using System.Linq;
using KPMG.PressfordConsulting.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(KPMG.PressfordConsulting.Startup))]

namespace KPMG.PressfordConsulting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists("Publisher"))
            {

                var role = new IdentityRole();
                role.Name = "Publisher";
                roleManager.Create(role);

                //Create Initial Users for KPMG Test - Begin
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                userManager.Create(new IdentityUser("publisherUser"), "KPMG123");
                userManager.Create(new IdentityUser("employeeUser"), "KPMG123");
                var user = userManager.FindByName("publisherUser");
                userManager.AddClaim(user.Id, new System.Security.Claims.Claim("IsAPublisher", "true"));

                userManager.AddToRole(user.Id, "Publisher");
                //Create Initial Users for KPMG Test - End

            }

            // creating Creating Employee role 
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
        }

    }
}
