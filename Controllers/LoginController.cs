using Microsoft.AspNetCore.Mvc;
using recruitment_agency.Data;
using recruitment_agency.Models;

namespace recruitment_agency.Controllers
{
    public class LoginController : Controller
    {
        private readonly ReccruimentAgencyDbContext _context;
        public LoginController (ReccruimentAgencyDbContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login([Bind("Email,Password")] Logins logins)
        {
            if (_context.applicants.Any(a => a.Password == logins.Password && a.Email == logins.Email))
            {
                int id = _context.applicants.Where(a => a.Password == logins.Password && a.Email == logins.Email).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());
                return RedirectToAction("Index", "Applicant", new { id = id });
            }
            else if (_context.employers.Any(a => a.Password == logins.Password && a.Email == logins.Email))
            {
                int id = _context.employers.Where(a => a.Password == logins.Password && a.Email == logins.Email).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());
                return RedirectToAction("Index", "Employer", new { id = id });
            }
            else if (_context.admins.Any(a => a.Password == logins.Password && a.Email == logins.Email))
            {
                int id = _context.admins.Where(a => a.Password == logins.Password && a.Email == logins.Email).Select(a => a.Id).FirstOrDefault();
                Response.Cookies.Append("userId", id.ToString());
                return RedirectToAction("Index", "Admin", new { id = id });
            }
            return View();
        }
        public IActionResult Logout()
        {
            Response.Cookies.Delete("userId");
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public IActionResult Register(string applicantName,string employerName, [Bind("Email,Password")] Logins logins)
        {
            if (logins.Email != null)
            {
                if(applicantName!=null)
                {
                    Applicant applicant = new Applicant();
                    applicant.Email = logins.Email;
                    applicant.Password = logins.Password;
                    _context.applicants.Add(applicant);

                    _context.SaveChanges();
                    int id = _context.applicants.Where(a => a.Password == logins.Password && a.Email == logins.Email).Select(a => a.Id).FirstOrDefault();


                    Response.Cookies.Append("userId", id.ToString());
                    return RedirectToAction("Index", "Applicant", new { id = id });
                } else
                {
                    Employer employer = new Employer();
                    employer.Email = logins.Email;
                    employer.Password = logins.Password;
                    
                    _context.employers.Add(employer);
                    _context.SaveChanges();
                    int id = _context.employers.Where(a => a.Password == logins.Password && a.Email == logins.Email).Select(a => a.Id).FirstOrDefault();


                    Response.Cookies.Append("userId", id.ToString());
                    return RedirectToAction("Index", "Employer", new { id = id });
                }

                
            }
            else
            {
                return View();
            }
        }
    }
}
