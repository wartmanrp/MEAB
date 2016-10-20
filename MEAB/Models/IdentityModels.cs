using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using MEAB.Models;

namespace MEAB.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ApplicationUser()
        {
            this.Units = new HashSet<Unit>();
            this.Warbands = new HashSet<Warband>();
            this.ArmyLists = new HashSet<ArmyList>();
            this.Heroes = new HashSet<Hero>();
        }

        public virtual ICollection<Unit> Units { get; set; }
        public virtual ICollection<Warband> Warbands { get; set; }
        public virtual ICollection<ArmyList> ArmyLists { get; set; }
        public virtual ICollection<Hero> Heroes { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MEABContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<ArmyList> ArmyLists { get; set; }
        public DbSet<Warband> Warbands { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }

    }
}