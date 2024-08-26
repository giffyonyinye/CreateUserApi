using Microsoft.EntityFrameworkCore;


namespace CreateUserApi.Models
{
    public class CreateUser
    {
        public int ID { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
    }
}
