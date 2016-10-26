using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities
{
    public class Chauffeur : IdentityUser
    {
        public override string Id { get; set; }
        public override string UserName { get; set; }
        public override string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PostalCode { get; set; }
    }
}
