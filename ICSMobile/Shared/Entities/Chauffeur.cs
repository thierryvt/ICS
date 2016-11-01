using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Shared.Entities
{
    public class Chauffeur : IdentityUser
    {
        public override string Id { get; set; }
        public override string UserName { get; set; }
        public override string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PostalCode { get; set; }


        // Navigation Properties 
        public ICollection<Opdracht> Opdrachten { get; set; }
    }
}
