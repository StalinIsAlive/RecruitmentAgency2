using System.Collections.Generic;

namespace RecruitmentAgency2.DATA.Models
{
    public class Vacancy
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public bool isFavourite { get; set; }

        public List<Questionnaire> questionnaires { get; set; }

    }
}
