using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNPHandIn2WebApi.Persistance;
using HandIn1.Data;
using Models;

namespace DNPHandIn2WebApi.Data
{
    public class UserSecurity : IUserSecurity
    {
        
        private readonly CustomDbContext _dbContext;
        
        public UserSecurity(CustomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<User> ValidateUser(string userName, string password) {
            User first = _dbContext.Users.FirstOrDefault(user => user.Username.Equals(userName));
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