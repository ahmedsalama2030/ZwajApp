using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Data;
using Microsoft.EntityFrameworkCore;
using ZwajApp.API.Dtos;
using Microsoft.AspNetCore.Identity;
using ZwajApp.API.Models;

namespace ZwajApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly UserManager<User> _userManager;

        private readonly DataContext _context;
        public AdminController(UserManager<User> userManager, DataContext context)
        {
            _userManager = userManager;
            _context = context;

        }
        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("userswithrole")]
        public async Task<IActionResult> getUsersWithRole()
        {

            var UserList = await (from user in _context.Users
                                  orderby user.UserName
                                  select new
                                  {
                                      Id = user.Id,
                                      UserName = user.UserName,
                                      Roles = (from userRole in user.UserRole
                                               join role in _context.Roles
                                               on userRole.RoleId equals role.Id
                                               select role.Name).ToList()

                                  }).ToListAsync();
            return Ok(UserList);
        }

        [Authorize(Policy = "RequireModrole")]

        [HttpGet("photomod")]
        public IActionResult getPhotoMod()
        {
            return Ok("مصرح  لاشراف صور");
        }
        [Authorize(Policy = "RequireAdminRole")]

        [HttpPost("editroles/{userName}")]
        public async Task<IActionResult> EditRoles(string userName, RoleEditDto roleEditDto)
        {
     var user= await  _userManager.FindByNameAsync(userName);
     var userroles=await _userManager.GetRolesAsync(user);
     var selectedroles=roleEditDto.RolesNames;
     selectedroles=selectedroles??new string[]{};
     var result=await _userManager.AddToRolesAsync(user,selectedroles.Except(userroles));
          if(!result.Succeeded) 
                 return BadRequest("حدث خطا الادوار");

          

          result =await _userManager.RemoveFromRolesAsync(user,userroles.Except(selectedroles));
          if(!result.Succeeded) 
                 return BadRequest("حدث خطا الادوار");

         return Ok(await _userManager.GetRolesAsync(user));        
           
        }
    }
}