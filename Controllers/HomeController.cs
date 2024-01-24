using Microsoft.AspNetCore.Mvc;

namespace Cargo_Tracking_Application.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return View();
            return Ok("Welcome to the default page!");
        }
    }
}
