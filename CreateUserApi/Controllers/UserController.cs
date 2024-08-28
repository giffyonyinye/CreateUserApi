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
        private readonly IGithubUser _githubUser;


        public UserController(IConfiguration configuration, IRegister register, IGithubUser githubUser)
        {
            _configuration = configuration;
            _register = register;
            _githubUser = githubUser;
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
            var result = await _register.CreateUser(user);
            return Ok(result);

        }

        [HttpPost]
        [Route("create-githubuser")]
        public async Task<IActionResult> GithubUser(GithubUserDto githubUser)
        {
            var result = await _githubUser.GithubUser(githubUser);
            return Ok(result);

        }
    }
}
