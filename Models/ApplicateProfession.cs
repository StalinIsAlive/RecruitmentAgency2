namespace recruitment_agency.Models
{ //заявка на добавление профессии
    public class ApplicateProfession
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        //вторичный ключ компании которая подала заявкуы
    }
}
