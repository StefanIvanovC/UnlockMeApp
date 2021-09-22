namespace UnlockMe.Web.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using UnlockMe.Services.Data;
    using UnlockMe.Web.ViewModels.Hearts;

    [ApiController]
    [Route("api/[Controller]")]
    public class HeartsController : BaseController
    {
        private readonly IHeartsService heartsService;

        public HeartsController(IHeartsService heartsService)
        {
            this.heartsService = heartsService;
        }

        [HttpPost]
        [Authorize]
        [IgnoreAntiforgeryToken]
        public async Task<ResponseHeartsViewModel> GiveHeart(GiveHeartsInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await this.heartsService.SetHeartAsync(input.PostId, userId, input.Value);
            var getNewCountOfHerts = this.heartsService.GetHeartsCount(input.PostId) + 1;
            return new ResponseHeartsViewModel { NewHeartCount = getNewCountOfHerts };
        }
    }
}
