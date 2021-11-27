using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandIn1.Data;
using Models;

namespace DNPHandIn2WebApi.Data
{
    public class UserSecurity : IUserSecurity
    {
        
        private List<User> users;

        public UserSecurity()
        {
            users = new[]
            {
                new User()
                {
                    Username = "Tomas",
                    Password = "Tomas",
                    CredentialLevel = 1
                }
            }.ToList();
        }

       
          


        public async Task<User> ValidateUser(string userName, string password) {
            User first = users.FirstOrDefault(user => user.Username.Equals(userName));
            if (first == null)
            {
                return null;
            }

            if (!first.Password.Equals(password))
            {
                return null;
            }

            return first;
        }
        
        
       
    }
}