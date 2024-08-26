using CreateUserApi.Dtos;
using CreateUserApi.Services.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CreateUserApi.Services.Implementation
{
    public class RegisterService : IRegister
    {
        private readonly IConfiguration _configuration;

        public RegisterService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateUser(CreateUserDto user)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("UserCon").ToString());
            SqlCommand cmd = new SqlCommand("INSERT INTO Users(Username, Email) VALUES('" + user.Username + "', '" + user.Email + "' )", con);
            con.Open();
            await cmd.ExecuteNonQueryAsync();
            con.Close();

            return "Successful";
        }
    }
}
