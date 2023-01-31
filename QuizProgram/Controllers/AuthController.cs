using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizProgram.Models;
using System.Collections.Concurrent;
using System.Data;

namespace QuizProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        private static ConcurrentDictionary<Guid, UserModel> users = new();

        public AuthController(AuthService authService)
        {
            _authService = authService;

            Guid g = Guid.NewGuid();

            users.TryAdd(g, new UserModel() { Id = g, Email = "gribovskiy0709@gmail.com", Password = "1111"});

            Console.WriteLine(users);
        }

        [HttpGet("IsLoggedIn")]
        public IActionResult IsLoggedIn()
        {
            return Ok(new { message = "Ok" });
        }


        [HttpGet("logOut")]
        public IActionResult LogOut()
        {
            Response.Cookies.Delete("token");

            return Ok(new
            {
                message = "You are logged out."
            });
        }

        public record User(string Email, string Password);

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp([FromBody] User account)
        {
            lock (users)
            {
                if(users.Values.FirstOrDefault(x=>x.Email == account.Email) == null)
                {
                    UserModel user = new UserModel() { Id = Guid.NewGuid(), Email = account.Email, Password = account.Password};

                    users.TryAdd(user.Id, user);

                    return Ok(new
                    {
                        Message = "Ok"
                    });
                }
                else
                    return BadRequest();
            }
        }

        [HttpPost("signIn")]
        public async Task<IActionResult> SignIn([FromBody] User account)
        {
            lock (users)
            {
                var user = users.Values.FirstOrDefault(x => x.Email == account.Email && x.Password == account.Password);

                if (user != null)
                {
              
                    Response.Cookies.Append("token", _authService.GetEncodedJwtString(user.Id), new CookieOptions
                    {
                        //Secure = true,
                        HttpOnly = true,
                        Expires = DateTime.Now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME))
                    });

                    return Ok(new
                    {
                        Message = "Ok"
                    });
                }
                else
                    return BadRequest();
            }
        }
    }
}
