namespace recruitment_agency.Models
{ //отклики на резюме/вакансии
    public class ResponseWork
    {
        public int Id { get; set; }
        //вторичный ключ работника

        //вторичный ключ работодателя


        //чекбоксы для подтверждения отклика
        public bool IsApprovedApplicant { get; set; }
        public bool IsApprovedEmployer { get; set; }
    }
}
