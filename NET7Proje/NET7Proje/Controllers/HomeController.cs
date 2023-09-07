using Microsoft.AspNetCore.Mvc;

namespace NET7Proje.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
