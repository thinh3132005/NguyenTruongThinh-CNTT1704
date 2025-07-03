using Microsoft.AspNetCore.Mvc;

namespace MedicalBooking.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}