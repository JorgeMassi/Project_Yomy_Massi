using Recipes_Final.Model;
using Recipes_Final.IService.Interface;
using Recipes_Final.Repository.Interface;

namespace Recipes_Final.IService.Implementation
{
    public class CategoryService : IService<Category, int>
    {//
        private readonly IRepository<Category, int> _repository;

        public CategoryService(IRepository<Category, int> _repository)
        {
            this._repository = _repository;
        }

        public Category Create(Category category)
        {
            return _repository.Create(category);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        

        public Category Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Category> RetrieveAll()
        {
            return _repository.RetrieveAll();
        }

        public Category Update(Category category)
        {
            return _repository.Update(category);
        }
    }

    
}
