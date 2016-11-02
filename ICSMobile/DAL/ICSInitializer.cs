using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Shared.Entities;
using System.Collections.Generic;
using System;
using System.Linq;

namespace DAL
{
    public class ICSInitializer : DropCreateDatabaseIfModelChanges<IcsContext>
    {
        // Bij runnen van project wordt onderstaande gemaakt
        protected override void Seed(IcsContext context)
        {
            var hasher = new PasswordHasher();

            #region Chaffuer
            var Chauffeurs = new List<Chauffeur>
            {
                new Chauffeur {FirstName="Patrick",LastName="Van Tillo", Id = Guid.NewGuid().ToString(), UserName="patrick"},
                new Chauffeur {FirstName="Dimitri",LastName="Van Tillo", Id = Guid.NewGuid().ToString(), UserName="dimitri"},
                new Chauffeur {FirstName="Eric",LastName="Van Tillo", Id = Guid.NewGuid().ToString(), UserName="eric"}
            };

            Chauffeurs.ForEach(s => context.Users.Add(s));
            #endregion

            #region Vrachtwagens
            var Vrachtwagens = new List<Vrachtwagen>
            {
                new Vrachtwagen {NummerPlaat="1-DEF-017", TotaalKM=5000,Merk="scania"},
                new Vrachtwagen {NummerPlaat="1-ABC-234", TotaalKM=1500},
                new Vrachtwagen {NummerPlaat="1-GGG-234", TotaalKM=1500},
                new Vrachtwagen {NummerPlaat="1-DDD-234", TotaalKM=1500},
                new Vrachtwagen {NummerPlaat="1-FFF-234", TotaalKM=1500},
                new Vrachtwagen {NummerPlaat="1-XXX-234", TotaalKM=1500},
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

            var Opdrachten = new List <Opdracht>
            {
                new Opdracht { Naam = "Vermeylen Referentienummer 1", ChauffeurID = Chauffeurs.ElementAt(0).Id, OpdrachtID=1},
                new Opdracht { Naam = "Amazon Referentienummer XYZFDF", ChauffeurID = Chauffeurs.ElementAt(1).Id, OpdrachtID=2},
                new Opdracht { Naam = "Bol 123 AAA", ChauffeurID = Chauffeurs.ElementAt(2).Id, OpdrachtID=3},
                new Opdracht { Naam = "Coolblue AAfgdfg58887", ChauffeurID = Chauffeurs.ElementAt(0).Id, OpdrachtID=4},
                new Opdracht { Naam = "MCS Titonic 899", ChauffeurID = Chauffeurs.ElementAt(1).Id, OpdrachtID=5},
                new Opdracht { Naam = "Zink etgfg5", ChauffeurID = Chauffeurs.ElementAt(2).Id, OpdrachtID=6},

            };
            Opdrachten.ForEach(s => context.Opdrachten.Add(s));
            #endregion

            #region Ritten

            var Ritten = new List<Rit>
            {
                new Rit { RitID=1, NummerPlaat="1-DEF-017", OpdrachtID=1,BeginKm=500,EindKm=600 },
                new Rit { RitID=2, NummerPlaat="1-DEF-017", OpdrachtID=1,BeginKm=600,EindKm=800 },
                new Rit { RitID=3, NummerPlaat="1-DEF-017", OpdrachtID=1,BeginKm=800,EindKm=900 },
                new Rit { RitID=4, NummerPlaat="1-ABC-234", OpdrachtID=2,BeginKm=200,EindKm=800 },
                new Rit { RitID=5, NummerPlaat="1-GGG-234", OpdrachtID=3,BeginKm=200,EindKm=800 },
                new Rit { RitID=6, NummerPlaat="1-DDD-234", OpdrachtID=4,BeginKm=200,EindKm=800 },
                new Rit { RitID=7, NummerPlaat="1-FFF-234", OpdrachtID=5,BeginKm=200,EindKm=800 },
                new Rit { RitID=8, NummerPlaat="1-XXX-234", OpdrachtID=6,BeginKm=200,EindKm=800 },

            };
            Ritten.ForEach(s => context.Ritten.Add(s));
            #endregion

            context.SaveChanges();
        }
    }
}
