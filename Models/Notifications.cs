namespace recruitment_agency.Models
{ //уведомление об отклике на вакансию
    public class Notifications
    {
        public int Id { get; set; }
        //будет использовано как текст для уведомления об отклике
        public string Description { get; set; }
        //вторичный ключ отклика
        public int ResponseWorkId { get; set; }
        public ResponseWork responseWork { get; set; }
    }
}
