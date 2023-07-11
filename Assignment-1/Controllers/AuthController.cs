using Assignment_1.Models.DTO;
using System.Net;
using Assignment_1.Repository.IRepository;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_1.Controllers
{
    [Route("api/UserAuth")]
    [ApiController]
    public class AuthController : Controller
    {
       
      
            private readonly IAuthRepository _authRepository;
         
            public AuthController(IAuthRepository authRepository)
            {
             _authRepository = authRepository;
            }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            var loginResponse = await _authRepository.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                ModelState.AddModelError("Custom Error", "Name & password Invalid!!");
                return BadRequest(ModelState);
               
            }
           
            return Ok(loginResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO registrationRequestDTO)
        {
            bool ifUserNameUnique = _authRepository.IsUniqueUser(registrationRequestDTO.Name);
            if (!ifUserNameUnique)
            {
                return BadRequest(new { message = "Username already exists" });
            }
            var user = await _authRepository.Register(registrationRequestDTO);
            if (user == null)
            {
                return BadRequest(new { message = "Error while registering" });
            }
            return Ok(registrationRequestDTO);
        }
    }
}
