using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PropertyManagement.Models;
using System;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(PropertyManagement.Startup))]
namespace PropertyManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //CreateUserRoles();
        }


        private async Task CreateUserRoles()
        {

            ApplicationDbContext context = new ApplicationDbContext();
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            IdentityResult roleResult;

            //Adding Admin Role
            var admin = await RoleManager.RoleExistsAsync("admin");
          


            if (!admin)
            {
                //create the roles and seed them to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("admin"));
            }
           
            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            IdentityUser adminUser = await UserManager.FindByEmailAsync("admin@gmail.com");
            

            var User = new IdentityUser();
            await UserManager.AddToRoleAsync(adminUser.Id, "admin");
          
        }


    }
}
