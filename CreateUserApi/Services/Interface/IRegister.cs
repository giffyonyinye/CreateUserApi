using CreateUserApi.Dtos;
using CreateUserApi.Models;

namespace CreateUserApi.Services.Interface
{
    public interface IRegister
    {
        Task<string> CreateUser(CreateUserDto user);
            
    }
}
