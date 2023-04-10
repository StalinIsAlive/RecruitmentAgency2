using Microsoft.AspNetCore.Mvc;
using recruitment_agency.Data;
using recruitment_agency.Models;

namespace recruitment_agency.Controllers
{
    public class AdminController : Controller
    {
        private readonly ReccruimentAgencyDbContext _context;

        public AdminController(ReccruimentAgencyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListApplicant()
        {
            ViewData["applicant"] = _context.applicants.ToList();
            return View();
        }

        public IActionResult ListEmployer()
        {
            ViewData["employer"] = _context.employers.ToList();
            return View();
        }
        public IActionResult ListProfession()
        {
            ViewData["profession"] = _context.professions.ToList();
            return View();
        }

        public IActionResult AddProfession()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProfessionAdd([Bind("Name,Description")] Professions professions)
        {
            _context.professions.Add(professions);
            await _context.SaveChangesAsync();
            return Redirect("~/Admin/ListProfession");
        }

    }
}
