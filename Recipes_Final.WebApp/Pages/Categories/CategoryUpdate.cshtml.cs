using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Categories
{
    public class CategoryUpdateModel : PageModel
    {
        private readonly IService<Category, int> _service;

        public CategoryUpdateModel(IService<Category, int> service)
        {
            _service = service;
        }

        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }

        public void OnGet(int id)
        {
            GetUser();
            Category = _service.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Category category = new Category();
            category.Id = Convert.ToInt32(Request.Form["id"]);
            category.Name = Convert.ToString(Request.Form["name"]);

            _service.Update(category);
            return Redirect("/Categories/CategoryRetrieveAll");

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
