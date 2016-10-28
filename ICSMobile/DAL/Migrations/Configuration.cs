using System.Collections.Generic;
using Shared.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.IcsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(DAL.IcsContext context)
        {
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
            var hasher = new PasswordHasher();

            #region Chaffuer
            var Chauffeurs = new List<Chauffeur>
            {
                new Chauffeur {FirstName="Patrick",LastName="Van Tillo", Id = Guid.NewGuid().ToString(), UserName="patrick"}
            };

            Chauffeurs.ForEach(s => context.Users.Add(s));
            #endregion

            #region Vrachtwagens
            var Vrachtwagens = new List<Vrachtwagen>
            {
                new Vrachtwagen {NummerPlaat="1-GDI-017", TotaalKM=5000,Merk="scania"},
                new Vrachtwagen {NummerPlaat="1-ABC-234", TotaalKM=1500}
            };

            Vrachtwagens.ForEach(s => context.Vrachtwagens.Add(s));
            #endregion

            #region Tankbeurt
            var Tankbeurten = new List<Tankbeurt>
            {
                new Tankbeurt {TankbeurtID=1, Liter=500,StartKm=500,EindKm=1500,NummerPlaat="1-GDI-017"},
                new Tankbeurt {TankbeurtID=2, Liter=555,StartKm=1500,EindKm=3500,NummerPlaat="1-GDI-017"},
                new Tankbeurt {TankbeurtID=3, Liter=457,StartKm=3500,EindKm=5000,NummerPlaat="1-GDI-017"},
                new Tankbeurt {TankbeurtID=4, Liter=300,StartKm=200,EindKm=1500,NummerPlaat="1-ABC-234"}
            };
            Tankbeurten.ForEach(s => context.Tankbeurten.Add(s));
            #endregion

            #region Opdrachten

            var Opdrachten = new List<Opdracht>
            {
                new Opdracht { ChauffeurID = Chauffeurs.ElementAt(0).Id, OpdrachtID=1},
                new Opdracht { ChauffeurID = Chauffeurs.ElementAt(0).Id, OpdrachtID=2},

            };
            Opdrachten.ForEach(s => context.Opdrachten.Add(s));
            #endregion

            #region Ritten

            var Ritten = new List<Rit>
            {
                new Rit { RitID=1, NummerPlaat="1-GDI-017", OpdrachtID=1,BeginKm=500,EindKm=600 },
                new Rit { RitID=2, NummerPlaat="1-GDI-017", OpdrachtID=1,BeginKm=600,EindKm=800 },
                new Rit { RitID=3, NummerPlaat="1-GDI-017", OpdrachtID=1,BeginKm=800,EindKm=900 },
                new Rit { RitID=3, NummerPlaat="1-ABC-234", OpdrachtID=2,BeginKm=200,EindKm=800 },

            };
            Ritten.ForEach(s => context.Ritten.Add(s));
            #endregion

            context.SaveChanges();
        }
    }
}
