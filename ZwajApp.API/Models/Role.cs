using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ZwajApp.API.Models
{
    public class Role:IdentityRole<int>
    {
    public ICollection<UserRole>  UserRole { get; set; }

    }
}