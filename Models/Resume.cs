namespace recruitment_agency.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        public bool isVisible { get; set; }
        
        //вторичный ключ предпочитаемой профессии
        public int ProfessionId { get; set; }
        public Professions professions { get; set; }
        //вторичный ключ соискателя
        public int ApplicantId { get; set; }
        public Applicant applicant { get; set; }
    }
}
