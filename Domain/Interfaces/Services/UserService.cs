using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<bool>  Login(string username, string password);
        
    }
}
