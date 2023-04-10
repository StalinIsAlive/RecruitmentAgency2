namespace recruitment_agency.Models
{ //отклики на резюме/вакансии
    public class ResponseVacancies
    {
        public int Id { get; set; }
        public string Description { get; set; }
        //вторичный ключ вакансии
        public int VacancyId { get; set; }
        public Vacancy vacancy{ get; set; }
        //вторичный ключ работника
        public int ApplicantId { get; set; }
        public Applicant applicant{ get; set; }
        //подтверждена ли заявка
        public bool isApproved { get; set; }
        //заявка отвергнута
        public bool isNotApproved { get; set; }
    }
}
