namespace recruitment_agency.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Salary { get; set; }
        public string Post { get; set; }
        public bool isVisible { get; set; }
        //требуемый опыт (количество лет) например от 4 лет опыта
        public int Experience { get; set; }
        //вторичный ключ компании
        public int EmployerId { get; set; }
        public Employer employer { get; set; }

        //вторичный ключ профессии
        public int ProfessionsId { get; set; }
        public Professions professions { get; set; }
        
    }
}
