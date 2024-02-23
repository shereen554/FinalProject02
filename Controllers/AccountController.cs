
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DTOS;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountController(UserManager<ApplicationUser>userManager ,IConfiguration configuration)
        {
            _userManager = userManager;
            this.configuration = configuration;
          
        }
        private readonly UserManager<ApplicationUser> _userManager;
       private readonly IConfiguration configuration;
        //Register

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterNewUser(RegisterUserDto userDto)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser appuser = new()
                {
                    UserName = userDto.UserName,
                    Email =userDto.Email
                   
                };
                IdentityResult Result = await _userManager.CreateAsync(appuser, userDto.Password);
                if(Result.Succeeded)
                {
                    return Ok("Sucess");
                }
                else
                {
                    foreach (var item in Result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return BadRequest(ModelState);
        }
        //login
        [HttpPost("Login")]
        public async Task<IActionResult> LogIn(dtoLogin login)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser?  user = await _userManager.FindByEmailAsync(login.Email);
                if(user !=null)
                {
                    if (await _userManager.CheckPasswordAsync(user, login.Password))
                    {

                        // Claims Token
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        ///Roles
                        ///
                        var roles = await _userManager.GetRolesAsync(user);

                        var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

                        SigningCredentials signincred =
                            new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            claims: claims,
                            issuer: configuration["JWT:ValidIssuer"],//url web api
                            audience: configuration["JWT:ValidAudiance"],//url consumer angular
                             expires: DateTime.Now.AddHours(1),
                            signingCredentials: signincred
                            );

                        return Ok(new
                        {
                            Token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        });

                        foreach (var role in roles)
                        {
                            claims.Add(new Claim (ClaimTypes.Role, role.ToString()));
                        }

                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email is in valid ");
                }
            }
            return BadRequest(ModelState);
        }
    }
    
}
