using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositorys;
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
    }
}
