namespace recruitment_agency.Models
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Salary { get; set; }
        public string Post { get; set; }
        
        //вторичный ключ компании

        //сводная таблица професий доступных для выбора

        
    }
}
