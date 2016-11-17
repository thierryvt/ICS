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
                new Chauffeur {Email = "patrickvantillo@gmail.com",FirstName="Patrick",
                    LastName ="Van Tillo",
                    Id = Guid.NewGuid().ToString(),
                    UserName ="patrickvantillo@gmail.com",
                    PasswordHash = hasher.HashPassword("Azerty1234"),
                    SecurityStamp = Guid.NewGuid().ToString()},

                new Chauffeur {Email = "dimitrivantillo@gmail.com",FirstName="Dimitri",
                    LastName ="Van Tillo",
                    Id = Guid.NewGuid().ToString(),
                    UserName ="dimitrivantillo@gmail.com",
                    PasswordHash = hasher.HashPassword("Azerty1234"),
                    SecurityStamp = Guid.NewGuid().ToString()},

                new Chauffeur {Email = "ericvantillo@gmail.com",FirstName="Eric",
                    LastName ="Van Tillo",
                    Id = Guid.NewGuid().ToString(),
                    UserName ="ericvantillo@gmail.com",
                    PasswordHash = hasher.HashPassword("Azerty1234"),
                    SecurityStamp = Guid.NewGuid().ToString()}
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
                new Tankbeurt {TankbeurtID=1, Liter=500,StartKm=500,EindKm=1500,NummerPlaat="1-DEF-017", ChauffeurID = Chauffeurs.ElementAt(0).Id},
                new Tankbeurt {TankbeurtID=2, Liter=555,StartKm=1500,EindKm=3500,NummerPlaat="1-DEF-017", ChauffeurID = Chauffeurs.ElementAt(1).Id},
                new Tankbeurt {TankbeurtID=3, Liter=457,StartKm=3500,EindKm=5000,NummerPlaat="1-DEF-017", ChauffeurID = Chauffeurs.ElementAt(2).Id},
                new Tankbeurt {TankbeurtID=4, Liter=300,StartKm=200,EindKm=1500,NummerPlaat="1-ABC-234", ChauffeurID = Chauffeurs.ElementAt(0).Id}
            };
            Tankbeurten.ForEach(s => context.Tankbeurten.Add(s));
            #endregion

            #region Opdrachten

            var Opdrachten = new List<Opdracht>
            {
                new Opdracht { Naam = "Vermeylen Referentienummer 1", NummerPlaat =Vrachtwagens.ElementAt(0).NummerPlaat, ChauffeurID = Chauffeurs.ElementAt(0).Id, OpdrachtID=1, Afgehandeld = false},
                new Opdracht { Naam = "Amazon Referentienummer XYZFDF",NummerPlaat =Vrachtwagens.ElementAt(1).NummerPlaat, ChauffeurID = Chauffeurs.ElementAt(1).Id, OpdrachtID=2, Afgehandeld = false},
                new Opdracht { Naam = "Bol 123 AAA",NummerPlaat =Vrachtwagens.ElementAt(2).NummerPlaat, ChauffeurID = Chauffeurs.ElementAt(2).Id, OpdrachtID=3, Afgehandeld = false},
                new Opdracht { Naam = "Coolblue AAfgdfg58887",NummerPlaat =Vrachtwagens.ElementAt(3).NummerPlaat, ChauffeurID = Chauffeurs.ElementAt(0).Id, OpdrachtID=4, Afgehandeld = true},
                new Opdracht { Naam = "MCS Titonic 899",NummerPlaat =Vrachtwagens.ElementAt(4).NummerPlaat, ChauffeurID = Chauffeurs.ElementAt(1).Id, OpdrachtID=5, Afgehandeld = false},
                new Opdracht { Naam = "Zink etgfg5",NummerPlaat =Vrachtwagens.ElementAt(5).NummerPlaat, ChauffeurID = Chauffeurs.ElementAt(2).Id, OpdrachtID=6, Afgehandeld = true },

            };
            Opdrachten.ForEach(s => context.Opdrachten.Add(s));
            #endregion

            #region Ritten

            var Ritten = new List<Rit>
            {
                new Rit { RitID=1, NummerPlaat=Opdrachten.ElementAt(0).NummerPlaat, OpdrachtID=1,BeginKm=500,EindKm=600 },
                new Rit { RitID=2, NummerPlaat=Opdrachten.ElementAt(0).NummerPlaat, OpdrachtID=1,BeginKm=600,EindKm=800 },
                new Rit { RitID=3, NummerPlaat=Opdrachten.ElementAt(0).NummerPlaat, OpdrachtID=1,BeginKm=800,EindKm=900 },
                new Rit { RitID=4, NummerPlaat=Opdrachten.ElementAt(1).NummerPlaat, OpdrachtID=2,BeginKm=200,EindKm=800 },
                new Rit { RitID=5, NummerPlaat=Opdrachten.ElementAt(2).NummerPlaat, OpdrachtID=3,BeginKm=200,EindKm=800 },
                new Rit { RitID=6, NummerPlaat=Opdrachten.ElementAt(3).NummerPlaat, OpdrachtID=4,BeginKm=200,EindKm=800 },
                new Rit { RitID=7, NummerPlaat=Opdrachten.ElementAt(4).NummerPlaat, OpdrachtID=5,BeginKm=200,EindKm=800 },
                new Rit { RitID=8, NummerPlaat=Opdrachten.ElementAt(5).NummerPlaat, OpdrachtID=6,BeginKm=200,EindKm=800 },

            };
            Ritten.ForEach(s => context.Ritten.Add(s));
            #endregion

            context.SaveChanges();
        }
    }
}
