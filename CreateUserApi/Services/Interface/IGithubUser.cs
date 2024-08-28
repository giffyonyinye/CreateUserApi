using CreateUserApi.Dtos;
using CreateUserApi.Models;


namespace CreateUserApi.Services.Interface
{
    public interface IGithubUser
    {
        Task<string> GithubUser(GithubUserDto githubUser);
    }
}
