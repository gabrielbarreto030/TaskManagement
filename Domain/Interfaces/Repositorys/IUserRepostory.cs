﻿using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositorys
{
    public interface IUserRepostory : IBaseRepository<User>
    {
        Task<User> GetByEmail(string email);    
    }
}
