using Microsoft.AspNet.Identity.EntityFramework;
using pavlikeMVC.Models;
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
            var usercontext = new ApplicationDbContext();
            var role = new IdentityRole { Name = "SuperUser" };
            usercontext.Roles.Add(role);
            var user = new ApplicationUser { UserName = "admin", Email = "ugurhan@sapmazbilisim.com", PasswordHash = "ADWxsPpGnDe6gSoncPm+e8RImfLucwlb4xjM/sQDPIvo6FH+ha3xInNNdUmKrckNBQ==", Roles = { } };
            usercontext.Users.Add(user);
            var userRole = new IdentityUserRole() { RoleId = role.Id, UserId = user.Id };
            user.Roles.Add(userRole);
            usercontext.SaveChanges();


            var ct = new Models.Context();

            ct.Authors.Add(new Author() { UserGuid = user.Id, Name = "SuperUser", EMail = user.Email, DateofBirth = DateTime.Now });
            ct.SaveChanges();

        }
    }
}
