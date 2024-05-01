//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Recipes_Final.IService.Interface;
using Recipes_Final.Model;
using System.Text.Json;

namespace Recipes_Final.WebApp.Pages.Measures
{
    public class MeasureUpdateModel : PageModel
    {
        private readonly IService<Measure, int> _service;

        public MeasureUpdateModel(IService<Measure, int> service)
        {
            _service = service;
        }

        public Measure Measure { get; set; }
        public User User { get; set; }
        public void OnGet(int id)
        {
            GetUser();
            Measure = _service.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(Request.Form["id"]);
            measure.Name = Convert.ToString(Request.Form["name"]);

            _service.Update(measure);
            return Redirect("/Measures/MeasureRetrieveAll");

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
