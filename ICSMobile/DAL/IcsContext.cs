using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shared.Entities;

namespace DAL
{
    [DbConfigurationType(typeof(ICSConfiguration))]
    public class IcsContext : IdentityDbContext<Chauffeur>
    {
        public IcsContext() : base("IcsContext")
        {
            Database.SetInitializer(new ICSInitializer());
        }
        public override IDbSet<Chauffeur> Users { get; set; }
        public DbSet<Opdracht> Opdrachten { get; set; }
        public DbSet<Rit> Ritten { get; set; }
        public DbSet<Tankbeurt> Tankbeurten { get; set; }
        public DbSet<Vrachtwagen> Vrachtwagens { get; set; }

        
        public static IcsContext Create()
        {
            return new IcsContext();
        }
    }   
}
