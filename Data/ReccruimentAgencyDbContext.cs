using Microsoft.EntityFrameworkCore;
using recruitment_agency.Models;

namespace recruitment_agency.Data
{
    public class ReccruimentAgencyDbContext : DbContext
    {
        public ReccruimentAgencyDbContext(DbContextOptions<ReccruimentAgencyDbContext> options) : base(options) { }

        //поля из таблиц
        public DbSet<Admin> admins { get; set; }
        public DbSet<Applicant> applicants { get; set; }
        public DbSet<ApplicateProfession> applicateProfessions { get; set; }
        public DbSet<CompanyType> companyTypes { get; set; }
        public DbSet<Employer> employers { get; set; }
        public DbSet<ListWorks> listWorks { get; set; }
        public DbSet<Notifications> notifications { get; set; }
        public DbSet<Professions> professions { get; set; }
        public DbSet<ResponseWork> responseWorks { get; set; }
        public DbSet<Resume> resumes { get; set; }
        public DbSet<Vacancy> vacancies { get; set; }
    }
}
