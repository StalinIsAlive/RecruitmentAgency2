using System.Text.RegularExpressions;

namespace recruitment_agency.Models
{
    public class ProfessionResume
    {
        public int ProfessionId { get; set; }
        public Professions professions{ get; set; }

        public int ResumeId{ get; set; }
        public Resume resume { get; set; }
    }
}
