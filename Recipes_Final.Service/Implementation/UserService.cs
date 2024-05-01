using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Repository.Implementation;
using Recipes_Final.Repository.Interface;
using Recipes_Final.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;// la clase no puede controlar como específicamente guardar. Se trabaja con Interfaces.

        public UserService(IUserRepository _repository)
        {//
            this._repository = _repository;
        }

        public User Create(User user)
        {
            return _repository.Create(user);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public User Login(string username, string password)
        {
            return _repository.Login(username , password);
        }

        public User Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<User> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public User Update(User user)
        {
            return _repository.Update(user);
        }
    }
}
