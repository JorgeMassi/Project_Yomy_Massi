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
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;
        private readonly IService<Recipe, int> _recipeService;
        private readonly IService<Category, int> _categoryService;
        private readonly IService<Difficulty, int> _difficultyService;
        private readonly IIngLineService _serviceIngLine;//
        private readonly IUserService _userService;

        public SearchService(ISearchRepository searchRepository, IService<Recipe, int> recipeService, IService<Category, int> categoryService, IService<Difficulty, int> difficultyService, IIngLineService serviceIngLine, IUserService userService)
        {
            _searchRepository = searchRepository;
            _recipeService = recipeService;
            _categoryService = categoryService;
            _difficultyService = difficultyService;
            _serviceIngLine = serviceIngLine;
            _userService = userService;
        }

        public List<Search> RetrieveRetrieveAllByCategory(int catid)
        {
            List<Search> searches = _searchRepository.RetrieveAllByCategory(catid);

            foreach (Search search in searches)
            {
                search.Author = _userService.Retrieve(search.Author.Id);
                search.Category = _categoryService.Retrieve(search.Category.Id);
                search.Difficulty = _difficultyService.Retrieve(search.Difficulty.Id);
                search.ingredientLines = _serviceIngLine.RetrieveAllByRecipeId(search);
            }
            return searches;
        }
    }
}
