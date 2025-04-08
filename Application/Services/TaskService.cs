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
    public class TaskService : ITaskService
    {
        public ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository) { 
        
          _taskRepository= taskRepository;
        }
        public  async Task<TaskEntity> Add(TaskEntity entity)
        {
          return await _taskRepository.Add(entity);    
        }

        public async Task<TaskEntity> Delete(TaskEntity entity)
        {
            return await _taskRepository.Delete(entity);
        }

        public async Task<List<TaskEntity>> GetAll()
        {
            return await _taskRepository.GetAll();
        }

        public async Task<TaskEntity> GetById(int id)
        {
            return await _taskRepository.GetById(id);
        }

        public async Task<List<TaskEntity>> taskEntitiesByObjetiveId(int id)
        {
            return await _taskRepository.taskEntitiesByObjetiveId(id);
        }

        public async Task<TaskEntity> Update(TaskEntity entity)
        {
            return await _taskRepository.Update(entity);
        }
    }
}
