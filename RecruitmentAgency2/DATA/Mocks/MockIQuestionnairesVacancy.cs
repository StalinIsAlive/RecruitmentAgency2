using RecruitmentAgency2.DATA.Interfaces;
using RecruitmentAgency2.DATA.Models;
using System.Collections.Generic;

namespace RecruitmentAgency2.DATA.Mocks
{
    public class MockIQuestionnairesVacancy : IQuestionnairesVacancy
    {
        public IEnumerable<Vacancy> AllVacancies
        {
            get {
                return new List<Vacancy> {
                    new Vacancy {name = "JavaDeveloper", description = "coolJob1", address = "Lenina1", phone = "8800555"},
                    new Vacancy {name = "C#Developer", description = "coolJob1", address = "Lenina2", phone = "8800556"}
                };
            }
        }
    }
}