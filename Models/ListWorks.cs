﻿using System.ComponentModel.DataAnnotations.Schema;

namespace recruitment_agency.Models
{ //места работы (типо стажа)
    public class ListWorks
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateStart {get;set;} 
        public DateTime DateEnd { get;set;}
        public string Description { get; set; }
        public string Post { get; set; }
        public string Profession { get; set; }
        
        //навесить вторичные ключи на id работника
        //public int Applicant { get; set; }
        //[ForeignKey("Applicant")]
    }
}
