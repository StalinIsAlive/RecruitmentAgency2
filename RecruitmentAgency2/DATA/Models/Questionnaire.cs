namespace RecruitmentAgency2.DATA.Models
{
    public class Questionnaire
    {
        public int id { get; set; } 
        public string fullName { get; set; }   
        public string phone { get; set; }    
        public string mail { get; set; }
        public string education { get; set; }
        public string relationOfMilitary { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public int VacancyId { get; set; }
        public virtual Vacancy Vacancy { get; set; }

    }
}
