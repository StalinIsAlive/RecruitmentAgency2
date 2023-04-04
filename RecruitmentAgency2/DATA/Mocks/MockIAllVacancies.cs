using RecruitmentAgency2.DATA.Interfaces;
using RecruitmentAgency2.DATA.Models;
using System.Collections.Generic;

namespace RecruitmentAgency2.DATA.Mocks
{
    public class MockIAllVacancies : IAllVacancies
    {
        private readonly IAllVacancies _allVacancies;
        public IEnumerable<Vacancy> Vacansies
        {
            get {
                return new List<Vacancy> {
                    new Vacancy
                    {
                        name = "JavaDeveloper1",
                        description = "coolJob1",
                        address = "Lenina1",
                        phone = "8800555"
                    },
                    new Vacancy
                    {
                        name = "JavaDeveloper2",
                        description = "coolJob2",
                        address = "Lenina2",
                        phone = "8800555"
                    },
                    new Vacancy
                    {
                        name = "JavaDeveloper3",
                        description = "coolJob13",
                        address = "Lenina3",
                        phone = "8800555"
                    },
                    new Vacancy
                    {
                        name = "JavaDeveloper4",
                        description = "coolJob4",
                        address = "Lenina4",
                        phone = "8800555"
                    }
                };
            }
        }
        public IEnumerable<Vacancy> getFavouritesVacansies { get; set; }

        public Vacancy getVacancyById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
