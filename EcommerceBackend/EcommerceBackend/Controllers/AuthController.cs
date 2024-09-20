using EcommerceBackend.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserModel userModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = new IdentityUser()
                {
                    Email = userModel.Email,
                    UserName = userModel.Email
                };

                var result = await _userManager.CreateAsync(user, userModel.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(ModelState);
                }

                return Accepted();

            }
            catch (Exception ex)
            {
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
            }

        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserModel userModel) // using Identity SignIn
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, true, false);

                if (!result.Succeeded)
                {
                    return Unauthorized(userModel);
                }

                return Accepted(new { userModel.Email });

            }
            catch (Exception ex)
            {
                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }

        }

        [HttpGet]
        [Route("checkAuth")]
        public async Task<IActionResult> CheckUser() // using Identity SignIn
        {

            if (User.Identity.IsAuthenticated)
            {
                return Ok(new { Email = User.Identity.Name });
            }


            return NoContent();

        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout() // using Identity SignIn
        {

            try
            {
                await _signInManager.SignOutAsync();

                return Ok();

            }
            catch (Exception ex)
            {
                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }

        }

    }
}
