namespace UnlockMe.Data
{
    using System;

    using Microsoft.AspNetCore.Identity;

    public static class IdentityOptionsProvider
    {
        public static void GetIdentityOptions(IdentityOptions options)
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;

            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 0, 30);

            options.SignIn.RequireConfirmedEmail = true;

            options.User.RequireUniqueEmail = true;
        }
    }
}
