using Activity26.Data;
using Activity26.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace Activity26.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDBcontext _dbcontext;
        private readonly IConfiguration _config;

        public AuthController(AppDBcontext dbcontext,IConfiguration configuration)
        {
            _dbcontext = dbcontext;
            _config = configuration;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(UserRegisterReq registerReq)
        {
            try
            {
                var UserRegister = new User()
                {
                    name = registerReq.name,
                    email = registerReq.email,
                    password = BCrypt.Net.BCrypt.HashPassword(registerReq.password),
                    phone = registerReq.phone,
                    Address=registerReq.Address,
                    role=registerReq.role,
                };

                var data= await _dbcontext.AddAsync(UserRegister);
                await _dbcontext.SaveChangesAsync();
                var res=createToken();
                return Ok(res);
            }
              catch(Exception ex)
             {
                 return BadRequest(ex.Message);
             }
        }

        //[HttpGet]
        private TokenModel createToken()
        {
            var key = _config["Jwt:key"];
            var seckey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
            var credentials = new SigningCredentials(seckey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                //claims:
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );

            var res = new TokenModel();
            res.token = new JwtSecurityTokenHandler().WriteToken(token);
            return res;

        }


        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LoginReq loginReq)
        {
            try
            {
              var user= await _dbcontext.Users.SingleOrDefaultAsync(r=>r.email== loginReq.Email);
                if (user != null) 
                {
  
                    var IsValid = BCrypt.Net.BCrypt.Verify(loginReq.Password, user.password);
                    if (IsValid)
                    {
                        var res = createToken();
                        return Ok (res);

                    }
                    else
                    {
                        return BadRequest("invalid password");
                       
                    }

                }
                else
                {
                  return BadRequest("User not found");
                }
            
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Check()
        {
            try
            {
               // var role = User.FindFirst("Role").Value;

                return Ok("hello");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        }
    }
