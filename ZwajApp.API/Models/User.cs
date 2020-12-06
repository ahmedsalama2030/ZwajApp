using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
namespace ZwajApp.API.Models
{
    public class User :IdentityUser<int>
    {
        
 
 
        public string  Gender { get; set; }
        public DateTime  DateOfBirth { get; set; }
        public string  KnownAs { get; set; }
        public DateTime  Created { get; set; }
        public DateTime  LastActive { get; set; }
        public string  Introduction { get; set; }
        public string  LookingFor { get; set; }
        public string  Interests { get; set; }
        public string  city { get; set; }
        public string  country { get; set; }

        public ICollection<Photoer>  Photos { get; set; }
        public ICollection<UserRole>  UserRole { get; set; }

    }
}