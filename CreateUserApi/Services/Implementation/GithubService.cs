using CreateUserApi.Dtos;
using CreateUserApi.Services.Interface;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;


namespace CreateUserApi.Services.Implementation
{
    public class GithubService: IGithubUser
    {
        private readonly IConfiguration _configuration;

        public GithubService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GithubUser(GithubUserDto githubUser)
        {
            try
            {
                SqlConnection con = new SqlConnection(_configuration.GetConnectionString("UserCon").ToString());
                await con.OpenAsync();

                SqlCommand findUser = new SqlCommand("SELECT COUNT(1) FROM GithubUser WHERE Username = '" + githubUser.Username + "'", con);
                //findUser.Parameters.AddWithValue("@Username", githubUser.Username);
                int userCount = (int)await findUser.ExecuteScalarAsync();
                con.Close();

                if (userCount > 0)
                {
                    return "User already exists in the database.";
                }

                var username = githubUser.Username;
                string url = url = $"https://api.github.com/users/{username}";
                using (HttpClient client = new HttpClient())
                {
                   client.DefaultRequestHeaders.Add("User-Agent", "request");

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string result = await response.Content.ReadAsStringAsync();
                    SqlCommand cmd = new SqlCommand("INSERT INTO GithubUser(Username) VALUES('" + githubUser.Username + "')", con);
                    con.Open();
                    await cmd.ExecuteNonQueryAsync();
                    con.Close();

                    return result;
                }

            }
            catch (Exception ex) {
                return ex.Message;
            }
        }
    }
}
