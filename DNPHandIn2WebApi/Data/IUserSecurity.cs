using System.Threading.Tasks;
using Models;

namespace HandIn1.Data
{
    public interface IUserSecurity
    {
        public Task<User> ValidateUser(string UserName, string Password);
    }
}