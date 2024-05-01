using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Service.Implementation
{
    public class DifficultyService : IService<Difficulty, int>
    {//
        private readonly IRepository<Difficulty, int> _repository;
      
        public DifficultyService(IRepository<Difficulty, int> repository)
        {
            _repository = repository;
        }   

        public Difficulty Create(Difficulty difficulty) 
        {
            return _repository.Create(difficulty);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        

        public Difficulty Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Difficulty> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Difficulty Update(Difficulty difficulty)
        {
            return _repository.Update(difficulty);
        }
    }
}
