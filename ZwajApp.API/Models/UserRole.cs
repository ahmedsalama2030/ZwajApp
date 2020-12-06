using Microsoft.AspNetCore.Identity;

namespace ZwajApp.API.Models
{
    public class UserRole:IdentityUserRole <int>
    {
     public User user{get;set;}
     public Role role{get;set;}
    }
}