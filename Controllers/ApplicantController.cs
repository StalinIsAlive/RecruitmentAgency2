using Microsoft.AspNetCore.Mvc;
using recruitment_agency.Data;
using recruitment_agency.Models;

namespace recruitment_agency.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly ReccruimentAgencyDbContext _context;

        public ApplicantController(ReccruimentAgencyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index() //заменить на id залогинного юзера
        {

            ViewData["vacancies"] = _context.vacancies.Where(a => a.isVisible).ToList();
            ViewData["profession"] = _context.professions.ToList();
            ViewData["employer"] = _context.employers.ToList();
            return View();
        }

        public IActionResult Detail(int id) //vacancy id
        {
            Vacancy vacancy = _context.vacancies.Where(a => a.Id == id).FirstOrDefault();
            Professions professions = _context.professions.Where(a => a.Id == vacancy.ProfessionsId)
                .FirstOrDefault();
            Employer employer= _context.employers.Where(a => a.Id == vacancy.EmployerId)
                .FirstOrDefault();
           // List<ListWorks> listWorks = _context.listWorks.Where(a => a.ApplicantId == applicant.Id).ToList();
            ViewData["vacancy"] = vacancy;
            ViewData["profession"] = professions;
            ViewData["employer"] = employer;
            //ViewData["listWorks"] = listWorks;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResponseVacancy() //при нажатии отклик на вакансию
        {
            ResponseVacancies responseVacancies = new ResponseVacancies();
            responseVacancies.VacancyId = Convert.ToInt32(Request.Form["vacancy"]);
            responseVacancies.ApplicantId = Convert.ToInt32(Request.Cookies["userId"]); //заменить на получение из куки
            responseVacancies.Description = Request.Form["description"]; //заменить на переменную запроса

            _context.responseVacancies.Add(responseVacancies);
            await _context.SaveChangesAsync();
            return Redirect("~/Applicant/Index");
        }

        public IActionResult Profile() //user id
        {
            //замена
            Applicant applicant= _context.applicants.Where(a => a.Id == Convert.ToInt32(Request.Cookies["userId"])).FirstOrDefault();
            ViewData["applicant"] = applicant;
            ViewData["listWorks"] = _context.listWorks.Where(a => a.ApplicantId== applicant.Id).ToList();
            ViewData["profession"] = _context.professions.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit([Bind("FirstName,LastName,SecondName,Address,Education,Email,Phone")] Applicant applicant)
        {
            //замена
            Applicant applicant1= _context.applicants.Where(a => a.Id == Convert.ToInt32(Request.Cookies["userId"])).FirstOrDefault();
            applicant1.LastName= applicant.LastName;
            applicant1.Address = applicant.Address;
            applicant1.SecondName= applicant.SecondName;
            applicant1.Email = applicant.Email;
            applicant1.Phone = applicant.Phone;
            applicant1.FirstName = applicant.FirstName;
            applicant1.Education = applicant.Education;

            _context.applicants.Update(applicant1);
            await _context.SaveChangesAsync();
            return Redirect("~/Applicant/Profile");
        }

        [HttpPost]
        public async Task<IActionResult> EditPass(string Password)
        { //замена
            Applicant applicant= _context.applicants.Where(a => a.Id == Convert.ToInt32(Request.Cookies["userId"])).FirstOrDefault();
            applicant.Password = Password;
            _context.applicants.Update(applicant);
            await _context.SaveChangesAsync();
            return Redirect("~/Applicant/Profile");
        }

        [HttpPost]
        public async Task<IActionResult> AddWork([Bind("CompanyName,DateStart,DateEnd,Description,Post,Profession")] ListWorks listWorks)
        { //замена
            listWorks.ApplicantId= Convert.ToInt32(Request.Cookies["userId"]);
            _context.listWorks.Add(listWorks);
            await _context.SaveChangesAsync();
            return Redirect("~/Applicant/Profile");
        }

        public IActionResult Resume() //user id
        {//изменить на userId cookie
            ViewData["resume"] = _context.resumes.Where(a => a.ApplicantId == Convert.ToInt32(Request.Cookies["userId"])).ToList();
            ViewData["profession"] = _context.professions.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResumeEdit([Bind("Id,Description,Salary,isVisible,ApplicantId,ProfessionsId")] Resume resume)
        {
            resume.ApplicantId  = Convert.ToInt32(Request.Cookies["userId"]);
            _context.resumes.Update(resume);
            await _context.SaveChangesAsync();
            return Redirect("~/Applicant/Resume");
        }

        public async Task<IActionResult> ResumeDelete(int id)
        {
            Resume resume= new Resume();
            resume.Id = id;
            _context.resumes.Remove(resume);
            await _context.SaveChangesAsync();
            return Redirect("~/Applicant/Resume");
        }

        [HttpPost]
        public async Task<IActionResult> ResumeAdd([Bind("Description,Salary,isVisible,ApplicantId,ProfessionId")] Resume resume)
        {
            resume.ProfessionsId = Convert.ToInt32(Request.Form["ProfessionsId"]);
            resume.ApplicantId= Convert.ToInt32(Request.Cookies["userId"]); //замена
            _context.resumes.Add(resume);
            await _context.SaveChangesAsync();
            return Redirect("~/Applicant/Resume");
        }

        //отправленные отклики
        public IActionResult ResponseList()
        {//замена
            List<Resume> resumes= _context.resumes.Where(a => a.ApplicantId== Convert.ToInt32(Request.Cookies["userId"])).ToList();
            List<ResponseResume> responseResumes= new List<ResponseResume>();
            foreach (var item in resumes)
            {
                if (_context.responseResumes.Where(a => a.ResumeId== item.Id && a.isApproved == false && a.isNotApproved == false).FirstOrDefault() != null)
                {
                    responseResumes.Add(_context.responseResumes.Where(a => a.ResumeId== item.Id && a.isApproved == false && a.isNotApproved == false).FirstOrDefault());
                }
                else
                {
                    continue;
                }
            }

            List<Employer> employers = _context.employers.ToList();

            ViewData["resumeRes"] = resumes;
            ViewData["responseRes"] = responseResumes;
            ViewData["employerRes"] = employers;

            return View();
        }

        //принятие резюме
        [HttpPost]
        public async Task<IActionResult> ApprovedResume(int id, string yes, string no)
        {
            ResponseResume response = _context.responseResumes.Where(a => a.Id == id).FirstOrDefault();

            if (yes != null)
            {
                response.isApproved = true;
            }
            else if (no != null)
            {
                response.isNotApproved = true;

            }
            _context.responseResumes.Update(response);
            await _context.SaveChangesAsync();
            return Redirect("~/Applicant/ResponseList");
        }

        //мои отклики
        public IActionResult MyResponse()
        { // замена
            List<Vacancy> vacancies= _context.vacancies.ToList();
            //замена
            List<ResponseVacancies> responseVacancies = _context.responseVacancies.Where(a => a.ApplicantId == Convert.ToInt32(Request.Cookies["userId"])).ToList();

            List<Employer> employers= _context.employers.ToList();

            ViewData["vacancy"] = vacancies;
            ViewData["responseRes"] = responseVacancies;
            ViewData["employer"] = _context.employers.ToList();

            return View();
        }

    }
}
