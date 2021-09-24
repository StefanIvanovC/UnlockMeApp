using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnlockMe.Data.Models;

namespace UnlockMe.Services.Data
{
    public class ProfilesService// : IProfilesService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ProfilesService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        
    }
}
