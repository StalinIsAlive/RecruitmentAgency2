using RecruitmentAgency2.DATA.Models;
using System.Collections.Generic;

namespace RecruitmentAgency2.DATA.Interfaces
{
    public interface IAllVacancies
    {
        IEnumerable<Vacancy> Vacansies { get; set; }
        IEnumerable<Vacancy> getFavouritesVacansies { get; set; }
        Vacancy getVacancyById(int id);
    }
}
