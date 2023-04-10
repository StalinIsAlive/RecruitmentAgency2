namespace recruitment_agency.Models
{ //отклики на резюме/вакансии
    public class ResponseResume
    {
        //после одобрения заявки обеими сторонами,
        //последней из подтвердивших придёт уведомление с тектом который будет предложено ввести последнему
        public int Id { get; set; }
        public string Description { get; set; }
        //вторичный ключ резюме
        public int ResumeId { get; set; }
        public Resume resume{ get; set; }
        //вторичный ключ работодателя
        public int EmployerId { get; set; }
        public Employer employer { get; set; }

        //подтверждена ли заявка
        public bool isApproved { get; set; }
        //заявка отвергнута
        public bool isNotApproved { get; set; }
    }
}
