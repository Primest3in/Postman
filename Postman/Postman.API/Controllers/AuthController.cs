using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Postman.API.Model.DTO;

namespace Postman.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.UserName
            };
            var identityResult =  await userManager.CreateAsync(identityUser, registerRequestDTO.Password);
            if(identityResult.Succeeded)
            {
                if(registerRequestDTO.Roles != null) 
                { 
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);
                    if(identityResult.Succeeded)
                    {
                        return Ok("User Created");
                    }
                }
            }

            return Ok("Something went wrong");
        }
    }
}
