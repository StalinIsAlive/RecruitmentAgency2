using Microsoft.AspNetCore.Mvc;

namespace recruitment_agency.Controllers
{
    public class EmployerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
