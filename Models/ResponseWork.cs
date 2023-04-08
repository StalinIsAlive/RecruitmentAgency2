namespace recruitment_agency.Models
{ //отклики на резюме/вакансии
    public class ResponseWork
    {
        //после одобрения заявки обеими сторонами,
        //последней из подтвердивших придёт уведомление с тектом который будет предложено ввести последнему
        public int Id { get; set; }
        //вторичный ключ работника
        public int ApplicantId { get; set; }
        public Applicant applicant { get; set; }
        //вторичный ключ работодателя
        public int EmployerId { get; set; }
        public Employer employer { get; set; }

        //чекбоксы для подтверждения отклика
        public bool IsApprovedApplicant { get; set; }
        public bool IsApprovedEmployer { get; set; }
    }
}
