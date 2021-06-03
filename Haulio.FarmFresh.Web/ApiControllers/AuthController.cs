using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Haulio.FarmFresh.Utility;
using Haulio.FarmFresh.BusinessLogic.Services;
using Haulio.FarmFresh.Web.Models;
using Microsoft.AspNetCore.Http;

namespace Haulio.FarmFresh.Web.Controllers
{
    [Route("api/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration iConfig)
        {
            this._userService = userService;
            this._configuration = iConfig;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        { 
            var loginResult = await _userService.GetAuthUser(model.UserName, model.Password);

            string Secret = _configuration.GetSection("AppSettings").GetSection("Secret").Value;
            int ExpiredInSecond = _configuration.GetSection("AppSettings").GetSection("ExpiredInSecond").Value.ParseInt(600);

            var accessToken = TokenUtility.CreateAccessToken(loginResult.UserId, loginResult.Username, ExpiredInSecond, Secret);

            HttpContext.Session.SetString("Token", accessToken.access_token);
            return Ok(accessToken);
        }
    }
}
