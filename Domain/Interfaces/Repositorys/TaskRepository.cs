using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositorys
{
    public interface ITaskRepository : IBaseRepository<TaskEntity>
    {
        Task<List<TaskEntity>> taskEntitiesByObjetiveId(int id);
    }
}
