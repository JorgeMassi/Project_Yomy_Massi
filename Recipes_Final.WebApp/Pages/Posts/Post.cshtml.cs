//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Posts
{
    public class PostModel : PageModel
    {
        private readonly IService<Post, int> _service;

        public PostModel(IService<Post, int> service)
        {
            _service = service;
        }
        public List<Post> Posts { get; set; }
        public User User { get; set; }

        public void OnGet()
        {
            GetUser();
            Posts = _service.RetrieveAll();
        }
        public IActionResult OnPost()
        {
            Post post = new Post();
            post.Id = Convert.ToInt32(Request.Form["id"]);
            post.User.Id = Convert.ToInt32(Request.Form["id_user"]);
            post.Recipes.Id = Convert.ToInt32(Request.Form["id_recipes"]);
            post.Rattings = Convert.ToInt32(Request.Form["ratting"]);
            post.Comment = Convert.ToString(Request.Form["comment"]);

            _service.Create(post);
            return Redirect("/Posts/retrieveall");
        }

        private void GetUser()
        {
            string user = HttpContext.Session.GetString("user");
            if (user != null)
            {
                User = JsonSerializer.Deserialize<User>(user);
            }
        }
    }
}
