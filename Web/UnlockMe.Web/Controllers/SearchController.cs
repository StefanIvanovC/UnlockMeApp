namespace UnlockMe.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SearchController : BaseController
    {
        public SearchController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }

        //[HttpGet]
        //public IActionResult List(SearchListInoutModel input)
        //{
        //}
    }
}
