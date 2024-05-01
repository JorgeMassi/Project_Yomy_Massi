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
    public class IngredientService : IService<Ingredient, int>
    {
        private readonly IRepository<Ingredient, int> _repository;

        public IngredientService(IRepository<Ingredient, int> _repository)
        {
            this._repository = _repository;
        }//

        public Ingredient Create(Ingredient ingredient)
        {
            return _repository.Create(ingredient);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public Ingredient Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Ingredient Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Ingredient> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

		

		public Ingredient Update(Ingredient ingredient)
        {
            return _repository.Update(ingredient);
        }
    }
}
