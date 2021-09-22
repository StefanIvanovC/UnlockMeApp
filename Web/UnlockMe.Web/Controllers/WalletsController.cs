namespace UnlockMe.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class WalletsController : Controller
    {
        public IActionResult MyWallet()
        {
            return this.View();
        }
    }
}
