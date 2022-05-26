using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPIJWT2.Helpers;
using WEBAPIJWT2.Models;

namespace WEBAPIJWT2.Controllers
{
    [Route("Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginHelper loginHelper;

        public LoginController(LoginHelper loginHelper)
        {
            this.loginHelper = loginHelper;
        }
        /// <summary>
        /// Login in Virtual Lab API
        /// </summary>
        /// <param name="userLogin">User and pass</param>
        /// <response code="401">Unauthorized. Wrong user and password.</response>              
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public IActionResult Login(UserLogin userLogin)
        {

            if (userLogin == null)
                return BadRequest("user and password required.");

            var _userInfo = loginHelper.authenticateUserAsync(userLogin.Username, userLogin.Password);
            _userInfo.Wait();
            if (_userInfo.Result != null)
            {
                return Ok(new { token = loginHelper.GenerateTokenJWT(_userInfo.Result) });
            }
            else
            {
                return Unauthorized();
            }
        }
        /// <summary>
        /// Test login in Virtual Lab API
        /// </summary>
        /// <param name="userLogin">User and pass</param>
        /// <response code="401">Unauthorized. JWT Token wrong.</response>    
        [HttpGet]
        [Authorize]
        [Route("LoginTest")]
        public IActionResult LoginTest()
        {
            return Ok(new { Message = "Successful user login." });
        }
        /// <summary>
        /// Test login in Virtual Lab API
        /// </summary>
        /// <param name="userLogin">User and pass</param>
        /// <response code="401">Unauthorized. JWT Token wrong.</response>    
        [HttpPost]
        [Authorize]
        [Route("TestPost")]
        public UserLogin TestPost(UserLogin userLogin)
        {
            userLogin.Username+="aaaaaaaa";

            return userLogin;
        }
    }
}
