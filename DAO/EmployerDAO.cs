using recruitment_agency.Data;
using recruitment_agency.Models;
using System.Collections;

namespace recruitment_agency.DAO
{
    public class EmployerDAO
    {
        private readonly ReccruimentAgencyDbContext _context;
        public EmployerDAO(ReccruimentAgencyDbContext context)
        {
            this._context = context;   
        }

        public List<Resume> getListResume(ArrayList parameters)
        {
            List<Resume> resumes = _context.resumes.Where(a=>a.isVisible).ToList();
            return resumes;
        }

        public Resume getResumeById(int id)
        {
            Resume resume = _context.resumes.Where(a => a.isVisible && a.Id==id).FirstOrDefault();
            return resume;
        }

        public Employer getProfile(int id)
        {
            Employer employer = _context.employers.Where(a => a.Id == id).FirstOrDefault();
            return employer;
        }
    }
}
