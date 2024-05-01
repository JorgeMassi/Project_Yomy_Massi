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
    public class PostService : IService<Post, int>
    {
        private readonly IRepository<Post, int> _repository;
        private readonly IUserService _userService;
        private readonly IService<Recipe, int> _recipeService;

        public PostService(IRepository<Post, int> repository, IUserService userService, IService<Recipe, int> recipeService)
        {
            _repository = repository;//
            _userService = userService;
            _recipeService = recipeService;
        }

        public Post Create(Post post)
        {
            return _repository.Create(post);
            
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        

        public Post Retrieve(int id)
        {
           return _repository.Retrieve(id);
        }

        public List<Post> RetrieveAll()
        {
            List<Post> posts = _repository.RetrieveAll();   
            foreach (Post post in posts) 
            {
                post.User = _userService.Retrieve(post.User.Id);
                post.Recipes = _recipeService.Retrieve(post.Recipes.Id);
                post.Comment = post.Comment; // preguntar esto si va asi bien.
                post.Rattings = post.Rattings;
            }return posts;  
        }

        public Post Update(Post post)
        {
            return _repository.Update(post);
        }
    }
}

