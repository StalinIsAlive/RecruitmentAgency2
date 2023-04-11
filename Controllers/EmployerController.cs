using Microsoft.AspNetCore.Mvc;
using recruitment_agency.Data;
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
            ViewData["applicant"] = _context.applicants.ToList();
            return View();
        }

        public IActionResult Detail(int id) //resume id
        {
            Resume resume = _context.resumes.Where(a => a.Id == id).FirstOrDefault();
            Professions professions = _context.professions.Where(a => a.Id == resume.ProfessionsId)
                .FirstOrDefault();
            Applicant applicant = _context.applicants.Where(a => a.Id == resume.ApplicantId)
                .FirstOrDefault();
            List<ListWorks> listWorks = _context.listWorks.Where(a => a.ApplicantId==applicant.Id).ToList();
            ViewData["resume"] = resume;
            ViewData["profession"] = professions;
            ViewData["applicant"] = applicant;
            ViewData["listWorks"]=listWorks;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResponseResume () //при нажатии отклик на вакансию
        {
            ResponseResume responseResume = new ResponseResume();
            responseResume.ResumeId = Convert.ToInt32(Request.Form["resume"]);
            responseResume.EmployerId = Convert.ToInt32(Request.Cookies["userId"]); //заменить на получение из куки
            responseResume.Description = Request.Form["description"]; //заменить на переменную запроса

            _context.responseResumes.Add(responseResume);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/Index");
        }

        public IActionResult Profile () //user id
        {
            //замена
            Employer employer = _context.employers.Where(a => a.Id == Convert.ToInt32(Request.Cookies["userId"])).FirstOrDefault();
            ViewData["employer"] = employer;
            ViewData["companyType"] = _context.companyTypes.Where(a=>a.Id==employer.CompanyType).FirstOrDefault();
            ViewData["companyTypeList"] = _context.companyTypes.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit ([Bind("Name,Address,DateOfCreate,Email,Phone,CompanyType")] Employer employer)
        {
            //замена
            Employer employer1 = _context.employers.Where(a => a.Id == Convert.ToInt32(Request.Cookies["userId"])).FirstOrDefault();
            employer1.Name = employer.Name;
            employer1.Address = employer.Address;
            employer1.DateOfCreate= employer.DateOfCreate;
            employer1.Email= employer.Email;
            employer1.Phone= employer.Phone;
            employer1.CompanyType = employer.CompanyType;

            _context.employers.Update(employer1);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/Profile");
        }

        [HttpPost]
        public async Task<IActionResult> EditPass(string Password)
        { //замена
            Employer employer = _context.employers.Where(a => a.Id == Convert.ToInt32(Request.Cookies["userId"])).FirstOrDefault();
            employer.Password = Password;
            _context.employers.Update(employer);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/Profile");
        }

        public IActionResult Vacancy() //user id
        {//изменить на userId cookie
            ViewData["vacancy"] = _context.vacancies.Where(a => a.EmployerId == Convert.ToInt32(Request.Cookies["userId"])).ToList();
            ViewData["profession"] = _context.professions.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VacancyEdit ([Bind("Id,Name,Description,Salary,Post,isVisible,Experience,EmployerId,ProfessionsId")] Vacancy vacancy)
        {
            vacancy.EmployerId= Convert.ToInt32(Request.Cookies["userId"]);
            _context.vacancies.Update(vacancy);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/Vacancy");
        }

        
        public async Task<IActionResult> VacancyDelete(int id)
        {
            Vacancy vacancy = new Vacancy();
            vacancy.Id = id;
            _context.vacancies.Remove(vacancy);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/Vacancy");
        }

        [HttpPost]
        public async Task<IActionResult> VacancyAdd([Bind("Name,Description,Salary,Post,isVisible,Experience,EmployerId,ProfessionId")] Vacancy vacancy)
        {
            vacancy.ProfessionsId =Convert.ToInt32(Request.Form["ProfessionsId"]);
            vacancy.EmployerId= Convert.ToInt32(Request.Cookies["userId"]); //замена
            _context.vacancies.Add(vacancy);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/Vacancy");
        }

        //отправленные отклики
        public IActionResult ResponseList()
        {
            List<Vacancy> vacancies = _context.vacancies.Where(a=>a.EmployerId==2).ToList();
            List<ResponseVacancies> responseVacancies = new List<ResponseVacancies>();
            foreach (var item in vacancies)
            {
                if(_context.responseVacancies.Where(a => a.VacancyId == item.Id && a.isApproved == false && a.isNotApproved == false).FirstOrDefault()!=null) { 
                responseVacancies.Add(_context.responseVacancies.Where(a => a.VacancyId == item.Id && a.isApproved==false && a.isNotApproved==false).FirstOrDefault());
                } else
                {
                    continue;
                }
            }

            List<Applicant> applicants= _context.applicants.ToList();

            ViewData["vacancyRes"] = vacancies;
            ViewData["responseRes"] = responseVacancies;
            ViewData["applicantRes"] = applicants;

            return View();
        }

        //принятие вакансии
        [HttpPost]
        public async Task<IActionResult> ApprovedVacancy(int id,string yes,string no)
        {
            ResponseVacancies response = _context.responseVacancies.Where(a=>a.Id==id).FirstOrDefault();
            
            if(yes!=null)
            {
                response.isApproved = true;
            } else if (no!=null)
            {
                response.isNotApproved = true;

            }
            _context.responseVacancies.Update(response);
            await _context.SaveChangesAsync();
            return Redirect("~/Employer/ResponseList");
        }

        //мои отклики
        public IActionResult MyResponse()
        { // замена
            List<Resume> resumes = _context.resumes.ToList();
            List<ResponseResume> responseResumes = _context.responseResumes.Where(a=>a.EmployerId== Convert.ToInt32(Request.Cookies["userId"])).ToList();
            
/*            foreach (var item in res)
            {
                if (_context.responseVacancies.Where(a => a.VacancyId == item.Id && a.isApproved == false && a.isNotApproved == false).FirstOrDefault() != null)
                {
                    responseVacancies.Add(_context.responseVacancies.Where(a => a.VacancyId == item.Id && a.isApproved == false && a.isNotApproved == false).FirstOrDefault());
                }
                else
                {
                    continue;
                }
            }*/

            List<Applicant> applicants = _context.applicants.ToList();

            ViewData["resume"] = resumes;
            ViewData["responseRes"] = responseResumes;
            ViewData["applicantRes"] = _context.applicants.ToList();

            return View();
        }

    }
}
