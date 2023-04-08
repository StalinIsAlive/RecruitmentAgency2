using Microsoft.AspNetCore.Mvc;

namespace recruitment_agency.Controllers
{
    public class ApplicantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
