using CreateUserApi.Dtos;
using CreateUserApi.Models;
using CreateUserApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CreateUserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IRegister _register;


        public UserController(IConfiguration configuration, IRegister register)
        {
            _configuration = configuration;
            _register = register;
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
            var result = await _register.CreateUser(user);
            return Ok(result);

        }
    }
}
