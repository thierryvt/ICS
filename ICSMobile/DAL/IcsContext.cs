using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Validation;

namespace DAL
{
    public class IcsContext : IdentityDbContext<Shared.Entities.Chauffeur>
    {

    }
}
