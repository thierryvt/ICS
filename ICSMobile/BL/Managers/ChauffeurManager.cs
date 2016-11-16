﻿using DAL.Repositories.EF;
using DAL.Repositories.Contracts;
using Shared.Entities;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using DAL;
using System;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BL.Managers
{
    public class ChauffeurManager
    {
        private readonly IChauffeurRepository _ChauffeurRepository = new ChauffeurRepository();


        // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
        public class ApplicationUserManager : UserManager<Chauffeur>
        {
            public ApplicationUserManager(IUserStore<Chauffeur> store)
                : base(store)
            {
            }

            public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
            {
                var manager = new ApplicationUserManager(new UserStore<Chauffeur>(context.Get<IcsContext>()));
                // Configure validation logic for usernames
                manager.UserValidator = new UserValidator<Chauffeur>(manager)
                {
                    AllowOnlyAlphanumericUserNames = false,
                    RequireUniqueEmail = true
                };

                // Configure validation logic for passwords
                manager.PasswordValidator = new PasswordValidator
                {
                    RequiredLength = 6,
                    RequireNonLetterOrDigit = true,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                };

                //// Configure user lockout defaults
                //manager.UserLockoutEnabledByDefault = true;
                //manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
                //manager.MaxFailedAccessAttemptsBeforeLockout = 5;

                //// Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
                //// You can write your own provider and plug it in here.
                //manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<Chauffeur>
                //{
                //    MessageFormat = "Your security code is {0}"
                //});
                //manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<Chauffeur>
                //{
                //    Subject = "Security Code",
                //    BodyFormat = "Your security code is {0}"
                //});
                //manager.EmailService = new EmailService();
                //manager.SmsService = new SmsService();
                var dataProtectionProvider = options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<Chauffeur>(dataProtectionProvider.Create("ASP.NET Identity"));
                }
                return manager;
            }
        }

        // Configure the application sign-in manager which is used in this application.
        public class ApplicationSignInManager : SignInManager<Chauffeur, string>
        {
            public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
                : base(userManager, authenticationManager)
            {
            }

            public override Task<ClaimsIdentity> CreateUserIdentityAsync(Chauffeur user)
            {
                return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
            }

            public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
            {
                return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
            }
        }

        // alle chauffeurs ophalen
        public IEnumerable<Chauffeur> AlleChauffeurs()
        {
            return _ChauffeurRepository.GetAllChauffeurs();
        }

        // 1 chauffeur met al zijn opdrachten en bijhorende ritten
        public Chauffeur AlleChauffeursMetOpdrachtRitten(string id)
        {
            return _ChauffeurRepository.FindAlleOpdrachtenRitten(id);
        }

        // 1 specifieke chauffeur
        public Chauffeur FindChauffeur(string id)
        {
            return _ChauffeurRepository.Find(id);
        }

        //public class EmailService : IIdentityMessageService
        //{
        //    public Task SendAsync(IdentityMessage message)
        //    {
        //        // Plug in your email service here to send an email.
        //        return Task.FromResult(0);
        //    }
        //}

        //public class SmsService : IIdentityMessageService
        //{
        //    public Task SendAsync(IdentityMessage message)
        //    {
        //        // Plug in your SMS service here to send a text message.
        //        return Task.FromResult(0);
        //    }
        //}
    }
}
