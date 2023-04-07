namespace recruitment_agency.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Salary { get; set; }
        
        //вторичный ключ (множественный) предпочитаемые профессии

        //вторичный ключ соискателя
    }
}
