using Data.Context;
using Domain.Entities;
using Domain.Interfaces.Repositorys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.Repository
{
    public class TaskEntityRepository : BaseRepository<TaskEntity>, ITaskRepository
    {
        public TaskEntityRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<List<TaskEntity>> taskEntitiesByObjetiveId(int id)
        {
            return await _context.Set<TaskEntity>()
                           .Where(e => e.ObjectiveId == id).ToListAsync();
        }
    }
}
