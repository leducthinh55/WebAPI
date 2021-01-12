using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        public AuthController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginVM loginVM)
        {
            var user = await  _userManager.FindByNameAsync(loginVM.Username);
            bool check = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            if(!check)
            {
                return BadRequest(new { message = "Username or password is not correct"});
            }
            var jwt = await GenerateIdentity(user);
            return Ok(jwt);
        }

        private async Task<String> GenerateIdentity(User user)
        {
            String securityKey = "qwertyuioasdfghjkwertyui1235";
            var symmectricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //signing credentials
            var signingCredentials = new SigningCredentials(symmectricSecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            var roles = await _userManager.GetRolesAsync(user);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                    issuer: "thinh",
                    audience: securityKey,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signingCredentials,
                    claims: claims
                );

            //return token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("CreateAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] UserCM userCM)
        {
            String username = userCM.Username;
            String password = userCM.Password;
            String fullname = userCM.Fullname;
            User user = new User()
            {
                UserName = username,
                FullName = fullname
            };
            var identityResult = await _userManager.CreateAsync(user, password);

            if(identityResult.Errors.Any())
            {
                return BadRequest(new { errors = identityResult.Errors.ToList() });
            }

            identityResult = await _userManager.AddToRoleAsync(user,"KH");

            if (identityResult.Errors.Any())
            {
                return BadRequest(new { errors = identityResult.Errors.ToList() });
            }

            return Ok(GenerateIdentity(user).Result);
        }
    }
}