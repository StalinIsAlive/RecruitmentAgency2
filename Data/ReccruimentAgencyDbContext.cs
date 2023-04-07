using Microsoft.EntityFrameworkCore;
using recruitment_agency.Models;

namespace recruitment_agency.Data
{
    public class ReccruimentAgencyDbContext : DbContext
    {
        public ReccruimentAgencyDbContext(DbContextOptions<ReccruimentAgencyDbContext> options) : base(options) { }

        //поля из таблиц
    }
}
