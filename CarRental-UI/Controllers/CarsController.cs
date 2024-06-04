using Microsoft.AspNetCore.Mvc;

namespace CarRental_UI.Controllers
{
    public class CarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
