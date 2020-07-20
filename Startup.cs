using Job_Book.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Job_Book.Startup))]
namespace Job_Book
{
    public partial class Startup
    {
        private ApplicationDbContext DB = new ApplicationDbContext();
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();

        }


        public void CreateDefaultRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(DB));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(DB));
            IdentityRole role = new IdentityRole();
            if (!roleManager.RoleExists("Admins"))
            {
                role.Name = "Admins";
                roleManager.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Gebril";
                user.Email = "Amrgebril80@gmail.com";
                var Check = userManager.Create(user, "@Mr123456");
                if (Check.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admins");
                }
            }
        }


    } 

   
}
