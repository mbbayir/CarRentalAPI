using Microsoft.AspNetCore.Mvc;

namespace CarRental_UI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
