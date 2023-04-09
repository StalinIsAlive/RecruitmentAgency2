using Microsoft.AspNetCore.Mvc;
using recruitment_agency.Data;
using recruitment_agency.DAO;
using recruitment_agency.Models;

namespace recruitment_agency.Controllers
{
    public class EmployerController : Controller
    {
        private readonly ReccruimentAgencyDbContext _context;

        public EmployerController(ReccruimentAgencyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() //заменить на id залогинного юзера
        {

            ViewData["resumes"] = _context.resumes.Where(a=>a.isVisible).ToList();
            ViewData["profession"] = _context.professions.ToList();
            return View();
        }

        public IActionResult Detail(int id) //resume id
        {
            //int id = 0;
            // = id;
            //id = Convert.ToInt32(Request.RouteValues["id"]);
            //Resume resume = 
            ViewData["resume"] = _context.resumes.Where(a => a.Id == id).FirstOrDefault();
            ViewData["id"] = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResponseResume (int id, string description) //при нажатии отклик на вакансию
        {
            ResponseWork responseWork = new ResponseWork();
            responseWork.Id = id;
            responseWork.Description = description;

            _context.responseWorks.Add(responseWork);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/Index");
        }

        public IActionResult Profile (int id) //user id
        {
            ViewData["profileInfo"] = _context.employers.Where(a=> a.Id==id).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit (int id, [Bind("Name,Description,Salary,Post,isVisible,Experience,EmployerId,ProfessionId")] Employer employer)
        {
            employer.Id = id;
            _context.employers.Update(employer);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/Vacancy");
        }

        public IActionResult Vacancy(int id) //user id
        {
            ViewData["vacancy"] = _context.vacancies.Where(a => a.EmployerId == id).FirstOrDefault();
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VacancyEdit (int id, [Bind("Name,Description,Salary,Post,isVisible,Experience,EmployerId,ProfessionId")] Vacancy vacancy)
        {
            vacancy.Id = id;
            _context.vacancies.Update(vacancy);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/Vacancy");
        }

        [HttpPost]
        public async Task<IActionResult> VacancyDelete(int id)
        {
            Vacancy vacancy = new Vacancy();
            vacancy.Id = id;
            _context.vacancies.Remove(vacancy);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/Vacancy");
        }

        [HttpPost]
        public async Task<IActionResult> VacancyAdd(int id, [Bind("Name,Description,Salary,Post,isVisible,Experience,EmployerId,ProfessionId")] Vacancy vacancy)
        {
            vacancy.Id = id;
            _context.vacancies.Add(vacancy);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/Vacancy");
        }
    }
}
