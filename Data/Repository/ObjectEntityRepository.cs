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
    public class ObjectEntityRepository : BaseRepository<ObjectEntity>, IObjectiveRepostory
    {
        public ObjectEntityRepository(ApplicationContext context) : base(context) { 
        }

        public async Task<List<ObjectEntity>> GetAllObjectEntities(int? userId)
        {
            return await _context.Set<ObjectEntity>()
                                .Where(e => e.UserId == userId).ToListAsync();
        }
    }
}
