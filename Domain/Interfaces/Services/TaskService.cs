using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface TaskService : BaseRepository<TaskEntity>
    {
        Task<List<TaskEntity>> taskEntitiesByObjetiveId(int id);
       
    }
}
