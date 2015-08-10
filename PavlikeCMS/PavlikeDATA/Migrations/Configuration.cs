using Microsoft.AspNet.Identity.EntityFramework;
using PavlikeDATA.Models;

namespace PavlikeDATA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "PavlikeDATA.Models.Context";
        }

        protected override void Seed(Context context)
        {
            //var usercontext = new ApplicationDbContext();
            //var role = new IdentityRole { Name = "SuperUser" };
            //usercontext.Roles.Add(role);
            ////Password is Sapmaz_2015
            //var user = new ApplicationUser { UserName = "admin", Email = "ugurhan@sapmazbilisim.com", PasswordHash = "AJYP53NfCtWZ0Z36CFoNysbcoTODg/8PHIzelTHJwWJOAHqY1IavgD9ZdG9u1UcdFQ==", Roles = { } };
            //usercontext.Users.Add(user);
            //var userRole = new IdentityUserRole() { RoleId = role.Id, UserId = user.Id };
            //user.Roles.Add(userRole);
            //usercontext.SaveChanges();


            //var ct = new Context();

            //ct.Authors.Add(new Author() { UserGuid = user.Id, Name = "SuperUser", EMail = user.Email, DateofBirth = DateTime.Now });
            //ct.SaveChanges();

        }
    }
}
