using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using Recipes_Final.Repository.Interface;
using Recipes_Final.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes_Final.Service.Implementation
{
    public class RecipesService : IService<Recipe, int>
    {
        private readonly IRepository<Recipe, int> _repository;
        private readonly IUserService _userService;
        private readonly IService<Category, int> _categoryService;
        private readonly IService<Difficulty, int> _difficultyService;
        //private readonly IIngLineService _ingLineService;

        public RecipesService(IRepository<Recipe, int> _repository, //
            IUserService _userService, 
            IService<Category, int> _categoryService, 
            IService<Difficulty, int> _difficultyService)
        {
            this._repository = _repository;
            this._userService = _userService;
            this._categoryService = _categoryService;
            this._difficultyService = _difficultyService;

        }
        

        public Recipe Create(Recipe recipe)
        {
            return _repository.Create(recipe);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

       

        public Recipe Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

              
         
        public List<Recipe> RetrieveAll()
        {
            List<Recipe> recipes = _repository.RetrieveAll();

            foreach (Recipe recipe in recipes)
            {
                recipe.Author = _userService.Retrieve(recipe.Author.Id);
                recipe.Category = _categoryService.Retrieve(recipe.Category.Id);
                recipe.Difficulty = _difficultyService.Retrieve(recipe.Difficulty.Id);
                //recipe.ingredientLines = _ingLineService.RetrieveAllByRecipeId(recipe.Id);

			}
            return recipes;
        }

		

		public Recipe Update(Recipe recipe)
        {
            return _repository.Update(recipe);
        }
    }
}