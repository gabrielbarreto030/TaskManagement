using Domain.Entities;
using Domain.Interfaces.Repositorys;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{

    public class ObjectiveService : IObjectiveService
    {
        private readonly IObjectiveRepostory _objectiveRepository;


        public ObjectiveService(IObjectiveRepostory objectiveRepository)
        {
            _objectiveRepository = objectiveRepository;
        }


        public async Task<ObjectEntity> Add(ObjectEntity entity)
        {
            return await _objectiveRepository.Add(entity);
        }


        public async Task<ObjectEntity> Delete(ObjectEntity entity)
        {
            return await _objectiveRepository.Delete(entity);
        }


        public async Task<List<ObjectEntity>> GetAll()
        {
            return await _objectiveRepository.GetAll();
        }


        public async Task<ObjectEntity> GetById(int id)
        {
            return await _objectiveRepository.GetById(id);
        }


        public async Task<ObjectEntity> Update(ObjectEntity entity)
        {
            return await _objectiveRepository.Update(entity);
        }


        public async Task<List<ObjectEntity>> GetAllObjectEntities(int? userId)
        {
           
            if (userId.HasValue)
            {
                return await _objectiveRepository.GetAllObjectEntities(userId.Value);
            }
            else
            {
                return await _objectiveRepository.GetAll(); 
            }
        }
    }
}
