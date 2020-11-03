using System;

namespace ZwajApp.API.Models
{
    public class Photoer
    {
        public int id{get;set;}
        public string  Url { get; set; }
        public string  Description { get; set; }
        public DateTime  DateAdded { get; set; }
        public bool  IsMain { get; set; }
     

     public User User { get; set; }
     public int UserId { get; set; }
    
    }
}