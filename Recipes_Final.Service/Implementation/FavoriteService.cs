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
    public class FavoriteService : IService<Favorite, int>
    {
        private readonly IRepository<Favorite, int> _repository;
        private readonly IUserService _userService;//
        private readonly IService<Recipe, int> _recipeService;

        public FavoriteService(IRepository<Favorite, int> repository, IUserService userService, IService<Recipe, int> recipeService)
        {
            _repository = repository;
            _userService = userService;
            _recipeService = recipeService;
        }



        /*/public FavoriteService(IRepository<Favorite, int> _repository, IService<User, int> userService, IService<Recipe, int> recipeService)
        {
            this._repository = _repository;
            this._userService = userService;
        }*/

        public Favorite Create(Favorite favorite)
        {
            return _repository.Create(favorite);

        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        

        public Favorite Retrieve(int id)
        {
            return _repository.Retrieve(id);
        }

        public List<Favorite> RetrieveAll()
        {
            List<Favorite> favorites = _repository.RetrieveAll();

            foreach (Favorite favorite in favorites)
            {
                
                
                favorite.User = _userService.Retrieve(favorite.User.Id);
                favorite.Recipe = _recipeService.Retrieve(favorite.Recipe.Id);

            }
            return favorites;
        }

        public Favorite Update(Favorite favorite)
        {
            return _repository.Update(favorite);
        }
    }
}
