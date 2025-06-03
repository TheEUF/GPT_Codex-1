using Microsoft.AspNetCore.Mvc;

namespace TodoMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
