using RecruitmentAgency2.DATA.Models;
using System.Collections.Generic;

namespace RecruitmentAgency2.DATA.Interfaces
{
    public interface IQuestionnairesVacancy
    {
        IEnumerable<Vacancy> AllVacancies { get; }
    }
}
