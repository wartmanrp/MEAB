namespace MEAB.Migrations
{
   using MEAB.Models;
   using Microsoft.AspNet.Identity;
   using Microsoft.AspNet.Identity.EntityFramework;
   using System;
   using System.Data.Entity;
   using System.Data.Entity.Migrations;
   using System.Linq;

   internal sealed class Configuration : DbMigrationsConfiguration<MEAB.Models.ApplicationDbContext>
   {
      public Configuration()
      {
      AutomaticMigrationsEnabled = true;
      }

      protected override void Seed(MEAB.Models.ApplicationDbContext context)
      {
   
         var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

         //creates admin if doesn't exist.
         if (!roleManager.RoleExists("Admin"))
               if (!context.Roles.Any(r => r.Name == "Admin"))
               {
                  roleManager.Create(new IdentityRole { Name = "Admin" });
               }

         //creates moderator role if doesn't exist
         if (!context.Roles.Any(r => r.Name == "Moderator"))
         {
               roleManager.Create(new IdentityRole { Name = "Moderator" });
         }

         var uStore = new UserStore<ApplicationUser>(context);
         var userManager = new UserManager<ApplicationUser>(uStore);

         //creates new user
         if (userManager.FindByEmail("powers.wartman@gmail.com") == null)
         {
               userManager.Create(new ApplicationUser
               {
                  UserName = "powers.wartman@gmail.com",
                  Email = "powers.wartman@gmail.com",
                  FirstName = "Powers",
                  LastName = "Wartman"
               }, "Password-1");
         }

         //assigns person to given role (admin || moderator), if not already in it.
         var userId = userManager.FindByEmail("powers.wartman@gmail.com").Id;

         if (!userManager.IsInRole(userId, "Admin"))
         {
               userManager.AddToRole(userId, "Admin");
         }

         if (context.UnitTypes.Count() < 1)
         {
            context.UnitTypes.Add(
               new UnitType { Name = "Infantry" });
            context.UnitTypes.Add(
               new UnitType { Name = "Cavalry" });
            context.UnitTypes.Add(
               new UnitType { Name = "Monster" });
            context.UnitTypes.Add(
               new UnitType { Name = "Monstrous Cavalry" });
            context.UnitTypes.Add(
               new UnitType { Name = "Artillery" });
            context.UnitTypes.Add(
               new UnitType { Name = "Wizard" });
            context.UnitTypes.Add(
               new UnitType { Name = "Hobbit" });
            context.UnitTypes.Add(
               new UnitType { Name = "Dwarf" });
            context.UnitTypes.Add(
               new UnitType { Name = "Goblin" });
         }
      
      }
   }
}
