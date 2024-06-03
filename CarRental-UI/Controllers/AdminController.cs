using Microsoft.AspNetCore.Mvc;

namespace CarRental_UI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
