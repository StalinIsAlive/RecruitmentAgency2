using System.ComponentModel.DataAnnotations.Schema;

namespace recruitment_agency.Models
{ //работодатель
    public class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfCreate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        //вторичный ключ от типа компании(id)
        public int CompanyType { get; set; }
        [ForeignKey("CompanyType")]
        public virtual CompanyType companyType { get; set; }
    }
}
