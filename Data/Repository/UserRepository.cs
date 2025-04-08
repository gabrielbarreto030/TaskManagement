using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositorys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepostory
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
         return   await _context.Users.FirstAsync(u => u.Email == email); 
        }
    }
}
