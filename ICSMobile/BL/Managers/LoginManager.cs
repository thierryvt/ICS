using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers
{
    // Configure the application sign-in manager which is used in this application.
    public class LoginManager : SignInManager<Chauffeur, string>
    {
        public LoginManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
               

        public static LoginManager Create(IdentityFactoryOptions<LoginManager> options, IOwinContext context)
        {
            return new LoginManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(Chauffeur user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }
    }
}
