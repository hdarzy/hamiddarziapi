using Common.Utilities;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(ApplicationDbContext dbContext):base (dbContext)
        {

        }
        public async Task<User> GetUserByNameFamilypassword(string name , string family , string password , CancellationToken cancellationToken)
        {
            var passhash = SecurityHelper.Getsha256(password);
            return await table.Where(p => p.Name == name && p.Family == family && p.PasswordHash == passhash).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
