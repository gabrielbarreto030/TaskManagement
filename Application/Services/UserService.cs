using Data.Repository;
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
    public class UserService : IUserService
    {
        private readonly IUserRepostory _userRepository;


        public UserService(IUserRepostory userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<User> Add(User entity)
        {
            return await _userRepository.Add(entity);
        }


        public async Task<User> Delete(User entity)
        {
            return await _userRepository.Delete(entity);
        }


        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }


        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }


        public async Task<User> Update(User entity)
        {
            return await _userRepository.Update(entity);
        }


        public async Task<bool> Login(string email, string password)
        {
           
            var user = await _userRepository.GetByEmail(email);
            if (user != null && user.Password == password) 
            {
                return true;
            }
            return false;
        }
    }
}
