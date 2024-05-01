//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Measures
{
    public class MeasuresModel : PageModel
    {
        private readonly IService<Measure, int> _service;

        public MeasuresModel(IService<Measure, int> service)
        {
            _service = service;
        }
        public List<Measure> Measures { get; set; }

        public User User { get; set; }
        public void OnGet()
        {
            GetUser();
            Measures = _service.RetrieveAll();
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
